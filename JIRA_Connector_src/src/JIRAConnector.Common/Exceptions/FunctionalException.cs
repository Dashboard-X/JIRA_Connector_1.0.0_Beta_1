using System;

namespace JIRAConnector.Common.Exceptions {
    public class FunctionalException : ApplicationException{
       
        public FunctionalException (string message) : base(message){}
            
    }
}
