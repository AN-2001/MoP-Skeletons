using System.Reflection;
using System.Runtime.InteropServices;
using Rhino.PlugIns;

// Plug-in Description Attributes - all of these are optional
// These will show in Rhino's option dialog, in the tab Plug-ins
[assembly: PlugInDescription(DescriptionType.Address, "Technion\r\nTaub Building\r\nHaifa, 320000")]
[assembly: PlugInDescription(DescriptionType.Country, "Israel")]
[assembly: PlugInDescription(DescriptionType.Email, "kacper.pluta@gmail.com")]
[assembly: PlugInDescription(DescriptionType.Phone, "")]
[assembly: PlugInDescription(DescriptionType.Fax, "")]
[assembly: PlugInDescription(DescriptionType.Organization, "Technion")]
[assembly: PlugInDescription(DescriptionType.UpdateUrl, "https://github.com/copyme/CSArch-demo")]
[assembly: PlugInDescription(DescriptionType.WebSite, "https://copyme.github.io/misc/cs-arch-spring")]
[assembly: PlugInDescription(DescriptionType.Icon, "GUISphereCreateExportPlugin.Resources.SampleCs.ico")]

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("GUISphereCreateExportPlugin")] // Plug-In title is extracted from this
[assembly: AssemblyDescription("GUISphereCreateExportPlugin")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Technion")]
[assembly: AssemblyProduct("GUISphereCreateExportPlugin")]
[assembly: AssemblyCopyright("Copyright © 2021, KP")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("6acc2d29-3c08-4752-97a3-56bf957bb03d")] // This will also be the Guid of the Rhino plug-in

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
