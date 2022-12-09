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
                if(message.Equals(string.Empty))    //will throw Custom exception if message is empty .
                {
                    throw new MoodAnalyserException("Message should not be empty", MoodAnalyserException.ExceptionTypes.EMPTY_MESSAGE);
                }
                else if (message.ToLower().Contains("sad"))   //null reference exception will occur while passing null.
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
                Console.WriteLine(ex.Message);
                throw new MoodAnalyserException("Message should not be null",MoodAnalyserException.ExceptionTypes.NULL_MESSAGE);
            }
        }
    }
}
