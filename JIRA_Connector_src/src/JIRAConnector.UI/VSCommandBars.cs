using System;
using System.Reflection;
using EnvDTE;

namespace JIRAConnector.UI {
    /// <summary>
    /// A class that wraps operations on the VS command bar model
    /// </summary>
    internal class VSCommandBars {
        protected object[] contextGuids = new object[] {};
        public const int AddCommandBarToEnd = -1;
        private object commands;
        private Type commandsType;
        private Type dteType;
        private _DTE dte;

        private object commandBars;
        private Type commandBarsType;


        private VSCommandBars() {
            commands = Context.DTE.Commands;
            commandsType = Context.DTE.Commands.GetType();

            dte = Context.DTE;
            dteType = Context.DTE.GetType();

            commandBars = dte.GetType().InvokeMember(
                "CommandBars", BindingFlags.GetProperty, null,
                Context.DTE, new object[] {});
            commandBarsType = commandBars.GetType();
        }

        public static VSCommandBars Create() {
            return new VSCommandBars();
        }

        public Command AddNamedCommand(string commandName, string text, string tooltip,
                                       ResourceBitmaps bitmapId, int status) {
            ParameterModifier pm = new ParameterModifier(7);
            for (int i = 0; i < 7; i++) {
                pm[i] = false;
            }

            // the 7th argument is a ref parameter
            pm[6] = true;

            return (Command) commandsType.InvokeMember(
                                 "AddNamedCommand2", BindingFlags.InvokeMethod, null,
                                 commands, new object[] {
                                                            Context.AddInInstance,
                                                            commandName,
                                                            text,
                                                            tooltip,
                                                            true,
                                                            59,
                                                            contextGuids
                                                            // The status parameter is not passed (yet)
                                                            // VS 2005 beta2 breaks with this parameter
                                                            // we will add it when most people have switched to final
                                                        },
                                 new ParameterModifier[] {pm}, null, null);
        }

        public object GetCommandBar(string name) {
            try {
                return commandBarsType.InvokeMember(
                    "Item", BindingFlags.GetProperty, null,
                    commandBars, new object[] {name});
            }
            catch (TargetInvocationException ex) {
                // swallow, command bar not found
                if (ex.InnerException is ArgumentException) {
                    return null;
                }
                else {
                    throw;
                }
            }
        }

        public object AddCommandBar(string name,
                                    vsCommandBarType type, object parent, int position) {
            if (position == AddCommandBarToEnd && parent != null) {
                object controls = parent.GetType().InvokeMember("Controls",
                                                                BindingFlags.GetProperty, null, parent,
                                                                new object[] {});
                position = (int) controls.GetType().InvokeMember("Count",
                                                                 BindingFlags.GetProperty, null, controls,
                                                                 new object[] {});
                position = position + 1;
            }
            parent = parent == null ? Type.Missing : parent;
            object objPosition = parent == null ? Type.Missing : position;
            return commandsType.InvokeMember("AddCommandBar",
                                             BindingFlags.InvokeMethod, null, commands,
                                             new object[] {
                                                              name, type,
                                                              parent, objPosition
                                                          });
        }

        public void SetControlToolTip(object control, string tooltip) {
            control.GetType().InvokeMember("TooltipText", BindingFlags.SetProperty, null,
                                           control, new object[] {tooltip});
        }

        public void SetControlCaption(object control, string caption) {
            control.GetType().InvokeMember("Caption", BindingFlags.SetProperty, null,
                                           control, new object[] {caption});
        }

        public object AddControl(object command, object owner, int position) {
            return command.GetType().InvokeMember("AddControl",
                                                  BindingFlags.InvokeMethod, null, command,
                                                  new object[] {owner, position});
        }

        public void SetControlTag(object control, string tag) {
            control.GetType().InvokeMember("Tag",
                                           BindingFlags.SetProperty, null, control, new object[] {tag});
        }

        public object GetBarControl(object bar, string name) {
            try {
                return bar.GetType().InvokeMember(
                    "Controls", BindingFlags.GetProperty, null,
                    bar, new object[] {name});
            }
            catch (TargetInvocationException ex) {
                // swallow, means the control wasn't found
                if (ex.InnerException is ArgumentException) {
                    return null;
                }
                else {
                    throw;
                }
            }
        }

        public object GetPopupCommandBar(object popup) {
            return popup.GetType().InvokeMember(
                "CommandBar", BindingFlags.GetProperty, null,
                popup, new object[] {});
        }

        public object FindControl(object bar, string name) {
            return bar.GetType().InvokeMember("FindControl",
                                              BindingFlags.InvokeMethod, null, bar,
                                              new object[] {
                                                               Type.Missing,
                                                               Type.Missing,
                                                               name,
                                                               Type.Missing,
                                                               Type.Missing
                                                           });
        }
    }
}