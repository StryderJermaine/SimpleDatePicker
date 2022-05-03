using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleDatePicker.Utils
{
    /// <summary>
    /// Date Utility with necessary date functions  
    /// </summary>
    public class DateUtil
    {
        /// <summary>
        /// A list of the calendar months as their full names
        /// </summary>
        public static List<string> MonthNames { get; } = new List<string>
        {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };

        /// <summary>
        /// A list of the calendar months as their month numbers as strings
        /// </summary>
        public static List<string> Months { get; } = new List<string>
        {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"
        };

        /// <summary>
        /// A list of the days of the week
        /// </summary>
        public static List<string> Days { get; } = new List<string>
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"
        };

        /// <summary>
        /// Method to get a month by its index 
        /// </summary>
        /// <param name="monthIndex">The index of the month</param>
        /// <returns>The month as a <see cref="string"/></returns>
        public static string GetMonth(int monthIndex)
        {
            var index = monthIndex - 1;

            return Months[index];
        }

        /// <summary>
        /// Method to get the days of the week as a list of their indexes
        /// </summary>
        /// <param name="month">The month in question</param>
        /// <param name="year">The year in question</param>
        /// <returns>A list of the days</returns>
        public static List<string> GetDays(string month, int year = 0)
        {
            var days = 0;

            switch (month)
            {
                case "9":
                case "4":
                case "6":
                case "11":
                    days = 30;
                    break;

                case "2":
                    days = DateTime.IsLeapYear(year) ? 29 : 28;
                    break;

                case "1":
                case "3":
                case "5":
                case "7":
                case "8":
                case "10":
                case "12":
                    days = 31;
                    break;
            }

            var daysList = new List<string>();

            for (var i = 1; i <= days; i++)
            {
                daysList.Add(i.ToString());
            }

            return daysList;
        }

        public static string GetMonthStringIndex(string month)
        {
            var monthNum = "";

            switch (month)
            {
                case "Jan":
                    monthNum = "01";
                    break;

                case "Feb":
                    monthNum = "02";
                    break;

                case "Mar":
                    monthNum = "03";
                    break;

                case "Apr":
                    monthNum = "04";
                    break;

                case "May":
                    monthNum = "05";
                    break;

                case "Jun":
                    monthNum = "06";
                    break;

                case "Jul":
                    monthNum = "07";
                    break;

                case "Aug":
                    monthNum = "08";
                    break;

                case "Sep":
                    monthNum = "09";
                    break;

                case "Oct":
                    monthNum = "10";
                    break;

                case "Nov":
                    monthNum = "11";
                    break;

                case "Dec":
                    monthNum = "12";
                    break;
            }

            return monthNum;
        }

        public static int GetMonthIndex(string month)
        {
            var monthNum = 0;

            switch (month)
            {
                case "January":
                    monthNum = 1;
                    break;

                case "February":
                    monthNum = 2;
                    break;

                case "March":
                    monthNum = 3;
                    break;

                case "April":
                    monthNum = 4;
                    break;

                case "May":
                    monthNum = 5;
                    break;

                case "June":
                    monthNum = 6;
                    break;

                case "July":
                    monthNum = 7;
                    break;

                case "August":
                    monthNum = 8;
                    break;

                case "September":
                    monthNum = 9;
                    break;

                case "October":
                    monthNum = 10;
                    break;

                case "November":
                    monthNum = 11;
                    break;

                case "December":
                    monthNum = 12;
                    break;
            }

            return monthNum;
        }

        public static string GetMonthName(int month)
        {
            switch (month)
            {
                case 1:
                    return "January";

                case 2:
                    return "February";

                case 3:
                    return "March";

                case 4:
                    return "April";

                case 5:
                    return "May";

                case 6:
                    return "June";

                case 7:
                    return "July";

                case 8:
                    return "August";

                case 9:
                    return "September";

                case 10:
                    return "October";

                case 11:
                    return "November";

                case 12:
                    return "December";
            }

            return string.Empty;
        }

        public static List<string> GetYears()
        {
            try
            {
                var years = new List<string>();

                var minYear = 1899;

                for (var i = minYear; i <= 2100; i++)
                {
                    years.Add(minYear.ToString());

                    minYear++;
                }

                return years;
            }
            catch (Exception e)
            {
                var x = e.Message;
                return null;
            }
        }

        public static List<string> GetYears(int? minYear, int? maxYear)
        {
            try
            {
                var years = new List<string>();

                minYear = minYear == 0 || minYear == 1 ? 1899 : minYear;

                maxYear = maxYear == 0 || maxYear == 1 ? 2100 : maxYear;

                for (var i = minYear; i <= maxYear; i++)
                {
                    years.Add(minYear.ToString());

                    minYear++;
                }

                return years;
            }
            catch (Exception e)
            {
                var x = e.Message;
                return null;
            }
        }

        public static List<string> GetDobYears()
        {
            try
            {
                //var years = new List<string>();

                //var minYear = DateTime.Now.Year - 18;

                //for (var i = minYear; i <= 1930; i--)
                //{
                //    years.Add(minYear.ToString());

                //    minYear++;
                //}

                //return years;

                var years = new List<string>();

                var minYear = 1930;

                var maxYear = 2001;

                for (var i = maxYear; i >= minYear; i--)
                {
                    years.Add(maxYear.ToString());

                    maxYear--;
                }

                return years;

            }
            catch (Exception e)
            {
                var x = e.Message;
                return null;
            }
        }

        public static List<string> GetDepDobYears()
        {
            try
            {
                var years = new List<string>();

                var minYear = DateTime.UtcNow.Year - 18;

                var maxYear = DateTime.UtcNow.Year;

                for (var i = maxYear; i >= minYear; i--)
                {
                    years.Add(maxYear.ToString());

                    maxYear--;
                }

                return years;

            }
            catch (Exception e)
            {
                var x = e.Message;
                return null;
            }
        }

        public static List<string> GetDaysList()
        {
            var daysList = new List<string>();
            for (var i = 1; i <= 31; i++)
            {
                daysList.Add(i.ToString());
            }

            return daysList;
        }

        public static List<string> GetFilteredMonths(int minMonth)
        {
            minMonth -= 1;

            return minMonth == 11 ? MonthNames : MonthNames.Where(month => MonthNames.IndexOf(month) >= minMonth).ToList();
        }
        
        public static List<string> GetFilteredDays(string month, int minDay)
        {
            minDay -= 1;

            return GetDays(month).Where(day => GetDays(month).IndexOf(day) >= minDay).ToList();
        }

        public static List<string> GetFilteredDaysMax(string month, int minDay)
        {
            minDay -= 1;

            return GetDays(month).Where(day => GetDays(month).IndexOf(day) <= minDay).ToList();
        }
    }
}
