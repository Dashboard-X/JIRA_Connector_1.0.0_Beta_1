using System;
using System.IO;
using System.Text;
using EnvDTE;
using EnvDTE80;

namespace JIRAConnector.Common {
    internal class OutputWindowWriter : TextWriter {
        private OutputWindowPane outputWindow;

        public OutputWindowWriter(DTE2 dte, string name) {
            outputWindow = dte.ToolWindows.OutputWindow.OutputWindowPanes.Add(name);
        }

        public override Encoding Encoding {
            get { return Encoding.Default; }
        }

        public void Clear() {
            outputWindow.Clear();
        }

        public override void Write(char c) {
            outputWindow.OutputString(c.ToString());
        }

        public override void Write(string s) {
            outputWindow.OutputString(s);
        }

        public override void WriteLine(string s) {
            outputWindow.OutputString(s + Environment.NewLine);
        }
    }
}