using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pra.StreamsEmployee.CORE.Services
{
    public class FileWriter
    {
        public static bool WriteStringToFile(string content, string path, string fileName)
        {
            bool successfull = false;
            if (!Directory.Exists(path))
                throw new Exception($"Het opgegeven pad {path} bestaat niet!");
            string fullPath = path + "\\" + fileName;

            if (File.Exists(fullPath))
            {
                try
                {
                    File.Delete(fullPath);
                }
                catch
                {
                    throw new Exception($"De bestandsnaam {fileName} in de map {path} is momenteel in gebruik.\nProbeer later opnieuw");
                }
            }

            try
            {
                using (FileStream fileStream = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        streamWriter.Write(content);
                        streamWriter.Close();
                    }
                }
                successfull = true;
            }
            catch (Exception e)
            {
                throw new Exception($"Er is een fout opgetreden. {e.Message}");
            }
            return successfull;
        }


    }
}
