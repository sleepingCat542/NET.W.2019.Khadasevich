using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UrlToXMLTask
{
    public class File
    {
        private string path;
        private List<string> records = new List<string>();

        public File(string path)
        {
            this.path = path;
            ReturnList();
        }

        public List<string> Records
        {
            get
            {
                if (records.Count != 0)
                {
                    return records;
                }
                else
                {
                    throw new ArgumentNullException("File without records");
                }
            }
        }


        private void ReturnList()
        {
            try
            {
                if (ReadFile())
                {
                    foreach (var record in records)
                    {
                        if (string.IsNullOrWhiteSpace(record))
                        {
                            records.Remove(record);
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        private bool ReadFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        records.Add(reader.ReadLine());
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        


    }
}
