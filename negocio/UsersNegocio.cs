using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using dominio; 

namespace negocio
{
    public class UsersNegocio
    {
        public bool Loguearse(Users user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id, email, pass, nombre, apellido, urlImagenPerfil, admin from USERS Where email = @email AND pass = @pass");
                datos.setearParametros("@email", user.Email);
                datos.setearParametros("@pass", user.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    user.Id = (int)datos.Lector["Id"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        user.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        user.Apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["urlImagenPerfil"] is DBNull))
                        user.UrlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    user.Admin = (bool)datos.Lector["admin"];
                    return true;
                }
                return false;
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
        public int registrarUsuario(Users user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into USERS (email, pass, nombre, apellido, admin) output inserted.Id values (@email, @pass, @nombre, @apellido, 0)");
                datos.setearParametros("@email", user.Email);
                datos.setearParametros("@pass", user.Pass);
                datos.setearParametros("@nombre", user.Nombre);
                datos.setearParametros("@apellido", user.Apellido);
                return datos.ejecutarAccionScalar();
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
        public void actualizarUsuario(Users user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update USERS set nombre = @nombre, apellido = @apellido, urlImagenPerfil = @img Where Id = @id");
                datos.setearParametros("@nombre", user.Nombre);
                datos.setearParametros("@apellido", user.Apellido);
                datos.setearParametros("@urlImagenPerfil", (object)user.UrlImagenPerfil ?? DBNull.Value);
                datos.setearParametros("@id", user.Id);
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
