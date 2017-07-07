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
            double[] xVar = new double[] { 1, 2, 3, 4, 5 ,6, 7, 8, 9, 10};
            double[] yVar = new double[] { 47.5 ,  167.5,    359.5,     623.5,    959.5,    1367.5,    1847.5,    2399,5, 3023.5,    3719.5 };

                     
            GeneticAlgorithm GA = new GeneticAlgorithm(50, new double[,] { { 0, 20 }, { 5, 50 }, { -5, 20 }, { 0, 3.5 } }, xVar, yVar);

            GA.Run(500,0.9,0.05);
            
            
        }
    }

}
