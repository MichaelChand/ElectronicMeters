using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicMeters
{
    public class Faceplate
    {
        private FaceplateModel _faceplateModel { get; set; }

        public Faceplate(FaceplateModel faceplateModel)
        {
            _faceplateModel = faceplateModel;
        }

        public void SetMargin(double width, double height, double offset)
        {
           _faceplateModel.Margin = new System.Windows.Thickness(width/2.0f, height + offset, 0, 0);
        }
    }
}
