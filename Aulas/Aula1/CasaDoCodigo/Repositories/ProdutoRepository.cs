using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<IList<Produto>> GetProdutos()
        {
            return await dbSet.ToListAsync();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            var produtoValido = dbSet
                                    .SingleOrDefault();

            foreach (var livro in livros)
            {
                if (produtoValido == null || !  dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                     dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }

             contexto.SaveChanges();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
