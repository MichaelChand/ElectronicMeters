using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ElectronicMeters
{     
    public class ActuatorModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public readonly double FSD = 90;
        public readonly double ZSD = 180 - 45;

        private double _x1;
        private double _y1;
        private double _x2;
        private double _y2;
        private double _width;
        private double _height;

        public double X1
        {
            get { return _x1; }
            set
            {
                _x1 = value;
                OnPropertyChanged("X1");
            }
        }

        public double Y1
        {
            get { return _y1; }
            set
            {
                _y1 = value;
                OnPropertyChanged("Y1");
            }
        }

        public double X2
        {
            get { return _x2; }
            set
            {
                _x2 = value;
                OnPropertyChanged("X2");
            }
        }

        public double Y2
        {
            get { return _y2; }
            set
            {
                _y2 = value;
                OnPropertyChanged("Y2");
            }
        }

        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged("Width");
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged("Height");
            }
        }
        public double Max { get; set; }
        public double Min { get; set; }
        public double Radius { get; set; }
        public double Granularity { get; set; }
        public double Range { get; set; }
        public double DeltaValue { get; set; }
        public double DeltaAngle { get; set; }
        public double Center { get; set; }

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
