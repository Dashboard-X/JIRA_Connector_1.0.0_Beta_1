using System;
using System.Data;
using System.IO;
using JIRAConnector.Common;

namespace JIRAConnector.UI {
    internal class UserSettingsHelper {
        /// <summary>
        /// Checks is the solution is linked to a JIRA project
        /// </summary>
        /// <param name="uisolution">The solution to check for</param>
        /// <returns>True if the solution is linked, False otherwise</returns>
        public static bool IsSolutionLinked(UISolution uisolution) {
            bool linked = false;
            try {
                string path = Environment.GetEnvironmentVariable("AppData") + @"\JIRAConnector";
                string filename = "usersettings.xml";
                string fullPath = path + "\\" + filename;

                //if the settings file exists check for the solution.
                UserSettings data;
                DataRow solution;
                if (Directory.Exists(path)) {
                    if (File.Exists(fullPath)) {
                        data = new UserSettings();
                        data.ReadXml(fullPath);
                        if (data.Solutions.Rows.Contains(uisolution.FullName)) {
                            //the solution exists, so use it
                            solution = data.Solutions.Rows.Find(uisolution.FullName);
                            uisolution.LoadType = (SolutionLoadType) solution["LoadType"];
                            uisolution.Settings.Password = (solution["Password"] is DBNull ? "" : (string)solution["Password"]);
                            uisolution.Settings.Port = (solution["Port"] is DBNull ? "" : (string)solution["Port"]);
                            uisolution.Settings.ProjectKey = (solution["ProjectKey"] is DBNull ? "" : (string)solution["ProjectKey"]);
                            uisolution.Settings.Url = (solution["Url"] is DBNull ? "" : (string)solution["Url"]);
                            uisolution.Settings.Username = (solution["UserName"] is DBNull ? "" : (string)solution["UserName"]);
                            linked = true;
                        }
                        else {
                            //the solution doesn't exists, create it
                            data.Solutions.AddSolutionsRow(uisolution.FullName, (int) uisolution.LoadType,
                                                           uisolution.Settings.Username, uisolution.Settings.Password,
                                                           uisolution.Settings.Url, uisolution.Settings.Port,
                                                           uisolution.Settings.ProjectKey);
                        }
                    }
                }
            }
            catch (Exception e) {
                LogManager.WriteMessage(e.Message + "\n" + e.StackTrace);
            }
            return linked;
        }

        internal static bool CanSolutionBeLinked(string solutionFullName) {
            bool canBeLinked = true;

            //TODO: Implement this

            return canBeLinked;
        }

        internal static void SaveSolutionSettings(UISolution uisolution) {
            try {
                string path = Environment.GetEnvironmentVariable("AppData") + @"\JIRAConnector";
                string filename = "usersettings.xml";
                string fullPath = path + "\\" + filename;

                //if the settings file doesn't exists, create it.
                UserSettings data;
                DataRow solution;
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                data = new UserSettings();
                if (File.Exists(fullPath)) {
                    data.ReadXml(fullPath);
                }
                if (data.Solutions.Rows.Contains(uisolution.FullName)) {
                    //the solution exists, so use it
                    solution = data.Solutions.Rows.Find(uisolution.FullName);
                    solution["FullName"] = uisolution.FullName;
                    solution["LoadType"] = (int) uisolution.LoadType;
                }
                else {
                    //the solution doesn't exists, create it
                    data.Solutions.AddSolutionsRow(uisolution.FullName, (int) uisolution.LoadType,
                                                   uisolution.Settings.Username, uisolution.Settings.Password,
                                                   uisolution.Settings.Url, uisolution.Settings.Port,
                                                   uisolution.Settings.ProjectKey);
                }
                data.WriteXml(fullPath);
            }
            catch (Exception e) {
                LogManager.WriteMessage(e.Message + "\n" + e.StackTrace);
            }
        }
    }
}