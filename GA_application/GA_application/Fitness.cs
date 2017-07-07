using System;
using System.Linq;
namespace GA_application
{
    public class Fitness
    {

        public Function function;
        private double[] targetFucntion;
        double[] populationError;
        double[] chromosomeError;

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
            populationError = new double[_populationSize];
            chromosomeError = new double[_targetFunction.Length];


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
            populationError = new double[population.GetLength(0)];
            fitnessValue = new double[population.GetLength(0)];
            for (int i =0; i< population.GetLength(0);i++ )
            {

                double[] currentFeature = new double[population.GetLength(1)];
                for(int j=0; j < population.GetLength(1); j++)
                {
                    currentFeature[j] = population[i, j];
                }
                
                //double[,] result = function.Evaluation(feature);

                double[] result = function.EvaluationJagged(currentFeature);

                for (int j = 0; j < result.Length; j++)
                {
                    //error[j] = Math.Abs(target[j, 1] - result[j, 1]);
                    chromosomeError[j] = Math.Abs(targetFucntion[j] - result[j]);
                }

                double sumError = chromosomeError.Sum();
                populationError[i] = sumError;
                fitnessValue[i] = constantFitness / sumError;
            }

            sumatoryFitness = fitnessValue.Sum();

        }

       
    }
}