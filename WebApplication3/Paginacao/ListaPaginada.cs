using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Paginacao
{
    public class ListaPaginada<T> : List<T>
    {
        public ListaPaginada(List<T> itens, int total, int pagina, int tamanho)
        {
            this.AddRange(itens);
            Atual = pagina;
            TotalPaginas = (int)Math.Ceiling(total / (double)tamanho);
        }

        public int Atual { get; set; }
        public int TotalPaginas { get; set; }

        public int PaginaAnterior => (Atual > 2) ? Atual - 1 : 1;
        public int ProximaPagina => (Atual < TotalPaginas) ? Atual + 1 : TotalPaginas;
        public int[] Paginas => Enumerable.Range(1, TotalPaginas).ToArray();

        public static ListaPaginada<T> Create(IQueryable<T> source, int pagina, int tamanho)
        {
            var count = source.Count();
            var items = source.Skip((pagina - 1) * tamanho).Take(tamanho).ToList();
            return new ListaPaginada<T>(items, count, pagina, tamanho);
        }
    }
}
