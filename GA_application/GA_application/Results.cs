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

        private Function function;

        public Results(double[] _maxFitnessGA, double[] _meanFitnessGA, double[] _maxErrorGA, double[][] _bestFeaturesGA, double[,] _evaluationGA, double[] _rangeOfMeasurement)
        {
            maxFitnessGA = _maxFitnessGA;
            meanFitnessGA = _meanFitnessGA;
            maxErrorGA = _maxErrorGA;
            bestFeaturesGA = _bestFeaturesGA;
            evaluationGA = _evaluationGA;

            function = new Function(_rangeOfMeasurement);
        }

        public double[,] Evaluation(double[] _feature)
        {
            return function.Evaluation(_feature);
        }
    }
}

