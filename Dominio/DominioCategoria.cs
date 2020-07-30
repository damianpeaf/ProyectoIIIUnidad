using Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DominioCategoria
    {

        private Categoria categoria = new Categoria();

        public String BuscarCategoria(string id)
        {
            return categoria.BuscarCategoria(id);
        }

        public List<string> ObtenerCategoria()
        {
            return categoria.ObtenerCategoria();
        }
    }
}
