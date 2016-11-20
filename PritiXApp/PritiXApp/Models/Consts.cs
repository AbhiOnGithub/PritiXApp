using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PritiXApp.Models
{
    public class Consts
    {
        public enum Languages
        {
            English,
            Dutch,
            French,
            German
        }

        public static string RestUrl = "http://prixitapi.azurewebsites.net/api/";
    }
}
