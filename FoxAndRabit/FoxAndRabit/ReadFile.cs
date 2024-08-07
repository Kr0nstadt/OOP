using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoxAndRabit
{
    public class ReadFile
    {
        private List<Animals> animals = new List<Animals>();
        private int n;
        private int m;

        public List<Animals> animalsfile => animals;
        public int nfile => n;
        public int mfile => m;

        public ReadFile()
        {
            string adress = "C:\\Users\\iamna\\YandexDisk-mileschko.sibsutis\\OOP\\OOP\\FoxAndRabit\\text.txt";
            string[]lines = File.ReadAllLines(adress);
            string patternFirstLine = @"\d+";
            MatchCollection matches = Regex.Matches(lines[0], patternFirstLine);
            n = Int32.Parse(matches[0].Value);
            m = Int32.Parse(matches[1].Value);

            for(int i = 1; i < lines.Length; i++)
            {
                if (lines[i][0] == 'R')
                {
                    animals.Add(new Rabbit(Int32.Parse(lines[i][10].ToString()),
                        Int32.Parse(lines[i][4].ToString()),
                        Int32.Parse(lines[i][6].ToString()), 
                        Int32.Parse(lines[i][8].ToString())));
                }
                if (lines[i][0] == 'F')
                {
                    animals.Add(new Fox(Int32.Parse(lines[i][10].ToString()),
                        Int32.Parse(lines[i][4].ToString()),
                        Int32.Parse(lines[i][6].ToString()),
                        Int32.Parse(lines[i][8].ToString())));
                }
            }
        }
    }
}
