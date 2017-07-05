using ControVTCard.Web.Helpers;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ControVTCard.Web.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(String login, string senha)
        {
            var ret = false;
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select count(*)from usuario where login=@login and senha=@senha";
                    
                    comando.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = CriptoHelper.HashMD5(senha);

                    ret = ((int)comando.ExecuteScalar() > 0);
                }
            }
            return ret;
        }
    }
}