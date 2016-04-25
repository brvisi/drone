using System;
using System.Windows.Forms;
using System.Timers;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

using Timer = System.Timers.Timer;

namespace IMU_module
{
    public partial class graph : Form
    {

        private readonly Timer _dataTimer;
        private double _currentX;
        private LineSeries _series1;
        private LineSeries _series2;
        private LineSeries _series3;

        private LinearAxis xAxis;
        private LinearAxis yAxis;

        private float[] euler_angles_raw = new float[3]; //yaw/pitch/roll - através dos índices

        public float[] euler_angles
        {
            get { return euler_angles_raw; }
            set { euler_angles_raw = value; }
        }



        public graph()
        {
            InitializeComponent();
            InitializeChart();


            _currentX = 0.05;
            _dataTimer = new Timer { Interval = 20 };
            _dataTimer.Elapsed += AddNewData;




            _dataTimer.Start();
        }

        private void AddNewData(object sender, ElapsedEventArgs args)
        {
            _series1.Points.Add(new DataPoint(_currentX, euler_angles[0]));
            _series2.Points.Add(new DataPoint(_currentX, euler_angles[1]));
            _series3.Points.Add(new DataPoint(_currentX, euler_angles[2]));

           xAxis.Pan(xAxis.Transform(-0.05 + xAxis.Offset));

            _currentX += 0.05;
            
            uiMainPlot.InvalidatePlot(true);

            //if (_currentX == 20)
            //    _dataTimer.Stop();
        }

        private void InitializeChart()
        {
            var model = new PlotModel
            {
                DefaultColors = OxyPalettes.HueDistinct(4).Colors,
                LegendBackground = OxyColor.FromAColor(140, OxyColors.WhiteSmoke),
                LegendBorder = OxyColors.Black,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendPlacement = LegendPlacement.Inside,
                LegendPosition = LegendPosition.BottomLeft,
                Title = "Real Time (Matriz de Rotação para Euler Angles)"
            };

            
            xAxis = new LinearAxis
            {
                Key = "xAxis",
                Position = AxisPosition.Bottom,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dash,
                Title = "Time",
            };
            model.Axes.Add(xAxis);

            yAxis = new LinearAxis
            {
                Key = "yAxis1",
                Position = AxisPosition.Left,
                PositionTier = 0,
                Minimum = -250,
                Maximum = 250,
                Title = "Graus º"
            };
            model.Axes.Add(yAxis);

            _series1 = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                StrokeThickness = 1,
                Tag = "pitch",
                Title = "pitch",
                YAxisKey = "yAxis1"
            };
            model.Series.Add(_series1);

            _series2 = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                StrokeThickness = 1,
                Tag = "roll",
                Title = "roll",
                YAxisKey = "yAxis1"
            };
            model.Series.Add(_series2);

            _series3 = new LineSeries
            {
                LineStyle = LineStyle.Solid,
                StrokeThickness = 1,
                Tag = "yaw",
                Title = "yaw",
                YAxisKey = "yAxis1"
            };
            model.Series.Add(_series3);

            uiMainPlot.Model = model;


        }
    }
}

