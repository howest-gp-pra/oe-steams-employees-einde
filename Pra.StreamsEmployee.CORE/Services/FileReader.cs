using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pra.StreamsEmployee.CORE
{
   public  class FileReader
    {
        public static string ReadFileToString(string path, string fileName)
        {
            string fileContent = "";
            string filePath = path + "\\" + fileName;
            try
            {
                using (StreamReader streamReader = new StreamReader(filePath, Encoding.UTF8))
                {
                    fileContent = streamReader.ReadToEnd();
                }
            }
            catch (IOException)
            {
                throw new IOException($"Het bestand {filePath} kan niet geopend worden.\nProbeer het te sluiten.");
            }
            catch (Exception e)
            {
                throw new Exception($"Er is een fout opgetreden. {e.Message}");
            }
            return fileContent;
        }

    }
}
