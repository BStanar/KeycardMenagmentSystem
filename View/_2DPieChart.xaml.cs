using KeycardManagementSystem.Model;
using KeycardMenagmentSystem.Model;
using KeycardMenagmentSystem.Services;
using KeycardMenagmentSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Converters;
using System.Windows.Shapes;

namespace KeycardMenagmentSystem.View
{
    public partial class _2DPieChart : UserControl
    {
        public _2DPieChart()
        {
            InitializeComponent();
            DrawPieChart();
        }

        private async void DrawPieChart()
        {
            float pieWidth = 200, pieHeight = 200, centerX = pieWidth / 2, centerY = pieHeight / 2, radius = pieWidth / 2;
            mainCanvas.Width = pieWidth;
            mainCanvas.Height = pieHeight;

            List<AccessLog> accessLogs =await new GetLogsService().GetAccesLogs();
            double successful = 0, failed = 0;

            foreach (AccessLog accessLog in accessLogs)
            {
                if (!accessLog.EventDate.Date.Equals(DateTime.Today)) accessLogs.Remove(accessLog);
                
            }

            foreach (AccessLog accessLog in accessLogs)
            {
                if (accessLog.Successful) successful++;
                else failed++;
            }

            System.Threading.Thread.Sleep(500);
            double a = (successful / (successful + failed)) * 100;
            double b = (failed / (successful + failed))*100;
            List<Category> Categories = new List<Category>()
            {
                new Category
                {
                    Title = "Successfull Card Scans",
                    Percentage = (int)a,
                    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4472C4")),
                },
                new Category
                {
                    Title = "Unsuccessfull Card Scans",
                    Percentage =100-(int)a,
                    ColorBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ED7D31")),
                },
            };
            detailsItemsControl.ItemsSource = Categories;

            // draw pie
            float angle = 0, prevAngle = 0;
            foreach (var category in Categories)
            {
                double line1X = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                double line1Y = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                angle = category.Percentage * (float)360 / 100 + prevAngle;
                Debug.WriteLine(angle);

                double arcX = (radius * Math.Cos(angle * Math.PI / 180)) + centerX;
                double arcY = (radius * Math.Sin(angle * Math.PI / 180)) + centerY;

                var line1Segment = new LineSegment(new Point(line1X, line1Y), false);
                double arcWidth = radius, arcHeight = radius;
                bool isLargeArc = category.Percentage > 50;
                var arcSegment = new ArcSegment()
                {
                    Size = new Size(arcWidth, arcHeight),
                    Point = new Point(arcX, arcY),
                    SweepDirection = SweepDirection.Clockwise,
                    IsLargeArc = isLargeArc,
                };
                var line2Segment = new LineSegment(new Point(centerX, centerY), false);

                var pathFigure = new PathFigure(
                    new Point(centerX, centerY),
                    new List<PathSegment>()
                    {
                        line1Segment,
                        arcSegment,
                        line2Segment,
                    },
                    true);

                var pathFigures = new List<PathFigure>() { pathFigure, };
                var pathGeometry = new PathGeometry(pathFigures);
                var path = new Path()
                {
                    Fill = category.ColorBrush,
                    Data = pathGeometry,
                };
                mainCanvas.Children.Add(path);

                prevAngle = angle;


                // draw outlines
                var outline1 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = line1Segment.Point.X,
                    Y2 = line1Segment.Point.Y,
                    Stroke = Brushes.White,
                    StrokeThickness = 5,
                };
                var outline2 = new Line()
                {
                    X1 = centerX,
                    Y1 = centerY,
                    X2 = arcSegment.Point.X,
                    Y2 = arcSegment.Point.Y,
                    Stroke = Brushes.White,
                    StrokeThickness = 5,
                };

                mainCanvas.Children.Add(outline1);
                mainCanvas.Children.Add(outline2);
            }
        }
    }

    public class Category
    {
        public float Percentage { get; set; }
        public string Title { get; set; }
        public Brush ColorBrush { get; set; }
    }
}