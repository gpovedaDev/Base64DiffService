using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64DiffService.Model
{
    public interface IDataManager
    {
        Base64Data GetValue(int id);
        void UpdateValue(int id, Base64Data newData, Base64Data previousData);
        void Add(int id, Base64Data newData);
    }
}
