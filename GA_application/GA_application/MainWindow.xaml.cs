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
            double[] yVar = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Function target = new Function(xVar, yVar);
            Function function = new  Function(xVar, yVar);

            //double[][] result1 = function.EvaluationJagged(new double[] { 12, 12, 10.5 ,0.01});
            //double[][] result2 = function.EvaluationJagged(new double[] { 30, 0.5, 12.5, 1.5 });


        }
    }

}
