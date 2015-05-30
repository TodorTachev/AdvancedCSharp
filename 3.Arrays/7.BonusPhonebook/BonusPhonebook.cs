using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BonusPhonebook
{
    static void Main()
    {
        Dictionary<string, List<string>> phonebook = new Dictionary<string, List<string>>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "search")
            {
                break;
            }
            string[] inputArr = input.Split('-');
            if (phonebook.ContainsKey(inputArr[0]))
            {
                phonebook[inputArr[0]].Add(inputArr[1]);
            }
            else
            {
                phonebook[inputArr[0]] = new List<string> { inputArr[1] };
            }
        }
        while (true)
        {
            string search = Console.ReadLine();
            if (phonebook.ContainsKey(search))
            {
                Console.WriteLine("{0} -> {1}", search, String.Join(", ", phonebook[search]));
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist.", search);
            }
        }
    }
}