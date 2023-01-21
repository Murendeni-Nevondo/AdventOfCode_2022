namespace DayThree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ItemPriorityDictionary itemPriorityDictionary = new ItemPriorityDictionary();
            int total = 0;

            try
            {
                string filePath = @"C:\2022 projects\DotNet\AdventOfCode_2022\DayThree\Input\input.txt";

                var input = File.ReadAllLines(filePath);

                foreach (var line in input)
                {
                    try
                    {
                        int priorityOneValue = itemPriorityDictionary.lowarCaseLetterValuePairs[GetCommonItem(SplitLineIntoHalf(line).Item1, SplitLineIntoHalf(line).Item2)];
                        total += priorityOneValue;
                    }
                    catch (Exception)
                    {}

                    try
                    {
                        int priorityTwoValue = itemPriorityDictionary.upperCaseLetterValuePairs[GetCommonItem(SplitLineIntoHalf(line).Item1, SplitLineIntoHalf(line).Item2)];
                        total += priorityTwoValue;
                    }
                    catch (Exception)
                    {}
                }
                Console.WriteLine(total);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        static (string, string) SplitLineIntoHalf(string line)
        {
            var lineLenth = line.Length;

            string firstPart = line.Substring(0, (lineLenth / 2));
            string secondPart = line.Substring((lineLenth / 2), lineLenth/2);

            return (firstPart, secondPart);
        }

        static char GetCommonItem(string firstPart, string secondPart)
        {

            var firstContapat = firstPart.ToList();
            var secondContapat = secondPart.ToList();

            var commonItem = firstContapat.Intersect(secondContapat).ToList();
            return commonItem.FirstOrDefault();
        }
    }
}