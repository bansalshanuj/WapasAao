using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WapasAao
{
    public class JsonUtilities
    {
        public static string[] JsonParse(string json)
        {
            string[] result = { string.Empty };
            if (string.IsNullOrEmpty(json) || json.Length < 2)/* not a valid json */
                return result;
            string[] parts;
            char[] dem = { ',', ':' };
            parts = json.Substring(1, json.Length - 2).Split(dem);
            if (parts.Length < 2) /*had no value*/
                return result;
            result = new string[parts.Length / 2];
            for (int i = 0; i < parts.Length / 2; i++)
            {
                result[i] = parts[2 * i].Substring(1, parts[2 * i].Length - 2);
                result[i] = result[i].Replace("\\\"", "\"");
                result[i] = result[i].Trim();
            }
            return result;
        }


        public static string[] GetValueListFromJSONArray(string jsonString)
        {
            List<string> valueList = new List<string>();

            if (string.IsNullOrEmpty(jsonString)
            || jsonString.Equals("null")
            )
                return valueList.ToArray();
            try
            {
                JArray jo = JArray.Parse(jsonString);
                foreach (JToken token in jo.Values())
                {
                    if (token.Type == JsonTokenType.String)
                        valueList.Add(token.Value<string>().Trim());
                }
            }
            catch (Exception e)
            {
                valueList.Add(jsonString);
                return valueList.ToArray();
            }

            return valueList.ToArray();
        }

        public static string EncodeToJSONArray(string str)
        {
            string[] strArray = new string[1];
            strArray[0] = str;
            return EncodeToJSONArray(strArray);
        }

        public static string EncodeToJSONArray(string[] strList)
        {
            try
            {
                JArray jsonArrayObject = new JArray();

                foreach (string str in strList)
                {
                    jsonArrayObject.Add(new JValue(str));
                }

                return jsonArrayObject.ToString();
            }
            catch (Exception e)
            {
                return string.Empty;
                // throw new Client_JSONException(e);
            }
        }

        public static Dictionary<string, string> JsonToDictionary(string json)
        {

            var dictionary = new Dictionary<string, string>();
            try
            {
                if (string.IsNullOrEmpty(json) || json.Length < 2) /* not a valid json */
                    return dictionary;
                json = json.TrimStart();
                string jsonWithoutBraces = json.Substring(1, json.Length - 2);
                string[] keyValuePair = jsonWithoutBraces.Split(',');
                foreach (string keyValue in keyValuePair)
                {
                    string[] keyValueArray = keyValue.Split(':');
                    keyValueArray[0] = keyValueArray[0].Replace("\"", string.Empty);
                    keyValueArray[1] = keyValueArray[1].Replace("\"", string.Empty);
                    if (dictionary.ContainsKey(keyValueArray[0]) == false)
                    {
                        dictionary.Add(keyValueArray[0], keyValueArray[1]);    
                    }
                }
            }
            catch (Exception e) { }
            return dictionary;
        }

        public static Dictionary<string, string> ParseFromJsonIntoSingleLevelDictionary(string json)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Parse(json);
            Dictionary<string, string> rtn = new Dictionary<string, string>();
            foreach (var p in jo.Properties())
            {
                try
                {
                    string key = p.Name.ToString();
                    //var v1 = p.Value.First;
                    string val = p.Value.ToString().Replace(@"""", ""); ;
                    rtn[key] = val;
                }
                catch (Exception e) { Console.WriteLine(e); }
            }
            return rtn;
        }
    }
}
