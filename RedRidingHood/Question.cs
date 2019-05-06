using System.Collections.Generic;

namespace RedRidingHood
{
    internal class Question
    {
        public string question;
        public string[] answers = new string[4];

        public Question(string question, string[] answers)
        {
            this.question = question;
            this.answers = answers;
        }

        public static List<Question> getQuestions()
        {
            List<Question> list = new List<Question>();

            //first answer is the correct one
            //TODO use JSON
            list.Add(new Question("Which of the following is a reserved keyword in C#?", new string[] { "All of these.", "abstract", "as", "foreach" }));
            list.Add(new Question("Which of the following defines boxing correctly?", new string[] { "When a value type is converted to object type, it is called boxing.", "When an object type is converted to a value type, it is called boxing.", "Both of the above.", "None of the above." }));
            list.Add(new Question("Which of the following converts a type to a string in C#?", new string[] { "ToString", "ToSingle", "ToSbyte", "ToInt64" }));
            list.Add(new Question("Which of the following operator returns the type of a class in C#?", new string[] { "typeof", "sizeof", "&</a>", "*" }));
            list.Add(new Question("Which of the following method helps in returning more than one value?", new string[] { "Output parameters", "Value parameters", "Reference parameters", "None of these." }));
            list.Add(new Question("Which of the following is the default access specifier of a class?", new string[] { "Internal", "Protected", "Public", "Private" }));

            return list;
        }
    }
}