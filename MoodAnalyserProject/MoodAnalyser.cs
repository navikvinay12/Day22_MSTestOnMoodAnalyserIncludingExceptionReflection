using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProject
{
    public class MoodAnalyser
    {
        string message;
        public MoodAnalyser() { }
        public MoodAnalyser(string message)
        {
            this.message=message;
        }
        public string AnalyseMood(string message)
        {
            if (message.ToLower().Contains("sad"))  //ToLower()Sad->sad.
            {
                return "SAD";
            }
            else
            {
                return "HAPPY";
            }
        }
        public string AnalyseMood()     //Refactor -Taking message via costructor not via parameterized method .
        {
            if (message.ToLower().Contains("sad"))  
            {
                return "SAD";
            }
            else
            {
                return "HAPPY";
            }
        }
    }
}
