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
        //UC5 CreatingMoodAnalyserParameterizedObject() to get Object of MoodAnalyser class .
        public object CreatingMoodAnalyserParameterizedObject(string className, string constructorName, string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                    var obj = constructorInfo.Invoke(new object[] { message });
                    return obj;
                }
                else
                {
                    throw new MoodAnalyserException("No Such Method", MoodAnalyserException.ExceptionTypes.CONSTRUCTOR_NOT_FOUND);
                }
            }
            else
            {
                throw new MoodAnalyserException("No Such Class", MoodAnalyserException.ExceptionTypes.CLASS_NOT_FOUND);
            }
        }
        public string InvokeAnalyserMethod(string message,string methodName)
        {
            try  
            {
                Type type= typeof(MoodAnalyser);    //in order to fetch only the specific data from the overall data in an assembly
                MoodAnalyserFactory factory=new MoodAnalyserFactory();
                object moodAnalyserObject = factory.CreatingMoodAnalyserParameterizedObject("MoodAnalyserProject.MoodAnalyser","MoodAnalyser",message);
                MethodInfo methodInfo = type.GetMethod(methodName);
                object info=methodInfo.Invoke(moodAnalyserObject,null);
                return info.ToString();
            }
            catch(Exception)
            {
                throw new MoodAnalyserException("No Such Method", MoodAnalyserException.ExceptionTypes.NO_SUCH_METHOD);
            }
        }
    }
}
