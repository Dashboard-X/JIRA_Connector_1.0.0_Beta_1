namespace JIRAConnector.UI {
    public class UISolutionSettings {
        private string username;
        private string password;
        private string url;
        private string port;
        private string projectKey;

        public UISolutionSettings() {}

        public UISolutionSettings(string username, string password, string url, string port, string projectKey) {
            this.username = username;
            this.password = password;
            this.url = url;
            this.port = port;
            this.projectKey = projectKey;
        }

        public string Username {
            get { return username; }
            set { username = value; }
        }

        public string Password {
            get { return password; }
            set { password = value; }
        }

        public string Url {
            get { return url; }
            set { url = value; }
        }

        public string Port {
            get { return port; }
            set { port = value; }
        }

        public string ProjectKey {
            get { return projectKey; }
            set { projectKey = value; }
        }
    }
}