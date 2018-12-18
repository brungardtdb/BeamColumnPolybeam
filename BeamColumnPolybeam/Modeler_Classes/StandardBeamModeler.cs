using System.Windows;
// Tekla Structures Namespaces
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using System.Collections;
// abstract class namespace
using BeamColumnPolybeam.Abstract_Classes;

namespace BeamColumnPolybeam.Modeler_Classes
{
    class StandardBeamModeler : BeamModeler
    {

        T3D.Point firstPoint = null; // first point picked by user
        T3D.Point secondPoint = null; // second point picked by user

        // constructor for StandardBeamModeler class
        public StandardBeamModeler(Model classModel)
        {
            // pass model reference value into base class
            base.classModel = classModel;
        }

        // method for modeling beam
        public void ModelBeam(ArrayList pickedPoints, string beamProfile)
        {
            
            try
            {
                // assign first and second points with values in arraylist
                firstPoint = pickedPoints[0] as T3D.Point;
                secondPoint = pickedPoints[1] as T3D.Point;

                // create new beam
                Beam modelerBeam = new Beam();
                base.classBeam = modelerBeam;

                // assign first and second points from arraylist
                firstPoint = pickedPoints[0] as T3D.Point;
                secondPoint = pickedPoints[1] as T3D.Point;

                // assign start and finish point to beam
                base.classBeam.StartPoint = firstPoint;
                base.classBeam.EndPoint = secondPoint;

                // set parameters for beam
                base.setProfile(beamProfile); 
                base.setName("THIS_BEAM");
                base.setFinish("Galvanized");
                base.setClass("9");
                base.setAssemblyNumPrefix("MXH");
                base.setAssemblyStartNum(1);
                base.setPartNumPrefix("HR");
                base.setPartStartNum(1);
                base.setMaterialString("A992");

                // set position for beam
                base.classBeam.Position.Depth = Position.DepthEnum.BEHIND; // set depth to behind
                base.classBeam.Position.Plane = Position.PlaneEnum.MIDDLE; // set plane position to middle
                base.classBeam.Position.Rotation = Position.RotationEnum.TOP; // set rotation to top

                base.insertBeam(); // insert beam into model
                
                base.updateModel(); // commit changes to model
               
            }
            catch
            {
                // set pickedpoints to null
                pickedPoints = null;

                // read error message to user
                MessageBox.Show("No points were picked");                
            }
        }
    }
}
