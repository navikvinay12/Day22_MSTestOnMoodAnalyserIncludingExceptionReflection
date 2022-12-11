using System.Runtime.Serialization;

namespace MoodAnalyserProject
{
    public class MoodAnalyserException : Exception  //created Custom exception , requirement for 3rd UC .
    {
        public ExceptionTypes exceptionType;
        public enum ExceptionTypes
        {
            NULL_MESSAGE,
            EMPTY_MESSAGE,
            CLASS_NOT_FOUND,
            CONSTRUCTOR_NOT_FOUND,
            NO_SUCH_METHOD
        }
        public MoodAnalyserException(string msg, ExceptionTypes exceptionType) : base(msg)
        {
            this.exceptionType = exceptionType;
        }
    }
}