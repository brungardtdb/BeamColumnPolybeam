using System;
using System.Windows;
using System.Windows.Controls;
// Tekla Structures Namespaces
using Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;
using TSMUI = Tekla.Structures.Model.UI;
using System.Collections;
// Modeler class namespaces
using BeamColumnPolybeam.Modeler_Classes;

namespace BeamColumnPolybeam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model currentModel;
        

        public MainWindow()
        {
            InitializeComponent();

            // try connecting to model
            try
            {
                currentModel = new Model();
            }
            catch 
            {
                MessageBox.Show("Model may not be connected.");                
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtColumnHeight_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        // button to create beam
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ArrayList pickedPoints = null; // arraylist for user picked points
            T3D.Point firstPoint = null; // first point picked by user
            T3D.Point secondPoint = null; // second point picked by user
            TSMUI.Picker picker = new TSMUI.Picker(); // new picker for user
            string beamProfile = txtProfile.Text; // profile for beam

            try
            {
                // prompt user to pick points in model
                pickedPoints = picker.PickPoints(Tekla.Structures.Model.UI.Picker.PickPointEnum.PICK_TWO_POINTS);

                
                // assign first and second points from arraylist
                firstPoint = pickedPoints[0] as T3D.Point;
                secondPoint = pickedPoints[1] as T3D.Point;
                
            }
            catch
            {
                // set pickedpoints to null
                pickedPoints = null;

                // read error message to user
                MessageBox.Show("No points were picked");
            }

            // if points aren't null
            if (firstPoint != null && secondPoint != null)
            {

                // create new beam modeler
                StandardBeamModeler myBeamModeler = new StandardBeamModeler(currentModel);               

                // model beam
                myBeamModeler.ModelBeam(pickedPoints, beamProfile);

            }


        }

        // button to create column
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            T3D.Point firstPoint = null; // insertion point for column
            TSMUI.Picker picker = new TSMUI.Picker(); // new picker for user
            double columnHeight; // height of column
            string beamProfile = txtProfile.Text; // profile for column / beam

            try
            {
                // try converting text in text box for column height to double
                columnHeight = Convert.ToDouble(txtColumnHeight.Text);
            }
            catch 
            {
                // if column height conversion failed, set height to zero and display error message
                columnHeight = 0;
                MessageBox.Show("No column height was entered.");
            }

            try
            {
                // prompt user to pick points in model
                firstPoint = picker.PickPoint();

                // create new column modeler
                ColumnModeler myColumnModeler = new ColumnModeler(currentModel);

                // model column
                myColumnModeler.ModelColumn(firstPoint, columnHeight, beamProfile);
            }
            catch
            {
                // set pickedpoints to null
                firstPoint = null;

                // read error message to user
                MessageBox.Show("No insertion points were picked");
            }

        }

        // button to create polybeam
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ArrayList pickedPoints = null; // arraylist for user picked points
            TSMUI.Picker picker = new TSMUI.Picker(); // new picker for user
            string beamProfile = txtProfile.Text; // profile for polybeam

            try
            {
                // prompt user to pick points in model
                pickedPoints = picker.PickPoints(Tekla.Structures.Model.UI.Picker.PickPointEnum.PICK_POLYGON);
            }
            catch
            {
                // set pickedpoints to null
                pickedPoints = null;

                // read error message to user
                MessageBox.Show("No points were picked");
            }

            if (pickedPoints != null)
            {
             
                // pass model to PolyBeamModelerChild class
                PolyBeamModelerChild myPolyBeamModeler = new PolyBeamModelerChild(currentModel);

                // Model beam using pickedPoints
                myPolyBeamModeler.ModelBeam(pickedPoints, beamProfile);            
                
            }
            
        }

       
    }
}
