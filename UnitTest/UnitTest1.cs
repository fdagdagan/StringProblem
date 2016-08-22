using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //format
            //input
            //(id,created,employee(id,firstname,employeeType(id), lastname),location)

            //format output
            //id
            //created
            //employee
            //- id
            //- firstname
            //- employeeType
            // -- id
            //- lastname
            //location

            //or Order By
            //created
            //employee
            //- employeeType
            //-- id
            //- firstname
            //- id
            //- lastname
            //id

                string input = "(id,created,employee(id,firstname,employeeType(id), lastname),location)";
                //input = input.Replace(" ", "");
               
                string[] stringArray = input.Split(',');
                //string[] stringArray1 = stringArray.Split('(');
		        int hyphenCount = 0;
                string[] temp;
                string item = string.Empty;
                string sPrint = string.Empty  ;
                string sHypen = string.Empty; 

		        for (var i=0; i < stringArray.Length ; i++) {

                    if (stringArray[i].StartsWith("("))
                    {
                        sPrint = stringArray[i].Replace("(", "");
                    }
                    
                    else if (stringArray[i].Contains("(") && stringArray[i].Contains(")"))
                    {
                        
                        temp = stringArray[i].Split('(');
                        sPrint = sHypen + " " + temp[0];
                        System.Diagnostics.Debug.WriteLine(sPrint.Replace(")", ""));
                        hyphenCount++;
                        sHypen = updateHyphenString(hyphenCount);
                        sPrint = " " + sHypen + " " + temp[1];
                        System.Diagnostics.Debug.WriteLine(sPrint.Replace(")", ""));
                        hyphenCount--;
                        sHypen = updateHyphenString(hyphenCount);
                        continue; 
                    }
                    else if (!stringArray[i].Contains("(") ) 
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
                        else if  (hyphenCount > 0)
                            sPrint =  sHypen + " " + temp[0];

                        hyphenCount++;
                        sHypen = updateHyphenString(hyphenCount);

                        System.Diagnostics.Debug.WriteLine(sPrint);
                        sPrint = sHypen + " " + temp[1];
                        System.Diagnostics.Debug.WriteLine(sPrint);
    
                        continue;
                    }
                    else if (stringArray[i].Contains(")"))
                    {
                        hyphenCount--;
                        sHypen = updateHyphenString(hyphenCount);
                    }
                    
                    
                    System.Diagnostics.Debug.WriteLine(sPrint.Replace(")",""));
		        }

                

        }

        private static string updateHyphenString(int iterations)
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
