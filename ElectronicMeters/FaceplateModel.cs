using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace ElectronicMeters
{
    public class FaceplateModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Thickness _thickness = new Thickness(0, 85, 0, 0);
        private double _width = 30;
        private double _height = 30;

        public Thickness Margin
        {
            get { return _thickness; }
            set
            {
                _thickness = value;
                OnPropertyChanged("MarginSetup");
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

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
