using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace UrlToXMLTask.Logic
{
    public class ExportToXml : File
    {
        private string savePath;
        private List<List<string>> listOfUrls = new List<List<string>>();

        public ExportToXml(string savePath, string path) 
            : base (path)
        {
            this.savePath = savePath;
            CreateList(base.Records);
        }

        public bool Export()
        {
            List<XElement> elements = new List<XElement>();

            foreach (var url in listOfUrls)
            {
                if (!url.Last().Contains('?'))
                {
                    elements.Add(new XElement("url",
                    new XElement("scheme", new XAttribute("type", url[0])),
                    new XElement("host", new XAttribute("name", url[1])),
                    from n in url.Skip(2)
                    select new XElement("uri",
                        new XElement("segment", n))
                    ));
                }
                else if (url.Last().Contains('?')&& url.Last().Contains('='))
                {
                    string[] str = url.Last().Trim('?').Split('=');

                    elements.Add(new XElement("url",
                    new XElement("scheme", new XAttribute("type", url[0])),
                    new XElement("host", new XAttribute("name", url[1])),
                    from n in url.Skip(2).Reverse().Skip(1).Reverse()
                    select new XElement("uri",
                        new XElement("segment", n)),
                    new XElement("parameters", 
                        new XElement("parameter",
                            new XAttribute("key",str[0]),
                            new XAttribute("value",str[1])))
                    ));
                }
                else
                {
                    elements.Add(new XElement("urlAdress",
                    new XElement("scheme", new XAttribute("type", url[0])),
                    new XElement("host", new XAttribute("name", url[1])),
                    from n in url.Skip(2).Reverse().Skip(1).Reverse()
                    select new XElement("uri",
                        new XElement("segment", n)),
                    new XElement("parameters",
                        new XElement("parameter",
                            new XAttribute("key", "")))
                    ));
                }                
            }

            XDocument doc = new XDocument(new XElement ("url",elements));
            XDeclaration xDeclaration = new XDeclaration("1.0", "UTF-8", "yes");
            doc.Declaration = xDeclaration;
            doc.Save(savePath);

            return true;

        }

        private void CreateList(List<string> records)
        {
            if (records == null)
            {
                throw new ArgumentNullException("File without records");
            }

            foreach(var record in records)
            {
                listOfUrls.Add(ParsingRecord(record));
            }
        }

        private List<string> ParsingRecord(string record)
        {

            List<string> obj = new List<string>();
            StringBuilder temp = new StringBuilder(record);

            //add http or https
            obj.Add(record.Split(new string[] { "://" }, StringSplitOptions.RemoveEmptyEntries).First());
            temp = temp.Remove(0, record.Contains("http://") ? 7 : 8);

            //add host name
            obj.Add(temp.ToString().Split('/').First());
            temp = temp.Remove(0, temp.ToString().IndexOf('/') + 1);

            //add other parameters
            string[] strArray = temp.ToString().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in strArray)
            {
                if (s.Contains('?'))
                {
                    string[] tempParameter = s.Split('?');
                    obj.Add(tempParameter[0]);
                    obj.Add("?" + tempParameter[1]);
                }
                else
                {
                    obj.Add(s);
                }
            }

            return obj;
        }
    }
}
