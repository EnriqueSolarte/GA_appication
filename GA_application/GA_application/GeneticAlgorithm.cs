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
        public double pCrossover { get; set; }
        public double pMutation { get; set; }
        public double population { get; set; }
        public double numberGenerations { get; set; }
        
        private double[] fitness { get; }

        public GeneticAlgorithm()
        {

        }

        private void RouletteWheelSelection()
        {

        }

        private void Crossover()
        {

        }

        private void Mutation()
        {

        }

    }
}
