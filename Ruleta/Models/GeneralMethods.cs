using Microsoft.AspNetCore.Mvc.RazorPages;
using NLog;
using Ruleta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ruleta.Models
{
    public class GeneralMethods : PageModel
    {
        private static Logger logger_;
        public IDBManager Manager { get; set; }
        public int ResponseAction { get; set; } 

        public GeneralMethods()
        {
            logger_ = LogManager.GetCurrentClassLogger();
        }

        public void RegisterLogFatal(Exception ex, Guid id)
        {
            var log = new LogEventInfo(LogLevel.Fatal, loggerName: "", message: "")
            {
                Message = ex.Message,
                Exception = ex
            };
            log.Properties.Add("idLog", id.ToString());
            log.Properties.Add("methodName", $"{ex.TargetSite.DeclaringType?.FullName}.{ex.TargetSite.Name}");
            logger_.Fatal(log);
        }

        
    }
}
