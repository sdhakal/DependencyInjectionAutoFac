using Autofac;
using Autofac.Core;
using DependencyInjectionAutoFac.Models;

namespace DependencyInjectionAutoFac
{
    //This class inherits from Module and overrides the load method
    //The Load Method takes an instance of ContainerBuilder
    public class DataModule : Module
    {
        private string _connectionString;
        public DataModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new DependencyInjectionAutoFacContext(_connectionString)).
                                                    InstancePerRequest();
            base.Load(builder);
        }
    }
}