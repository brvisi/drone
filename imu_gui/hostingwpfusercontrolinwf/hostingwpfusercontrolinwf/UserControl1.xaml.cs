using System;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HostingWpfUserControlInWf
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl 
    {

        public void Rotate(float amountX, float amountY, float amountZ)

        {

            Transform3DGroup transformGroup = new Transform3DGroup();

            RotateTransform3D rotateTransformX = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), 0));
            RotateTransform3D rotateTransformY = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0));
            RotateTransform3D rotateTransformZ = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), 0));

            rotateTransformX.CenterX = rotateTransformY.CenterX = rotateTransformZ.CenterX = 0;
            rotateTransformY.CenterY = rotateTransformY.CenterY = rotateTransformZ.CenterY = 0;
            rotateTransformZ.CenterZ = rotateTransformY.CenterZ = rotateTransformZ.CenterZ = 0;

            transformGroup.Children.Add(rotateTransformX);
            transformGroup.Children.Add(rotateTransformY);
            transformGroup.Children.Add(rotateTransformZ);

            (rotateTransformX.Rotation as AxisAngleRotation3D).Angle = amountX;
            (rotateTransformY.Rotation as AxisAngleRotation3D).Angle = amountY;
            (rotateTransformZ.Rotation as AxisAngleRotation3D).Angle = amountZ;

            model.Transform = transformGroup;


        }



        public UserControl1()
        {
            InitializeComponent();
        }
    }
}
