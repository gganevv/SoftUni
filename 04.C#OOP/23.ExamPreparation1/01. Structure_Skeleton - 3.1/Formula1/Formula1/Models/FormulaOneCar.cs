namespace Formula1.Models
{
    using System;

    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsePower;
        private double enineDisplacement;

        public FormulaOneCar(string model, int horsePower, double enineDisplacement)
        {
            Model = model;
            Horsepower = horsePower;
            EngineDisplacement = enineDisplacement;
        }
        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }
                model = value;
            }
        }

        public int Horsepower
        {
            get { return horsePower; }
            private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }
                horsePower = value;
            }
        }

        public double EngineDisplacement
        {
            get { return enineDisplacement; }
            private set
            {
                if (value < 1.6 || value > 2)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }
                enineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps) => EngineDisplacement / Horsepower * laps;
    }
}
