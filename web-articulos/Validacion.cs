using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace web_articulos
{
    public static class Validacion
    {
        public static bool esVacio(params object[] cajasTexto)
        {
            foreach (var caja in cajasTexto)
            {
                if (caja is TextBox textBox)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                        return true;
                    else
                        return false;
                }
                if (caja is DropDownList ddl)
                {
                    if (string.IsNullOrEmpty(ddl.Text))
                        return true;
                    else
                        return false;
                }
            }

            return false;
        }
    }
}