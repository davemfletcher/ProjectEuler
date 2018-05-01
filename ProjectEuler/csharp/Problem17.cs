using ProjectEuler.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.csharp
{
    /// <summary>
    /// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

    // If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?

    // NOTE: Do not count spaces or hyphens.For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters.The use of "and" when writing out numbers is in compliance with British usage.
    /// </summary>
    public class Problem17 : IProblem
    {
        public Answer Solution()
        {
            return new Answer
            {
                Description = FirstAttempt()
            };
        }

        private string FirstAttempt()
        {
            DateTime birthday = DateTime.ParseExact("20/11/2017", "dd/MM/yyyy", null);
            string sReturn = "??y"; ;
            string strMeasure = string.Empty;
            //string strAge = string.Empty;

            if (!string.IsNullOrEmpty(sReturn))
            {

                //DateTime birthday = DateTime.ParseExact(strDOB, "dd/MM/yyyy", null);
                strMeasure = "y";
                DateTime now = DateTime.Today;
                int age = now.Year - birthday.Year;
                if (now < birthday.AddYears(age))
                    sReturn = age--.ToString() + "y";
                if (age == 0)
                {
                    var days = now.Subtract(birthday).Days;
                    if (days > 31)
                    {
                        //use months
                        int months = (int)(Math.Floor((float)days / (365.25 / 12.0)));
                        sReturn = months.ToString() + "m";
                    }
                    else if (days.Between(14, 32))
                    {
                        //use weeks
                        var we = (float)days / 7;
                        int weeks = days / 7;
                        sReturn = weeks.ToString() + "w";
                    }
                    else
                    {
                        //use days
                        sReturn = days.ToString() + "d";
                    }
                }
            }

            return sReturn;
        }

        private string SecondAttempt()
        {
            DateTime birthday = DateTime.ParseExact("20/11/2017", "dd/MM/yyyy", null);
            string sReturn = "??y"; ;
            string strMeasure = string.Empty;
            //string strAge = string.Empty;

            if (!string.IsNullOrEmpty(sReturn))
            {

                //DateTime birthday = DateTime.ParseExact(strDOB, "dd/MM/yyyy", null);
                strMeasure = "y";
                DateTime now = DateTime.Today;
                int years = now.Year - birthday.Year;

                //if (now < birthday.AddYears(years))
                //    sReturn = years--.ToString() + "y";

                if (years >= 2)
                    sReturn = years.ToString() + "y";
                else
                {
                    var days = now.Subtract(birthday).Days;
                    if (days > 90)
                    {
                        //use months
                        int months = (int)(Math.Floor((float)days / (365.25 / 12.0)));
                        sReturn = months.ToString() + "m";
                    }
                    else if (days.Between(14, 32))
                    {
                        //use weeks
                        var we = (float)days / 7;
                        int weeks = days / 7;
                        sReturn = weeks.ToString() + "w";
                    }
                    else
                    {
                        //use days
                        sReturn = days.ToString() + "d";
                    }

                }
            }

            return sReturn;
        }
    }
}
