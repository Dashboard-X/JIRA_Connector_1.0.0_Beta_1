using System;
using System.IO;
using EnvDTE;
using EnvDTE80;
using JIRAConnector.Common;

namespace JIRAConnector.UI {
    public static class Context {
        private static OutputWindowWriter outputWriter = null;
        private static DTE2 applicationObject;
        private static AddIn addInInstance;
        private static Window toolWindow = null;
        private const string guidToolWindow = "{858C3FCD-8B39-4540-A592-F31C1520B174}";
        private static Window m_toolWin = null;
        private static Command showJiraconnWindowCommand = null;
        private static VSCommandBars commandBars = null;

        public static DTE2 ApplicationObject {
            get { return applicationObject; }
            set { applicationObject = value; }
        }

        /// <summary>
        /// The top level automation object.
        /// </summary>
        public static _DTE DTE {
            get {
                //Type t = Type.GetTypeFromProgID("VisualStudio.DTE.7.1", true);
                //return (_DTE) Activator.CreateInstance(t);
                return applicationObject;
            }
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

        private static VSCommandBars CommandBars {
            get {
                if (commandBars == null) {
                    commandBars = VSCommandBars.Create();
                }
                return commandBars;
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

        public static void ActivateJiraConnToolbar() {
            try {
                LogManager.WriteDebugMessage("Creating commandbar");
                CreateJIRAConnSubMenu();
            }
            catch (Exception ex) {
                LogManager.WriteMessage(ex.Message);
            }
        }

        /// <summary>
        /// Creates an "JIRAConn" submenu on the Tools menu.
        /// </summary>
        private static void CreateJIRAConnSubMenu() {
            //TODO: Complete later
            //object toolMenu = CommandBars.GetCommandBar("Tools");

            //// check that the menu isn't already there
            //object jiraConnMenu = CommandBars.GetBarControl(toolMenu, "JIRAConn");
            //if (jiraConnMenu == null) {
            //    CommandBars.AddCommandBar("JIRAConn",
            //                              vsCommandBarType.vsCommandBarTypeMenu, toolMenu, 1);
            //    Command cmd = CommandBars.AddNamedCommand("LinkSolutionToJIRA", "Link Solution to JIRA",
            //                                              "Links the actual solution to JIRA", ResourceBitmaps.Default,
            //                                              0);

            //    object bar = CommandBars.GetCommandBar("Tools.JIRAConn");
            //    if (bar != null) {
            //        object cntrl = CommandBars.AddControl(cmd, bar, 1);
            //        CommandBars.SetControlTag(cntrl, "Tools.JIRAConn.LinkSolutionToJIRA");
            //    }
            //}
        }

        public static void DeactivateToolbar() {
            if (showJiraconnWindowCommand != null) {
                showJiraconnWindowCommand.Delete();
            }
            if (m_toolWin != null) {
                m_toolWin.Close(vsSaveChanges.vsSaveChangesNo);
            }
        }
    }
}