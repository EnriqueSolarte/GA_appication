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
            int population = 100;
            double[,] rangeFeatures = new double[,] { {20,50}, {0, 0.1 }, {0,20.5} };
            GeneticAlgorithm GA = new GeneticAlgorithm(population,rangeFeatures);


            GA.Run();
            
        }
    }

}
