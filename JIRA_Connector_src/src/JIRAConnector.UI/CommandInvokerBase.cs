using System.Collections.Generic;
using JIRAConnector.UI.Commands;

namespace JIRAConnector.UI {
    public abstract class CommandInvokerBase : ICommandInvoker {
        private CommandBase selectedCommand;
        private IDictionary<string, CommandBase> commandList;

        public void AddCommand(CommandBase command) {
            CommandList.Add(command.Name, command);
        }

        public void RemoveCommand(CommandBase command) {
            if (commandList != null) {
                commandList.Remove(command.Name);
            }
        }

        public void SetCommand(string commandName) {
            selectedCommand = CommandList[commandName];
            selectedCommand.Parameters.Clear();
        }

        public void Execute() {
            selectedCommand.Execute();
        }

        public CommandBase SelectedCommand {
            get { return selectedCommand; }
        }
        
        private IDictionary<string,CommandBase> CommandList {
            get {
                if (commandList == null){
                    commandList = new Dictionary<string, CommandBase>();
                }
                return commandList;
            }
        }
        
    }
}