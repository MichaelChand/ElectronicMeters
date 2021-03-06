﻿using System;
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

namespace ElectronicMeters
{
    /// <summary>
    /// Interaction logic for Galvanometer.xaml
    /// </summary>
    public partial class Galvanometer : UserControl
    {
        public static readonly DependencyProperty DeltaValueDepedencyObject = DependencyProperty.Register("DeltaValue", typeof(double), typeof(Galvanometer), new PropertyMetadata((double)0.0, MeterUpdateCallback));
        public static readonly DependencyProperty MaxDepedencyObject = DependencyProperty.Register("Max", typeof(double), typeof(Galvanometer), new PropertyMetadata((double)0.0, RangeUpdateCallback));
        public static readonly DependencyProperty MinDepedencyObject = DependencyProperty.Register("Min", typeof(double), typeof(Galvanometer), new PropertyMetadata((double)0.0, RangeUpdateCallback));
        public static readonly DependencyProperty TitleDepedencyObject = DependencyProperty.Register("Title", typeof(string), typeof(Galvanometer), new PropertyMetadata("Meter Name", TitleUpdateCallback));
        public ActuatorModel ActuatorModel { get; set; }
        private ActuatorControl _actuatorControl;
        public FaceplateModel _faceplateModel { get; set; }
        private Faceplate _faceplate { get; set; }

        public double DeltaValue
        {
            get { return (double)GetValue(DeltaValueDepedencyObject); }
            set { SetValue(DeltaValueDepedencyObject, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleDepedencyObject); }
            set { SetValue(TitleDepedencyObject, value); }
        }

        public double Max
        {
            get { return (double)GetValue(MaxDepedencyObject); }
            set { SetValue(MaxDepedencyObject, value); }
        }

        public double Min
        {
            get { return (double)GetValue(MinDepedencyObject); }
            set { SetValue(MinDepedencyObject, value); }
        }

        public Galvanometer()
        {
            InstanceInitializations();
            InitializeComponent();
            _actuatorControl = new ActuatorControl(ActuatorModel);
        }

        private void InstanceInitializations()
        {
            ActuatorModel = new ActuatorModel();
            _faceplateModel = new FaceplateModel();
        }

        private void AddToMeterGrid(UIElement element)
        {
            MeterGrid.Children.Add(element);
        }

        public static void TitleUpdateCallback(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            (sender as Galvanometer)._faceplateModel.Title = (sender as Galvanometer).Title;
        }

        public static void RangeUpdateCallback(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            (sender as Galvanometer).RangeUpdate();
        }

        private void RangeUpdate()
        {
            ActuatorModel.Max = Max;
            ActuatorModel.Min = Min;
        }

        public static void MeterUpdateCallback(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            (sender as Galvanometer).Update();
        }

        private void Update()
        {
            if(_actuatorControl != null)
                _actuatorControl.Update(DeltaValue);
        }

        private void Galvanometer_Loaded(object sender, RoutedEventArgs e)
        {
            ZeroMeter();
            SetupFaceplate();
            DrawBackplate();
        }

        private void SetupFaceplate()
        {
            _faceplateModel.Height = 30;
            _faceplateModel.Width = 30;
            _faceplate = new Faceplate(_faceplateModel);
            _faceplate.SetMargin(0, ActuatorModel.Height - 20, 15);
        }

        private void ZeroMeter()
        {
            ActuatorModel.Width = this.ActualWidth;
            ActuatorModel.Height = this.ActualHeight;
            _actuatorControl = new ActuatorControl(ActuatorModel);
            _actuatorControl.Update(ActuatorModel.Min);
        }

        private void DrawBackplate()
        {
            IBackplate backplate = new BasicBackplate(ActuatorModel, AddToMeterGrid);
            backplate.GeneratePlate();
        }

        private void Galvanometer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ZeroMeter();
            SetupFaceplate();
            DrawBackplate();
        }
    }
}
