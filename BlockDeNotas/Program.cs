
using AppCore.IServices;
using AppCore.Services;
using Autofac;
using Dominio.Interfaces;
using Infraestructura.Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDeNotas
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = new ContainerBuilder();
            builder.RegisterType<BinnaryNotaRepos>().As<INotaModel>();

            builder.RegisterType<NotaServices>().As<INotaService>();
            var container = builder.Build();

           

            Application.Run(new Form1(container.Resolve<INotaService>()));
        }
    }
}
