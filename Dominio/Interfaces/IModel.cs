using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public  interface  IModel<T>
    {

        void Add(T t);
        void Delete(T t);
        List<T> Read();
    }
}
