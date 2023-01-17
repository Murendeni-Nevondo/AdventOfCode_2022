namespace DayOne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string filePath = @"C:\2022 projects\DotNet\AdventOfCode_2022\DayOne\Inputs\input.txt";

            //Part one output
            DayOnePartOne(filePath);

            //Part two output
            DayOnePartTwo(filePath);
        }

        static void DayOnePartOne(string fileInputPath)
        {
            try
            {
                var caloriesInput = File.ReadAllLines(fileInputPath);

                int currentMaxCalorie = default;
                int elfCalorie = default;

                foreach (string calorie in caloriesInput)
                {
                    if (calorie == string.Empty)
                    {
                        if (currentMaxCalorie > elfCalorie)
                            elfCalorie = currentMaxCalorie;
                        currentMaxCalorie = 0; //reset max
                    }
                    else
                    {
                        currentMaxCalorie += Convert.ToInt32(calorie);
                    }

                }

                Console.WriteLine(elfCalorie);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        static void DayOnePartTwo(string fileInputPath)
        {
            try
            {
                var caloriesInput = File.ReadAllLines(fileInputPath);

                var topThreeCalories = new int[caloriesInput.Length];

                int currentMaxCalorie = default;
                int sum = default;

                foreach (string calorie in caloriesInput)
                {
                    if (calorie == string.Empty)
                    {
                        for (int i = 2; i >= 0; i--)
                        {
                            if (currentMaxCalorie > topThreeCalories[i])
                            {
                                if (i != 2)
                                {
                                    topThreeCalories[i + 1] = topThreeCalories[i];
                                }
                                topThreeCalories[i] = currentMaxCalorie;
                            }
                        }

                        //Reset max and move to the next ELF
                        currentMaxCalorie = 0;
                    }
                    else
                    {
                        currentMaxCalorie += Convert.ToInt32(calorie);
                    }
                }

                foreach (int maxCalorie in topThreeCalories)
                {
                    sum += maxCalorie;
                }
                Console.WriteLine(sum);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}