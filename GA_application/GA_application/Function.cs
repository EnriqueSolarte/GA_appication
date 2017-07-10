using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_application
{
    public class Function
    {

        public double[,] DependentVariables { get; set; }
        public double[] IndependentVariable { get; set; }
      
        public double[] features;
        private double[] xVar;
        private double[] yVar;
    
        public Function(double[] _xVar)
        {

            DependentVariables = new double[_xVar.Length,2];
          
            xVar = new double[_xVar.Length];
            yVar = new double[_xVar.Length];

            xVar = _xVar;                       
        }

      
        public double[,] Evaluation(double[] _feature)
        {
            

            for (int i = 0;i<xVar.Length;i++)
            {
                DependentVariables[i, 0] = xVar[i];
                DependentVariables[i, 1] = _feature[0] * xVar[i]+3* _feature[1]* xVar[i]* xVar[i] - 5* _feature[2]*_feature[3];
            }
            
            return DependentVariables;
        }

       
    }
}
