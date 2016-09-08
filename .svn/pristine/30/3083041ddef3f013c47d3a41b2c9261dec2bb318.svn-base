using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZodiacSign
{
    class Program
    {
        static void Main(string[] args)
        {
            int iDate = 0;
            int iMonth = 0;
            int iYear = 0;
            string strWeekDay = string.Empty;
            string zodiacSign = string.Empty;
            Program obj = new Program();
            try
            {
                Console.WriteLine("Enter the date: ");
                iDate = Convert.ToInt16(Console.ReadLine().Trim());
                Console.WriteLine("Enter the month: ");
                iMonth = Convert.ToInt16(Console.ReadLine().Trim());
                Console.WriteLine("Enter the year: ");
                iYear = Convert.ToInt16(Console.ReadLine().Trim());
                strWeekDay = obj.ConverttoDate(iDate, iMonth, iYear);
                zodiacSign = obj.GetZodiacSign(iDate, iMonth);
                obj.Display(strWeekDay, zodiacSign);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Display(string strWeekDay, string zodiacSign)
        {
            Console.WriteLine("Day of the date is: " + strWeekDay);
            Console.WriteLine("Your zodiac sign is: " + zodiacSign);
        }

        public string ConverttoDate(int iDate, int iMonth, int iYear)
        {
            return (new DateTime(iYear, iMonth, iDate)).DayOfWeek.ToString();
        }

        public string GetZodiacSign(int iDate, int iMonth)
        {
            int month = iMonth;
            int day = iDate;
            switch (month)
            {
                case 1:
                    if (day <= 19)
                        return "Capricorn";
                    else
                        return "Aquarius";

                case 2:
                    if (day <= 18)
                        return "Aquarius";
                    else
                        return "Pisces";
                case 3:
                    if (day <= 20)
                        return "Pisces";
                    else
                        return "Aries";
                case 4:
                    if (day <= 19)
                        return "Aries";
                    else
                        return "Taurus";
                case 5:
                    if (day <= 20)
                        return "Taurus";
                    else
                        return "Gemini";
                case 6:
                    if (day <= 20)
                        return "Gemini";
                    else
                        return "Cancer";
                case 7:
                    if (day <= 22)
                        return "Cancer";
                    else
                        return "Leo";
                case 8:
                    if (day <= 22)
                        return "Leo";
                    else
                        return "Virgo";
                case 9:
                    if (day <= 22)
                        return "Virgo";
                    else
                        return "Libra";
                case 10:
                    if (day <= 22)
                        return "Libra";
                    else
                        return "Scorpio";
                case 11:
                    if (day <= 21)
                        return "Scorpio";
                    else
                        return "Sagittarius";
                case 12:
                    if (day <= 21)
                        return "Sagittarius";
                    else
                        return "Capricorn";
            }
            return "";
        }
    }
}
