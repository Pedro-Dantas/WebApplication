using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebApplication.Repositores
{
    public class ClientRepository
    {
        public class Client
        {
            public string Nome { get; set; }
            public string Cpf { get; set; }
        }

        /*
        *  Data Source:	Identifica o servidor e pode ser a máquina local (localhost), um dns ou um endereço IP.
        *  Initial Catalog:	O nome do banco de dados
        *  Integrated Security:	Defina para SSPI para fazer a conexão usando a autenticação do WIndows.(Usar Integrated Security é seguro somente quando você esta em uma máquina fora da rede)
        *  User ID:	Nome do usuário definido no SQL Server. 
        *  Password:Senha do usuário definida no SQL Server.
        */

        //String de conexão
        private static string ConnectionString = "Data Source=BRRIOWN022117\\SQLEXPRESS;Initial Catalog=ProjetoPai;Integrated Security=False;User Id=sa;Password=sa;Persist Security Info=True;MultipleActiveResultSets=True";

        public static List<string> GetClientes()
        {
            //Cria uma instância do objeto Connection em memória com um unico construtor do tipo string 
            SqlConnection SQLConnection = new SqlConnection(ConnectionString);
            try
            {
                 SQLConnection.Open();

                /*Passa a conexão para o objeto command (responsável por executar comandos contra o banco de dados)
                 *command é a referência da instância SqlCommand
                 * Comando na query ("select * from [ProjetoPai].[dbo].[Clientes]")
                 * SQLConnection é a conexão com o banco de dados
                 */
                SqlCommand command = new SqlCommand("select * from Clientes", SQLConnection);
                
                /* Para criar um objeto DataReader usamos o método ExecuteReader de um objeto Command.
                 * ExecuteReader executa a consulta e retorna um objeto SqlDataReader;
                 * Objeto DataReader é uma maneira de ler os dados retornados pelos objetos Command, 
                 * ele permite acessar e percorrer os registros no modo de somente leitura.
                 */
                SqlDataReader ReadQuery = command.ExecuteReader();

                List<string> ReadAllNamesLoaded = new List<string>();

                if (ReadQuery.HasRows)
                {
                    while (ReadQuery.Read())
                    {
                        //Percorre e lê a primeira coluna de cada linha do conjunto de registros 
                        //ReadAllNamesLoaded.Add(ReadQuery.GetString(1).ToString());
                        ReadAllNamesLoaded.Add(ReadQuery["Nome"].ToString() + "-" + ReadQuery["Cpf"].ToString()); 
                    }
                }

                //Fecha o Reader e a conexão
                if (ReadQuery == null && SQLConnection == null)
                {
                    ReadQuery.Close();
                    SQLConnection.Close();
                }
                return ReadAllNamesLoaded;
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Erro resultado: " + ex);
                Console.ResetColor();
                return null;
            }
        }

        public static List<string> GetNameById(int id)
        {
            SqlConnection SQLConnection = new SqlConnection(ConnectionString);
            try
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand($"select * from Clientes where Id = {id}", SQLConnection);

                SqlDataReader ReadQuery = command.ExecuteReader();
                
                List<string> ReadNameById = new List<string>();

                if (ReadQuery.HasRows)
                {
                    while (ReadQuery.Read())
                    {
                        ReadNameById.Add((ReadQuery["Nome"] + "-" + ReadQuery["Cpf"]).ToString());
                    }
                }

                if (ReadQuery == null && SQLConnection == null)
                {
                    ReadQuery.Close();
                    SQLConnection.Close();
                    return null;
                }
                return ReadNameById;
            }

            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Erro resultado: " + ex);
                Console.ResetColor();
                return null;
            }
        }
        public static List<string> GetAccount(string ClienteID)
        {
            SqlConnection SQLConnection = new SqlConnection(ConnectionString);
            try
            {
                SQLConnection.Open();

                SqlCommand command = new SqlCommand($"SELECT * FROM Clientes AS CL JOIN Contas AS C ON C.ClienteID = CL.Id WHERE CL.Id = {ClienteID}", SQLConnection);

                SqlDataReader ReadQuery = command.ExecuteReader();

                List<string> ReadAccountById = new List<string>();

                if (ReadQuery.HasRows)
                {
                    while (ReadQuery.Read())
                    {
                        ReadAccountById.Add((ReadQuery["Id"] + "-" + ReadQuery["Nome"] + "-" + ReadQuery["Cpf"] + "-" + ReadQuery["ID"]
                            + "-" + ReadQuery["ClienteID"] + "-" + ReadQuery["Numero"] + "-" + ReadQuery["Saldo"]).ToString());
                    }
                }

                if (ReadQuery == null && SQLConnection == null)
                {
                    ReadQuery.Close();
                    SQLConnection.Close();
                    return null;
                }
                return ReadAccountById;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Erro resultado: " + ex.Message);
                Console.ResetColor();
                return null;
            }
        }

        public static bool PostClient(Client client)
        {
            SqlConnection SQLConnection = new SqlConnection();
            try
            {
                SQLConnection.Open();

                SqlCommand CommandInsertClient = new SqlCommand($"INSERT INTO Clientes (Nome, Cpf) VALUES ('{client.Nome}', '{client.Cpf}');", SQLConnection);

                if (SQLConnection == null)
                {
                    SQLConnection.Close();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Erro resultado: " + ex.Message);
                Console.ResetColor();
                return false;
            }
        }
        
        //novo metodo

    }
}

