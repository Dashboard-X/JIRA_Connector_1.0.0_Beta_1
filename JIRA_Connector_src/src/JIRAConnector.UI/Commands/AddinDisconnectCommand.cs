using JIRAConnector.Common;

namespace JIRAConnector.UI.Commands {
    /// <summary>
    /// A command executed on Addin disconnection
    /// </summary>
    internal class AddinDisconnectCommand : CommandBase {
        /// <summary>
        /// Default constuctor
        /// </summary>
        /// <param name="controller">A controller to interact with</param>
        public AddinDisconnectCommand(UIController controller) : base(controller) {
            name = "ADDIN_DISCONNECT";
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        public override void Execute() {
            LogManager.WriteMessage("Disconnecting JIRA Connector.");
            foreach (IEventSink sink in controller.Sinks) {
                sink.UnHookEvents();
            }
            Context.DeactivateWindowPane();
            Context.DeactivateToolbar();
        }
    }
}