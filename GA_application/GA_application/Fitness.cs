using System;
using System.Linq;
namespace GA_application
{
    public class Fitness
    {

        public  Function function;
        private double[] yTarget;
        private double[] populationError;
        private double[] chromosomeError;

        private double sumatoryFitness { get; set; }

        private double[] fitnessValue { get; set; }
      
        public double meanFitnesss { get; set; }

        public double constantFitness { set; get; }

        public double[,] target { set; get; }

        public double maxFitness { set; get; }
        public double maxFitnessIndex { set; get;}

  
        public Fitness(int _constantFitness, double[,] _target, double[] _x)
        {
            //Second contructor
            constantFitness = _constantFitness;
            target = _target;
            function = new Function(_x);
            chromosomeError = new double[_target.GetLength(0)];
        }
        

        public Fitness(int _constantFitness, int _populationSize, double[] _yTargetFunction)
        {
            //Kike constructor
            yTarget = _yTargetFunction;
            constantFitness = _constantFitness;
            chromosomeError = new double[_yTargetFunction.Length];

        }

        
        public double[] GetMaxFitness()
        {
            
            maxFitness = fitnessValue.Max();
            maxFitnessIndex = fitnessValue.ToList().IndexOf(maxFitness);

            double[] result = new double[2] { maxFitness, maxFitnessIndex};
            return result;

        }

        public void Evaluation(double[,] population)
        {         
            populationError = new double[population.GetLength(0)];
            fitnessValue = new double[population.GetLength(0)];
            for (int i =0; i< population.GetLength(0); i++ )
            {

                double[] currentFeature = new double[population.GetLength(1)];
                // currentFeature: Get the current set of features into the population
                for(int j=0; j < population.GetLength(1); j++)

                {
                    currentFeature[j] = population[i, j];
                }
                
                //Evaluation of the current feature
                double[,] result = function.Evaluation(currentFeature);

            
                for (int j = 0; j < result.GetLength(0); j++)
                {
                    if (target != null)
                    {
                        chromosomeError[j] = Math.Abs(target[j, 1] - result[j, 1]);
                    }
                    else
                    {
                        chromosomeError[j] = Math.Abs(yTarget[j] - result[j, 1]);
                    }

                                         
                }


                double sumError = chromosomeError.Sum();
                populationError[i] = sumError; // gotten Error for each feature
                fitnessValue[i] = constantFitness / sumError; // fitness to current feature
                
            }

            maxFitness = GetMaxFitness()[0];
            maxFitnessIndex = GetMaxFitness()[1];
            meanFitnesss = fitnessValue.Sum() / fitnessValue.Length;
            sumatoryFitness = fitnessValue.Sum();
        }
      

    }
}