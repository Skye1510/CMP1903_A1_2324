using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {
        public List<int> stats;

        public Statistics()
        {
            stats = new List<int>();
        }

        public void GetCurrentScores()
        {
            string[] strings = File.ReadAllLines(".\\Stats.txt");
            for (int i = 0; i < strings.Length; i++)
            {
                stats.Add(Convert.ToInt32(strings[i]));
            }
        }

        public void ShowScores()
        {
            Console.WriteLine("Sevens Out Plays: " + stats[0]);
            Console.WriteLine("Sevens Out High-Score: " + stats[1]);
            Console.WriteLine("Three or More Plays: " + stats[2]);
            Console.WriteLine("Three or More High-Score: " + stats[3]);
        }

        public void UpdateScores()
        {
            File.WriteAllText(".\\Stats.txt", stats[0] + "\n" + stats[1] + "\n" + stats[2] + "\n" + stats[3]);
        }
    }
}
