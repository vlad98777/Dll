using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


    namespace ValidationLibrary
    {
        public static class Validator
        {
            public static bool IsValidFullName(string fullName)
            {
                return Regex.IsMatch(fullName, @"^[а-яА-ЯёЁa-zA-Z\s]+$");
            }

            public static bool IsValidAge(string age)
            {
                return int.TryParse(age, out _);
            }

            public static bool IsValidPhone(string phone)
            {
                return Regex.IsMatch(phone, @"^\+\d{1,3} \d{1,4} \d{7,10}$"); // Пример формата: +1 1234 5678901
            }

            public static bool IsValidEmail(string email)
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            }
        }
    }