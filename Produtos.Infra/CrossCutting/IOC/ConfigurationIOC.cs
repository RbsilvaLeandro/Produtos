using Autofac;
using AutoMapper;
using Produtos.Application;
using Produtos.Application.Interfaces;
using Produtos.Application.Mapper;
using Produtos.Domain.Core.Intrefaces.Repositories;
using Produtos.Domain.Core.Intrefaces.Services;
using Produtos.Domain.Services;
using Produtos.Infra.Data.Repositories;

namespace Produtos.Infra.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationProdutoService>().As<IApplicationProdutoService>();

            builder.RegisterType<ProdutoService>().As<IProdutoService>();
       
            builder.RegisterType<ProdutoRepository>().As<IProdutoRepository>();

            #endregion

            builder.Register(c => new MapperConfiguration(cfg =>
            {        
                cfg.AddProfile(new DtoToModelMapperProduto());
                cfg.AddProfile(new ModelToDtoMapperProduto());
            }));

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();

        }
    }
}
