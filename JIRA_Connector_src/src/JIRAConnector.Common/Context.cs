using System;
using System.IO;
using EnvDTE;
using EnvDTE80;

namespace JIRAConnector.Common {
    public static class Context {
        private static OutputWindowWriter outputWriter = null;
        private static DTE2 applicationObject;
        private static AddIn addInInstance;
        private static Window toolWindow = null;
        private const string guidToolWindow = "{858C3FCD-8B39-4540-A592-F31C1520B174}";

        public static DTE2 ApplicationObject {
            get { return applicationObject; }
            set { applicationObject = value; }
        }

        public static AddIn AddInInstance {
            get { return addInInstance; }
            set { addInInstance = value; }
        }

        public static TextWriter Output {
            get {
                if (outputWriter == null) {
                    outputWriter = new OutputWindowWriter(applicationObject, "JIRA Connector");
                }
                return outputWriter;
            }
        }

        /// <summary>
        /// Show WindowPane for jiraconn
        /// </summary>
        public static void ActivateWindowPane(string assemblyLocation, string progId, string title) {
            if (toolWindow == null) {
                Windows2 toolWins = (Windows2) applicationObject.Windows;

                object objTemp = null;

                // Create a new tool window, embedding the 
                // LineCounterBrowser control inside it...
                toolWindow = toolWins.CreateToolWindow2(
                    addInInstance,
                    assemblyLocation,
                    progId,
                    title,
                    guidToolWindow, ref objTemp);

                toolWindow.Visible = true;
            }
        }

        public static void DeactivateWindowPane() {
            if (toolWindow != null) {
                toolWindow.Visible = false;
                toolWindow.Detach();
                toolWindow = null;
            }
        }
    }
}