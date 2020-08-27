using Autofac;
using Desafio.CrosCutting.Adapter.Interfaces;
using Desafio.CrosCutting.Adapter.Map;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Domain.Interfaces.Services;
using Desafio.Domain.Services;
using Desafio.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Application.Services;
using Desafio.Application.Interfaces;

namespace Desafio.CrosCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<TanqueServiceApplication>().As<ITanqueServiceApplication>();
            #endregion

            #region IOC Services
            builder.RegisterType<TanqueService>().As<ITanqueService>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<TanqueRepository>().As<ITanqueRepository>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<TanqueMapper>().As<ITanqueMapper>();
            #endregion

            #endregion

        }
    }
}
