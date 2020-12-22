using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ruleta.Context;
using Ruleta.Interfaces;
using Ruleta.Models;

namespace Ruleta.Pages
{
    public class RegisterModel : GeneralMethods
    {
        public RegisterModel(IDBManager dBManager)
        {
            Manager = dBManager;
        }
        public void OnGet()
        {
        }

        public void OnPostRegister(string Username, string Password)
        {
            //var id = Guid.NewGuid();
            //try
            //{
            //    using (var db = new RouletteContext(dBManager: Manager))
            //    {
            //        var validation = db.Users.Where(i => i.Username == Username).FirstOrDefault();
            //        if (validation == null)
            //        {
            //            User userModel = new User();
            //            userModel.Username = Username;
            //            userModel.Credit = 1000;
            //            userModel.Password = Encrypt(Password);
            //            db.Add(userModel);
            //            db.SaveChanges();
            //            ResponseAction = 1;
            //        }
            //        else
            //        {
            //            ResponseAction = 2;
            //        }
            //    }
            //    OnGet();
            //}
            //catch (Exception ex)
            //{
            //    RegisterLogFatal(ex: ex, id: id);
            //    ResponseAction = 3;
            //}
        }
    }
}
