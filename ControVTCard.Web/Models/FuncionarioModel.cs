﻿using ControVTCard.Web.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControVTCard.Web.Models
{
    public class FuncionarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor informe o nome.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor informe o Matrícula.")]
        public int Matricula { get; set; }
        [Required(ErrorMessage = "Por favor informe a quantidade utilizada por dia.")]
        public int Utl_Diaria { get; set; }
        

        public static List<FuncionarioModel> RecuperarLista()
        {
            var ret = new List<FuncionarioModel>();

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "select * from funcionario order by nome";
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ret.Add(new FuncionarioModel
                        {
                            Id = (int)reader["id"],
                            Nome = (string)reader["nome"],
                            Matricula = (int)reader["matricula"],
                            Utl_Diaria = (int)reader["utl_diaria"]
                        });
                    }
                }
            }

            return ret;
        }

        //public static UsuarioModel RecuperarPeloId(int id)
        //{
        //    UsuarioModel ret = null;

        //    using (var conexao = new SqlConnection())
        //    {
        //        conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
        //        conexao.Open();
        //        using (var comando = new SqlCommand())
        //        {
        //            comando.Connection = conexao;
        //            comando.CommandText = "select * from usuario where (id = @id)";

        //            comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

        //            var reader = comando.ExecuteReader();
        //            if (reader.Read())
        //            {
        //                ret = new UsuarioModel
        //                {
        //                    Id = (int)reader["id"],
        //                    Nome = (string)reader["nome"],
        //                    Login = (string)reader["login"]
        //                };
        //            }
        //        }
        //    }

        //    return ret;
        //}

        //public static bool ExcluirPeloId(int id)
        //{
        //    var ret = false;

        //    if (RecuperarPeloId(id) != null)
        //    {
        //        using (var conexao = new SqlConnection())
        //        {
        //            conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
        //            conexao.Open();
        //            using (var comando = new SqlCommand())
        //            {
        //                comando.Connection = conexao;
        //                comando.CommandText = "delete from usuario where (id = @id)";

        //                comando.Parameters.Add("@id", SqlDbType.Int).Value = id;

        //                ret = (comando.ExecuteNonQuery() > 0);
        //            }
        //        }
        //    }

        //    return ret;
        //}

        //public int Salvar()
        //{
        //    var ret = 0;

        //    var model = RecuperarPeloId(this.Id);

        //    using (var conexao = new SqlConnection())
        //    {
        //        conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
        //        conexao.Open();
        //        using (var comando = new SqlCommand())
        //        {
        //            comando.Connection = conexao;

        //            if (model == null)
        //            {
        //                comando.CommandText = "insert into usuario (nome, login, senha) values (@nome, @login, @senha); select convert(int, scope_identity())";

        //                comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = this.Nome;
        //                comando.Parameters.Add("@login", SqlDbType.VarChar).Value = this.Login;
        //                comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = CriptoHelper.HashMD5(this.Senha);

        //                ret = (int)comando.ExecuteScalar();
        //            }
        //            else
        //            {
        //                comando.CommandText =
        //                    "update usuario set nome=@nome, login=@login" +
        //                    (!string.IsNullOrEmpty(this.Senha) ? ", senha=@senha" : "") +
        //                     " where id = @id";

        //                comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = this.Nome;
        //                comando.Parameters.Add("@login", SqlDbType.VarChar).Value = this.Login;

        //                if (!string.IsNullOrEmpty(this.Senha))
        //                {
        //                    comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = CriptoHelper.HashMD5(this.Senha);
        //                }

        //                comando.Parameters.Add("@id", SqlDbType.Int).Value = this.Id;

        //                if (comando.ExecuteNonQuery() > 0)
        //                {
        //                    ret = this.Id;
        //                }
        //            }
        //        }
        //    }

        //    return ret;
        //}

    }
}