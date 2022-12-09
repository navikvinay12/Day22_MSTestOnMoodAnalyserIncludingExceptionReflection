using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoodAnalyserProject.Reflections
{
    public class MoodAnalyserFactory
    {
        //UC4 CreatingMoodAnalyserObject() to get Object of MoodAnalyser class .
        public object CreatingMoodAnalyserObject(string className, string constructorName)
        {
            string pattern = "." + constructorName + "$";
            Match result = Regex.Match(className, pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executingAssembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = executingAssembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyserType);
                }
                catch (Exception ex)
                {
                    throw new MoodAnalyserException("no such class", MoodAnalyserException.ExceptionTypes.CLASS_NOT_FOUND);
                }
            }
            else
            {
                throw new MoodAnalyserException("no such method", MoodAnalyserException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
            }
        }
    }
}
