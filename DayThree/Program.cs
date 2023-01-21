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

                //Part One
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
                Console.WriteLine($"Part One: {total}");

                int counter = 0;

                var ruckSackGroupList = new string[3];

                //Part Two
                var partTwoTotal = 0;

                foreach(var item in input)
                {
                    ruckSackGroupList[counter] = item;
                    counter++;

                    if (counter % 3 is 0)
                    {
                        var ruckSackOne = new List<char>();
                        var ruckSackTwo = new List<char>();
                        var ruckSackThree = new List<char>();

                        for (int j = 0; j < 3; j++)
                        {
                            if (j == 0)
                            {
                                foreach (var d in ruckSackGroupList[0].ToArray())
                                {
                                    ruckSackOne.Add(d);
                                }
                            }

                            if (j == 1)
                            {
                                foreach (var e in ruckSackGroupList[1].ToArray())
                                {
                                    ruckSackTwo.Add(e);
                                }
                            }

                            if (j == 2)
                            {
                                foreach (var f in ruckSackGroupList[2].ToArray())
                                {
                                    ruckSackThree.Add(f);
                                }
                            } 
                        }
                        
                        var commonItemInGroup = ruckSackOne.Intersect(ruckSackTwo).Intersect(ruckSackThree).ToList().FirstOrDefault();

                        try
                        {
                            partTwoTotal += itemPriorityDictionary.lowarCaseLetterValuePairs[commonItemInGroup];
                        }
                        catch (Exception)
                        {

                        }

                        try
                        {
                            partTwoTotal += itemPriorityDictionary.upperCaseLetterValuePairs[commonItemInGroup];
                        }
                        catch (Exception)
                        {

                        }

                        ruckSackGroupList = new string[3];
                        counter = 0;
                    }
                }
                Console.WriteLine($"Part Two: { partTwoTotal }");
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