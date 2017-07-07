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
            double[] yVar = new double[] { 47.4750,   95.4750,  143.4750,  191.4750,  239.4750,  287.4750,  335.4750,  383.4750, 431.4750,  479.4750 };

                     
            GeneticAlgorithm GA = new GeneticAlgorithm(100, new double[,] { { 0, 20 }, { 5, 50 }, { -5, 20 }, { 0, 3.5 } }, xVar, yVar);

            GA.Run(300,0.9,0.01);
            
        }
    }

}
