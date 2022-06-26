using Autofac;
using StoreManager.Infrastructure.DbContexts;
using StoreManager.Infrastructure.Repositories;
using StoreManager.Infrastructure.Services;
using StoreManager.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Infrastructure
{
    public class StoreModule : Module
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;


        public StoreModule(string connectionString, string assemblyName)
        {
            _connectionString = connectionString;
            _assemblyName = assemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StoreDbContext>().AsSelf()
                 .WithParameter("connectionString", _connectionString)
                 .WithParameter("assemblyName", _assemblyName)
                 .InstancePerLifetimeScope();

            builder.RegisterType<StoreDbContext>().As<IStoreDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("assemblyName", _assemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ItemRepository>().As<IItemRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StoreUnitOfWork>().As<IStoreUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ItemService>().As<IItemService>()
                .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
