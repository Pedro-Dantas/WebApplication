using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication.Repositores
{
    public class MyConfig
    {
        /*
        *  Data Source:	Identifica o servidor e pode ser a máquina local (localhost), um dns ou um endereço IP.
        *  Initial Catalog:	O nome do banco de dados
        *  Integrated Security:	Defina para SSPI para fazer a conexão usando a autenticação do WIndows.(Usar Integrated Security é seguro somente quando você esta em uma máquina fora da rede)
        *  User ID:	Nome do usuário definido no SQL Server. 
        *  Password:	Senha do usuário definida no SQL Server.
        */

        //String de conexão
        private string ConnectionString = "Data Source=localhost,1433;Initial Catalog=ProjetoPai;Integrated Security=False;User Id=sa;Password=sa";

        private void CreateCommand()
        {
            //Cria uma instância do objeto Connection em memória com um unico construtor do tipo string
            SqlConnection SQLConnection = new SqlConnection(ConnectionString);
            try
            {
                //Abre a conexão
                SQLConnection.Open();

                //Passa a conexão para o objeto command (responsável por executar comandos contra o banco de dados)
                SqlCommand command = new SqlCommand("select * from Clientes", SQLConnection);

                /* Para criar um objeto DataReader usamos o método ExecuteReader de um objeto Command.
                 * ExecuteReader executa a consulta e retorna um objeto SqlDataReader;
                 * Objeto DataReader é uma maneira de ler os dados retornados pelos objetos Command, 
                 * ele permite acessar e percorrer os registros no modo de somente leitura.
                 */
                SqlDataReader ReadQuery = command.ExecuteReader();

                //Percorre e lê a primeira coluna de cada linha do conjunto de registros 
                //Pode pecorrer por nome de coluna também ReadQuery[Clientes] por exemplo
                while (ReadQuery.Read())
                {
                    Console.WriteLine(ReadQuery[0]);

                    //Fecha o Reader e a conexão
                    if (ReadQuery == null && SQLConnection == null)
                    {
                        ReadQuery.Close();
                        SQLConnection.Close();
                    }
                }
        }
            catch(Exception ex)
            {
                Console.WriteLine("Erro resultado: " + ex);
            }

        }

    }
}
