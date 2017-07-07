using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_application
{
    class Features
    {
        //public double[,] test { get; set; }
        public double populationSize { get; }
        public double numberFeatures { get; }

        public double[] bestFeature { get; set; }
        public double[,] population { get; set; }
    
        public double [,] rangeFeatures {get; }

        public Features(int _populationSize, double[,] _rangeFeatures)
        {
            rangeFeatures = _rangeFeatures;
            numberFeatures = _rangeFeatures.GetLength(0);
            bestFeature = new double[(int)numberFeatures+1];
            population = new double[_populationSize, (int)numberFeatures];
            populationSize = _populationSize;
            initializePopulation();
        }

        private void initializePopulation()
        {
            Random rnd = new Random();
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < numberFeatures; j++)
                {
                    population[i, j] = rangeFeatures[j, 0] + rnd.NextDouble() * (rangeFeatures[j, 1] - rangeFeatures[j, 0]);
                }
            }
            //test = population;
        }
    }
}
