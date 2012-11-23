namespace JIRAConnector.Common {
    public class JiraConfigurationHelper {
        private static string userName;
        private static string password;
        private static string url;
        private static string port;
        private static string projectKey;

        public static string GetUserName() {
            return userName;
        }

        public static string GetUserPassword() {
            return password;
        }

        public static string GetJiraURL() {
            return url;
        }

        public static string getJiraPort() {
            return port;
        }

        public static string getCurrentProjectKey() {
            return projectKey;
        }

        public static string GetTechnicalErrorMessage() {
            return "A technical error has ocurred during the operation. Watch de output window for details.";
        }

        public static string UserName {
            set { userName = value; }
        }

        public static string Password {
            set { password = value; }
        }

        public static string Url {
            set { url = value; }
        }

        public static string Port {
            set { port = value; }
        }

        public static string ProjectKey {
            set { projectKey = value; }
        }
    }
}