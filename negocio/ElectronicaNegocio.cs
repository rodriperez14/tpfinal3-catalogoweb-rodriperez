using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesos;

namespace negocio
{
    public class ElectronicaNegocio
    {
        public List<Electronica> listarCategoria()
        {
			List<Electronica> lista = new List<Electronica>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("Select Id, Descripcion From CATEGORIAS");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Electronica aux = new Electronica();
					aux.Id = (int)datos.Lector["Id"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];

					lista.Add(aux);
				}
				return lista;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }
        public List<Electronica> listarMarca()
        {
            List<Electronica> lista = new List<Electronica>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, Descripcion From MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Electronica aux = new Electronica();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
