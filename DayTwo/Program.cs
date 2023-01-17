namespace DayTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                const string filePath = @"C:\2022 projects\DotNet\AdventOfCode_2022\DayTwo\Inputs\input.txt";

                var rockPaperScissorsInput = File.ReadAllLines(filePath);

                int totalScore = 0;

                foreach (string line in rockPaperScissorsInput)
                {
                    string myShape = MapInputCharToShape(line[2]);
                    string opponentShape = MapInputCharToShape(line[0]);

                    int roundScore = ScoreRound(myShape, opponentShape);
                    totalScore += roundScore;
                    //Console.WriteLine($"My Shape: {myShape} Opponent Shape: {opponentShape} = {roundScore}");

                }
                Console.WriteLine($"My Total Score: {totalScore}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static string MapInputCharToShape(char character)
        {
            switch (character)
            {
                case 'A' or 'X':
                    return "Rock";
                case 'Y' or 'B':
                    return "Paper";
                case 'Z' or 'C':
                    return "Scissors";
                default:
                    return string.Empty;
            }
        }

        static int MapShapeToScore(string shape)
        {
            switch (shape)
            {
                case "Rock":
                    return 1;
                case "Paper":
                    return 2;
                case "Scissors":
                    return 3;
                default:
                    return 0;
            }
        }

        static bool Won(string myShape, string opponentShape)
        {
            if (myShape.Equals("Rock") && opponentShape.Equals("Scissors"))
            {
                return true;
            }
            else if (myShape.Equals("Scissors") && opponentShape.Equals("Paper"))
            {
                return true;
            }
            else if (myShape.Equals("Paper") && opponentShape.Equals("Rock"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool IsADraw(string myShape, string opponentShape)
        {
            return myShape == opponentShape;
        }

        static int ScoreRound(string myShape, string opponentShape)
        {
            int points = MapShapeToScore(myShape);

            if (Won(myShape, opponentShape))
            {
                points += 6;
            }
            else if (IsADraw(myShape, opponentShape))
            {
                points += 3;
            }

            return points;
        }
    }
}