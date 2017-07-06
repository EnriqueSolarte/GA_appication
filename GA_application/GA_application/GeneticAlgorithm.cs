﻿using System;
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
        public double numberGenerations { get; set; }


        
        public GeneticAlgorithm()
        {
           
        }

        private double[] EvaluationFitness()
        {
            throw new NotImplementedException();
        }

        private void RouletteWheelSelection()
        {
            Random rand = new Random();
            for (int i = 0; i < features.populationSize; i++)
            {
                double test = rand.NextDouble() * fitness.sumatoryFitness;
                double partSum = fitness.fitnessValue[0];
                int j = 1;
                while (partSum < test)
                {
                    partSum = partSum + fitness.fitnessValue[j + 1];
                    j++;
                    if (j == features.populationSize)
                    {
                        j = 0;
                    }
                }
                features.selectedPopulation[i] = features.population[j];

                features.selectedPopulation[0] = features.maxInPopulation;
                features.UploadPopulation();   
            }
        }

        private void Crossover()
        {

        }

        private void Mutation()
        {

        }

        private void Run()
        {

        }


    }
}
