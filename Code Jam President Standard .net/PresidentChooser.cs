using System;
using System.Collections.Generic;

namespace Code_Jam_President_Standard.net
{
    public class PresidentChooser
    {
        // stores if the name contains an alphabet
        private bool[] isLetterPresent;
        // list of all the tests
        public List<List<string>> Tests { get; set; }
        // list of all the presidents chosen by the algorithm
        public List<string> Presidents { get; set; }

        public PresidentChooser()
        {
            isLetterPresent = new bool[26];
            Tests = new List<List<string>>();
            Presidents = new List<string>();
        }

        private void FindPresident(List<string> names)
        {
            int maxCount = -1;
            string currentPres = "";
            foreach (var name in names)
            {
                int count = 0;
                foreach (char letter in name)
                {
                    int index = letter - 'A';
                    if (index >= 0 && index < 26) // is a valid letter in alphabet
                    {
                        if (!isLetterPresent[index])
                        {
                            isLetterPresent[index] = true;
                            count++;
                        }
                    }
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    currentPres = name;
                }
                if (count == maxCount)
                {
                    if (string.Compare(name, currentPres) < 0) { currentPres = name; }
                }

                for (int i = 0; i < 26; i++) { isLetterPresent[i] = false; }
            }
            Presidents.Add(currentPres);
        }

        // assumes the input correctly formatted
        private void ParseInput()
        {
            int testsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < testsCount; i++)
            {
                int peopleCount = int.Parse(Console.ReadLine());
                var people = new List<string>();
                for (int j = 0; j < peopleCount; j++)
                {
                    var person = Console.ReadLine();
                    people.Add(person);
                }
                Tests.Add(people);
            }
        }

        private void WriteOutput()
        {
            for (int i = 0; i < Presidents.Count; i++)
            {
                Console.WriteLine($"Case #{i + 1}: {Presidents[i]}");
            }
        }

        public void ChoosePresidents()
        {
            ParseInput();

            foreach (var names in Tests)
            {
                FindPresident(names);
            }

            WriteOutput();
        }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            PresidentChooser pc = new PresidentChooser();
            pc.ChoosePresidents();
        }
    }
}
