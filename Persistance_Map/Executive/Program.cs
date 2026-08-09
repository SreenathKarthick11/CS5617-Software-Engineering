using Persistence;

namespace Executives
{
    internal class Program
    {
        private static void Intial_screen()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("|      Persistent Map           |");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. Save");
            Console.WriteLine("2. Retrieve");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Exit");
            Console.WriteLine("5. Clear");
            Console.WriteLine();

        }
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();

            bool running = true;

            Intial_screen();

            while (running)
            {

                Console.Write("\nEnter your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Key: ");
                        string? key = Console.ReadLine();

                        Console.Write("Enter Value: ");
                        string? value = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(key) && value != null)
                        {
                            fileManager.Save(key, value);
                            Console.WriteLine("\nRecord saved successfully.");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid input.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter Key: ");
                        key = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(key))
                        {
                            Console.WriteLine($"\nValue: {fileManager.Retrieve(key)}");
                        }
                        break;

                    case "3":
                        Console.Write("Enter Key: ");
                        key = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(key))
                        {
                            if (fileManager.Delete(key))
                                Console.WriteLine("\nRecord deleted successfully.");
                            else
                                Console.WriteLine("\nKey not found.");
                        }
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    case "5":
                        Console.Clear();
                        Intial_screen();
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice.");
                        break;
                }


            }
        }
    }
}