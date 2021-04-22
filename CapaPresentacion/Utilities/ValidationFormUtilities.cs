using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CapaPresentacion.Utilities
{
    class ValidationFormUtilities
    {
        //shprcu ensn.r gs;dr
        public static void OnlyNumber(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
        public static void OnlyLetters(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
        public static void DecimalNumber(object sender, KeyPressEventArgs e)
        {
            //if txtbox.container(".")
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (e.KeyChar.ToString().Equals("."))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }


        }
        public static bool CorrectEmail(string email)
        {
            //^[^@]+@[^@]+\.[a-zA-Z]{2,}$

            return Regex.IsMatch(email, @"^[^@] +@[^@] +\.[a-zA - Z]{ 2,}$");
        }

        public static bool NoEmptyOrNullFields(string fields)
        {
            if (string.IsNullOrEmpty(fields))
            {
                return false;
            }
            return true;
        }


    }
}



