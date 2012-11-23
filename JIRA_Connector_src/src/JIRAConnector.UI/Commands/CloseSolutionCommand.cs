using System;
using System.Windows.Forms;
using JIRAConnector.Common;

namespace JIRAConnector.UI.Commands {
    internal class CloseSolutionCommand : CommandBase {
        public CloseSolutionCommand(UIController controller) : base(controller) {
            name = "CLOSESOLUTION";
        }

        public override void Execute() {
            try {
                Context.DeactivateWindowPane();
                //TODO: Implement this
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}