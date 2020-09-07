using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroSMS.Business.Manager.Repository
{
   public interface IRepository <T>
    {
        T Add(T entity);
        List<T> GetAll();

    }
}
