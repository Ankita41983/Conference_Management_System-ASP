using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo<TYPE, ID, RET>
    {
        List<TYPE> Get();
        TYPE Get(ID id);
        RET Add(TYPE obj);
        RET Update(TYPE obj);
        bool DELETE(ID id);
        object GetAll();
        bool Delete(int id);
    }
}
