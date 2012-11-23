using System.IO;

namespace JIRAConnector.Common {
    /// <summary>
    /// Manages the writing of debug and log messages to the output window of Visual Studio
    /// </summary>
    public class LogManager {
        private TextWriter textWriter = null;
        private static LogManager logManager = null;

        private LogManager(TextWriter writer) {
            textWriter = writer;
        }

        public TextWriter TextWriter {
            get { return textWriter; }
        }

        public static LogManager Instance() {
            return logManager;
        }

        public static void Create(TextWriter textWriter) {
            logManager = new LogManager(textWriter);
        }

        /// <summary>
        /// Writes a mesagge to the output window of Visual Studio
        /// </summary>
        /// <param name="text">The message to be written</param>
        public static void WriteMessage(string text) {
            Instance().TextWriter.WriteLine(text);
        }

        /// <summary>
        /// Writes a debug message to the output window of Visual Studio,
        /// ONLY if the option "debug-mode=true" is set in the configuration file
        /// </summary>
        /// <param name="text">The message to be written</param>
        public static void WriteDebugMessage(string text) {
            //TODO: Only print if debug mode is enabled through configuration
            Instance().TextWriter.WriteLine("**DEBUG** :" + text);
        }
    }
}