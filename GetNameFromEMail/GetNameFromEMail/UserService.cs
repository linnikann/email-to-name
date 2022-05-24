using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace GetNameFromEMail
{
    public class UserService
    {
        public void ConvertCSV() //einlesen, user erstellen, in neue csv schreiben
        {
            string inputPath = "C:\\1\\emails.csv";
            string outputPath = "C:\\1\\users.csv";
            string line;
            using (StreamReader sr = new(inputPath))
            using (StreamWriter sw = new(outputPath))
            while ((line = sr.ReadLine()) != null)
            {
                User user = new(line, GetFirstName(line), GetLastName(line));

                sw.WriteLine(user.ToString());
            }
        }

        public string GetFirstName(string email)
        {
            string localPart = GetCleanLocalPart(email);
            string[] names = GetNames(localPart);
            return GetCapitalizedNames(names)[0];
        }

        public string GetLastName(string email)
        {
            string localPart = GetCleanLocalPart(email);
            string[] names = GetNames(localPart);
            if (names.Length == 1)
            {
                return String.Empty;
            }
            else
            {
                return GetCapitalizedNames(names)[^1];
            }
        }

        public static string GetCleanLocalPart(string email)
        {
            string localPart = RemoveDomain(email);
            localPart = RemoveDecimals(localPart);
            localPart = RemoveDelimitersAtEnd(localPart);
            return localPart;
        }

        private static string RemoveDomain(string email) // testen
        {
            return email.Split('@')[0];
        }

        private static string RemoveDecimals(string fullNameStringWithDecimals)
        {
            //selects multiple decimals
            string selectDecimals = @"\d+";
            return Regex.Replace(fullNameStringWithDecimals, selectDecimals, string.Empty);
        }

        private static string RemoveDelimitersAtEnd(string nameString)
        {
            //select delimiters at last position
            string lastDelimiters = @"([^\w]|_)*$";
            return Regex.Replace(nameString, lastDelimiters, string.Empty);
        }

        public static string[] GetNames(string localPart)
        {
            bool hasDoubleFirstName = Regex.IsMatch(localPart, @"\w-\w*\.\w");
            bool hasDoubleLastName = Regex.IsMatch(localPart, @"\w\.\w*-\w");

            string delimiters = hasDoubleFirstName || hasDoubleLastName ? @"([^\w\-]|_)+" : @"([^\w]|_)+";
            
            return Regex.Split(localPart, delimiters);
        }

        public string[] GetCapitalizedNames(string [] names)
        {
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = names[i].Contains('-') ? GetCapitalizedDoubleNames(names[i]) : GetCapitalizedName(names[i]);
            }
            return names;
        }

        private string GetCapitalizedName(string name)
        {
            return name.Length <= 1 ? name.ToUpper() : char.ToUpper(name[0]) + name[1..];
        }

        private string GetCapitalizedDoubleNames(string name)
        {
            string[] individualNames = name.Split('-');

            for (int j = 0; j < individualNames.Length; j++)
            {
                individualNames[j] =GetCapitalizedName(individualNames[j]);
            }

            return string.Join("-", individualNames);
        }
    }
}
