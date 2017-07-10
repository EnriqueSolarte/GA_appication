using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_application
{
    public class Results
    {
        public double[] maxFitnessGA { get; }
        public double[] meanFitnessGA { get; }
        public double[] maxErrorGA { get; }
        public double[][] bestFeaturesGA { get; }
        public double[,] evaluationGA { get; }
        public double[] theBestFetureGA { get; set; }

        public int generations { get; }

        private Function function;

        public Results(double[] _maxFitnessGA, double[] _meanFitnessGA, double[] _maxErrorGA, double[][] _bestFeaturesGA, double[,] _evaluationGA, double[] _rangeOfMeasurement)
        {
            maxFitnessGA = _maxFitnessGA;
            meanFitnessGA = _meanFitnessGA;
            maxErrorGA = _maxErrorGA;
            bestFeaturesGA = _bestFeaturesGA;
            evaluationGA = _evaluationGA;

            generations = _bestFeaturesGA[0].Length;
            theBestFetureGA = _bestFeaturesGA[_bestFeaturesGA[0].Length];
            function = new Function(_rangeOfMeasurement);
        }

        public double[,] Evaluation(double[] _feature)
        {
            return function.Evaluation(_feature);
        }

        public double[][] EvaluationJagged(double[] _feature)
        {

            double[,] data = function.Evaluation(_feature);

            double[] xVar=new double[data.GetLength(0)];
            double[] yVar = new double[data.GetLength(0)];

            for (int i = 0; i < data.GetLength(0); i++)
            {
                xVar[i] = data[i, 0];
                yVar[i] = data[i, 1];
            }

            double[][] dataJageed = new double[2][] {xVar , yVar };

            return dataJageed;
        }


    }
}

