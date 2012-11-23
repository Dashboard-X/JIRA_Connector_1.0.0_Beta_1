using EnvDTE80;

namespace JIRAConnector.UI {
    public class AddinEventSink : CommandInvokerBase, IEventSink {
        public void OnStartup(DTE2 dte) {
            SetCommand("ADDIN_STARTUP");
            UISolution solution = null;
            if (dte.Solution.IsOpen) {
                solution = new UISolution(dte.Solution);
            }
            SelectedCommand.Parameters.Add("SOLUTION", solution);
            Execute();
        }

        public void OnDisconnect() {
            SetCommand("ADDIN_DISCONNECT");
            Execute();
        }

        public void HookEvents() {}

        public void UnHookEvents() {}
    }
}