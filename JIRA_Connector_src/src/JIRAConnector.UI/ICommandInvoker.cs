using JIRAConnector.UI.Commands;
namespace JIRAConnector.UI {
    public interface ICommandInvoker {
        void AddCommand(CommandBase command);
        void RemoveCommand(CommandBase command);
        void SetCommand(string commandName);
        void Execute();
        CommandBase SelectedCommand
        {
            get;
        }
    }
}