﻿using System;

namespace GA_application
{
    public class Fitness
    {
        public double sumatoryFitness { get; }
        public double[] fitnessValue { get; }
        public int indexFitnessMaximo { get;}

        private double _constantFitness { set; get; }

        public Fitness(int constantFitness)
        {
            _constantFitness = constantFitness;
        } 

        public double[] Evaluation()
        {
            double[] _fitness = new double[3];
            return _fitness;
        }
    }
}