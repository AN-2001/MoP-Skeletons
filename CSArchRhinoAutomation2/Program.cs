using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSArchRhinoAutomation2
{
    static class Program
    {
        public enum Errors
        {
            RHINO_INIT_FAILD,
            RHINO_NOT_INIT,
            RHINO_INIT_SUCCESS,
            RHINO_ALREADY_INIT,
            COMMAND_EXEC_ERROR,
            COMMAND_EXEC_SUCCESS,
            PLUGIN_INIT_ERROR,
            PLUGIN_NOT_INSTALLED,
            PLUGIN_INIT_SUCCESS
        }

        private static dynamic rhino = null;
        private static dynamic plugin = null;
        public static bool RhinoVisable(bool value)
        {
            if(rhino == null || rhino.IsInitialized() == 0)
            {
                return false;
            }
            // <summary>
            // A flag contronling whether the main window should be shown on the screen.
            // For more information see: https://developer.rhino3d.com/api/rhinoscript/rhino_properties_methods/visible.htm
            // </summary
            rhino.Visible = value;
            return true;
        }

        public static Errors SendShpere2Rhino(double x, double y, double z, double radius)
        {
            if (rhino == null || rhino.IsInitialized() == 0 || plugin == null)
            {
                return Errors.RHINO_NOT_INIT;
            }
            plugin.AddSphere(x, y, z, radius);
            return Errors.COMMAND_EXEC_SUCCESS;
        }

        public static Errors STPExportAll(string filename)
        {
            if (rhino == null || rhino.IsInitialized() == 0 || plugin == null)
            {
                return Errors.RHINO_NOT_INIT;
            }
            // we select all objects created in Rhino
            plugin.SaveSTP(filename);
            return Errors.COMMAND_EXEC_SUCCESS;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if(InitRhino() != Errors.RHINO_INIT_SUCCESS)
            {
                throw new SystemException("Rhino could not be initalized!");
            }

            if(LoadRhinoPlugins() != Errors.PLUGIN_INIT_SUCCESS)
            {
                throw new SystemException("Rhino plugins could not be loaded!");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        /// <summary>
        /// This method initalize a connection to an instance of Rhino using the ActiveX COM (Component Object Model) interface.
        /// For more info see: 
        /// https://developer.rhino3d.com/api/rhinoscript/introduction/external_access.htm
        /// https://developer.rhino3d.com/api/rhinoscript/rhino_properties_methods/rhino_properties_and_methods.htm
        /// </summary>
        private static Errors InitRhino()
        {
            if (rhino != null)
            {
                return Errors.RHINO_ALREADY_INIT;
            }
            try
            {
                const string rhino_id = "Rhino.Application";
                var type = Type.GetTypeFromProgID(rhino_id);
                rhino = Activator.CreateInstance(type);
            }
            catch
            {
                return Errors.RHINO_INIT_FAILD;
            }

            if (null == rhino)
            {
                Console.WriteLine("Failed to create Rhino application");
                return Errors.RHINO_INIT_FAILD;
            }

            // Wait until Rhino is initialized before calling into it
            const int bail_milliseconds = 15 * 1000;
            var time_waiting = 0;
            while (0 == rhino.IsInitialized())
            {
                Thread.Sleep(100);
                time_waiting += 100;
                if (time_waiting > bail_milliseconds)
                {
                    Console.WriteLine("Rhino initialization failed");
                    return Errors.RHINO_INIT_FAILD;
                }
            }

            /// <summary>
            /// It conntrols whether the Rhino instance should be closed or not. Here we decide to close it, 
            /// so the process is not hanging once our application is closed.
            /// For more info see: https://developer.rhino3d.com/api/rhinoscript/rhino_properties_methods/releasewithoutclosing.htm
            /// </summary>
            rhino.ReleaseWithoutClosing = 0;
            return Errors.RHINO_INIT_SUCCESS;
        }

        private static Errors LoadRhinoPlugins()
        {
            if (rhino == null || rhino.IsInitialized() == 0)
            {
                return Errors.RHINO_NOT_INIT;
            }

            // SphereCreateExportPlugInCommand is a hidden command in the SphereCreateExportPlugInCommand plug-in
            // that basically does nothing. By running this do-nothing command,
            // we can make sure the SampleCsRhino plug-in is loaded before trying
            // to get it's scripting object.
            int debug_val = rhino.RunScript("_-SphereCreateExportPlugInCommand", 1);
            if(debug_val == 0)
            {
                return Errors.PLUGIN_NOT_INSTALLED;
            }

            try
            {
                // Guid is from SphereCreateExportPlugIn assembly file
                const string plugin_id = "954da49f-0c15-4dd6-8e28-9fb1d1311c4b";
                plugin = rhino.GetPlugInObject(plugin_id, plugin_id);
            }
            catch
            {
                // ignored
            }

            if (null == plugin)
            {
                return Errors.PLUGIN_INIT_ERROR;
            }
            return Errors.PLUGIN_INIT_SUCCESS;
        }
    }
}
