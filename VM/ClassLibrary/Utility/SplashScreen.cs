using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CapstoneProject
{
    public static class SplashScreen
    {
        public static string StartupScreen()
        {
            string fullFilePath = $@"C:\workspace\team\week-4-pair-exercises-c-team-4\19_Capstone\dotnet\etc\SplashScreen.txt";
            string textFile = File.ReadAllText(fullFilePath);
            return textFile;

            
            
            //using (StreamReader sr = new StreamReader(fullFilePath))
            //{
            //    while (!sr.EndOfStream)
            //    {
            //        textFile = sr.ReadLine();
            //    }
            //}
            //return textFile;
        }

    }
};
