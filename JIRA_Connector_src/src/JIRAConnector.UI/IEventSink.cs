namespace JIRAConnector.UI {
    public interface IEventSink {
        void HookEvents();
        void UnHookEvents();
    }
}