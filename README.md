# MoP skeleton
This repo contains the skeleton files for MoP 2024.

## Requirements

* Rhino 8 64 bits for Windows
* Visual Studio 2019 with C# and .NET 4.8 (it is enough to use the community version, see [here](https://visualstudio.microsoft.com/vs/community/))

## Rhino Grasshopper
These projects demonstrate (and constitute a starting base) how to write plug-ins for Grasshopper (GH).

### CreateSphereGrasshopper
CreateSphereGrasshopper is a straightforward GH plug-in, which demonstrates how to use Rhino and GH APIs. The plug-in creates a sphere that can then be controlled via the GH interface, i.e., the user can control the coordinates of the center and the radius.

![sphere_api](https://user-images.githubusercontent.com/456607/113514103-6e597200-9575-11eb-8624-413105ac4c3f.png)

### Text2GeomViaIrit2Grasshopper
Text2GeomViaIrit2Grasshopper is another example of GH and Rhino API use, but it also shows how to connect code written in an external C++ library. The plug-in allows for providing different parameters, e.g., user text, font size, font family, etc.

_The conversion of the text is done by a C++ library called [IRIT](http://www.cs.technion.ac.il/~irit/) and developed by [prof. Gershon Elber](http://www.cs.technion.ac.il/~gershon/). The bridge between C++ and C# is possible thanks to bindings defined in the IritNet interface. Nevertheless, IritNet does not cover the whole interface of Irit, and therefore, in case of issues, it is advised to contact me as soon as possible. I will then do whatever possible to add the missing functionalities._

The IritNet and Irit libraries are already provided in Release and Debug form. Moreover, the project file is configured to automatically place the correct version of these libraries with respect to the compilation scenario set in Visual Studio. _Assuming that the defualt installation path was chosen during Rhino 8 installation._


In the directory ```Examples```, you can find a file ```grass_hopper_demo_text_extrude```, which shows the use of the plug-in, in a pipeline that not only creates polygons from the user provided text but also extrudes these polygons.

![text_pipeline](https://user-images.githubusercontent.com/456607/113514061-33efd500-9575-11eb-8fdb-121c2830760d.png)

![extrude](https://user-images.githubusercontent.com/456607/113514224-153e0e00-9576-11eb-830c-1e357236f85b.png)

## Useful links

* [Rhino Common API](https://developer.rhino3d.com/api/RhinoCommon/html/R_Project_RhinoCommon.htm)
* [Grasshopper SDK](https://developer.rhino3d.com/api/grasshopper/html/723c01da-9986-4db2-8f53-6f3a7494df75.htm)

