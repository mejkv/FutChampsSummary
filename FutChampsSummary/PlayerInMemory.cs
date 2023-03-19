﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FutChampsSummary
{
    internal class PlayerInMemory : PlayerBase
    {
        private List<float> score = new List<float>();

        public PlayerInMemory(string name, string rarity)
            :base(name, rarity)
        { 
        }

        public override event RatingAbove9Delegate RatingAbove9;

        public override void AddScore(float score)
        {
            if (score >= 0 && score <= 10)
            {
                this.score.Add(score);

                if (score > 10 )
                {
                    RatingAbove9(this, new EventArgs());
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
            var result = (float)score;
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
            var statistics = new Statistics();

            foreach (var score in this.score)
            {
                statistics.AddScore(score);
            }

            return statistics;
        }
    }
}
