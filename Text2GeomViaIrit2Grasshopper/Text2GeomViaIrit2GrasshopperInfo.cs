using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace Text2GeomViaIrit2Grasshopper
{
    public class Text2GeomViaIrit2GrasshopperInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "Text2GeomViaIrit2Grasshopper";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("f222630f-85d8-42fa-8e38-ba3fa8e7ccbc");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
