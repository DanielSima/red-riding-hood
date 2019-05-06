using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RedRidingHood
{
    /// <summary>
    /// where you start
    /// </summary>
    internal class Home : Tile
    {
        public Home(int xCoordinate = 0, int yCoordinate = 0) : base(xCoordinate, yCoordinate)
        {
        }

        public override string ToString()
        {
            return "HOME";
        }

        public override int Action()
        {
            return -1;
        }
    }

    /// <summary>
    /// where you need to get
    /// </summary>
    internal class GrandmasHome : Tile
    {
        public GrandmasHome(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
        }

        public override string ToString()
        {
            return "GRANDMA";
        }

        public override int Action()
        {
            return -1;
        }
    }

    /// <summary>
    /// player must answer question
    /// </summary>
    internal class Obstacle : Tile
    {
        public Obstacle(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
        }

        public override string ToString()
        {
            return "TRAP";
        }

        public override int Action()
        {
            //get questions
            List<Question> questions = Question.getQuestions();
            //select random question
            Question currentQuestion = questions[new Random().Next(0, questions.Count)];
            //shuffle answers in another array, so we still have correct answer first in this one
            //most complicated shuffle ever
            string[] shuffledAnswers = currentQuestion.answers.OrderBy(a => Guid.NewGuid()).ToArray();

            //print question
            Console.WriteLine(currentQuestion.question);
            for (int i = 0; i < shuffledAnswers.Length; i++)
            {
                Console.WriteLine(" - " + shuffledAnswers[i]);
            }
            //print possible answers and wait for response
            char keyPressed = 'N';
            bool oneChar = false;
            while (!oneChar)
            {
                Console.WriteLine("Correct answer? (A/B/C/D)");
                string key = Console.ReadLine().ToLower();
                if (key == "a" || key == "b" || key == "c" || key == "d")
                {
                    keyPressed = Convert.ToChar(key);
                    oneChar = true;
                }
            }
            //asign selected letter to answer
            string selectedAnswer = "";
            switch (keyPressed)
            {
                case 'a':
                    selectedAnswer = shuffledAnswers[0];
                    break;

                case 'b':
                    selectedAnswer = shuffledAnswers[1];
                    break;

                case 'c':
                    selectedAnswer = shuffledAnswers[2];
                    break;

                case 'd':
                    selectedAnswer = shuffledAnswers[3];
                    break;
            }
            //check if answer is correct
            if (selectedAnswer != currentQuestion.answers[0])
            {
                Console.WriteLine("Incorrect!");
                return 1;
            }
            else
            {
                Console.WriteLine("Correct!");
                return 0;
            }
        }
    }

    /// <summary>
    /// relaxation spot
    /// </summary>
    internal class ViewPoint : Tile
    {
        public ViewPoint(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
        }

        public override string ToString()
        {
            return "VIEW";
        }

        public override int Action()
        {
            Console.WriteLine("As you walked to grandma's house, you looked upon a tree, whose branches hides a pair of squirells, one with brown fur and the second one also brown, because there are not really other types of squirells around here. Squirell on the left has a large acorn and the other is trying to take it from her(or him). Then you see a magnificent hawk flying towards them, but you remember that you need to go to grandma's, so you continue.");
            return -1;
        }
    }

    /// <summary>
    /// teleports the player
    /// </summary>
    internal class Teleport : Tile
    {
        public Teleport(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
        }

        public override string ToString()
        {
            return "?";
        }

        public override int Action()
        {
            Console.WriteLine("What happened, where am I?");
            return -2;
        }
    }

    /// <summary>
    /// restores presents
    /// </summary>
    internal class Field : Tile
    {
        public Field(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
        }

        public override string ToString()
        {
            return "FIELD";
        }

        public override int Action()
        {
            return -3;
        }
    }
}