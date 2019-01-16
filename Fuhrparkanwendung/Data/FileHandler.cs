using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fuhrparkanwendung.Data
{
    class FileHandler
    {
        public FileHandler()
        {
        }

        public string NormalizeDirectoryPath(string argPath)
        {
            if (argPath.Contains("/"))
            {
                string[] pathElements = argPath.Split('/');
                string normalizedPath = "";
                for (int i = 0; i < pathElements.Length - 1; i++)
                {
                    normalizedPath += pathElements[i] + "/";
                }
                normalizedPath = normalizedPath.TrimEnd('/');
                return normalizedPath;
            }
            else
            {
                return "";
            }
        }

        public string NormalizeFileName(string argFile)
        {
            if (argFile.Contains("."))
            {
                string[] pathElements = argFile.Split('/');
                string[] fileElements = pathElements[pathElements.Length - 1].Split('.');
                return fileElements[0] + "." + fileElements[fileElements.Length - 1];
            }
            else
            {
                throw new Exception("A file name must at least contain one '.' .");
            }
        }

        public bool Save(string argPathToFile, string[] argContent, bool argCreateDir, bool argOverrideFile)
        {
            string pathDirectoryPart = NormalizeDirectoryPath(argPathToFile);
            string pathFileNamePart = NormalizeFileName(argPathToFile);
            string fullNormalizedPath = "";
            if (pathDirectoryPart != "")
            {
                fullNormalizedPath = pathDirectoryPart + "/" + pathFileNamePart;
            }
            else
            {
                fullNormalizedPath = pathFileNamePart;
            }
            if (!Directory.Exists(pathDirectoryPart) && argCreateDir && pathDirectoryPart != "")
            {
                try
                {
                    Directory.CreateDirectory(pathDirectoryPart);
                }
                catch
                {
                    return false;
                }
            }
            if (Directory.Exists(pathDirectoryPart) || pathDirectoryPart == "")
            {
                if (!(File.Exists(fullNormalizedPath) && !argOverrideFile))
                {
                    try
                    {
                        StreamWriter sw = new StreamWriter(fullNormalizedPath);
                        foreach (string argContentLine in argContent)
                        {
                            sw.WriteLine(argContentLine);
                        }
                        sw.Close();
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string[] Load(string argPathToFile)
        {
            string fullNormalizedPath = "";
            if (NormalizeDirectoryPath(argPathToFile) != "")
            {
                fullNormalizedPath = NormalizeDirectoryPath(argPathToFile) + "/" + NormalizeFileName(argPathToFile);
            }
            else
            {
                fullNormalizedPath = NormalizeFileName(argPathToFile);
            }
            if (File.Exists(fullNormalizedPath))
            {
                try
                {
                    List<string> allLines = new List<string>();
                    StreamReader sr = new StreamReader(fullNormalizedPath);
                    string lineContent = "";
                    while ((lineContent = sr.ReadLine()) != null)
                    {
                        allLines.Add(lineContent);
                    }
                    sr.Close();
                    return allLines.ToArray();
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public string CreateCSVHeader(string[] argFields, char argDelimiter)
        {
            string csvHeader = "";
            for (int i = 0; i < argFields.Length; i++)
            {
                csvHeader += argFields[i];
                if (i < argFields.Length - 1)
                {
                    csvHeader += argDelimiter;
                }
            }
            return csvHeader;
        }
    }
}
