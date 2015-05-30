using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Phonebook
{
    static void Main()
    {
        Dictionary<string, string> phonebook = new Dictionary<string, string>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "search")
            {
                break;
            }
            string[] inputArr = input.Split('-');
            phonebook[inputArr[0]] = inputArr[1];
        }
        while (true)
        {
            string search = Console.ReadLine();
            if (phonebook.ContainsKey(search))
            {
                Console.WriteLine("{0} -> {1}", search, phonebook[search]);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", search);
            }
        }
    }
}