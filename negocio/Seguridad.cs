﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sessionActiva(object user)
        {
            Users usuario = user != null ? (Users)user : null;
            if (usuario != null && usuario.Id != 0) 
                return true;
            return false;
        }
        public static bool esAdmin(object user)
        {
            Users usuario = user != null ? (Users)user : null;
            return usuario != null ? usuario.Admin : false;
        }
        public static bool esFavorito(Users user, Articulos articulo)
        {
            try
            {
                FavoritosNegocio favoritosNegocio = new FavoritosNegocio();
                List<Favoritos> listaFavoritos = favoritosNegocio.listarFavoritos(user);
                foreach (Favoritos item in listaFavoritos)
                {
                    if (item.Articulo.Id == articulo.Id)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
