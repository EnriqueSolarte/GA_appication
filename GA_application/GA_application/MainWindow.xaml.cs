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

            //This code test the function evaluation method.
            //double[] rangeOfMeasurement = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            //Function evalTarget = new Function(rangeOfMeasurement);
            //Function evalTarget1 = new Function(rangeOfMeasurement);
            //double[,] result = evalTarget.Evaluation(new double[] {45, 20, 0.1 });
            //double[,] result1 = evalTarget1.Evaluation(new double[] { 10, 0.2, 27 });

            double[] x = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            double[] y = new double[] { 1, 4, 9, 16, 25, 36, 49, 64, 81, 100 };
            double[] input = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            double[,] rangefeatures = new double[,] { { 0, 20 }, { 5, 50 }, { -5, 20 }, { 0, 3.5} };
            //double[,] target = new double[,] { { 1, 1 }, { 2, 4 }, { 3, 9 }, { 4, 16 } , { 5, 25 } };
            double[] rangeOfMeasurement = new double[] { 1, 2, 3, 4, 5};

            Function evalTarget = new Function(rangeOfMeasurement);
            double[,] result = evalTarget.Evaluation(new double[] { 12, 12, 10.5, 0.01 });

            GeneticAlgorithm GA = new GeneticAlgorithm(1000, rangefeatures, result, rangeOfMeasurement);

            GA.Run(50,0.9,0.01);
            

        }
    }

}
