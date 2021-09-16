using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DividersFinder.service
{
    public interface IFileWriterService
    {
        List<ulong> WriteText(ulong number);
    }

    public class FileWriterService : IFileWriterService
    {
        private readonly IDividersFinder _dividersFinder;
        private readonly IJsonDataSerializer _jsonDataSerializer;
        public FileWriterService(IDividersFinder dividersFinder, IJsonDataSerializer jsonDataSerializer)
        {
            _dividersFinder = dividersFinder;
            _jsonDataSerializer = jsonDataSerializer;
        }
        public  List<ulong> WriteText(ulong number)
        {
               
            List<ulong> valuesList = new List<ulong>();
            valuesList = null;          
            var dataDeser = _jsonDataSerializer.Deserialize();
            foreach (var item in dataDeser)
            {           
              dataDeser.TryGetValue(number, out List<ulong> values);
              valuesList = values;
            }
            if(valuesList!=null)
            {
                return valuesList;             
            }
            else
            {
               var resultOffinding = _dividersFinder.FindNumbers(number);
                var data = new Dictionary<ulong, List<ulong>>();
                dataDeser.Add(number, resultOffinding);
               //dataDeser.Add(data);
                //var dataForJson = new List<Dictionary<ulong, List<ulong>>>();
                //dataForJson.Add(data);
                _jsonDataSerializer.Serialize(dataDeser);
                return resultOffinding;                
            }
            
        }
    }
}
