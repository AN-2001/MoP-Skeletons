using Grasshopper.Kernel;
using Rhino.Geometry;
using System;
using IritNet;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace Text2GeomViaIrit2Grasshopper
{
    public class Text2GeomViaIrit2GrasshopperComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public Text2GeomViaIrit2GrasshopperComponent()
          : base("Text2GeomViaIrit2Grasshopper", "Text2Geom",
              "Converts text into polygons or outline polygons.",
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
            pManager.AddTextParameter("Font name", "FN", "Font family name.", GH_ParamAccess.item, "Times New Roman");
            pManager.AddNumberParameter("Font size", "FS", "Font size.", GH_ParamAccess.item, 20.0);
            pManager.AddIntegerParameter("Font style", "FT", "Regular = 0, Italic = 1, Bold = 2, and Bold and Italic = 3.", GH_ParamAccess.item, 0);
            pManager.AddNumberParameter("Text spacing", "TS", "The distance between letters.", GH_ParamAccess.item, 0.0);
            pManager.AddIntegerParameter("Output type", "OT", "Polygons = 0, Outline = 1.", GH_ParamAccess.item, 0);
            pManager.AddTextParameter("Text", "T", "The text to be converted.", GH_ParamAccess.item, "!שלום");

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
            pManager.AddCurveParameter("Polygons", "P", "A list of polygons.", GH_ParamAccess.list);

            // Sometimes you want to hide a specific parameter from the Rhino preview.
            // You can use the HideParameter() method as a quick way:
            //pManager.HideParameter(0);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        unsafe protected override void SolveInstance(IGH_DataAccess DA)
        {
            string text = "!שלום";
            byte[] fontName = Encoding.ASCII.GetBytes("Times New Roman");
            IritNet.UserFontStyleType fontStyle = IritNet.UserFontStyleType.USER_FONT_STYLE_REGULAR;
            double fontSize = 20;
            double textSpacing = 0;
            IritNet.UserFont3DEdgeType text3DEdgeType = IritNet.UserFont3DEdgeType.USER_FONT_3D_EDGE_NORMAL;
            double[] text3DSetup = new double[] { 0.0, 0.0 }; // ignored
            double tolerance = 0.005;
            UserFontGeomOutputType outputType = UserFontGeomOutputType.USER_FONT_OUTPUT_OUTLINE_FILLED2D_POLYS;
            byte compactOutput = 0; // FALSE
            byte[] placedTextBaseName = Encoding.ASCII.GetBytes("Hopper");
            IritNet.IPObjectStruct * placedTextGeom = null;
            byte * errorSt = null;

            string fontNameTmp = "Times New Roman";
            if (!DA.GetData(0, ref fontNameTmp)) return;
            fontName = Encoding.ASCII.GetBytes(fontNameTmp);
            if (!DA.GetData(1, ref fontSize)) return;
            int fontStyleTmp = 0;
            if (!DA.GetData(2, ref fontStyleTmp)) return;
            if (!DA.GetData(3, ref textSpacing)) return;
            int outputTypeTmp = 0;
            if (!DA.GetData(4, ref outputTypeTmp)) return;
            if (!DA.GetData(5, ref text)) return;

            if (fontSize <= 10E-06)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Font size cannot be zero!");
                return;
            }

            if (fontStyleTmp < 0 || fontStyleTmp > 3)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Wrong font style!");
                return;
            }
            else
            {
                fontStyle = (IritNet.UserFontStyleType)fontStyleTmp;
            }

            if (textSpacing < 0)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Text spacing cannot be negative!");
                return;
            }


            if (outputTypeTmp < 0 || outputTypeTmp > 1)
            {
                AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "Wrong output type!");
                return;
            }
            else if (outputTypeTmp == 0)
            {
                outputType = UserFontGeomOutputType.USER_FONT_OUTPUT_FILLED2D_POLYS;
            }
            else
            {
                outputType = UserFontGeomOutputType.USER_FONT_OUTPUT_OUTLINE_FILLED2D_POLYS;
            }


            int outval = IritUser.UserFontConvertTextToGeom(text, fontName, fontStyle, fontSize, textSpacing, text3DEdgeType, text3DSetup, tolerance, outputType, compactOutput, placedTextBaseName, out placedTextGeom, out errorSt);

            List<Polyline> polylines = new List<Polyline>();

            IritNet.IPObjectStruct* letter = null;
            for (int i = 0; (letter = IritNet.Irit.IPListObjectGet(placedTextGeom, i)) != null; i++)
            {
                IritNet.IPPolygonStruct* polygons = null;
                if (outputType == UserFontGeomOutputType.USER_FONT_OUTPUT_FILLED2D_POLYS)
                {
                    polygons = letter->U.Pl;
                    IritPolygonsToRhino(polygons, true, ref polylines);
                }
                else if (outputType == UserFontGeomOutputType.USER_FONT_OUTPUT_OUTLINE_FILLED2D_POLYS)
                {
                    polygons = IritHelpers.TraverseCrvHierarchy(letter, tolerance);
                    IritPolygonsToRhino(polygons, false, ref polylines);
                }
                
            }

            // Finally assign the collection of all the polygons to the output.
                DA.SetDataList(0, polylines);
        }

        private unsafe protected void IritPolygonsToRhino(IritNet.IPPolygonStruct* polygons, bool closeIt, ref List<Polyline> polylines)
        {
            while (polygons != null)
            {
                List<Point3d> poly = new List<Point3d>();
                IritNet.IPVertexStruct* ver = polygons->PVertex;
                IritNet.IPVertexStruct* first = ver;
                if (ver == null)
                {
                    AddRuntimeMessage(GH_RuntimeMessageLevel.Error, "The pointer to the vertices is not set!");
                    return;
                }
                do
                {
                    poly.Add(new Point3d() { X = ver->Coord[0], Y = ver->Coord[1], Z = ver->Coord[2] });
                    ver = ver->Pnext;
                } while (ver != first && ver != null);

                if(closeIt)
                    poly.Add(poly[0]); // we add the first at the end in order to obtain a polygon
                Polyline polyline = new Polyline(poly);
                polylines.Add(polyline);
                polygons = polygons->Pnext;
            }
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
            get { return new Guid("16fc3b61-11e2-43e1-9764-5fcbaf43adaa"); }
        }
    }
}
