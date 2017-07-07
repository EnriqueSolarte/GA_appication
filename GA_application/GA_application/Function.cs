using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_application
{
    class Function
    {
        public double[,] DependentVariables { get; set; }
        public double[] IndependentVariable { get; set; }

        public Function(double[] _x)
        {
            //_xLength is the length of the dependent data (provided). It is double vector that
            //keeps the x axis data.
            DependentVariables = new double[_x.Length,2];
            IndependentVariable = _x;
        }

        public double[,] Evaluation(double[] feature)
        {
            //y=a*x Assuming a random function where y = DependantVariable, x = IndependantVariable and 
            //a = feature
            double[] y = new double[IndependentVariable.Length];

            for (int i = 0;i<IndependentVariable.Length;i++)
            {
                DependentVariables[i, 0] = IndependentVariable[i];
                DependentVariables[i, 1] = feature[0] * IndependentVariable[i]+3*feature[1]* IndependentVariable[i]* IndependentVariable[i] - 5*feature[2]*feature[3];
            }
            
            return DependentVariables;
        }
    }
}
