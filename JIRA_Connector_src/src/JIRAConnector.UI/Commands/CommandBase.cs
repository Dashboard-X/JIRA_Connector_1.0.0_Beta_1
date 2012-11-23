using System.Collections.Generic;

namespace JIRAConnector.UI.Commands {
    public abstract class CommandBase {
        protected string name;
        protected IDictionary<string, object> parameters;
        protected UIController controller;

        public CommandBase(UIController controller) {
            this.controller = controller;
        }
        
        public abstract void Execute();

        public string Name {
            get { return name; }
        }

        public IDictionary<string, object> Parameters {
            get {
                if (parameters == null) {
                    parameters = new Dictionary<string, object>();
                }
                return parameters;
            }
        }
    }
}