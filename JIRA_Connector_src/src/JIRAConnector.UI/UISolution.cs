using EnvDTE;

namespace JIRAConnector.UI {
    public class UISolution {
        private Solution solution;
        private SolutionLoadType loadType;
        private UISolutionSettings settings;

        public UISolution(Solution solution) {
            this.solution = solution;
        }

        public string FullName {
            get { return solution.FullName; }
        }

        public SolutionLoadType LoadType {
            get { return loadType; }
            set { loadType = value; }
        }

        public UISolutionSettings Settings {
            get {
                if (settings == null )
                    settings = new UISolutionSettings();
                return settings;
            }
            set { settings = value; }
        }
    }
}