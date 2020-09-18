using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;


namespace Dominio
{
    public class DominioPost
    {

        private Post post = new Post();

        public DataSet mostrarPost(int tabla, string id)
        {
            DataSet Datos = new DataSet();
            Datos = post.Mostrar(tabla, id);
            return Datos;
        }

        public void InsertarPost(string titulo, string contenido, int categoria, string idUsuario)
        {
            post.Insertar(titulo, contenido, categoria, idUsuario);
        }

        public void ActualizarPost(string id, string titulo, string contenido, int idCategoria)
        {
            post.Actualizar(id, titulo, contenido, idCategoria);
        }

        public String[] BuscarPost(string id) {

            return post.Buscar(id);

        }

        public void EliminarPost(string id)
        {
            post.Eliminar(id);
        }

        public DataTable ReportePost()
        {
            return post.Informe();
        }

    }
}
