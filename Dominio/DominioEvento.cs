
using System;
using System.Collections.Generic;
using System.Linq;
using Clases;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Dominio
{
    public class DominioEvento
    {

        private Evento evento = new Evento();

        public DataSet mostrarEvento(int tabla, string id)
        {
            DataSet Datos = new DataSet();
            Datos = evento.Mostrar(tabla, id);
            return Datos;
        }

        public void InsertarEvento(string inicia, string termina, string titulo, string descripcion, int categoria)
        {
            evento.Insertar(inicia, termina, titulo, descripcion, categoria);
        }

        public void ActualizarEvento(string id, string inicia, string termina, string titulo, string descripcion, int categoria)
        {
            evento.Actualizar(id, inicia, termina, titulo, descripcion, categoria);
        }

        public String[] Buscarevento(string id)
        {

            return evento.Buscar(id);

        }

        public void Eliminarevento(string id)
        {
            evento.Eliminar(id);
        }

    }
}
