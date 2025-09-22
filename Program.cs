using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter customer number (1-9999): ");
            int customerNumber = int.Parse(Console.ReadLine());

            if (customerNumber < 1 || customerNumber > 9999)
            {
                Console.WriteLine("Customer number must be between 1 and 9999.");
                return;
            }

            string T1 = GenerateLetterFromYear();
            string T2 = GenerateBranchLetter("ZENI"); // You can change branch here
            string T3 = GenerateDayLetter();
            string T4 = GenerateDateLetter();
            string T5 = GenerateCustomerCode(customerNumber);

            string transactionCode = T1 + T2 + T3 + T4 + T5;
            Console.WriteLine("Transaction Code: " + transactionCode);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid input: " + ex.Message);
        }
    }

    static string GenerateCustomerCode(int number)
    {
        return number.ToString("D4");  // Format as 4-digit number with leading zeros
    }

    static string GenerateLetterFromYear()
    {
        int baseYear = 2024;
        int currentYear = DateTime.Now.Year;
        int offset = (currentYear - baseYear) % 26;
        return ((char)('A' + offset)).ToString();
    }

    static string GenerateDayLetter()
    {
        string dayName = DateTime.Now.DayOfWeek.ToString().ToLower();
        Dictionary<string, string> dayMap = new Dictionary<string, string>()
        {
            { "monday", "I" },
            { "tuesday", "J" },
            { "wednesday", "K" },
            { "thursday", "R" },
            { "friday", "S" },
            { "saturday", "T" },
            { "sunday", "E" }
        };

        return dayMap.ContainsKey(dayName) ? dayMap[dayName] : "X";
    }

    static string GenerateDateLetter()
    {
        int day = DateTime.Now.Day;
        Random rand = new Random();

        if (day % 2 == 0)
        {
            return ((char)rand.Next('B', 'M' + 1)).ToString();  // B to M
        }
        else
        {
            return ((char)rand.Next('R', 'T' + 1)).ToString();  // R to S
        }
    }

    static string GenerateBranchLetter(string branch)
    {
        Random rand = new Random();

        if (branch == "ZENI")
        {
            List<char> options = new List<char>();
            for (char c = 'K'; c <= 'O'; c++) options.Add(c);
            for (char c = 'k'; c <= 'o'; c++) options.Add(c);
            return options[rand.Next(options.Count)].ToString();
        }
        else if (branch == "MALYI")
        {
            string choices = "OPQRopqr";
            return choices[rand.Next(choices.Length)].ToString();
        }
        else if (branch == "XORANS")
        {
            string choices = "WXYZwxyz";
            return choices[rand.Next(choices.Length)].ToString();
        }
        else
        {
            return "Z";
        }
    }
}
