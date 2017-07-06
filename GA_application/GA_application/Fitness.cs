using System;

namespace GA_application
{
    public class Fitness
    {
        public double sumatoryFitness { get; }
        public double[] fitnessValue { get; }
        public int indexFitnessMaximo { get;}

        private double constantFitness { set; get; }

        public Fitness(int _constantFitness)
        {
            constantFitness = _constantFitness;
        } 

    }
}