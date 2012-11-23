using System;
using System.Windows.Forms;
using EnvDTE;
using EnvDTE80;
using Extensibility;
using JIRAConnector.Common;

namespace JIRAConnector.UI.Extensibility {
    /// <summary>
    /// Implementation of IDTExtensibility2 and IDTCommandTarget
    /// </summary>
    public class Connect : Object, IDTExtensibility2, IDTCommandTarget {
        private DTE2 applicationObject;
        private AddIn addInInstance;
        private AddinEventSink addinEventSink;
        private UIController controller;

        /// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
        //public Connect()
        //{
        //}
        /// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
        /// <param term='application'>Root object of the host application.</param>
        /// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
        /// <param term='addInInst'>Object representing this Add-in.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom) {
            applicationObject = (DTE2) application;
            addInInstance = (AddIn) addInInst;

            // Only execute the startup code if the connection mode is a startup mode
            //if( connectMode == ext_ConnectMode.ext_cm_UISetup ) {
            if (connectMode == ext_ConnectMode.ext_cm_AfterStartup) {
                //Initializing Context
                Context.ApplicationObject = applicationObject;
                Context.AddInInstance = addInInstance;

                //Initializing EventSinks
                SolutionEventSink solutionEventSink = new SolutionEventSink();
                addinEventSink = new AddinEventSink();

                //Initializing Controller
                controller = new UIController();
                controller.Sinks.Add(solutionEventSink);
                controller.Sinks.Add(addinEventSink);
                controller.Init(solutionEventSink, addinEventSink);

                addinEventSink.OnStartup(applicationObject);

                if (Context.ApplicationObject.Solution.IsOpen){
                    solutionEventSink.OnOpenSolution();
                }
            }
        }

        /// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
        /// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom) {
            //Definition of handlers for solution events
            if (disconnectMode != ext_DisconnectMode.ext_dm_UISetupComplete &&
                disconnectMode != ext_DisconnectMode.ext_dm_HostShutdown) {
                addinEventSink.OnDisconnect();
            }
        }

        /// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />		
        public void OnAddInsUpdate(ref Array custom) {}

        /// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnStartupComplete(ref Array custom) {}

        /// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
        /// <param term='custom'>Array of parameters that are host application specific.</param>
        /// <seealso class='IDTExtensibility2' />
        public void OnBeginShutdown(ref Array custom) {
            addinEventSink.OnDisconnect();
            //if (commandBar != null) {
            //    commandBar.Delete(Type.Missing);
            //}
            //if (m_toolWin != null) {
            //    m_toolWin.Close(vsSaveChanges.vsSaveChangesNo);
            //}
        }

        /// <summary>Implements the QueryStatus method of the IDTCommandTarget interface. This is called when the command's availability is updated</summary>
        /// <param term='commandName'>The name of the command to determine state for.</param>
        /// <param term='neededText'>Text that is needed for the command.</param>
        /// <param term='status'>The state of the command in the user interface.</param>
        /// <param term='commandText'>Text requested by the neededText parameter.</param>
        /// <seealso class='Exec' />
        public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status,
                                ref object commandText) {
            if (neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone) {}
        }

        /// <summary>Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.</summary>
        /// <param term='commandName'>The name of the command to execute.</param>
        /// <param term='executeOption'>Describes how the command should be run.</param>
        /// <param term='varIn'>Parameters passed from the caller to the command handler.</param>
        /// <param term='varOut'>Parameters passed from the command handler to the caller.</param>
        /// <param term='handled'>Informs the caller if the command was handled or not.</param>
        /// <seealso class='Exec' />
        public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut,
                         ref bool handled) {
            MessageBox.Show(commandName);
            handled = false;
            //if (executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
            //{
            //    if (commandName.Contains("JIRAConnector"))
            //    {
            //        handled = true;
            //    }
            //}
        }
    }
}