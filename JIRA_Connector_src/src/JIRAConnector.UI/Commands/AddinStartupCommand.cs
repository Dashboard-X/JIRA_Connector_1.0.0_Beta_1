using JIRAConnector.Common;

namespace JIRAConnector.UI.Commands {
    /// <summary>
    /// Command executed on the addin startup
    /// </summary>
    internal class AddinStartupCommand : CommandBase {
        /// <summary>
        /// Instantiate and initialize AddinStartupCommand
        /// </summary>
        /// <param name="controller">A controller to interact with</param>
        public AddinStartupCommand(UIController controller) : base(controller) {
            name = "ADDIN_STARTUP";
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        public override void Execute() {
            LogManager.WriteMessage("Initializing JIRA Connector...");
            if (parameters["SOLUTION"] != null) {
                UISolution solution = (UISolution)parameters["SOLUTION"];
                //CommandHelper.OnAddinStartUp(solution);
            }
            Context.ActivateJiraConnToolbar();
        }
    }
}