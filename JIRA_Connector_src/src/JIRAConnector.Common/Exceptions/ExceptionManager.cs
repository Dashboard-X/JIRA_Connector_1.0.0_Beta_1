using System;
using System.Net;
using System.Web.Services.Protocols;

namespace JIRAConnector.Common.Exceptions{
    public class ExceptionManager{
        
        public static void PublishException(Exception ex) {
           if (ex is FunctionalException ) {
                throw ex;
            }else if (ex is SoapException) {
                PublishSoapException((SoapException) ex);
            }else if (ex is WebException) {
                throw new FunctionalException("Error connecting to JIRA: invalid URL or Port");
            }
            else {
                LogManager.WriteDebugMessage("TECHNICAL ERROR: " + ex.Message + "\n" + ex.StackTrace);
                throw new TechnicalException();
            }
        }

        private static void PublishSoapException(SoapException ex){
            if (ex.Detail.FirstChild.Name.Contains("RemoteAuthenticationException")){
                throw new FunctionalException("Error authenticating to JIRA: bad UserName or Password");
            }else{
                LogManager.WriteDebugMessage("TECHNICAL ERROR: " + ex.Message + "\n" + ex.StackTrace);
                throw new TechnicalException();
            }
        }
    }
}
