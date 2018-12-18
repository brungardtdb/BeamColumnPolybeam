using System.Windows;
// Tekla Structures Namespaces
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
// abstract class namespace
using BeamColumnPolybeam.Abstract_Classes;

namespace BeamColumnPolybeam.Modeler_Classes
{
    class ColumnModeler : BeamModeler
    {
        // constructor for ColumnModeler class
        public ColumnModeler(Model classModel)
        {
            // pass model reference value into base class
            base.classModel = classModel;
        }

        // method for modeling column
        public void ModelColumn(T3D.Point firstPoint, double columnHeight, string beamProfile)
        {

            try
            {
                // create new beam
                Beam modelerBeam = new Beam();
                base.classBeam = modelerBeam;

                // assign start and finish point to beam
                base.classBeam.StartPoint = firstPoint;
                base.classBeam.EndPoint = new T3D.Point(firstPoint.X, firstPoint.Y, firstPoint.Z + (columnHeight * 25.4));

                // set parameters for beam
                base.setProfile(beamProfile);
                base.setName("THIS_Column");
                base.setFinish("Galvanized");
                base.setClass("9");
                base.setAssemblyNumPrefix("CXH");
                base.setAssemblyStartNum(1);
                base.setPartNumPrefix("HR");
                base.setPartStartNum(1);
                base.setMaterialString("A992");

                // set position for beam
                base.classBeam.Position.Depth = Position.DepthEnum.MIDDLE; // set depth to behind
                base.classBeam.Position.Plane = Position.PlaneEnum.MIDDLE; // set plane position to middle
                base.classBeam.Position.Rotation = Position.RotationEnum.TOP; // set rotation to top

                base.insertBeam(); // insert beam into model

                base.updateModel(); // commit changes to model

            }
            catch
            {
                // set pickedpoints to null
                firstPoint = null;

                // read error message to user
                MessageBox.Show("No points were picked");
            }
        }
    }
}
