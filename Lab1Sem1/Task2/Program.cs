namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Select an option (1, 2 or 0):");
                Console.WriteLine("1, enter circle data manually from keyboard");
                Console.WriteLine("2, enter cylinder data manually from keyboard");
                Console.WriteLine("0, exit program");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Manual circle input");
                        TCircle userCircle = new TCircle();
                        try
                        {
                            userCircle.Input();
                            userCircle.Output();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}\n");
                        }
                        Console.WriteLine("Do you want to do any basic math operations (-, *, +) ? Enter yes or no:");
                        string answer = Console.ReadLine();
                        if (answer == "yes")
                        {
                            Console.WriteLine("Enter details for the second circle:");
                            TCircle secondCircle = new TCircle();
                            secondCircle.Input();

                            int cmp = userCircle.CompareTo(secondCircle); 
                            if (cmp > 0) Console.WriteLine("First circle is larger than second");
                            else if (cmp < 0) Console.WriteLine("First circle is smaller than second");
                            else Console.WriteLine("Circles are equal");

                            TCircle sumCircle = userCircle + secondCircle;
                            Console.WriteLine($"Sum of circles. {sumCircle}");

                            TCircle diffCircle = userCircle - secondCircle;
                            Console.WriteLine($"Difference of circles. {diffCircle}");

                            Console.Write("Enter a multiplier number: ");
                            double multiplier = double.Parse(Console.ReadLine());
                            if (multiplier >= 0)
                            {
                                TCircle multCircle1 = userCircle * multiplier;
                                Console.WriteLine($"Circle * number. {multCircle1}");

                                TCircle multCircle2 = multiplier * userCircle;
                                Console.WriteLine($"Number * circle. {multCircle2}");
                            }
                            else
                            {
                                Console.WriteLine("Invalid number entered for multiplier");
                            }
                        }
                        break;

                    case "2":
                        Console.WriteLine("Manual cylinder input");
                        TCylinder userCylinder = new TCylinder();
                        try
                        {
                            userCylinder.Input();
                            userCylinder.Output();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}\n");
                        }
                        break;
                    case "0":
                        Console.WriteLine("Exiting program");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Choice must be 1, 2 or 0. Please try again\n");
                        break;
                }
            }
        }
    }
}