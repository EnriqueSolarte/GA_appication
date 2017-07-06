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
    
        public GeneticAlgorithm(int population, double[,] rangeOfFeatures)
        {
            features = new Features(population, rangeOfFeatures);
        }
   
        private void RouletteWheelSelection()
        {
            Random rnd = new Random();
            double[,] selectedPopulation = new double[(int)features.populationSize,(int)features.numberFeatures];

            for(int i =0; i< features.populationSize; i++)
            {
                double test = rnd.NextDouble()*fitness.sumatoryFitness;
                double partSum = fitness.fitnessValue[0];
                int j = 1;
                while (partSum < test)
                {
                    partSum = partSum + fitness.fitnessValue[j + 1];
                    j++;
                    if (j == features.populationSize) j = 1;
                }
                for(int ii=0; ii< features.numberFeatures; ii++)
                {
                    selectedPopulation[i, ii] = features.population[j, ii];
                }
            }
            for (int ii = 0; ii < features.numberFeatures; ii++)
            {
                selectedPopulation[1, ii] = features.population[fitness.indexFitnessMaximo, ii];
            }
         
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
            for (int i=0; i< features.populationSize; i++)
            {
                if(rnd.NextDouble() < pMutation)
                {
                    for (int j=0; j< features.numberFeatures; j++)
                    {
                        features.population[i, j] = features.rangeFeatures[1, j] + rnd.NextDouble() * (features.rangeFeatures[2,j] - features.rangeFeatures[1,j]);
                    }
                }
            }
        }

        public void Run()
        {
            
        }


    }
}
