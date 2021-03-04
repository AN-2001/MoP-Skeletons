using Grasshopper.Kernel;
using Rhino;
using Rhino.Geometry;
using System;
using System.Collections;
using System.Collections.Generic;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace CreateSphereGrasshopper
{
    public class CreateSphereGrasshopperComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public CreateSphereGrasshopperComponent()
          : base("CreateSphereGrasshopper", "CreateSphere",
              "Construct a Sphere using Rhino Common API.",
              "CSArch", "Primitive") 
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            // Use the pManager object to register your input parameters.
            // You can often supply default values when creating parameters.
            // All parameters must have the correct access type. If you want 
            // to import lists or trees of values, modify the ParamAccess flag.
            // see https://developer.rhino3d.com/api/grasshopper/html/Overload_Grasshopper_Kernel_GH_Component_GH_InputParamManager_AddNumberParameter.htm
            pManager.AddNumberParameter("X", "X", "X-coordinate of the sphere center.", GH_ParamAccess.item, 0);
            pManager.AddNumberParameter("Y", "Y", "Y-coordinate of the sphere center.", GH_ParamAccess.item, 0);
            pManager.AddNumberParameter("Z", "Z", "Z-coordinate of the sphere center.", GH_ParamAccess.item, 0);
            pManager.AddNumberParameter("Radius", "r", "Sphere radius.", GH_ParamAccess.item, 1);

            // If you want to change properties of certain parameters, 
            // you can use the pManager instance to access them by index:
            //pManager[0].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            // Use the pManager object to register your output parameters.
            // Output parameters do not have default values, but they too must have the correct access type.
            // see https://developer.rhino3d.com/api/grasshopper/html/Methods_T_Grasshopper_Kernel_GH_Component_GH_OutputParamManager.htm
            pManager.AddBrepParameter("Sphere", "S", "Sphere", GH_ParamAccess.item); 

            // Sometimes you want to hide a specific parameter from the Rhino preview.
            // You can use the HideParameter() method as a quick way:
            //pManager.HideParameter(0);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            // First, we need to retrieve all data from the input parameters.
            // We'll start by declaring variables and assigning them starting values.
            double x = 0, y = 0, z = 0, r = 1;
           

            // Then we need to access the input parameters individually. 
            // When data cannot be extracted from a parameter, we should abort this method.
            if (!DA.GetData(0, ref x)) return;
            if (!DA.GetData(1, ref y)) return;
            if (!DA.GetData(2, ref z)) return;
            if (!DA.GetData(3, ref r)) return;

            Point3d center = new Point3d(x, y, z); // Rhino.Geometry.Point3d

            // We should now validate the data and warn the user if invalid data is supplied.
            if (r < 0.0)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Radius must be bigger than zero!");
                return;
            }

            // We're set to create the sphere now. To keep the size of the SolveInstance() method small, 
            // The actual functionality will be in a different method:
            Sphere sphere = new Sphere(center, r); // Rhino.Geometry.Sphere

            // Finally assign the sphere to the output parameter.
            DA.SetData(0, sphere);
        }

        /// <summary>
        /// The Exposure property controls where in the panel a component icon 
        /// will appear. There are seven possible locations (primary to septenary), 
        /// each of which can be combined with the GH_Exposure.obscure flag, which 
        /// ensures the component will only be visible on panel dropdowns.
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.primary; }
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("5a2f3ae0-c855-4768-ba33-0c8fd1d15e1e"); }
        }
    }
}
