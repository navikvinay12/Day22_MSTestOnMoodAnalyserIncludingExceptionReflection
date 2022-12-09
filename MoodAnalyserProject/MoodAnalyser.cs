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
            if (message.ToLower().Contains("sad"))  
            {
                return "SAD";
            }
            else
            {
                return "HAPPY";
            }
        }
        public string AnalyseMood()     
        {
            try
            {
                if (message.ToLower().Contains("sad"))  //TC 2.1, Given null should return "HAPPY".(try catch to handle exception).
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch(NullReferenceException ex)
            {
                return "Happy";
            }
        }
    }
}
