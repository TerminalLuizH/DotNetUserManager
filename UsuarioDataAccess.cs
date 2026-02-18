using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace LoginSystem
{
    public class UsuarioDataAccess
    {

        static string connection = "Server=Luiz;Database=SistemaCadastro;Trusted_Connection=True;";

        public void inserirDadosDoUsuario(Usuario usuario)
        {



            
            using (SqlConnection conn = new SqlConnection(connection))
            {
                string sql = @"IF NOT EXISTS(SELECT * FROM sys.tables WHERE name = 'Usuarios') BEGIN CREATE TABLE Usuarios (Id INT PRIMARY KEY IDENTITY(1,1), NomeCompleto NVARCHAR(100) NOT NULL, Email NVARCHAR(100) NOT NULL, Senha NVARCHAR(100) NOT NULL) END";
                string query = @"INSERT INTO Usuarios (Senha, Email, NomeCompleto) VALUES (@Senha, @Email, @Nome)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Senha", usuario.senha);
                cmd.Parameters.AddWithValue("@Email", usuario.email);
                cmd.Parameters.AddWithValue("@Nome", usuario.nomeCompleto);

                conn.Open();
                cmd.ExecuteNonQuery();

            }
            Console.WriteLine("Usuario inserido com sucesso!!");
            
        }
            
            public bool LoginValido(string email, string senha) { 
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();

                string query = @"SELECT COUNT(*) FROM Usuarios WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    int resultado = (int)cmd.ExecuteScalar();
                    return resultado > 0;

                }
            }
        }

    }
}
