using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Country_Info_Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Input data for a specific country");
                Console.WriteLine("2. Search for a country by name");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice (1-3): ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddCountryData();
                }
                else if (choice == "2")
                {
                    SearchCountryData();
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Exiting the program.");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please enter a number between 1 and 3.");
                }
            }
        }

        static void AddCountryData()
        {
            Console.Write("Enter country name: ");
            string countryName = Console.ReadLine();

            Console.Write("Enter country code (ISO): ");
            string countryCode = Console.ReadLine();

            Console.Write("Enter population: ");
            string population = Console.ReadLine();

            Console.Write("Enter capital city: ");
            string capitalCity = Console.ReadLine();

            Console.Write("Enter official languages (comma-separated): ");
            string officialLanguages = Console.ReadLine();

            Console.Write("Enter GDP: ");
            string gdp = Console.ReadLine();

            Console.Write("Enter time zone: ");
            string timeZone = Console.ReadLine();

            string fileName = $"{countryName}.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine($"Country Name: {countryName}");
                    writer.WriteLine($"Country Code (ISO): {countryCode}");
                    writer.WriteLine($"Population: {population}");
                    writer.WriteLine($"Capital City: {capitalCity}");
                    writer.WriteLine($"Official Languages: {officialLanguages}");
                    writer.WriteLine($"GDP: {gdp}");
                    writer.WriteLine($"Time Zone: {timeZone}");
                }

                Console.WriteLine($"Data for {countryName} has been saved to {fileName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
            }
        }

        static void SearchCountryData()
        {
            Console.Write("Enter the country name to search: ");
            string countryName = Console.ReadLine();
            string fileName = $"{countryName}.txt";

            if (File.Exists(fileName))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        Console.WriteLine($"\nDetails for {countryName}:");
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"No data found for {countryName}. Make sure the file exists.");
            }
        }
    }
}
