using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_application
{
    public class Function
    {
        public double[] features;
        private double[] xVariables;
        private double[] yVariables;

        public Function(double[] _xVar)
        {

            xVariables = new double[_xVar.Length];
            yVariables = new double[_xVar.Length];

            xVariables = _xVar;                       
        }

        public Function()
        {

        }

        public double[] EvaluationJagged(double[] _feature)
        {
            features = _feature;

            for (int i = 0; i < xVariables.GetLength(0); i++)
            {
               yVariables[i] =  _feature[0]*xVariables[i] + 3* _feature[1] * xVariables[i] * xVariables[i] - 5* _feature[2]*_feature[3];
            }

           return yVariables;
        }

        public double[,] Evaluation(double[] feature)
        {
            return new double[1, 1];
        }
    }
}
