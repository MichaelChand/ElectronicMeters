using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicMeters
{
    public class ActuatorControl
    {
        private ActuatorModel _actuatorModel { get; set; }

        public ActuatorControl(ActuatorModel actuatorModel)
        {
            _actuatorModel = actuatorModel;
            Setup();
        }

        private void Setup()
        {
            _actuatorModel.Radius = (_actuatorModel.Height - 20) - GetPercentageOfValue(_actuatorModel.Height - 20, 10);
            _actuatorModel.Range = _actuatorModel.Max - _actuatorModel.Min;
            _actuatorModel.Granularity = _actuatorModel.FSD / _actuatorModel.Range;
            _actuatorModel.Center = _actuatorModel.Width / 2.0f;
            _actuatorModel.X2 = _actuatorModel.Width / 2.0;
            _actuatorModel.Y2 = _actuatorModel.Height - 20;
        }

        public void Update(double deltaValue)
        {
            _actuatorModel.DeltaValue = ValueValidate(deltaValue);
            _actuatorModel.DeltaAngle = _actuatorModel.Granularity * _actuatorModel.DeltaValue;
            MoveNeedle();
        }

        private void MoveNeedle()
        {
            _actuatorModel.X1 = _actuatorModel.Center + GetXFromDeg(_actuatorModel.ZSD - _actuatorModel.DeltaAngle, _actuatorModel.Radius);
            _actuatorModel.Y1 = _actuatorModel.Center - GetYFromDeg(_actuatorModel.ZSD - _actuatorModel.DeltaAngle, _actuatorModel.Radius);
        }

        private double ValueValidate(double value)
        {
            return value <= _actuatorModel.Min ? 0 : 
                            value >= _actuatorModel.Max ? _actuatorModel.Range: 
                                     value - _actuatorModel.Min; 
        }

        private double GetXFromDeg(double deg, double radius)
        {
            return (float)radius * Math.Cos(DegreesToRadians(deg));
        }

        private double GetYFromDeg(double deg, double radius)
        {
            return (float)radius * Math.Sin(DegreesToRadians(deg));
        }

        private double DegreesToRadians(double degrees)
        {
            return (float)degrees * ((float)Math.PI / 180.0f);
        }

        private double GetPercentageOfValue(double value, double percent)
        {
            double percentage = 1 + (percent / 100);
            return (value * percentage) - value;
        }
    }
}
