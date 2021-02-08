using System.Runtime.InteropServices;
using Rhino;
using Rhino.Commands;

namespace SphereCreateExportPlugIn
{
    /// <summary>
    /// SphereCreateExportPlugInCommand is a hidden command  that basically does nothing.
    /// This command is called by CSArchRhinoAutomation2 just so we can make sure this
    /// plug-ins is loaded before trying to get it's scripting object.
    /// </summary>
    [Guid("7973ccea-609f-4080-b35c-0b0632568c1d"), CommandStyle(Style.Hidden)]
  public class SphereCreateExportPlugInCommand : Command
  {
    /// <returns>
    /// The command name as it appears on the Rhino command line.
    /// </returns>
    public override string EnglishName => "SphereCreateExportPlugInCommand";

    /// <summary>
    /// Called by Rhino to run the command.
    /// </summary>
    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
      // Do nothing...
      return Result.Success;
    }
  }
}
