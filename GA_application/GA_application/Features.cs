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

        public double[,] population { get; }
        public double[,] selectedPopulation { get; set; }
        public double[] maxInPopulation { get; }
        public double [,] rangeFeatures { set; get; }

        public Features(int _populationSize, int _numberFeatures)
        {
            population = new double[_populationSize, _numberFeatures];
            selectedPopulation = new double[_populationSize,_numberFeatures];
            maxInPopulation = new double[_numberFeatures];
            rangeFeatures = new double[2,_numberFeatures];


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
