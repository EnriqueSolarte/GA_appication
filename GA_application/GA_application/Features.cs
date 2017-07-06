using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_application
{
    class Features
    {
     
        public double populationSize { get;}
        public double numberFeatures { get; }

        public double[,] population { get; }
        public double[,] selectedPopulation { get; set; }
        public double[] maxInPopulation { get; }
        public double [,] rangeFeatures { set; get; }

        public Features(int _populationSize, int _numberFeatures)
        {
            population = new double[_numberFeatures, _populationSize];
            selectedPopulation = new double[_numberFeatures, _populationSize];
            maxInPopulation = new double[_numberFeatures];
            rangeFeatures = new double[_numberFeatures, 2];


        }

        private void initializePopulation()
        {

        }

        internal void UploadPopulation()
        {
            throw new NotImplementedException();
        }
    }
}
