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
        private double[] xVar;
        private double[] yVar;

        public Function(double[] _xVar)
        {

            xVar = new double[_xVar.Length];
            yVar = new double[_xVar.Length];

            xVar = _xVar;                       
        }

        public double[] Evaluationkike(double[] _feature)
        {
            features = _feature;

            for (int i = 0; i < xVar.GetLength(0); i++)
            {
               yVar[i] =  _feature[1]*Math.Sin(xVar[i] *3* _feature[0]) +  xVar[i] * xVar[i] * _feature[2];
            }

           return yVar;
        }

       
    }
}
