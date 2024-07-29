using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FoxAndRabit
{
    internal class ReadFile
    {
        private List<Animals> animals = new List<Animals>();
        private int n;
        private int m;

        public ReadFile()
        {
            string adress = "C:\\Users\\karpo\\OneDrive\\Рабочий стол\\OOP\\OOP\\FoxAndRabit";
            string[]lines = File.ReadAllLines(adress);
            string patternFirstLine = @"\d+";
            MatchCollection matches = Regex.Matches(lines[0], patternFirstLine);
            n = Int32.Parse(matches[0].Value);
            m = Int32.Parse(matches[1].Value);

            for(int i = 1; i < lines.Length; i++)
            {
                if (lines[i][0] == 'R')
                {
                    animals.Add(new Rabbit(lines[i][10], lines[i][4], lines[i][6], lines[i][8]));
                }
                if (lines[i][0] == 'F')
                {
                    animals.Add(new Fox(lines[i][10], lines[i][4], lines[i][6], lines[i][8]));
                }
            }
        }
    }
}
