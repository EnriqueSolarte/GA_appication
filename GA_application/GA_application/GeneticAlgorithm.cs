using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_application
{
    class GeneticAlgorithm
    {
        public Features features { get; set; }
        public Fitness fitness { get; set; }

        public double pCrossover { get; set; }
        public double pMutation { get; set; }
        public double generationNumber{ get; set; }
        //range of mesurement for x axis
        public double[] rangeOfMeasurement { get; set; }
                
        public GeneticAlgorithm(int population, double[,] rangeOfFeatures, double[,] target, double[] _rangeOfMeasurement)
        {
            rangeOfMeasurement = _rangeOfMeasurement;
            features = new Features(population, rangeOfFeatures);
            fitness = new Fitness(300, target, rangeOfMeasurement);
        }
   
        private void RouletteWheelSelection()
        {
            Random rnd = new Random();
            double[,] selectedPopulation = new double[(int)features.populationSize,(int)features.numberFeatures];

            for(int i =0; i< features.populationSize; i++)
            {
                double test = rnd.NextDouble()*fitness.sumatoryFitness;
                double partSum = fitness.fitnessValue[0];
                int j = 0;
                while (partSum < test)
                {
                    partSum = partSum + fitness.fitnessValue[j + 1];
                    j++;
                    if (j == features.populationSize) j = 0;
                }
                for(int ii=0; ii< features.numberFeatures; ii++)
                {
                    selectedPopulation[i, ii] = features.population[j, ii];
                }
            }
            fitness.GetMaxFitness();
            if (features.bestFeature[0] < fitness.maxFitness)
            {
                for (int ii = 0; ii < features.numberFeatures; ii++)
                {
                    selectedPopulation[0, ii] = features.population[(int)fitness.maxFitnessIndex-1, ii];
                }
                //it is also necessary to save the best feature in the bestFeature variable.
                features.bestFeature[0] = fitness.maxFitness;
                for (int ii = 1; ii < features.bestFeature.Length; ii++)
                {
                    features.bestFeature[ii]= features.population[(int)fitness.maxFitnessIndex-1, ii-1];
                }
            }
            else
            {
                for (int ii = 0; ii < features.numberFeatures; ii++)
                {
                    selectedPopulation[0, ii] = features.bestFeature[ii+1];
                }
            }

            features.population = selectedPopulation;
        }

        private void Crossover()
        {
            Random rnd = new Random();
            
            for(int i=0; i<features.populationSize; i=i+2)
            {
                if(rnd.NextDouble() <= pCrossover)
                {
                    for(int j=0; j<features.numberFeatures;j++)
                    {
                        double aux = rnd.NextDouble();
                        features.population[i, j] = (1 - aux) * features.population[i, j] + aux * features.population[i + 1, j];
                        features.population[i + 1, j] = aux * features.population[i, j] + (1 - aux) * features.population[i + 1, j];
                    }
                }
            }
        }

        private void Mutation()
        {
            Random rnd = new Random();
            for (int i = 0; i < features.populationSize; i++)
            {
                if (rnd.NextDouble() <= pMutation)
                {
                    for (int j = 0; j < features.numberFeatures; j++)
                    {
                        features.population[i, j] = features.rangeFeatures[j,0] + rnd.NextDouble() * (features.rangeFeatures[j,1] - features.rangeFeatures[j,0]);
                    }
                }
            }
        }
 
        public void Run(int _generationNumber, double _pCrossover, double _pMutation)
        {
            generationNumber = _generationNumber;
            pCrossover = _pCrossover;
            pMutation = _pMutation;
            double[] maxFitnessRecord = new double[(int)generationNumber];

            fitness.Evaluation(features.population);
            for (int gen = 0; gen < _generationNumber; gen++)
            {
                RouletteWheelSelection();
                Crossover();
                Mutation();
                fitness.Evaluation(features.population);
                maxFitnessRecord[gen] = features.bestFeature[0];
            }
        }
    }
}
