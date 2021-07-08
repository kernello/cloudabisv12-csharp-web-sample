using CloudABISSampleWebApp.Models.MatchingServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudABISSampleWebApp.Utilities
{
    public class SessionManager
    {

        public static CloudABISAPICredential CloudABISCredentials
        {
            get { return (CloudABISAPICredential)HttpContext.Current.Session["CloudABISCredentials"]; }
            set { HttpContext.Current.Session["CloudABISCredentials"] = value; }
        }
        public static string CloudABISAPIToken
        {
            get { return (string)HttpContext.Current.Session["CloudABISAPIToken"]; }
            set { HttpContext.Current.Session["CloudABISAPIToken"] = value; }
        }

    }

}