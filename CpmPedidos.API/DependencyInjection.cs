﻿using CpmPedidos.Domain.Entities;
using CpmPedidos.Interface.Repositories;
using CpmPedidos.Repository.Repositories;

namespace CpmPedidos.API
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }

        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IProdutoRepository, ProdutoRepository>();
            serviceProvider.AddScoped<IPedidoRepository, PedidoRepository>();
            serviceProvider.AddScoped<ICidadeRepository, CidadeRepository>();

        }
    }
}
