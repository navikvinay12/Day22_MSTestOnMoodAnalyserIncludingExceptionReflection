using MoodAnalyserProject;

namespace MSTestingOnMoodAnalyser
{
    [TestClass]
    public class MoodAnalyserTestClass
    {
        [TestMethod]
        [DataRow("I am in Sad Mood","SAD")]     //TC 1.1    Given "I am in Sad Mood" should return "SAD" .
        public void GivenSad_ViaMethod_ReturnSad(string message,string expected)
        {
            //Arrange
            MoodAnalyser moodAnalyser=new MoodAnalyser();

            //Act
            string actualOutput=moodAnalyser.AnalyseMood(message);

            //Assert
            Assert.AreEqual(actualOutput, expected);
        }
        [TestMethod]
        [DataRow("I am in Any Mood", "HAPPY")]     //TC 1.2    Given "I am in Any Mood" should return "HAPPY" .
        public void GivenAnyMood_ViaMethod_ReturnHappy(string message, string expected)
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser();

            //Act
            string actualOutput = moodAnalyser.AnalyseMood(message);

            //Assert
            Assert.AreEqual(actualOutput, expected);
        }
        [TestMethod]
        [DataRow("I am in Sad Mood", "SAD")] //After Refactor Repeating TC 1.1, Given "I am in Sad Mood" should return "SAD" .
        public void GivenSad_ViaConstructor_ReturnSad(string message, string expected)
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);//message passed via constructor

            //Act
            string actualOutput = moodAnalyser.AnalyseMood();//message not passed via parameterised method.

            //Assert
            Assert.AreEqual(actualOutput, expected);
        }
        [TestMethod]
        [DataRow("I am in Any Mood", "HAPPY")] //After Refactor Repeating TC 1.2, Given "I am in Any Mood" should return "HAPPY" .
        public void GivenAnyMood_ViaConstructor_ReturnHappy(string message, string expected)
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);//message passed via constructor

            //Act
            string actualOutput = moodAnalyser.AnalyseMood();//message not passed via parameterised method.

            //Assert
            Assert.AreEqual(actualOutput, expected);
        }
        [TestMethod]
        [DataRow(null, "Happy")] //TC 2.1, Given null should return "HAPPY" .
        public void GivenNullMood_ViaConstructor_ReturnHappy(string message, string expected)
        {
            //Arrange
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);

            //Act
            string actualOutput = moodAnalyser.AnalyseMood();

            //Assert
            Assert.AreEqual(actualOutput, expected);
        }
        [TestMethod]
        [DataRow(null, "Message should not be null")] //TC 3.1 Given null should throw CustomMoodAnalysisException
        public void GivenNull_ShouldThrow_CustomException_NullMsg(string message,string expected)
        {
            //Arrange
            MoodAnalyser moodAnalyzer = new MoodAnalyser(message);
            try
            {
                //Act
                string actualOutput = moodAnalyzer.AnalyseMood();
            }
            catch(MoodAnalyserException ex)
            {
                //Assert
                Assert.AreEqual(ex.Message,expected);
            }
        }
        [TestMethod]
        [DataRow("", "Message should not be empty")] //TC 3.2 Given empty should throw CustomMoodAnalysisException
        public void GivenEmptyMessage_ShouldThrow_CustomException_EmptyMsg(string message, string expected)
        {
            //Arrange
            MoodAnalyser moodAnalyzer = new MoodAnalyser(message);
            try
            {
                //Act
                string actualOutput = moodAnalyzer.AnalyseMood();
            }
            catch (MoodAnalyserException ex)
            {
                //Assert
                Assert.AreEqual(ex.Message, expected);
            }
        }
    }
}