using System.Reflection;
using System.Windows.Forms;
using JIRAConnector.Common;
using JIRAConnector.UI.Dialogs;

namespace JIRAConnector.UI.Commands {
    internal class CommandHelper {
        internal static void OnAddinStartUp(UISolution solution) {
            //checks if the solution is linked to JIRA
            if (UserSettingsHelper.IsSolutionLinked(solution) && solution.LoadType != SolutionLoadType.Ask) {
                //solution is linked
                if (solution.LoadType == SolutionLoadType.Link) {
                    LoadConfiguration(solution);
                    InitializeAddIn();
                }
            }
            else {
                //solution is not linked, check if it is necessary to link it
                if (UserSettingsHelper.CanSolutionBeLinked(solution.FullName)) {
                    DialogResult result =
                        MessageBox.Show(
                            "JIRA Connector has detected a solution that hasn't been linked to JIRA. Would you like to link the solution to a JIRA project?\n Click 'YES' to link, 'NO' to never link the solution or 'CANCEL' to see this message next time this solution is opened.",
                            "JIRA Connector", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.No) {
                        solution.LoadType = SolutionLoadType.NeverLink;
                        UserSettingsHelper.SaveSolutionSettings(solution);
                    }
                    else if (result == DialogResult.Yes) {
                        LogManager.WriteMessage("Saving solution settings.");
                        solution.LoadType = SolutionLoadType.Link;
                        SolutionLinkSettings solutionSettings = new SolutionLinkSettings(solution);
                        DialogResult settingsResult = solutionSettings.ShowDialog();
                        if (settingsResult == DialogResult.OK) {
                            //Settings were entered, initializing addin
                            LoadConfiguration(solution);
                            InitializeAddIn();
                        }
                        else {
                            //User cancel settings, so we ask him next time he opens the solution
                            solution.LoadType = SolutionLoadType.Ask;
                        }
                        UserSettingsHelper.SaveSolutionSettings(solution);
                    }
                    else if (result == DialogResult.Cancel) {
                        solution.LoadType = SolutionLoadType.Ask;
                        UserSettingsHelper.SaveSolutionSettings(solution);
                    }
                }
            }
        }

        private static void LoadConfiguration(UISolution solution) {
            JiraConfigurationHelper.Password = solution.Settings.Password;
            JiraConfigurationHelper.Port = solution.Settings.Port;
            JiraConfigurationHelper.ProjectKey = solution.Settings.ProjectKey;
            JiraConfigurationHelper.Url = solution.Settings.Url;
            JiraConfigurationHelper.UserName = solution.Settings.Username;
        }

        private static void InitializeAddIn() {
            //Assembly for the usercontrol
            Assembly asm =
                Assembly.GetAssembly(typeof (JiraConnectorMainToolbar));

            // The Control ProgID for the user control
            string ctrlProgID = (typeof (JiraConnectorMainToolbar)).FullName;

            Context.ActivateWindowPane(asm.Location, ctrlProgID, "JIRA Connector");

            //Context.ActivateJiraConnToolbar();
            
            //TODO: Initialize addin for the solution
        }
    }
}