using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LoginSystem
{
    public class Usuario
    {
         public string senha;
         public string email;
         public string nomeCompleto;

        public Usuario(string senha, string email, string nomeCompleto)
        {
            this.senha = senha;
            this.email = email;
            this.nomeCompleto = nomeCompleto;
        }

        

    }
}
