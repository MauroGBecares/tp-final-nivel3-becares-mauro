using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticulosNegocio
    {
        public List<Articulos> listar()
        {
            List<Articulos> articulos = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, A.ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria From ARTICULOS A, CATEGORIAS C, MARCAS M Where M.Id = A.IdMarca AND C.Id = A.IdCategoria");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"]; 

                    articulos.Add(aux);
                }
                return articulos;
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
        public void AgregarArticulo(Articulos valor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                datos.setearParametros("@Codigo", valor.Codigo);
                datos.setearParametros("@Nombre", valor.Nombre);
                datos.setearParametros("@Descripcion", valor.Descripcion);
                datos.setearParametros("@IdMarca", valor.Marca.Id);
                datos.setearParametros("@IdCategoria", valor.Categoria.Id);
                datos.setearParametros("@ImagenUrl", valor.UrlImagen);
                datos.setearParametros("@Precio", valor.Precio);
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
        public void ModificarArticulo(Articulos valor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where id = @Id");
                datos.setearParametros("@Codigo", valor.Codigo);
                datos.setearParametros("@Nombre", valor.Nombre);
                datos.setearParametros("@Descripcion", valor.Descripcion);
                datos.setearParametros("@IdMarca", valor.Marca.Id);
                datos.setearParametros("@IdCategoria", valor.Categoria.Id);
                datos.setearParametros("@ImagenUrl", valor.UrlImagen);
                datos.setearParametros("@Precio", valor.Precio);
                datos.setearParametros("@Id", valor.Id);
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
        public void eliminarArticulo(int valor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete from ARTICULOS where id = @Id");
                datos.setearParametros("@Id", valor);
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
        public List<Articulos> filtro(string campo, string criterio, string filtro)
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();
            string consulta = "Select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, A.ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria From ARTICULOS A, CATEGORIAS C, MARCAS M Where M.Id = A.IdMarca AND C.Id = A.IdCategoria AND ";
            try
            {
                switch (campo)
                {
                    case "Codigo de Articulo":
                        if (criterio == "Igual")
                            consulta += "Codigo = '" + filtro + "'";
                        else
                            consulta += "Codigo like '" + filtro + "%'";
                        break;
                    case "Nombre":
                        if (criterio == "Comienza con")
                            consulta += "Nombre like '" + filtro + "%'";
                        else if (criterio == "Contiene")
                            consulta += "Nombre like '%" + filtro + "%'";
                        else
                            consulta += "Nombre like '%" + filtro + "'";
                        break;
                    case "Marca":
                        if (criterio == "Comienza con")
                            consulta += "M.Descripcion like '" + filtro + "%'";
                        else if (criterio == "Contiene")
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                        else
                            consulta += "M.Descripcion like '%" + filtro + "'";
                        break;
                    case "Categoria":
                        if (criterio == "Comienza con")
                            consulta += "C.Descripcion like '" + filtro + "%'";
                        else if (criterio == "Contiene")
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                        else
                            consulta += "C.Descripcion like '%" + filtro + "'";
                        break;
                    default:
                        if (criterio == "Menos a")
                            consulta += "Precio < " + filtro;
                        else if (criterio == "Igual")
                            consulta += "Precio = " + filtro;
                        else
                            consulta += "Precio > " + filtro;
                        break;
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Marca = new Marcas();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categorias();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

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
