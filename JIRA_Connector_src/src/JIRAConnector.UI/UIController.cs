using System;
using System.Collections.Generic;
using System.Windows.Forms;
using JIRAConnector.Common;
using JIRAConnector.Common.Exceptions;
using JIRAConnector.Core;
using JIRAConnector.UI.Commands;
using JIRAConnector.UI.Dialogs;

namespace JIRAConnector.UI {
    public class UIController {
        private IList<IEventSink> sinks = null;
        private IJiraProxy jiraProxy;
        private JiraConnectorMainToolbar mainToolbar;
        BusinessObjectBindingList<Issue> unresolvedIssuesCache = null;

        /// <summary>
        /// Returns a instance of the Proxy class to JIRA.
        /// </summary>
        private IJiraProxy Proxy {
            get {
                if (jiraProxy == null){
                    jiraProxy = new JiraProxy();
                }
                return jiraProxy;
            }
        }

        public BusinessObjectBindingList<Issue> GetAllIssuesFromProject(string projectName) {
            BusinessObjectBindingList<Issue> issues = null;
            try {
                issues = Proxy.GetAllIssuesFromProject(projectName);
            }
            catch (Exception ex) {
                HandleException(ex);
            }
            return issues;
        }

        private void HandleException(Exception ex) {
            if (ex is FunctionalException) {
                DisplayErrorMessage(ex.Message, "Functional Error");
            }
            else {
                LogManager.WriteMessage(ex.Message + "\n" + ex.StackTrace);
                DisplayErrorMessage(JiraConfigurationHelper.GetTechnicalErrorMessage(), "Technical Error");
            }
        }

        internal void Init(ICommandInvoker solutionInvoker, ICommandInvoker addinInvoker) {
            LogManager.Create(Context.Output);
            LogManager.WriteMessage("Initializing commands.");
            solutionInvoker.AddCommand(new OpenSolutionCommand(this));
            solutionInvoker.AddCommand(new CloseSolutionCommand(this));

            addinInvoker.AddCommand(new AddinStartupCommand(this));
            addinInvoker.AddCommand(new AddinDisconnectCommand(this));
        }

        public IList<IEventSink> Sinks {
            get {
                if (sinks == null) {
                    sinks = new List<IEventSink>();
                }
                return sinks;
            }
        }
        
