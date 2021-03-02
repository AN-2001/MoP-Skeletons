using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace CreateSphereGrasshopper
{
    public class CreateSphereGrasshopperInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "CreateSphereGrasshopper";
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
                return new Guid("dd9eb6a6-db40-45d1-a1b6-008fa26f83e3");
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
