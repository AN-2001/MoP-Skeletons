using System.Windows.Forms;
using Rhino;
using Rhino.Commands;
using RhinoWindows;

namespace GUISphereCreateExportPlugin.Commands
{
  [System.Runtime.InteropServices.Guid("3a403bca-7bca-4913-bfb1-df74f2022592")]
  public class GUISphereCreateExportPluginFormCommand : Command
  {
    public override string EnglishName
    {
      get { return "GUISphereCreateExport"; }
    }

    protected override Result RunCommand(RhinoDoc doc, RunMode mode)
    {
      var rc = Result.Cancel;

      if (mode == RunMode.Interactive)
      {
        var form = new Forms.GUISphereCreateExportPluginForm { StartPosition = FormStartPosition.CenterParent };
        var dialog_result = form.ShowDialog(RhinoWinApp.MainWindow);
        if (dialog_result == DialogResult.OK)
          rc = Result.Success;
      }
      else
      {
        var msg = string.Format("Scriptable version of {0} command not implemented.", EnglishName);
        RhinoApp.WriteLine(msg);
      }

      return rc;
    }
  }
}
