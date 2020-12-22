using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Newtonsoft.Json;
using Ruleta.Interfaces;
using Ruleta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ruleta.Builders
{
    public class BDBManager : IDBManager
    {
        public BDBManager()
        {
        }

        public string BuildConnectionString()
        {
            CredentialsDB credentialsModel = new CredentialsDB();
            string accessKeyId = Environment.GetEnvironmentVariable("AccessKeyId");
            string secretAccessKey = Environment.GetEnvironmentVariable("SecretKeyId");
            string secretName = Environment.GetEnvironmentVariable("SecretName");
            var clientAWS = new AmazonSecretsManagerClient(accessKeyId, secretAccessKey, RegionEndpoint.USEast1);
            var req = new GetSecretValueRequest
            {
                SecretId = secretName
            };
            GetSecretValueResponse response = null;
            try
            {
                response = clientAWS.GetSecretValueAsync(req).Result;
                credentialsModel = JsonConvert.DeserializeObject<CredentialsDB>(response.SecretString);
            }
            catch (DecryptionFailureException e)
            {
                throw;
            }
            string ConecctionString = String.Format("Server ={0}; Database = {1}; User Id = {2}; Password = {3}; MultipleActiveResultSets = true", credentialsModel.Server, credentialsModel.BD, credentialsModel.User, credentialsModel.Password);
            return ConecctionString;
        }
    }
}
