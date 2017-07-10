using System;
using System.Linq;
namespace GA_application
{
    public class Fitness
    {

        public Function function;
        private double[] targetFucntion;
        private double[] populationError;
        double[] chromosomeError;

        public double sumatoryFitness { get; set; }

        public double[] fitnessValue { get; set; }
        public double maximoFitness { get; set; }
        public double indexMaximoFitness { get; set; }
        public double meanFitnesss { get; set; }
        public double[] errorValue { get; set; }

        private double constantFitness { set; get; }

        public double[,] target { set; get; }


        //public Fitness(int _constantFitness, double[,] _target)
        //{
        //    constantFitness = _constantFitness;
        //    target = _target;
        //    function = new Function();
        //}

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

            maximoFitness = value;
            indexMaximoFitness = index;

            double[] result = new double[2] { value, index};
            return result;
        }

        public void Evaluation(Features _features)
        {
            
            populationError = new double[_features.population.GetLength(0)];
            fitnessValue = new double[_features.population.GetLength(0)];
            for (int i =0; i< _features.population.GetLength(0); i++ )
            {

                double[] currentFeature = new double[_features.population.GetLength(1)];
                for(int j=0; j < _features.population.GetLength(1); j++)
                {
                    currentFeature[j] = _features.population[i, j];
                }
                
                double[] result = function.EvaluationJagged(currentFeature);

                for (int j = 0; j < result.Length; j++)
                {
                    chromosomeError[j] = Math.Abs(targetFucntion[j] - result[j]);
                }

                double sumError = chromosomeError.Sum();
                populationError[i] = sumError;
                fitnessValue[i] = constantFitness / sumError;
                
            }

            maximoFitness = GetMaxFitness()[0];
            indexMaximoFitness = GetMaxFitness()[1];
            meanFitnesss = fitnessValue.Sum() / fitnessValue.Length;
            sumatoryFitness = fitnessValue.Sum();
        }

       
    }
}