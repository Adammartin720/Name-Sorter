using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

//using Linq lists to allow for easy splitting of data



namespace Name_Sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                // Filepaths for both unsorted and sorted text files (located in debug folder)
                String filepath = @"unsorted-names-list.txt";
                String filepath2 = @"sorted-names-list.txt";

                // Create a list named people to hold the split data of given name and lastname
                List<Person> people = new List<Person>();

                List<String> lines = File.ReadAllLines(filepath).ToList();

                // Entries are split on comma within text file and are put into two entries,
                // if text file does not seperate given and last names via comma then program will not work
                // could not find another way to select final word in file
                 foreach (var line in lines)
                {
                    string[] entries = line.Split(',');
                    Person newPerson = new Person();
                    newPerson.FirstName = entries[0];
                    newPerson.LastName = entries[1];

                    people.Add(newPerson);

                }

                 //Order by firstname then lastname so those who share last name are then sorted via given name
                people = people.OrderBy(y => y.FirstName).ToList();

                people = people.OrderBy(x => x.LastName).ToList();

                foreach (var Person in people)
                {
                    //Writting Given names and lastname to screen
                    Console.WriteLine($"{ Person.FirstName } { Person.LastName }");
                }

                List<string> output = new List<string>();
                foreach (var person in people)
                {
                    //Creating output to allow for writing to another text file
                    output.Add($"{ person.FirstName }, {person.LastName }");
                }

                //Confirmation of writing to text file
                Console.WriteLine("Writing to text file");
                File.WriteAllLines(filepath2, output);
                Console.WriteLine("All entires written to new file");


                Console.ReadLine();
            }
        }

        }
    }

