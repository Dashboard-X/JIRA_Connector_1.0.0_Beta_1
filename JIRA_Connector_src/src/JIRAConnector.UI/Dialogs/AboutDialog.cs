using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace JIRAConnector.UI.Dialogs
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
            lblVersion.Text += Assembly.GetExecutingAssembly().GetName().Version.ToString();
            object[] o = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute),false);
            lblVersion.Text += " " + ((System.Reflection.AssemblyInformationalVersionAttribute)(o[0])).InformationalVersion;
            
        }
    }
}