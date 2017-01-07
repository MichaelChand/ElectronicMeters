using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ElectronicMeters
{
    public class BasicBackplate : IBackplate
    {
        private ActuatorModel _actuatorModel;
        private Action<Line> _callback;

        public BasicBackplate(ActuatorModel actuatorModel, Action<Line> callback)
        {
            _actuatorModel = actuatorModel;
            _callback = callback;
        }

        public virtual void GenerateArc()
        {
            Draw(DrawArcLine, 1);
        }

        private void Draw(Action<Line, int, double> drawAction, int startIndex)
        {
            double granularity = _actuatorModel.FSD / 10.0f;
            for (int i = startIndex; i < 11; i++)
            {
                Line arcLine = new Line();
                drawAction(arcLine, i, granularity);

                _callback.Invoke(arcLine);
            }
        }

        protected virtual void DrawArcLine(Line arcLine, int position, double granularity)
        {
            arcLine.X1 = _actuatorModel.Center + GetXFromDeg(_actuatorModel.ZSD - ((position - 1) * granularity), _actuatorModel.Radius - 15);
            arcLine.Y1 = (_actuatorModel.Height - 20) -  GetYFromDeg(_actuatorModel.ZSD - ((position - 1) * granularity), _actuatorModel.Radius - 15);
            arcLine.X2 = _actuatorModel.Center + GetXFromDeg(_actuatorModel.ZSD - ((position) * granularity), _actuatorModel.Radius - 15);
            arcLine.Y2 = (_actuatorModel.Height - 20) - GetYFromDeg(_actuatorModel.ZSD - ((position) * granularity), _actuatorModel.Radius - 15);
            arcLine.Stroke = new SolidColorBrush(Colors.Black);
        }

        public virtual void GenerateMarking()
        {
            Draw(DrawMark, 0);
        }

        protected virtual void DrawMark(Line arcLine, int position, double granularity)
        {
            arcLine.X1 = _actuatorModel.Center + GetXFromDeg(_actuatorModel.ZSD - (position * granularity), _actuatorModel.Radius - 10);
            arcLine.Y1 = (_actuatorModel.Height - 20) - GetYFromDeg(_actuatorModel.ZSD - (position * granularity), _actuatorModel.Radius - 10);
            arcLine.X2 = _actuatorModel.Center + GetXFromDeg(_actuatorModel.ZSD - (position * granularity), _actuatorModel.Radius - 15);
            arcLine.Y2 = (_actuatorModel.Height - 20) - GetYFromDeg(_actuatorModel.ZSD - (position * granularity), _actuatorModel.Radius - 15);
            arcLine.Stroke = new SolidColorBrush(Colors.Black);
        }

        public virtual void GeneratePlate()
        {
            GenerateArc();
            GenerateMarking();
        }

        protected double GetXFromDeg(double deg, double radius)
        {
            return (float)radius * Math.Cos(DegreesToRadians(deg));
        }

        protected double GetYFromDeg(double deg, double radius)
        {
            return (float)radius * Math.Sin(DegreesToRadians(deg));
        }

        protected double DegreesToRadians(double degrees)
        {
            return (float)degrees * ((float)Math.PI / 180.0f);
        }
    }
}
