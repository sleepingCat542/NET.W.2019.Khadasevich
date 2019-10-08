using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlToXMLTask.Logic;


namespace NET.W._2019.Khadasevich._19._01
{
    class Program
    {
        static void Main(string[] args)
        {
            ExportToXml first = new ExportToXml("first.xml","first.txt");
            first.Export();

            ExportToXml second = new ExportToXml("second.xml", "second.txt");
            second.Export();

            ExportToXml third = new ExportToXml("third.xml", "third.txt");
            third.Export();
        }       
    }
}
