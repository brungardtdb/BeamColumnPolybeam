using System;
using System.Windows;
// Tekla Structures Namespaces
using Tekla.Structures.Model;


namespace BeamColumnPolybeam.Abstract_Classes
{
    public abstract class BeamModeler
    {
        // fields for BeamModeler class
        protected Model classModel; // tekla model we will be working in
        protected Beam classBeam; // beam we will be modeling

        // constructor for modeler class
        protected BeamModeler()
        {

        }


        // method to set profile for beam
        public void setProfile(String beamProfile)
        {
            try
            {
                this.classBeam.Profile.ProfileString = beamProfile;
            }
            catch
            {
                MessageBox.Show("Invalid profile was entered.");
            }
        }

        // method to set name for beam
        public void setName(string beamName)
        {
            try
            {
                this.classBeam.Name = beamName;
            }
            catch
            {

                MessageBox.Show("Something went wrong.");
            }
        }

        // method to set finish for beam
        public void setFinish(string beamFinish)
        {
            try
            {
                this.classBeam.Finish = beamFinish;
            }
            catch
            {

                MessageBox.Show("Invalid finish.");
            }
        }

        // method to set class for beam
        public void setClass(string beamClass)
        {
            try
            {
                this.classBeam.Class = beamClass;
            }
            catch
            {

                MessageBox.Show("Invalid class.");
            }
        }

        // method to set assembly number prefix for beam
        public void setAssemblyNumPrefix(string assemblyNumPrefix)
        {
            try
            {
                this.classBeam.AssemblyNumber.Prefix = assemblyNumPrefix;
            }
            catch
            {

                MessageBox.Show("Something went wrong.");
            }
        }

        // method to set assembly number start number
        public void setAssemblyStartNum(int assemblyStartNum)
        {
            try
            {
                this.classBeam.AssemblyNumber.StartNumber = assemblyStartNum;
            }
            catch
            {

                MessageBox.Show("Invalid start number for assembly.");
            }
        }

        // method to set assembly number prefix for beam
        public void setPartNumPrefix(string partNumPrefix)
        {
            try
            {
                this.classBeam.PartNumber.Prefix = partNumPrefix;
            }
            catch
            {

                MessageBox.Show("Something went wrong.");
            }
        }

        // method to set assembly number prefix for beam
        public void setPartStartNum(int partStartNum)
        {
            try
            {
                this.classBeam.PartNumber.StartNumber = partStartNum;
            }
            catch
            {

                MessageBox.Show("Something went wrong.");
            }
        }

        // method to set assembly number prefix for beam
        public void setMaterialString(string beamMaterial)
        {
            try
            {
                this.classBeam.Material.MaterialString = beamMaterial;
            }
            catch
            {

                MessageBox.Show("Invalid material.");
            }
        }

        // method to insert beam
        public void insertBeam()
        {
            this.classBeam.Insert();
        }

        // method to update model
        public void updateModel()
        {
            this.classModel.CommitChanges();
        }


    }
}
