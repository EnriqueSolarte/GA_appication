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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            double[,] rangeFeatures = new double[,] { { 0, 20 }, { 5, 50 }, { -5, 20 }, { 0, 3.5} };
            double[] rangeMeasurement = new double[] { 1, 2, 3, 4, 5};

            Function evalTarget = new Function(rangeMeasurement);
            double[,] result = evalTarget.Evaluation(new double[] { 12, 12, 10.5, 0.01 });

            //Population, rangeFeatures, result, rangeMeasuremet
            GeneticAlgorithm GA = new GeneticAlgorithm(1000, rangeFeatures, result, rangeMeasurement);
            //Generation, Pcrossover, Pmutation
            GA.Run(50,0.9,0.01);
        }
    }

}
