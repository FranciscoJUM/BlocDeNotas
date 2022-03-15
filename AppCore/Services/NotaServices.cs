using Dominio.Interfaces;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.IServices;

namespace AppCore.Services
{
    public  class NotaServices: BaseServices<Nota>, INotaService
    {

        INotaModel activoModel;
        public NotaServices(INotaModel model) : base(model)
        {
            this.activoModel = model;
        }

        public Nota GetById(int id)
        {
            return activoModel.GetById(id);
        }
    }
}
