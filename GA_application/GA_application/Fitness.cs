using System;
using System.Linq;
namespace GA_application
{
    public class Fitness
    {

        private Function function;
        private double[] targetFucntion;

        public double sumatoryFitness { get; set; }
        public double[] fitnessValue { get; set; }

        private double constantFitness { set; get; }

        public double[,] target { set; get; }


        public Fitness(int _constantFitness, double[,] _target)
        {
            constantFitness = _constantFitness;
            target = _target;
            function = new Function();
        }

        public Fitness(int _constantFitness, int _populationSize, double[] _targetFunction)
        {
            //Kike constructor
            targetFucntion = _targetFunction;
            constantFitness = _constantFitness;
            fitnessValue = new double[_populationSize];
        }

        public double[] GetMaxFitness()
        {
            double value = fitnessValue.Max();
            double index = fitnessValue.ToList().IndexOf(value);

            double[] result = new double[2] { value, index };
            return result;
        }

        public void Evaluation(double[,] population)
        {
            double[] error = new double[population.GetLength(0)];
            fitnessValue = new double[population.GetLength(0)];
            for (int i =0; i< population.GetLength(0);i++ )
            {

                double[] feature = new double[population.GetLength(1)];
                for(int j=0; j < population.GetLength(1); j++)
                {
                    feature[j] = population[i, j];
                }
                
                //double[,] result = function.Evaluation(feature);

                double[][] result = function.EvaluationJagged(feature);

                for (int j = 0; j < result.Length; j++)
                {
                    //error[j] = Math.Abs(target[j, 1] - result[j, 1]);
                    error[j] = Math.Abs(targetFucntion[j] - result[1][j]);
                }

                double sumError = error.Sum();

                fitnessValue[i] = constantFitness / sumError;
            }

            sumatoryFitness = fitnessValue.Sum();

        }

       
    }
}