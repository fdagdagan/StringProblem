using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;

namespace BusinessLayer.Business
{
    public class EmployeeBL : IEmployee
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<string> GetData(string input)
        {
            
            //input = "(id,created,employee(id,firstname,employeeType(id), lastname),location)";
            List<string> reply = new List<string>();

            string[] stringArray = input.Split(',');
            
            int hyphenCount = 0;
            string[] temp;
            string item = string.Empty;
            string sPrint = string.Empty;
            string sHypen = string.Empty;

            for (var i = 0; i < stringArray.Length; i++)
            {

                if (stringArray[i].StartsWith("("))
                {
                    sPrint = stringArray[i].Replace("(", "");
                }

                else if (stringArray[i].Contains("(") && stringArray[i].Contains(")"))
                {

                    temp = stringArray[i].Split('(');
                    sPrint = sHypen + " " + temp[0];
                    reply.Add(sPrint.Replace(")", ""));
                    hyphenCount++;
                    sHypen = UpdateHyphenString(hyphenCount);
                    sPrint = " " + sHypen + " " + temp[1];
                    reply.Add(sPrint.Replace(")", ""));
                    hyphenCount--;
                    sHypen = UpdateHyphenString(hyphenCount);
                    continue;
                }
                else if (!stringArray[i].Contains("("))
                {
                    if (!stringArray[i].EndsWith(")"))
                    {
                        if (hyphenCount == 0)
                            sPrint = stringArray[i];
                        else if (hyphenCount > 0)
                            sPrint = sHypen + " " + stringArray[i];
                    }
                    else
                    {
                        sPrint = stringArray[i];
                        if (hyphenCount == 0)
                            sPrint = stringArray[i];
                        else if (hyphenCount > 0)
                            sPrint = sHypen + " " + stringArray[i];

                        if ((stringArray.Length - 1) == i)
                            sPrint = stringArray[i];
                    }

                }
                else if (stringArray[i].Contains("("))
                {

                    temp = stringArray[i].Split('(');
                    if (hyphenCount == 0)
                        sPrint = temp[0];
                    else if (hyphenCount > 0)
                        sPrint = sHypen + " " + temp[0];

                    hyphenCount++;
                    sHypen = UpdateHyphenString(hyphenCount);

                    reply.Add(sPrint);
                    sPrint = sHypen + " " + temp[1];
                    reply.Add(sPrint);

                    continue;
                }
                else if (stringArray[i].Contains(")"))
                {
                    hyphenCount--;
                    sHypen = UpdateHyphenString(hyphenCount);
                }


                reply.Add(sPrint.Replace(")", ""));
            }


            return reply;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iterations"></param>
        /// <returns></returns>
        private static string UpdateHyphenString(int iterations)
        {
            String hyphenString = "";
            for (int count = 0; count < iterations; count++)
            {
                hyphenString += "-";
            }
            return hyphenString;
        }
    }
}
