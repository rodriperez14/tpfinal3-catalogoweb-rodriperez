using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using accesos;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria, A.Id From ARTICULOS A, CATEGORIAS C, MARCAS M Where C.Id = A.IdCategoria And M.Id = A.IdMarca ");
                if (id != "")
                    datos.setearConsulta("Select Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria, A.Id From ARTICULOS A, CATEGORIAS C, MARCAS M Where C.Id = A.IdCategoria And M.Id = A.IdMarca and A.Id = " + id);
                     
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    //Validar los datos que quedaran en Null
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    //aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Electronica();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Electronica();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    
                    if(!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                //conexion.Close();
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
        public List<Articulo> listar2()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria, A.Id From ARTICULOS A, CATEGORIAS C, MARCAS M Where C.Id = A.IdCategoria And M.Id = A.IdMarca ";
                datos.setearConsulta(consulta);

                //datos.setearProcedimiento("storedListar");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    //Cargar los 3 primeros datos para no dejar null
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Electronica();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Electronica();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];


                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion,IdMarca, IdCategoria, ImagenUrl, Precio) values (@codigo, @nombre, @descripcion, @idMarca, @IdCategoria, @imagenUrl, @precio)");
                datos.setearParametro("@codigo", nuevo.Codigo);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                datos.setearParametro("@imagenUrl", nuevo.ImagenUrl);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.ejecutarAccion();
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

        //public void agregarConSP(Articulo nuevo)
        //{
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        datos.setearProcedimiento("storedAltaArticulo");
        //        datos.setearParametro("@codigo", nuevo.Codigo);
        //        datos.setearParametro("@nombre", nuevo.Nombre);
        //        datos.setearParametro("@desc", nuevo.Descripcion);
        //        datos.setearParametro("@idMarca", nuevo.Marca.Id);
        //        datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
        //        datos.setearParametro("@img", nuevo.ImagenUrl);
        //        datos.setearParametro("@precio", nuevo.Precio);
        //        datos.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}
        public void modificar(Articulo arti)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @marca, IdCategoria = @categoria, ImagenUrl = @imagen, Precio = @precio Where Id = @id");
                datos.setearParametro("@codigo",arti.Codigo);
                datos.setearParametro("@nombre",arti.Nombre);
                datos.setearParametro("@descripcion",arti.Descripcion);
                datos.setearParametro("@marca",arti.Marca.Id);
                datos.setearParametro("@categoria",arti.Categoria.Id);
                datos.setearParametro("@imagen",arti.ImagenUrl);
                datos.setearParametro("@precio",arti.Precio);
                datos.setearParametro("@id", arti.Id);

                datos.ejecutarAccion();
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
        //public void modificarConSP(Articulo arti)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        datos.setearProcedimiento("storedModificarArticulo");
        //        datos.setearParametro("@codigo", arti.Codigo);
        //        datos.setearParametro("@nombre", arti.Nombre);
        //        datos.setearParametro("@desc", arti.Descripcion);
        //        datos.setearParametro("@idMarca", arti.Marca.Id);
        //        datos.setearParametro("@idCategoria", arti.Categoria.Id);
        //        datos.setearParametro("@img", arti.ImagenUrl);
        //        datos.setearParametro("@precio", arti.Precio);
        //        datos.setearParametro("@id", arti.Id);

        //        datos.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro("@id",id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo> ();
            AccesoDatos datos = new AccesoDatos ();
            try
            {
                string consulta = "Select Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria, A.Id From ARTICULOS A, CATEGORIAS C, MARCAS M Where C.Id = A.IdCategoria And M.Id = A.IdMarca And ";
                switch (campo)
                {
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Precio":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "Precio < " + filtro;
                                break;
                            default:
                                consulta += "Precio = " + filtro;
                                break;
                        }
                        break;
                    case "Marca":                 
                        switch (criterio)
                        {
                            case "Samsung":
                                consulta += "M.Descripcion like 'Samsung'";                  
                                break;
                            case "Apple":
                                consulta += "M.Descripcion like 'Apple'";
                                break;
                            case "Sony":
                                consulta += "M.Descripcion like 'Sony'";
                                break;
                            case "Huawei":
                                consulta += "M.Descripcion like 'Huawei'";
                                break;
                            default:
                                consulta += "M.Descripcion like 'Motorola'";
                                break;
                        }
                        break;
                    case "Categoria":
                        switch (criterio)
                        {
                            case "Celulares":
                                consulta += "C.Descripcion like 'Celulares'";
                                break;
                            case "Televisores":
                                consulta += "C.Descripcion like 'Televisores'";
                                break;
                            case "Media":
                                consulta += "C.Descripcion like 'Media'";
                                break;                           
                            default:
                                consulta += "M.Descripcion like 'Audio'";
                                break;
                        }
                        break;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    //Cargar los 3 primeros datos para no dejar null
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    aux.Marca = new Electronica();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Electronica();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];


                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
    
}
