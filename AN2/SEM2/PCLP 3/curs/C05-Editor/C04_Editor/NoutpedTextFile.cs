using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C04_Editor
{
    class NoutpedTextFile
    {
        public String FileName
        {
            set; get;
        }

        public String FileContent
        {
            set; get;
        }

        public bool IsSaved
        {
            set; get;
        }

        public bool save()
        {
            try
            {
                StreamWriter wr = new StreamWriter(FileName);
                wr.Write(FileContent);
                wr.Close();
                return true;
            }
            catch (Exception ex)
            {
            }

            return false;
        }
        public bool load()
        {
            try
            {
                StreamReader sr = new StreamReader(FileName);
                FileContent = sr.ReadToEnd();
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
            }

            return false;
        }
    }
}
