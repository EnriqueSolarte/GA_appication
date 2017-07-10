using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_application
{
    class GeneticAlgorithmKike
    {
        
        private Features features { get; set; }
        private Fitness fitness { get; set; }

        private double pCrossover { get; set; }
        private double pMutation { get; set; }
        private double generationNumber{ get; set; }
     
        public double[] rangeOfMeasurement { get; set; }
                
        public GeneticAlgorithm(int population, double[,] rangeOfFeatures, double[,] target, double[] _rangeOfMeasurement)
        {
            rangeOfMeasurement = _rangeOfMeasurement;
            features = new Features(population, rangeOfFeatures);
            fitness = new Fitness(300, target, rangeOfMeasurement);
            public double[] maxfitnessGA { get; set; }
            public double[] meanfitnessGA { get; set; }

        }
      
       public GeneticAlgorithmKike(int populationSize, double[,] rangeOfFeatures, double[] xTarget, double[] yTarget)
        {
            // kike Constructor
            features = new Features(populationSize, rangeOfFeatures);
            fitness = new Fitness(50000, (int)features.populationSize, yTarget);

            fitness.function = new Function(xTarget);
        }

        private void RouletteWheelSelectionKike()
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

                   // if (j == features.populationSize-1) j = 0;
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

            double[,] selectedPopulation = features.population;
            for (int i=0; i<features.populationSize-1; i=i+2)
            {
                if(rnd.NextDouble() <= pCrossover)
                {
                    for(int j=0; j<features.numberFeatures;j++)
                    {
                        double aux = rnd.NextDouble();
                        features.population[i, j] = (1 - aux) * selectedPopulation[i, j] + aux * selectedPopulation[i + 1, j];
                        features.population[i + 1, j] = aux * selectedPopulation[i, j] + (1 - aux) * selectedPopulation[i + 1, j];
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
       
        public void Runkike(double generations, double _pCrossover, double _pMutation)
        {

            pCrossover = _pCrossover;
            pMutation = _pMutation;
            generationNumber = generations;

            maxfitnessGA = new double[(int)generationNumber];
            meanfitnessGA = new double[(int)generationNumber];

            fitness.Evaluationkike(features);
            for (int gen = 1; gen <= generationNumber; gen++)
            {
                RouletteWheelSelectionKike();
                Crossoverkike();
                Mutationkike();
                fitness.Evaluationkike(features);

                maxfitnessGA[gen-1] = features.bestFeature[0];
                meanfitnessGA[gen-1] = fitness.meanFitnesss;
            }


        }
    }
}
