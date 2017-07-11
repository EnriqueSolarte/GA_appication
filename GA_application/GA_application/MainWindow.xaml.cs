using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace GA_application
{

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //Genetic algorithm object
        GeneticAlgorithm GA { get; set; }

        #region plotting data
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

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        
        //Main body
        public MainWindow()
        {
            InitializeComponent();
            
        }

        //AMin Functions
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        public Results Optimization(InputGraph _data)
        {
            //double[,] rangeFeatures = new double[,] { { 10, 15 }, { 10, 15 }, { 8, 15 }, { 0.005, 1 } };
            double[,] rangeFeatures = new double[,] { { _data.featureAMin, _data.featureAMax }, 
                                                      { _data.featureBMin, _data.featureBMax }, 
                                                      { _data.featureCMin, _data.featureCMax }, 
                                                      { _data.featureDMin, _data.featureDMax } };

            double[] rangeMeasurement = new double[100];

            double aux = 0;
            for (int i = 0; i < rangeMeasurement.Length; i++)
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

            //Population, rangeFeatures, xVat, YVar
            //GA_1 = new GeneticAlgorithm(1000, rangeFeatures, xVar, yVar);
            GA = new GeneticAlgorithm((int)_data.population, rangeFeatures, xVar, yVar);
            //Generation, Pcrossover, Pmutation
            //GA_1.Run(500, 0.9, 0.9);
            GA.Run(_data.generations, _data.crossoverProb, _data.mutationProb);

            return GA.results;
        }
        private InputGraph ReadData()
        {
            InputGraph _data = new InputGraph();

            double _generations, _population, _crossoverProb, _mutationProb;
            double _featureAMax, _featureBMax, _featureCMax, _featureDMax;
            double _featureAMin, _featureBMin, _featureCMin, _featureDMin;

            double.TryParse(this.TextBoxGeneration.Text, out _generations);
            _data.generations = _generations;

            double.TryParse(this.TextBoxPopulation.Text, out _population);
            _data.population = _population;

            double.TryParse(this.TextBoxCrossover.Text, out _crossoverProb);
            _data.crossoverProb = _crossoverProb;

            double.TryParse(this.TextBoxMutation.Text, out _mutationProb);
            _data.mutationProb = _mutationProb;

            double.TryParse(this.TextBoxAMin.Text, out _featureAMin);
            _data.featureAMin = _featureAMin;

            double.TryParse(this.TextBoxAMax.Text, out _featureAMax);
            _data.featureAMax = _featureAMax;

            double.TryParse(this.TextBoxBMin.Text, out _featureBMin);
            _data.featureBMin = _featureBMin;

            double.TryParse(this.TextBoxBMax.Text, out _featureBMax);
            _data.featureBMax = _featureBMax;

            double.TryParse(this.TextBoxCMin.Text, out _featureCMin);
            _data.featureCMin = _featureCMin;

            double.TryParse(this.TextBoxCMax.Text, out _featureCMax);
            _data.featureCMax = _featureCMax;

            double.TryParse(this.TextBoxDMin.Text, out _featureDMin);
            _data.featureDMin = _featureDMin;

            double.TryParse(this.TextBoxDMax.Text, out _featureDMax);
            _data.featureDMax = _featureDMax;

            return _data;
        }
        public void DrawGraph()
        {
            
        //Extract Data
            double[] ydata = GA.results.EvaluationJagged(GA.results.theBestFetureGA)[1];
            double[] xdata = GA.results.EvaluationJagged(GA.results.theBestFetureGA)[0];
            double[] feature = new double[] { 12, 12, 10.5, 0.01 };
            double[] ytarget = GA.results.EvaluationJagged(feature)[1];
            double[] yerror = GA.results.maxErrorGA;

            //Function graph variables
            ChartValues<double> data1 = new ChartValues<double>();
            ChartValues<double> data2 = new ChartValues<double>();
            string[] xdataString = new string[xdata.Length];

            data1.AddRange(ydata);
            data2.AddRange(ytarget);
            for (int i = 0; i < ydata.Length; i++)
            {
                xdataString[i] = xdata[i].ToString();
            }

            //Error and Feature graph variable
            ChartValues<double> data3 = new ChartValues<double>();
            ChartValues<double> data6 = new ChartValues<double>();
            ChartValues<double> data7 = new ChartValues<double>();
            ChartValues<double> data8 = new ChartValues<double>();
            ChartValues<double> data9 = new ChartValues<double>();
            string[] xdataString1 = new string[GA.results.generations];
            data3.AddRange(yerror);

            for (int i = 0; i < GA.results.generations; i++)
            {
                xdataString1[i] = i.ToString();
                //Features
                data6.Add(GA.results.bestFeaturesGA[i][0]);
                data7.Add(GA.results.bestFeaturesGA[i][1]);
                data8.Add(GA.results.bestFeaturesGA[i][2]);
                data9.Add(GA.results.bestFeaturesGA[i][3]);
            }

            //Fitness graph variables
            ChartValues<double> data4 = new ChartValues<double>();
            ChartValues<double> data5 = new ChartValues<double>();
            data4.AddRange(GA.results.maxFitnessGA);
            data5.AddRange(GA.results.meanFitnessGA);

            //Function graph
            functionGraph = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "GA result",
                    Values = data1,
                    PointGeometry = DefaultGeometries.Cross,
                    PointGeometrySize = 5
                },

                new LineSeries
                {
                    Title = "Target",
                    Values = data2,
                    PointGeometrySize = 5
                }
            };

            labelsFunction = xdataString;
            YFormatterFunction = value => value.ToString();
            OnPropertyChanged("functionGraph");
            OnPropertyChanged("labelsFunction");
            OnPropertyChanged("YFormatterFunction");

            //Error graph
            errorGraph = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "GA error",
                    Values = data3,
                    PointGeometry = null
                }
            };

            labelsError = xdataString1;
            YFormatterError = value => value.ToString();
            OnPropertyChanged("errorGraph");
            OnPropertyChanged("labelsError");
            OnPropertyChanged("YFormatterError");

            //Features plot

            featuresGraph = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Feature One",
                    Values = data6,
                    PointGeometry = null
                },

                new LineSeries
                {
                    Title = "Feature Two",
                    Values = data7,
                    PointGeometry = null
                },

                new LineSeries
                {
                    Title = "Feature Three",
                    Values = data8,
                    PointGeometry = null
                },

                new LineSeries
                {
                    Title = "Feature Four",
                    Values = data9,
                    PointGeometry = null
                }


            };

            labelFeatures = xdataString1;
            YFormatterFeatures = value => value.ToString();
            OnPropertyChanged("featuresGraph");
            OnPropertyChanged("labelFeatures");
            OnPropertyChanged("YFormatterFeatures");

            //Fitness graph
            fitnessGraph = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Maximun Fitness",
                    Values = data4,
                    PointGeometry = null
                },

                new LineSeries
                {
                    Title = "Mean Fitness",
                    Values = data5,
                    PointGeometry = null
                }
            };

            labelsFitness = xdataString1;
            YFormatterFitness = value => value.ToString();
            OnPropertyChanged("fitnessGraph");
            OnPropertyChanged("labelsFitness");
            OnPropertyChanged("YFormatterFitness");

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputGraph data = new InputGraph();
            data = ReadData();
            Optimization(data);
            DrawGraph();
        }

    }
}




