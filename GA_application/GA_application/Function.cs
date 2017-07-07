using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_application
{
    public class Function
    {
        public double[][] dependentVariable;
        public double[] IndependentVariable;
        private double[] xVariables;
        private double[] yVariables;

        public Function(double[] _xVar)
        {

            xVariables = new double[_xVar.Length];
            yVariables = new double[_xVar.Length];

            xVariables = _xVar;
               
            dependentVariable = new double[][] { xVariables, yVariables };
                       
        }

        public Function()
        {

        }

        public double[][] EvaluationJagged(double[] feature)
        {
            IndependentVariable = feature;

            for (int i = 0; i < xVariables.GetLength(0); i++)
            {
               yVariables[i] =  feature[0]*xVariables[i] + 3* feature[1] * xVariables[i] - 5* feature[2]*feature[3];
            }

            dependentVariable[0] = new double[xVariables.GetLength(0)];
            dependentVariable[0] = xVariables ;
            dependentVariable[1] = new double[yVariables.GetLength(0)];
            dependentVariable[1] = yVariables;

            return dependentVariable;
        }

        public double[,] Evaluation(double[] feature)
        {
            return new double[1, 1];
        }
    }
}
