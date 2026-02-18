using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration.Internal;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using System.Data.SqlClient;
using ZstdSharp.Unsafe;
using Org.BouncyCastle.Crypto.Digests;
using System.Net.Mail;
namespace LoginSystem;

    public class Cadastro
    {
    
        static private UsuarioDataAccess _datauser = new UsuarioDataAccess();
        

    public Cadastro(UsuarioDataAccess user)
        {
            _datauser = user;
        }


        public static void Main(string[] args)
        {
            
        Entrar();
            
            
        }

    public static void Entrar()
    {
        
        
            menu();
            string nome;
            string senha;
            string email;
            string resposta;
        
        
        
            resposta = Console.ReadLine();
            Usuario u = new Usuario("", "", "");
            
            Login:
            if (resposta == "1")
            {
                Console.WriteLine("Login(Email): ");
                email = Console.ReadLine();

                Console.WriteLine("Senha: ");
                senha = LerSenha();
                if (_datauser.LoginValido(email, senha))
                {
                    Console.WriteLine("Os dados estão corretos!");
                }
                else
                {
                    Console.WriteLine("Os dados estão incorretos");
                goto Login;
                }



            }
            else if (resposta == "2")
            {

                Console.WriteLine("Nome Completo: ");
                nome = Console.ReadLine();

                inserirEmailNovamente:
                Console.WriteLine("Insira seu email: ");
                email = Console.ReadLine();

                if (formatoDoEmailValido(email))
                {
                    Console.WriteLine("Email valido!");
                }
                else
                {
                    Console.WriteLine("Formato de email incorreto");
                goto inserirEmailNovamente;
                }

        inserirSenhaNovamente:

                Console.WriteLine("Senha: ");
                senha = LerSenha();
                if (SenhaValida(senha))
                {
                    Console.WriteLine("Senha muito forte!");
            }
                else
            {
                goto inserirSenhaNovamente;
            }


            Usuario user = new Usuario(senha, email, nome);
                cadastrar(user);


            
        }
    }

        static void cadastrar(Usuario usuario)
        {
            _datauser.inserirDadosDoUsuario(usuario);
        }
        
        static void menu()
        {
            Console.WriteLine("---|CADASTRO|---");
            Console.WriteLine("1-Para entrar \n2- Para cadastrar");
        }

    static bool SenhaValida(string senha)
    {
        if (senha.Length < 8)
            return false;

        bool temMaiuscula = false;
        bool temMinuscula = false;
        bool temNumero = false;

        foreach (char c in senha)
        {
            if (!char.IsLetterOrDigit(c))
                return false; 

            if (char.IsUpper(c))
                temMaiuscula = true;

            if (char.IsLower(c))
                temMinuscula = true;

            if (char.IsDigit(c))
                temNumero = true;
        }

        return temMaiuscula && temMinuscula && temNumero;
    }

    static bool formatoDoEmailValido(string email)
    {
        try
        {
            MailAddress endereco = new MailAddress(email);
            return true;
        }
        catch
        {
            return false;
        }
    }
    static string LerSenha()
    {
        string senha = "";

        while (true)
        {
            ConsoleKeyInfo tecla = Console.ReadKey(true);

            if (tecla.Key == ConsoleKey.Enter)
                break;

            senha += tecla.KeyChar;
        }

        Console.WriteLine();
        return senha;
    }

}

