using AppLanches.Context;
using AppLanches.Models;
using AppLanches.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLanches.Areas.Admin.Servicos
{
    public class GraficoVendasService
    {
        private readonly AppDbContext context;

        public GraficoVendasService(AppDbContext context)
        {
            this.context = context;
        }

        public List<LancheGrafico> GetVendasLanches(int dias=360)
        {
            var data = DateTime.Now.AddDays(-dias);
            // realizando o relacionamento entre as tabelas, fazendo as comparações,
            // agrupando e somando os dados para retornar pro grafico...
            var lanches = (from pd in context.PedidoDetalhes
                           join l in context.Lanches on pd.LancheId equals l.LancheId
                           where pd.Pedido.PedidoEnviado >= data
                           group pd by new { pd.LancheId, l.Nome }
                           into g
                           select new { LancheNome = g.Key.Nome, LanchesQuantidade = g.Sum(q=> q.Quantidade), 
                               LanchesValorTotal = g.Sum(a => a.Preco * a.Quantidade)
                           });

            //Realizando a conversão para a lista LancheGrafico
            var lista = new List<LancheGrafico>();
            foreach (var item in lanches)
            {
                // criando as instancias para incluir na lista
                var lanche = new LancheGrafico();
                lanche.LancheNome = item.LancheNome;
                lanche.LanchesQuantidade = item.LanchesQuantidade;
                lanche.LanchesValorTotal = item.LanchesValorTotal;
                lista.Add(lanche);
            }
            return lista;
        }
    }
}