﻿using ControVTCard.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

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
                    comando.CommandText = string.Format(
                    "select count(*)from usuario where login='{0}' and senha='{1}'", login, CriptoHelper.HashMD5(senha));
                    ret = ((int)comando.ExecuteScalar() > 0);
                }
            }
            return ret;
        }
    }
}