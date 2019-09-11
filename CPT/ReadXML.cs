using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CPT
{
    class ReadXML
    {
        public class Issue
        {
            public string code;
            public int pages;

            public Issue(string _code, int _pages)
            {
                this.code = _code;
                this.pages = _pages;
            }

            public void addPage()
            {
                pages++;
            }
        }

        public List<Issue> IssuesList = new List<Issue>();

        public ReadXML()
        {
        }
        
        public void Load(string fileName)
        {
            XDocument myFile = XDocument.Load(fileName);

            Clear();

            foreach (XElement page in myFile.Elements("publication_plan").Elements("page"))
            {
                string edition = page.Element("base_editions").Value;
                if (edition.Length != 2)
                {
                    int pNum = Convert.ToInt32(page.Element("physical_page_number").Value);
                    string section = page.Element("section").Value;

                    int index = IssuesList.FindIndex(e => e.code == edition);
                    if (index == -1)
                    {
                        Issue ei = new Issue(edition, 1);
                        IssuesList.Add(ei);
                    }
                    else
                    {
                        IssuesList.ElementAt(index).addPage();
                    }
                }
            }
        }

        private void Clear()
        {
            if (IssuesList.Count != 0)
                IssuesList.Clear();
        }
    }
}
