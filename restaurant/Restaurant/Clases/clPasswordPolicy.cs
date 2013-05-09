using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Restaurant.Clases
{
    public class clPasswordPolicy
    {
        private static int Minimum_Length = 8;
        private static int Upper_Case_length = 1;
        private static int Lower_Case_length = 1;
        private static int NonAlpha_length = 1;
        private static int Numeric_length = 1;
        private static string _stError;

        public string StError
        {
            get { return _stError; }
            set { _stError = value; }
        }
        public static bool IsValid(string Password)
        {
            if (Password.Length < Minimum_Length)
            {
                clPasswordPolicy pw = new clPasswordPolicy();
                pw.StError = "Deben ser mas de 8 caracteres";
                return false;
            }
            if (UpperCaseCount(Password) < Upper_Case_length)
                return false;
            if (LowerCaseCount(Password) < Lower_Case_length)
                return false;
            if (NumericCount(Password) < Numeric_length)
                return false;
            if (NonAlphaCount(Password) < NonAlpha_length)
                return false;
            return true;
        }

        private static int UpperCaseCount(string Password)
        {
            clPasswordPolicy pw = new clPasswordPolicy();
            pw.StError = "Debe tener al menos una letra mayúscula";
            return Regex.Matches(Password, "[A-Z]").Count;
        }

        private static int LowerCaseCount(string Password)
        {
            clPasswordPolicy pw = new clPasswordPolicy();
            pw.StError = "Debe tener al menos una letra minúscula";
            return Regex.Matches(Password, "[a-z]").Count;
        }
        private static int NumericCount(string Password)
        {
            clPasswordPolicy pw = new clPasswordPolicy();
            pw.StError = "Debe tener al menos un caracter numérico";
            return Regex.Matches(Password, "[0-9]").Count;
        }
        private static int NonAlphaCount(string Password)
        {
            clPasswordPolicy pw = new clPasswordPolicy();
            pw.StError = "Debe tener al menos un caracter no numérico";
            return Regex.Matches(Password, @"[^0-9a-zA-Z\._]").Count;
        }
    }
}