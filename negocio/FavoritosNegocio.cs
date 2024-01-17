using System;
using dominio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class FavoritosNegocio
    {
        public List<Favoritos> listarFavoritos(Users user)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Favoritos> listaFavoritos = new List<Favoritos>();
            try
            {
                datos.setearConsulta("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, C.Descripcion as Categoria, A.ImagenUrl, A.Precio, A.IdMarca, A.IdCategoria, F.IdUser, F.IdArticulo From ARTICULOS A, CATEGORIAS C, MARCAS M, FAVORITOS F Where M.Id = A.IdMarca AND C.Id = A.IdCategoria AND F.IdUser = @usuario AND F.IdArticulo = A.Id");
                datos.setearParametros("@usuario", user.Id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Favoritos aux = new Favoritos();
                    aux.Usuario = new Users();
                    aux.Usuario.Id = user.Id;
                    aux.Usuario.Email = user.Email;
                    aux.Usuario.Pass = user.Pass;
                    aux.Usuario.Nombre = user.Nombre;
                    aux.Usuario.Apellido = user.Apellido;
                    aux.Usuario.UrlImagenPerfil = user.UrlImagenPerfil;
                    aux.Usuario.Admin = user.Admin;
                    aux.Articulo = new Articulos();
                    aux.Articulo.Id = (int)datos.Lector["Id"];
                    aux.Articulo.Codigo = (string)datos.Lector["Codigo"];
                    aux.Articulo.Nombre = (string)datos.Lector["Nombre"];
                    aux.Articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.Articulo.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Articulo.Marca = new Marcas();
                    aux.Articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Articulo.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Articulo.Categoria = new Categorias();
                    aux.Articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Articulo.Precio = (decimal)datos.Lector["Precio"];

                    listaFavoritos.Add(aux);
                }
                return listaFavoritos;
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
        public void AgregarFavorito(Users user, Articulos articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into FAVORITOS (IdUser, IdArticulo) values (@user, @articulo)");
                datos.setearParametros("@user", user.Id);
                datos.setearParametros("@articulo", articulo.Id);
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
        public void EliminarFavorito(Users user, Articulos articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete from FAVORITOS where IdUser = @IdUser AND IdArticulo = @IdArticulo");
                datos.setearParametros("@IdUser", user.Id);
                datos.setearParametros("@IdArticulo", articulo.Id);
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
    }
}
