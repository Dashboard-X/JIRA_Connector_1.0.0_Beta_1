using System;

namespace JIRAConnector.Common{
    public class IssueComment{
        private string author;
        private DateTime? date;
        private string text;

        public IssueComment() {
        }

        public IssueComment(string author, DateTime? date, string text) {
            this.author = author;
            this.date = date;
            this.text = text;
        }

        public string Author {
            get { return author; }
            set { author = value; }
        }

        public DateTime? Date{
            get { return date; }
            set { date = value; }
        }

        public string Text {
            get { return text; }
            set { text = value; }
        }
    }
}
