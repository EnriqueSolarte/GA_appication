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
using LiveCharts;
using LiveCharts.Wpf;

namespace GA_application
{
  
    public partial class MainWindow : Window
    {
       GeneticAlgorithm GA_1 { get; set; }
        GeneticAlgorithm GA_2 { get; set; }

        public SeriesCollection functionGraph { get; set; }
        public string[] labelsFunction { get; set; }
        public Func<double, string> YFormatterFunction { get; set; }

        public SeriesCollection errorGraph { get; set; }
        public string[] labelsError { get; set; }
        public Func<double, string> YFormatterError { get; set; }

        public SeriesCollection fitnessGraph { get; set; }
        public string[] labelsFitness { get; set; }
        public Func<double, string> YFormatterFitness { get; set; }


        public SeriesCollection featuresGraph { get; set; }
        public string[] labelFeatures { get; set; }
        public Func<double, string> YFormatterFeatures { get; set; }





        public MainWindow()
        {
            InitializeComponent();
            Optimization();
            
            //Extract Data
            double[] ydata = GA_1.results.EvaluationJagged(GA_1.results.theBestFetureGA)[1];
            double[] xdata = GA_1.results.EvaluationJagged(GA_1.results.theBestFetureGA)[0];
            double[] feature = new double[] { 12, 12, 10.5, 0.01 };
            double[] ytarget = GA_1.results.EvaluationJagged(feature)[1];
            double[] yerror = GA_1.results.maxErrorGA;
            
            //Function graph variables
            ChartValues<double> data1 = new ChartValues<double>();
            ChartValues<double> data2 = new ChartValues<double>();
            string[] xdataString = new string[xdata.Length];

            data1.AddRange(ydata);
            data2.AddRange(ytarget);
            for(int i=0; i<ydata.Length;i++)
            {
                xdataString[i] = xdata[i].ToString();   
            }

            //Error and Feature graph variable
            ChartValues<double> data3 = new ChartValues<double>();
            ChartValues<double> data6 = new ChartValues<double>();
            ChartValues<double> data7 = new ChartValues<double>();
            ChartValues<double> data8 = new ChartValues<double>();
            ChartValues<double> data9 = new ChartValues<double>();
            string[] xdataString1 = new string[GA_1.results.generations];
            data3.AddRange(yerror);

            for (int i = 0; i < GA_1.results.generations; i++)
            {
                xdataString1[i] = i.ToString();
                //Features
                data6.Add(GA_1.results.bestFeaturesGA[i][0]);
                data7.Add(GA_1.results.bestFeaturesGA[i][1]);
                data8.Add(GA_1.results.bestFeaturesGA[i][2]);
                data9.Add(GA_1.results.bestFeaturesGA[i][3]);
            }

            //Fitness graph variables
            ChartValues<double> data4 = new ChartValues<double>();
            ChartValues<double> data5 = new ChartValues<double>();
            data4.AddRange(GA_1.results.maxFitnessGA);
            data5.AddRange(GA_1.results.meanFitnessGA);


            //Function graph
            functionGraph = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "GA result",
                    Values = data1
                },

                new LineSeries
                {
                    Title = "Target",
                    Values = data2
                }
            };

            labelsFunction = xdataString;
            YFormatterFunction = value => value.ToString();
            //DataContext = this;
            
            //Error graph
            errorGraph = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "GA error",
                    Values = data3
                }
            };

            labelsError = xdataString1;
            YFormatterError = value => value.ToString();

            //Features plot
            featuresGraph = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Feature One",
                    Values = data6
                },

                new LineSeries
                {
                    Title = "Feature Two",
                    Values = data7
                },

                new LineSeries
                {
                    Title = "Feature Three",
                    Values = data8
                },

                new LineSeries
                {
                    Title = "Feature For",
                    Values = data9
                }
            };

            labelFeatures = xdataString1;
            YFormatterFeatures = value => value.ToString();

            //Fitness graph
            fitnessGraph = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Maximun Fitness",
                    Values = data4
                },

                new LineSeries
                {
                    Title = "Mean Fitness",
                    Values = data5
                }
            };

            labelsFitness = xdataString1;
            YFormatterFitness = value => value.ToString();
            DataContext = this;
        }


        public void Optimization()
        {
            double[,] rangeFeatures = new double[,] { { 10, 15 }, { 10, 15 }, { 8, 15 }, { 0.005, 1 } };

            double[] rangeMeasurement = new double[100];

            double aux = 0;
            for(int i=0; i< rangeMeasurement.Length; i++)
            {
                rangeMeasurement[i] = aux + 0.1;
                aux = rangeMeasurement[i];
            }

            Function evalTarget = new Function(rangeMeasurement);
            double[,] result = evalTarget.Evaluation(new double[] { 12, 12, 10.5, 0.01 });

            ////Population, rangeFeatures, result, rangeMeasuremet
            //GA_1 = new GeneticAlgorithm(100, rangeFeatures, result, rangeMeasurement);
            ////Generation, Pcrossover, Pmutation
            //GA_1.Run(300, 0.9, 0.1);

            double[] xVar = rangeMeasurement;
            double[] yVar = new double[rangeMeasurement.Length];
            for (int i = 0; i < rangeMeasurement.Length; i++)
            {
                yVar[i] = result[i, 1];
            }

            GA_1 = new GeneticAlgorithm(1000, rangeFeatures, xVar, yVar);
            GA_1.Run(500, 0.9, 0.9);
        }
    }

}

