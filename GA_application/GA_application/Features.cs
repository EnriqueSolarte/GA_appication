using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_application
{
    class Features
    {
     
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

            initializePopulation();
        }

        private void initializePopulation()
        {
            Random rnd = new Random();
            for (int i = 0; i < numberFeatures; i++)
                for (int j = 0; j < populationSize; j++)
                    population[i, j] = rangeFeatures[1,j]+rnd.NextDouble()*(rangeFeatures[2,j]-rangeFeatures[1,j]);
        }
    }
}
