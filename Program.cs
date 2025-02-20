using System;
using GeometryLibrary;
using TextLibrary;
using ValidationLibrary;

namespace ADO__10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Использование GeometryLibrary
            Console.WriteLine($"Площадь квадрата со стороной 5: {Geometry.SquareArea(5)}");

            // Использование TextLibrary
            Console.WriteLine($"Палиндром 'racecar': {TextUtils.IsPalindrome("racecar")}");

            // Использование ValidationLibrary
            Console.WriteLine($"Проверка ФИО: {Validator.IsValidFullName("Иванов Иван Иванович")}");

            // Использование FileSystemLibrary
            FileSystemUtils.SearchWordInFile("example.txt", "example");
        }
    }
}
