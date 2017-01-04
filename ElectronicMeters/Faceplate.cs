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
            System.Windows.Thickness thickness = new System.Windows.Thickness(0, height - offset, 0, 0);
            _faceplateModel.Margin = thickness;
        }
    }
}
