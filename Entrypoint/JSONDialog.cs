using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Entrypoint
{
    class JSONDialog
    {
        string _folderName = "responses";
        string _fileName = "responses.json";

        Dictionary<string, string[]> _responsesDict = new Dictionary<string, string[]>();


        public JSONDialog()
        {
            
            if (!checkFileExists())
            {
                MakeFileIfNeeded();
                WriteToJson();
            }
        }

        void MakeFileIfNeeded()
        {
            string _wholePath = $"{_folderName}\\{_fileName}";

            if (!Directory.Exists(_folderName))
            {
                Directory.CreateDirectory(_folderName);
            }
            if (!File.Exists(_wholePath))
            {
                File.Exists(_wholePath);
            }
        }

        public bool checkFileExists()
        {
            string _wholePath = $"{_folderName}\\{_fileName}";

            return File.Exists(_wholePath);
        }

        void WriteToJson()
        {
            string _wholePath = $"{_folderName}\\{_fileName}";

            string greet = "greetings";
            string[] greetArr = { "Salutations mortal." };

            _responsesDict.Add(greet, greetArr);

            using (StreamWriter sw = new StreamWriter(_wholePath))
            {
                string strToWrite = JsonConvert.SerializeObject(_responsesDict, Formatting.Indented);
                sw.WriteLine(strToWrite);
            }

        }

        public Dictionary<string,string[]> readFromFile()
        {
            string _wholePath = $"{_folderName}\\{_fileName}";

            Dictionary<string, string[]> dictToReturn;

            using(StreamReader sr = new StreamReader(_wholePath))
            {
                string fileContent = sr.ReadToEnd();
                dictToReturn = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(fileContent);

            }

            return dictToReturn;

        }
    }
}
