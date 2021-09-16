using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DividersFinder.service
{
    public interface IJsonDataSerializer
    {
        Dictionary<ulong, List<ulong>> Deserialize();
        void Serialize(Dictionary<ulong, List<ulong>> resultOffinding);
    }

    public class JsonDataSerializer : IJsonDataSerializer
    {
        public void Serialize(Dictionary<ulong, List<ulong>> resultOffinding)
        {
            var jsonData = JsonConvert.SerializeObject(resultOffinding, Formatting.Indented);
            File.WriteAllText(@"C:\Users\user\source\repos\dividers_finder\DividersFinder\DividersFinder.service\Writelines5.json", jsonData);
        }

        public Dictionary<ulong,List<ulong>> Deserialize()
        {
            var readjsonData = File.ReadAllText(@"C:\Users\user\source\repos\dividers_finder\DividersFinder\DividersFinder.service\Writelines5.json");
            var readingData = JsonConvert.DeserializeObject<Dictionary<ulong, List<ulong>>>(readjsonData);
            return readingData;
        }

    }
}
