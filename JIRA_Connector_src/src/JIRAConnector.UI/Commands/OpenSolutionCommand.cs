using System;
using JIRAConnector.Common;

namespace JIRAConnector.UI.Commands {
    internal class OpenSolutionCommand : CommandBase {
        public OpenSolutionCommand(UIController controller) : base(controller) {
            name = "OPENSOLUTION";
        }

        public override void Execute() {
            try {
                UISolution solution = (UISolution) parameters["SOLUTION"];
                CommandHelper.OnAddinStartUp(solution);
            }
            catch (Exception ex) {
                LogManager.WriteMessage(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}