using System;
using System.Linq;
namespace GA_application
{
    public class Fitness
    {
        private Function function;
        public double sumatoryFitness { get; set; }
        public double[] fitnessValue { get; set; }

        private double constantFitness { set; get; }

        public double[,] target { set; get; }

        public double maxFitness { set; get; }
        public double maxFitnessIndex { set; get;}



        //public Fitness(int _constantFitness, double[,] _target)
        //{
        //    constantFitness = _constantFitness;
        //    target = _target;
        //    //function = new Function(_x);
        //}

        public Fitness(int _constantFitness, double[,] _target, double[] _x)
        {
            //Second contructor
            constantFitness = _constantFitness;
            target = _target;
            function = new Function(_x);
        }
        
        public void GetMaxFitness()
        {
            //double value = fitnessValue.Max();
            //double index = fitnessValue.ToList().IndexOf(value);

            maxFitness = fitnessValue.Max();
            maxFitnessIndex = fitnessValue.ToList().IndexOf(maxFitness);

            //double[] result = new double[2] { value, index };
            //return result;
        }

        public void Evaluation(double[,] population)
        {
            double[] error = new double[target.GetLength(0)];
            fitnessValue = new double[population.GetLength(0)];
            for (int i =0; i< population.GetLength(0); i++)
            {
                double[] feature = new double[population.GetLength(1)];
                for(int j=0; j < population.GetLength(1); j++)
                {
                    feature[j] = population[i, j];
                }
                
                double[,] result = function.Evaluation(feature);

                for (int j = 0; j < result.GetLength(0); j++)
                {
                    error[j] = Math.Abs(target[j, 1] - result[j, 1]);
                }

                double sumError = error.Sum();
                fitnessValue[i] = constantFitness / sumError;
            }

            sumatoryFitness = fitnessValue.Sum();
            
        }
    }
}