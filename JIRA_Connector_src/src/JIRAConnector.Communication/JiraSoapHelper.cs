using JIRAConnector.Common;
using JIRAConnector.Communication.JiraWebService;

namespace JIRAConnector.Communication
{
    public class JiraSoapHelper{
        public static JiraSoapServiceService GetJiraSoapServiceProxy() {
            return GetWSProxy(JiraConfigurationHelper.GetJiraURL(), JiraConfigurationHelper.getJiraPort());
        }
        
        public static JiraSoapServiceService GetJiraSoapServiceProxy(string url, string port) {
            return GetWSProxy(url, port);
        }
        
        private static JiraSoapServiceService GetWSProxy(string url, string port) {
            JiraSoapServiceService proxy = new JiraSoapServiceService();
            proxy.Url = url + ":" + port + "/rpc/soap/jirasoapservice-v2";
            return proxy;
        }
    }
}
