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
      
        public double meanFitnesss { get; set; }
        public double[] errorValue { get; set; }

        private double constantFitness { set; get; }

        public double[,] target { set; get; }

        public double maxFitness { set; get; }
        public double maxFitnessIndex { set; get;}

  
        public Fitness(int _constantFitness, double[,] _target, double[] _x)
        {
            //Second contructor
            constantFitness = _constantFitness;
            target = _target;
            function = new Function(_x);
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
            
            maxFitness = fitnessValue.Max();
            maxFitnessIndex = fitnessValue.ToList().IndexOf(maxFitness);

            double[] result = new double[2] { maxFitness, maxFitnessIndex};
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
                
                double[] result = function.SimpleEvaluation(currentFeature);


                for (int j = 0; j < result.Length; j++)
                {
                    chromosomeError[j] = Math.Abs(targetFucntion[j] - result[j]);
                }


                double sumError = chromosomeError.Sum();
                populationError[i] = sumError;
                fitnessValue[i] = constantFitness / sumError;
                
            }

            maxFitness = GetMaxFitness()[0];
            maxFitnessIndex = GetMaxFitness()[1];
            meanFitnesss = fitnessValue.Sum() / fitnessValue.Length;
            sumatoryFitness = fitnessValue.Sum();
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
                    error[j] = Math.Abs(target[j,1] - result[j,1]);
                }
                double sumError = error.Sum();

                fitnessValue[i] = constantFitness / sumError;
                
            }
            sumatoryFitness = fitnessValue.Sum();
        }
    }
}