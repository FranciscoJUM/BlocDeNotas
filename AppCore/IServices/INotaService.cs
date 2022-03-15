using Dominio.Entities;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.IServices
{
    public  interface INotaService: IServices<Nota>
    {
        Nota GetById(int id);
    }
}
