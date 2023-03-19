using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FutChampsSummary.PlayerBase;

namespace FutChampsSummary
{
    internal class PlayerInFile: PlayerBase
    {
        public override event ScoreAddedDelegate ScoreAdded;

        private const string fileName = "scores.txt";

        public PlayerInFile(string name, string surname)
            : base(name, surname)
        {
        }

        public override void AddScore(float score)
        {
            if (score >= 0 && score <= 100)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(score);
                }

                if (ScoreAdded != null)
                {
                    ScoreAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Invalid score value");
            }
        }

        public override void AddScore(double score)
        {
            var result = (float)score;
            this.AddScore(result);
        }

        public override void AddScore(int score)
        {
            float result = score;
            this.AddScore(result);
        }

        public override void AddScore(char score)
        {
            switch (score)
            {
                case 'A':
                case 'a':
                    this.AddScore(100);
                    break;
                case 'B':
                case 'b':
                    this.AddScore(80);
                    break;
                case 'C':
                case 'c':
                    this.AddScore(60);
                    break;
                case 'D':
                case 'd':
                    this.AddScore(40);
                    break;
                case 'E':
                case 'e':
                    this.AddScore(20);
                    break;
                default:
                    throw new Exception("Invalid score value");
            }
        }

        public override void AddScore(string score)
        {
            if (float.TryParse(score, out float result))
            {
                this.AddScore(result);
            }
            else
            {
                switch (score)
                {
                    case "A":
                    case "a":
                        this.AddScore(100);
                        break;
                    case "B":
                    case "b":
                        this.AddScore(80);
                        break;
                    case "C":
                    case "c":
                        this.AddScore(60);
                        break;
                    case "D":
                    case "d":
                        this.AddScore(40);
                        break;
                    case "E":
                    case "e":
                        this.AddScore(20);
                        break;
                    default:
                        throw new Exception("Invalid score value");
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = this.StatisticsFromFile();
            var finalResult = this.GetStatisticsFromFile(result);
            return finalResult;
        }

        private List<float> StatisticsFromFile()
        {
            var scores = new List<float>();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        scores.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return scores;
        }

        private Statistics GetStatisticsFromFile(List<float> scores)
        {
            var statistics = new Statistics();

            foreach (var score in scores)
            {
                statistics.AddScore(score);
            }

            return statistics;
        }
    }
}
