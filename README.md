# CSArch-demo
This repository contains basic code that explains Rhino 7 API for the spring course 2020/2021


## Requiements

* Rhino 7 64 bits for Windows ([get for free 90-days evaluation license](https://www.rhino3d.com/download/rhino-for-windows/evaluation))
* Visual Studio 2019 with C# and .NET 4.8 (it is enough to use the community version)

## Rhino Grasshopper
These projects demonstrate (and constitute a starting base) how to write plug-ins for Grasshopper (GH).

### CreateSphereGrasshopper
CreateSphereGrasshopper is a straightforward GH plug-in, which demonstrates how to use Rhino and GH APIs. The plug-in creates a sphere that can then be controlled via the GH interface, i.e., the user can control the coordinates of the center and the radius.

### Text2GeomViaIrit2Grasshopper
Text2GeomViaIrit2Grasshopper is another example of GH and Rhino API use, but it also shows how to connect code written in an external C++ library. The plug-in allows for providing different parameters, e.g., user text, font size, font family, etc.

## Rhino Automation

These projects demonstrate how to use the Rhino API (Rhino plug-ins, and scripts)

* CSArchRhinoAutomation1
* CSArchRhinoAutomation2

In the spring semester of 2021, we will not use this code.

## Useful links

* [Rhino Common API](https://developer.rhino3d.com/api/RhinoCommon/html/R_Project_RhinoCommon.htm)
* [Grasshopper SDK](https://developer.rhino3d.com/api/grasshopper/html/723c01da-9986-4db2-8f53-6f3a7494df75.htm)
