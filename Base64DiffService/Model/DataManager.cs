using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64DiffService.Model
{
    public class DataManager : IDataManager
    {
        static ConcurrentDictionary<int, Base64Data> _dataCollection;
        private static object lockObject = new Object();

        public static ConcurrentDictionary<int, Base64Data> DataInstance
        {
            get
            {
                if (_dataCollection == null)
                {
                    lock (lockObject)
                    {
                        _dataCollection = new ConcurrentDictionary<int, Base64Data>();
                    }
                }
                return _dataCollection;
            }
        }

        public Base64Data GetValue(int id)
        {
            Base64Data memoryData;
            DataInstance.TryGetValue(id, out memoryData);

            return memoryData;
        }

        public void UpdateValue(int id, Base64Data updatedData, Base64Data memoryData)
        {
            DataInstance.TryUpdate(id, updatedData, memoryData);
        }


        public void Add(int id, Base64Data newData)
        {
            DataInstance.TryAdd(id, newData);
        }
    }
}
