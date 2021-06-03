using System;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            Difficulty Rank = 0;
            double score = 0;
            
            SelectPages(Rank, score);
        }

        static void SelectPages(Difficulty Rank, double score)
        {
            Console.WriteLine("Score: {0}, Difficulty: {1}", score, Rank);
            int Select;
            for (int i = 0; ; i++)
            {
                Console.WriteLine("Please input 0 - 2.");
                Select = int.Parse(Console.ReadLine());

                if (Select == 0)
                {
                    playGame(Rank, score);
                }
                else if (Select == 1)
                {
                    GameLevels(ref Rank, score);
                }
                else if (Select == 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please just Input 0-2 you damn son");
                }
                break;
            }

        }

        static void playGame(Difficulty Rank, double score)
        {
            int numquestion = 0;
            double level = 0;
            if (Rank == 0)
            {
                numquestion = 3;
                level = 0;
            }
            if (Rank == Difficulty.Normal)
            {
                numquestion = 5;
                level = 1;
            }
            if (Rank == Difficulty.Hard)
            {
                numquestion = 7;
                level = 2;
            }
            Problem[] Gameplay = GenerateRandomProblems(numquestion);

            long a = DateTimeOffset.Now.ToUnixTimeSeconds();
            double ture = 0;
            for (int i = 0; i <= Gameplay.Length - 1; i++)
            {
                Console.WriteLine(Gameplay[i].Message);
                int answer;
                answer = int.Parse(Console.ReadLine());

                if (Gameplay[i].Answer == answer)
                {
                    ture++;
                }
            }
            long b = DateTimeOffset.Now.ToUnixTimeSeconds();
            long time = b - a;

            double now;
            now = (ture / numquestion) * ((25 - level * level) / Math.Max(time, 25 - level * level)) * Math.Pow(2 * level + 1, 2);
            Console.WriteLine("Your score is {0}", now);
            score += now;

            SelectPages(Rank, score);
        }

        static void GameLevels(ref Difficulty Rank, double score)
        {
            for (int i = 0; ; i++)
            {
                int choose;
                Console.WriteLine("In put the difficulty: ");
                choose = int.Parse(Console.ReadLine());

                if (choose == 0)
                {
                    Rank = Difficulty.Easy;
                }
                else if (choose == 1)
                {
                    Rank = Difficulty.Normal;
                }
                else if (choose == 2)
                {
                    Rank = Difficulty.Hard;
                }
                else 
                {
                    Console.WriteLine("Please Input 0-2");
                }
                break;
            }
            Console.WriteLine("difficult:{0}", Rank);
            
            SelectPages(Rank, score);
        }
        enum Difficulty
        {
            Easy,
            Normal,
            Hard
        }
        struct Problem
        {
            public string Message;
            public int Answer;

            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }
        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];

            Random rnd = new Random();
            int x, y;

            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                    new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] =
                    new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }

            return randomProblems;
        }
    }
}
