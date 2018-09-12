using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrypoint
{
    public class TalkingLogic
    {
        public Dictionary<string, string[]> responses;
        JSONDialog jd;

        string[] keyWordArr;

        char[] splitCharArr = { '!', ',', '.', ' ', '?', '/', '-','_','>','<','|','(',')'};



        public TalkingLogic()
        {
            if(jd == null)
            {
                jd = new JSONDialog();
            }
            if (responses == null)
            {
                responses = jd.readFromFile();
            }
            if(keyWordArr == null)
            {
                fillKeywordArray(responses);
            }
            

        }

        void fillKeywordArray(Dictionary<string, string[]> inputDict)
        {
            List<string> temp = new List<string>();

            foreach(KeyValuePair<string,string[]> key in inputDict)
            {
                temp.Add(key.Key.ToString());
            }
            keyWordArr = temp.ToArray<string>();

        }

        string responseFromDictBase(string inputStr)
        {
            
            string[] iStringArr = inputStr.ToLower().Split(splitCharArr);

            string keyValue = "";
            string output = "";


            foreach(string s in keyWordArr)
            {
                for (int i = 0;i<iStringArr.Length;i++)
                {
                    if(s == iStringArr[i])
                    {
                        keyValue = s;
                        break;
                    }
                }
            }

            if(keyValue != "")
            {
                output = responses[keyValue][improvedRNG(0, responses[keyValue].Length - 1)];
            }
            else
            {
                output = responses["default"][improvedRNG(0, responses["default"].Length - 1)];
            }

            return output;
        }

        public Task<string> responseFromDictTask(string inputStrTask)
        {
            return Task.Factory.StartNew(() => responseFromDictBase(inputStrTask));
        }


        int improvedRNG(int min,int max)
        {
            Random rng = new Random();
            return rng.Next(min, max);
        }

    }
}
