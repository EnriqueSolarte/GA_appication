using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GA_application
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            double[] xVar = new double[] { 1, 2, 3, 4, 5 ,6, 7, 8, 9, 10};
            double[] yVar = new double[] {-11.8913,    3.0859,   11.2118, - 5.7323, - 9.3638,    8.7127,    7.9661, - 9.6261, - 4.0388,   12.5070};

                     
            GeneticAlgorithmKike GA = new GeneticAlgorithmKike(100, new double[,] { { 0, 15 }, { 5, 15 }, { 0, 1 } }, xVar, yVar);

            GA.Runkike(500,0.9,0.05);
            
            
        }
    }

}