        /// <summary>
        /// Displays a MessageBox containing an error message 
        /// </summary>
        /// <param name="errorMessage">The error message displayed to the user</param>
        /// <param name="errorTitle">The heading of the MessageBox dialog</param>
        internal void DisplayErrorMessage(string errorMessage, string errorTitle) {
            MessageBox.Show(errorMessage,"JiraConnector Error: " + errorTitle,MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Displays a MessageBox containing an informative message 
        /// </summary>
        /// <param name="informationMessage">The  message displayed to the user</param>
        /// <param name="title">The heading of the MessageBox dialog</param>
        internal void DisplayInformationMessage(string informationMessage, string title){
            MessageBox.Show(informationMessage, "JiraConnector Info: " + title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        /// <summary>
        /// Handles the request to show all the details for a selected issue in the main toolbar
        /// </summary>
        /// <param name="selectedIssue">The <c>Issue</c> whose details are going to be shown</param>
        internal void HandleFullIssueDetailRequest(Issue selectedIssue) {
            if (selectedIssue != null)
            {
                try {
                    //Since the issues shown in the main window only have basic info, we need to ask for the other stuff to the Proxy.
                    Proxy.AddDetailedInfoToIssue(selectedIssue);
                    this.DisplayFullIssueDetail(selectedIssue);    
                } catch (Exception e) {
                    this.HandleException(e);
                }
            }else{
              DisplayErrorMessage("There's no Issue selected", "Error Displaying Details for an Issue");
          }
        }
        
        /// <summary>
        /// Displays a Dialog containing detailed information about an Issue
        /// </summary>
        /// <param name="issue">The <c>Issue</c> whose details are going to be shown</param>
        private void DisplayFullIssueDetail(Issue issue) {
            IssueDetailsDialog dialog = new IssueDetailsDialog(issue);
            dialog.ShowDialog();
        }

        /// <summary>
        /// Handles the user request to add a comment to an Issue
        /// </summary>
        /// <param name="selectedIssue">The <c>Issue</c> entity to which the comment will be added</param>
        internal void HandleAddCommentToIssueRequest(Issue selectedIssue){
            if (selectedIssue != null){
                try{
                    IssueCommentDialog dialog = new IssueCommentDialog();
                    dialog.ShowDialog();
                    string commentText = dialog.Comment;
                    if (dialog.Comment != String.Empty)
                        Proxy.AddCommentToIssue(selectedIssue, commentText);
                    else
                        DisplayErrorMessage("No text has been entered","Adding a Comment");
                    dialog.Dispose();
                }
                catch (Exception e){
                    this.HandleException(e);
                }
            }
            else{
                DisplayErrorMessage("There's no Issue selected", "Error adding a commento to an Issue");
            }
        }
        
        /// <summary>
        /// Handles the user request to resolve an issue
        /// </summary>
        /// <param name="selectedIssue">The <c>Issue</c> entity to resolve</param>
        internal void HandleResolveIssueRequest(Issue selectedIssue) {
            if (selectedIssue != null){
                try{
                    ResolveIssueDialog resolveIssueDialog = new ResolveIssueDialog(this.Proxy.GetAllResolutions());
                    if (resolveIssueDialog.ShowDialog()==DialogResult.OK) {
                        this.Proxy.ResolveIssue(selectedIssue, resolveIssueDialog.selectedResolution, resolveIssueDialog.ResolutionComment);
                        this.unresolvedIssuesCache.Remove(selectedIssue);
                        this.MainToolbar.RefreshIssuesToShow();
                    }
                    resolveIssueDialog.Dispose();
                }
                catch (Exception e){
                    this.HandleException(e);
                }
            }
            else{
                DisplayErrorMessage("There's no Issue selected", "Error resolving an Issue");
            }
        }

        /// <summary>
        /// Handles the user request to close an issue
        /// </summary>
        /// <param name="selectedIssue">The <c>Issue</c> entity to close</param>
        internal void HandleCloseIssueRequest(Issue selectedIssue) {
            if (selectedIssue != null) {
                try {
                    ResolveIssueDialog resolveIssueDialog = new ResolveIssueDialog(this.Proxy.GetAllResolutions());
                    if (resolveIssueDialog.ShowDialog() == DialogResult.OK) {
                        this.Proxy.CloseIssue(selectedIssue, resolveIssueDialog.selectedResolution, resolveIssueDialog.ResolutionComment);
                        this.unresolvedIssuesCache.Remove(selectedIssue);
                        this.MainToolbar.RefreshIssuesToShow();
                    }
                    resolveIssueDialog.Dispose();
                } catch (Exception e) {
                    this.HandleException(e);
                }
            } else {
                DisplayErrorMessage("There's no Issue selected", "Error closing an Issue");
            }
        }

        internal List<string> GetAllProjectKeys() {
            List<string> ret = new List<string>();
            try {
              ret = Proxy.GetAllProjectKeysForCurrenUser();
                
            }catch(Exception e) {
                this.HandleException(e);
            }
            return ret;
        }

        public void HandleTestSettingsRequest(SolutionLinkSettings settingsDialog){
            try {
                //Try to authenticate the user first
                Proxy.AuthenticateUser( settingsDialog.Solution.Settings.Url, 
                                    settingsDialog.Solution.Settings.Port,
                                    settingsDialog.Solution.Settings.Username,
                                    settingsDialog.Solution.Settings.Password);

                //If the login was sucessful, we save to memory te settings entered by the user so we can obtain the project keys
                JiraConfigurationHelper.Password = settingsDialog.Solution.Settings.Password;
                JiraConfigurationHelper.Port = settingsDialog.Solution.Settings.Port;
                JiraConfigurationHelper.Url = settingsDialog.Solution.Settings.Url;
                JiraConfigurationHelper.UserName = settingsDialog.Solution.Settings.Username;
                
                List<string> keys = this.GetAllProjectKeys();
             
                settingsDialog.DisplayProjectKeys(keys);
            }
            catch (Exception e){
                settingsDialog.DisplayTestFailedMessage();
                this.HandleException(e);
            }
            
        }

        /// <summary>
        /// Handles user request to log work done for an Issue
        /// </summary>
        /// <param name="selectedIssue">The issue that the user wants to log work on</param>
        public void HandleLogWorkDoneRequest(Issue selectedIssue) {
            if (selectedIssue != null){
                try{
                    LogWorkDoneDialog dialog = new LogWorkDoneDialog(selectedIssue);
                    if (dialog.ShowDialog()==DialogResult.OK && dialog.WorkDone != String.Empty) {
                        Proxy.LogWorkDone(selectedIssue, dialog.WorkDone, dialog.WorkDescription);
                    }
                    dialog.Dispose();
                }
                catch (Exception e){
                    this.HandleException(e);
                }
            }
            else{
                DisplayErrorMessage("There's no Issue selected", "Error logging work done");
            }
        }

        /// <summary>
        /// Gets all the unresolved issues assigned to the current user and store them into a local cache
        /// </summary>
        /// <param name="projectKey"></param>
        /// <returns></returns>
        public BusinessObjectBindingList<Issue> GetOpenIssuesFromProject(string projectKey){
            try{
                if (this.unresolvedIssuesCache == null) {
                    unresolvedIssuesCache = Proxy.GetOpenIssuesFromProject(projectKey);
                }
            }
            catch (Exception ex){
                HandleException(ex);
            }
            return unresolvedIssuesCache;
        }

        public JiraConnectorMainToolbar MainToolbar {
            get { return mainToolbar; }
            set { mainToolbar = value; }
        }

        /// <summary>
        /// Handles the user request to indicates that he/she has started to work on an issue
        /// </summary>
        /// <param name="selectedIssue">The <c>Issue</c> entity whose progress is being marked as started</param>
        public void HandleStartIssueProgressRequest(Issue selectedIssue){
            if (selectedIssue != null){
                try{
                    this.Proxy.StartIssueProgress(selectedIssue);
                    selectedIssue.Status = "In Progress";
                    this.MainToolbar.RefreshIssuesToShow();
                }
                catch (Exception e){
                    this.HandleException(e);
                }
            }
            else{
                DisplayErrorMessage("There's no Issue selected", "Error starting progress on an Issue");
            }
        }

        public void HandleRefreshIssuesRequest() {
            RefreshIssues();
        }

        private void RefreshIssues()
        {
            this.InvalidateUnresolvedIssuesCache();
            this.unresolvedIssuesCache = GetOpenIssuesFromProject(JiraConfigurationHelper.getCurrentProjectKey());
            MainToolbar.RefreshIssuesToShow();
        }

        private void InvalidateUnresolvedIssuesCache() {
            this.unresolvedIssuesCache = null;
        }


        internal void HandleAboutRequest()        {
            AboutDialog about = new AboutDialog();
            about.ShowDialog();
        }

        internal void HandleStopIssueProgressRequest(Issue selectedIssue) {
            if (selectedIssue != null){
                try {
                    this.Proxy.StopIssueProgress(selectedIssue);
                    RefreshIssues();
                }
                catch (Exception e){
                    this.HandleException(e);
                }
            }
            else{
                DisplayErrorMessage("There's no Issue selected", "Error stopping progress on an Issue");
            }
        }
    }
}