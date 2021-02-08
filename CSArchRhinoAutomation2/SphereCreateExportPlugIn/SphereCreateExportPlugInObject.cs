using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Rhino;
using Rhino.Geometry;

namespace SphereCreateExportPlugIn
{
    [System.Runtime.InteropServices.ComVisible(true)]
    public class SphereCreateExportPlugInObject
    {
        /// <summary>
        /// Return a sample string
        /// </summary>
        public string GetName()
        {
            return "SphereCreateExportPlugInObject";
        }

        /// <summary>
        /// We create a sphere centered at x, y, z of a given radius using Rhino Common API
        /// For more info. see: https://developer.rhino3d.com/api/RhinoCommon/html/M_Rhino_Geometry_Sphere__ctor_1.htm
        /// </summary>
        public Rhino.Commands.Result AddSphere(double x, double y, double z, double radius)
        {
            var doc = RhinoDoc.ActiveDoc;
            Rhino.Geometry.Point3d center = new Rhino.Geometry.Point3d(x, y, z);
            Rhino.Geometry.Sphere sphere = new Rhino.Geometry.Sphere(center, radius);
            System.Guid objG = doc.Objects.AddSphere(sphere);
            if (objG != System.Guid.Empty)
            {
                doc.Views.Redraw();
                return Rhino.Commands.Result.Success;
            }
            return Rhino.Commands.Result.Failure;
        }

        /// <summary>
        /// All the objects are saved as STEP file.
        /// For more info. see: 
        /// https://developer.rhino3d.com/api/RhinoCommon/html/M_Rhino_FileIO_FileStp_Write.htm
        ///  https://developer.rhino3d.com/api/RhinoCommon/html/T_Rhino_FileIO_FileStpWriteOptions.htm
        /// </summary>
        /// <returns></returns>
        public Rhino.Commands.Result SaveSTP(string filepath)
        {
            var doc = RhinoDoc.ActiveDoc;
            var options = new Rhino.FileIO.FileStpWriteOptions();
            if (Rhino.FileIO.FileStp.Write(filepath, doc, options))
            {
                return Rhino.Commands.Result.Success;
            }
            else
            {
                return Rhino.Commands.Result.Failure;
            }
        }
    }
}
