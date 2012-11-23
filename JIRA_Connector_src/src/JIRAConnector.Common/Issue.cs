using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace JIRAConnector.Common{
    [XmlRoot("item")]
    public class Issue{
        private string title;
        private string link;
        private string description;
        private string summary;
        private string type;
        private string priority;
        private string status;
        private string resolution;
        private string assignee;
        private string reporter;
        private string created;
        private string updated;
        private List<IssueComment> comments;
        private IssueIdentificator identificator;
        private string originalEstimate;
        private string remainingEstimate;
        private string dueDate;
        private string timeSpent;
        private string[] fixVersions;
        private string[] affectsVersions;
        private string component;
        

        [Browsable(false)]
        [XmlElement("key")]
        public IssueIdentificator Identificator{
            get { return identificator; }
            set { identificator = value; }
        }
        
        [Browsable(false)]
        [XmlElement("title")]
        public string Title {
            get { return title; }
            set { title = value; }
        }

        [Browsable(false)]
        [XmlElement("link")]
        public string Link {
            get { return link; }
            set { link = value; }
        }

        [Browsable(false)]
        [XmlElement("description")]
        public string Description {
            get { return description; }
            set { description = value; }
        }

        [XmlIgnore()]
        public string Key{
            get { return this.Identificator.key; }
            set { this.Identificator.key = value; }
        }

        [XmlElement("summary")]
        public string Summary{
            get { return this.summary; }
            set { this.summary = value; }
        }

        [XmlElement("type")]
        public string Type{
            get { return this.type; }
            set { this.type = value; }
        }

        [XmlElement("priority")]
        public string Priority{
            get { return this.priority; }
            set { this.priority = value; }
        }

        [XmlElement("status")]
        public string Status{
            get { return this.status; }
            set { this.status = value; }
        }

        [Browsable(false)]
        [XmlElement("resolution")]
        public string Resolution {
            get { return resolution; }
            set { resolution = value; }
        }

        [Browsable(false)]
        [XmlElement("assignee")]
        public string Assignee{
            get { return this.assignee; }
            set { this.assignee = value; }
        }

        [XmlElement("reporter")]
        public string Reporter{
            get { return this.reporter; }
            set { this.reporter = value; }
        }

        [Browsable(true)]
        [XmlElement("created")]
        public string Created {
            get {
                //to get rid of those annoying extra characters in the string representation of the datetime.
                return created.Substring(5, 11);
            }
            set { created = value; }
        }

        [Browsable(false)]
        [XmlElement("updated")]
        public string Updated {
            get {
                //to get rid of those annoying extra characters in the string representation of the datetime.
                return updated.Substring(5,11);
            }
            set { updated = value; }
        }

        [Browsable(false)]
        public List<IssueComment> Comments {
            get { return comments; }
            set { comments = value; }
        }
        
        [Browsable(false)]
        public string Id {
            get { return this.Identificator.id; }
        }

        public Issue() {
            this.identificator = new IssueIdentificator();
        }

        public override bool Equals(object obj){
            return (((Issue)obj).Id == this.Id);
        }

        public override int GetHashCode(){
            return Int32.Parse(this.Id);
        }

        [Browsable(false)]
        [XmlElement("timeoriginalestimate")]
        public string OriginalEstimate {
            get { return originalEstimate; }
            set { originalEstimate = value; }
        }

        [Browsable(false)]
        [XmlElement("timeestimate")]
        public string RemainingEstimate {
            get { return remainingEstimate; }
            set { remainingEstimate = value; }
        }

        [Browsable(false)]
        [XmlElement("due")]
        public string DueDate {
            get {
                if (dueDate != String.Empty)
                    return dueDate.Substring(5,11);
                
                return dueDate;
            }
            set { dueDate = value; }
        }

        [Browsable(false)]
        [XmlElement("timespent")]
        public string TimeSpent {
            get { return timeSpent; }
            set { timeSpent = value; }
        }

        [Browsable(false)]
        [XmlElement("fixVersion")]
        public string[] FixVersions
        {
            get { return fixVersions; }
            set { fixVersions = value; }
        }

        [Browsable(false)]
        [XmlElement("version")]
        public string[] AffectsVersions
        {
            get { return affectsVersions; }
            set { affectsVersions = value; }
        }

        [Browsable(true)]
        [XmlElement("component")]
        public string Component
        {
            get { return component; }
            set { component = value; }
        }
    }
   
    public class IssueIdentificator {
       [XmlAttribute("id")]
       public string id;
        [XmlText()]
        public string key;
    }
    
}
