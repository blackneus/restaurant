using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Resources;

namespace Restaurant.Clases
{
    [Serializable]
    public  class clTraducir
    {
        public static string Traducir(string stpalabra, string stidioma)
        {
            string stTraducir=string.Empty;
            string resxFile = string.Empty;
            switch (stidioma)
            { 
                case "es-mx":
                    resxFile = "Resource";
                    break;
                case  "en-us":
                    resxFile = "Resource.en";
                    break;
            }
         //   clUsuario objempPK = Session["User"] == null ? null : Session["User"] as clUsuario; return objempPK; 
            stTraducir = HttpContext.GetGlobalResourceObject(resxFile, stpalabra) == null ? stpalabra : HttpContext.GetGlobalResourceObject(resxFile, stpalabra).ToString();
      



            return stTraducir;
        }
    }
 
}