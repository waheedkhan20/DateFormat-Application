using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataApplication
{
    class Program
    {
        static void Main(string[] args)
        {			
            int day = 0, newday = 0, month = 0, year = 0, daysToAdd = 0;
            int[] thirtymonths = { 4, 6, 9, 11 }; // 30 days of the months
            int[] thirtyonemonths = { 1, 3, 5, 7, 8, 10, 12 }; // 31 days of the months
            bool isLeapYear = false;
            bool flag = true;
            Console.WriteLine("Enter a date in dd/mm/yyyy format!");
            string sourcedate = Console.ReadLine();
            Console.WriteLine("enter a number between 1-28");
            try { daysToAdd = Convert.ToInt32(Console.ReadLine()); } catch { Console.WriteLine("enter only number"); return; }
            if (daysToAdd > 28 || daysToAdd < 1)
            {
                Console.WriteLine("number not in range");
                return;
            }
            string[] datearray = sourcedate.Split('/');
            if (datearray.Length != 3)
                Console.WriteLine("Please enter a valid date");
            try
            {
                year = Convert.ToInt32(datearray[2]);
                if (year < 1 || year > 9999)
                {
                    Console.WriteLine("not a valid year");
                    return;
                }
                //checking whether year is leap year
                if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0))
                    isLeapYear = true;

                month = Convert.ToInt32(datearray[1]);
                if (month < 1 || month > 12)
                {
                    Console.WriteLine("not a valid month");
                    return;
                }
                day = Convert.ToInt32(datearray[0]);
                if (day < 1 || day > 31)
                {
                    Console.WriteLine("not a valid day");
                    return;
                }
                if (isLeapYear && month == 2 && day > 29)
                {
                    Console.WriteLine("day is wrong");
                    return;
                }
                if (!isLeapYear && month == 2 && day > 28)
                {
                    Console.WriteLine("wrong day");
                    return;
                }

                newday = day + daysToAdd;
                if (Array.Exists(thirtymonths, element => element == month) && newday > 30)
                {
                    day = newday - 30;
                    month++;
                    flag = false;
                }

                if (day > 30 && Array.Exists(thirtymonths, x => x == month))
                {
                    Console.WriteLine("wrong day");
                    return;

                }

                if (month == 2 && isLeapYear && newday > 29)
                {
                    day = newday - 29;
                    month++;
                    flag = false;
                }
                if (month == 2 && !isLeapYear && newday > 28)
                {
                    day = newday - 28;
                    month++;
                    flag = false;
                }
                if (flag && Array.Exists(thirtyonemonths, element => element == month) && newday > 31)
                {
                    day = newday - 31;
                    month++;
                    flag = false;
                }
                if (flag) { day = newday; }
                if (month > 12)
                {
                    year++;
                    month = 1;
                }
                Console.WriteLine($"{day}/{month}/{year}");
                Console.ReadLine();
            }
            catch (Exception) { Console.WriteLine("Please Enter Date Format dd/mm/yyyy"); }
        }
    }
}
