namespace FutChampsSummary
{
    public class Statistics
    {
        public float Min { get; private set; }

        public float Max { get; private set; }

        public float Sum { get; private set; }

        public float Count { get; private set; }

        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }

        public char AverageLetter
        {
            get
            {
                switch (this.Average)
                {
                    case var average when average >= 8:
                        return 'A';
                    case var average when average >= 6:
                        return 'B';
                    case var average when average >= 4:
                        return 'C';
                    case var average when average >= 2:
                        return 'D';
                    default:
                        return 'E';
                }
            }
        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
        }

        public void AddScore(float score)
        {
            this.Count++;
            this.Sum += score;
            this.Min = Math.Min(score, this.Min);
            this.Max = Math.Max(score, this.Max);
        }
    }
}
