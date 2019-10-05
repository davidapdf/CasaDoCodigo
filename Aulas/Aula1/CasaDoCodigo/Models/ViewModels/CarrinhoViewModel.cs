using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class CarrinhoViewModel
    {
        public CarrinhoViewModel(IList<ItemPedido> itens)
        {
            this.itens = itens;
        }

        public IList<ItemPedido> itens { get; }

        public decimal Total => itens.Sum(i => i.Quantidade * i.PrecoUnitario);
    }
}
