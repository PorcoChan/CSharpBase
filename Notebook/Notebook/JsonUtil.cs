using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Notebook
{
    class JsonUtil
    {
        public JsonUtil()
        {
        }

        public JObject parseJsonString(string jsonString)
        {
            JObject jsonObject = (JObject)JsonConvert.DeserializeObject(jsonString);
            return jsonObject;
        }

        public Dictionary<string, string> getJsonKV(string jsonString)
        {
            Dictionary<string, string> dict = new Dictionary<string,string>();
            //JsonReader jsonReader = new JsonReader(new StringReader(jsonString));

            return dict;
        }
    }
}
