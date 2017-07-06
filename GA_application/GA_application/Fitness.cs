using System;
using System.Linq;
namespace GA_application
{
    public class Fitness
    {
        public double sumatoryFitness { get; }
        public double[] fitnessValue { get; }

        private double constantFitness { set; get; }

        public double[] target { set; get; }

        public Fitness(int _constantFitness, int populationSize)
        {
            constantFitness = _constantFitness;
            fitnessValue = new double[populationSize];
        } 

        private double[] GetMaxFitness()
        {
            double value = fitnessValue.Max();
            double index = fitnessValue.ToList().IndexOf(value);

            double[] result = new double[2] { value, index };
            return result;
        }
        


    }
}