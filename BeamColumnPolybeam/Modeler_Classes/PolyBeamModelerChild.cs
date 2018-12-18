using System.Windows;
// Tekla Structures Namespaces
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using System.Collections;
// abstract class namespace
using BeamColumnPolybeam.Modeler_Classes.Abstract_Classes;

namespace BeamColumnPolybeam.Modeler_Classes
{
    class PolyBeamModelerChild : PolyBeamModeler
    {
        // constructor for StandardBeamModeler class
        public PolyBeamModelerChild(Model classModel)
        {
            // pass model reference value into base class
            base.classModel = classModel;
        }

        // method for modeling beam
        public void ModelBeam(ArrayList userPoints, string beamProfile)
        {
            // if user has only picked one point
            // display error message
            if (userPoints.Count == 1)
            {
                MessageBox.Show("Not enough points");
            }
            // if user has only picked two points
            // create standard beam
            else if (userPoints.Count == 2)
            {
                // create new beam modeler
                StandardBeamModeler myBeamModeler = new StandardBeamModeler(classModel);

                // model beam
                myBeamModeler.ModelBeam(userPoints, beamProfile);
            }
            // if user selects 3 or more points
            else if (userPoints.Count >= 3)
            {
                // create new beam
                PolyBeam modelerBeam = new PolyBeam();
                base.classBeam = modelerBeam;

                // assign first value in array list as start point
                base.classBeam.AddContourPoint(new ContourPoint(userPoints[0] as T3D.Point, null));

                // loop through values in array list, stopping before the last value
                // add chamfer to each internal point
                for (int i = 1; i < userPoints.Count - 1; i++)
                {
                    base.classBeam.AddContourPoint(new ContourPoint(userPoints[i] as T3D.Point, new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT)));
                }
                
                // assign last value in array list as end point
                base.classBeam.AddContourPoint(new ContourPoint(userPoints[userPoints.Count - 1] as T3D.Point, null));

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

           
        }

    }
}
