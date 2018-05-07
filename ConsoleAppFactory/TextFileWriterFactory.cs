using System;
using System.IO;
namespace ConsoleAppFactory
{
    public class TextFileWriterFactory
    {
        public void WriteText(string strPath, string Text)
        {  if (File.Exists(strPath))
            {
                using (StreamWriter sw =  File.AppendText(strPath))
                {
                    sw.Write(Environment.NewLine);
                    sw.Write("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    sw.Write(Environment.NewLine);
                    sw.Write(Text);
                }
            }
        }

        public void CreateFile(string strPath,string FileName)
        {            
            if (!File.Exists(System.IO.Path.Combine(strPath, FileName)))
            {
                System.IO.Directory.CreateDirectory(strPath);
                using (FileStream fs = new FileStream(System.IO.Path.Combine(strPath, FileName), FileMode.OpenOrCreate))
                {
                    using (BinaryWriter w = new BinaryWriter(fs))
                    {
                            w.Write("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!"+ Environment.NewLine);
                            w.Write(" File Created date " + DateTime.Now.ToShortDateString() + Environment.NewLine);
                            w.Write(" File Created On "+ DateTime.Now.ToShortTimeString() + Environment.NewLine);
                            w.Write(" !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                }
               
            }
        }


    }
}
