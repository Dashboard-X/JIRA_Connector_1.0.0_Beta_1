using System;
using EnvDTE;
using JIRAConnector.Common;

namespace JIRAConnector.UI {
    public class SolutionEventSink : CommandInvokerBase, IEventSink {
        private SolutionEvents solutionEvents = null;
        private _dispSolutionEvents_AfterClosingEventHandler afterClosingEventHandler = null;
        private _dispSolutionEvents_OpenedEventHandler openedEventHandler = null;
        private bool hooked = false;

        public SolutionEventSink() {
            solutionEvents = Context.ApplicationObject.Events.SolutionEvents;
            HookEvents();
        }

        public void HookEvents() {
            if (!hooked) {
                hooked = true;
                afterClosingEventHandler = new _dispSolutionEvents_AfterClosingEventHandler(solutionEvents_AfterClosing);
                solutionEvents.AfterClosing += afterClosingEventHandler;
                openedEventHandler = new _dispSolutionEvents_OpenedEventHandler(solutionEvents_Opened);
                solutionEvents.Opened += openedEventHandler;
            }
        }

        public void UnHookEvents() {
            solutionEvents.AfterClosing -= afterClosingEventHandler;
            solutionEvents.Opened -= openedEventHandler;
            solutionEvents = null;
        }

        private void solutionEvents_Opened() {
            if (Context.ApplicationObject.Solution.IsOpen) {
                try {
                    SetCommand("OPENSOLUTION");
                    SelectedCommand.Parameters.Add("SOLUTION", new UISolution(Context.ApplicationObject.Solution));
                    Execute();
                }
                catch (Exception ex) {
                    LogManager.WriteDebugMessage(ex.Message);
                }
            }
        }

        private void solutionEvents_AfterClosing() {
            SetCommand("CLOSESOLUTION");
            SelectedCommand.Parameters.Add("SOLUTION", new UISolution(Context.ApplicationObject.Solution));
            Execute();
        }

        public void OnOpenSolution() {
            solutionEvents_Opened();
        }
    }
}