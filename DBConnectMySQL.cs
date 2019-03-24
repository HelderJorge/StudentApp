using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;
using System.Data;


//Ligações ao MySQL

public class DBConnectMySQL
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    //Constructor com o metodo "Initialize"
    public DBConnectMySQL()
    {
        Initialize();
    }

    //Metodo "Initialize" cria o objeto "connection" da classe MySqlConnection
    private void Initialize()
    {
        //server = "192.168.137.153" ou outro qualquer;
        server = "127.0.0.1"; // o local
        database = "maisfuturo"; //Escolher a base de dados.
        uid = "root";
        password = "";

        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
    }

    //Metodo "Openconnection" usa o objeto "connection" para chamar o metodo Open
    private bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            this.CloseConnection();
            //Registo do erro
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
    }

    //Metodo "CloseConnection" usa o objeto "connection" para chamar o metodo Close
    private bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            this.CloseConnection();
            //Registo do erro
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
    }

    //Metodo Count retorna um inteiro
    public int Count()
    {
        int Count = -1;
        try
        {
            string query = "SELECT Count(*) FROM teste;";

            //o objeto chama o OpenConnection
            if (this.OpenConnection() == true)
            {
                //Cria um objeto (cmd) da classe MysqlCommand usando o objeto connection
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //O objeto cmd chama o método ExecuteScalar - retorna um escalar
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //o objeto chama o CloseConnection
                this.CloseConnection();
            }
        }
        catch (MySqlException ex)
        {
            this.CloseConnection();
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return Count;
        }
        return Count;
    }

    //Metodo AVG retorna um float, para usar noutra página
    public float Average()
    {
        float avg = -1;
        try
        {
            string query = "SELECT AVG(idade) FROM [Tabela];";
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                avg = float.Parse(cmd.ExecuteScalar().ToString());
                this.CloseConnection();
            }
        }
        catch (MySqlException ex)
        {
            this.CloseConnection();
            //Registo do erro
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return avg;
        }
        return avg;
    }

    //Metodo Bind para pesquisar por disciplina
    public string Bind(ref GridView gv1, string Disciplina, string Data1, string Data2)
    {
        string Msg;
        if (Data1.Equals("inserir/atualizar") || Data2.Equals("pesquisar"))
        {
            this.CloseConnection();
            Msg = "Inserir o intervalo de datas a visualizar! ";
            return Msg;
        }
        else
        {
            DateTime data1 = Convert.ToDateTime(Data1);
            Data1 = data1.ToString("yyyy-MM-dd");
            DateTime data2 = Convert.ToDateTime(Data2);
            Data2 = data2.ToString("yyyy-MM-dd");
            try
            {
                string query = "Select * from teste where Disciplina ='" + Disciplina +
                    "' and Data >='" + Data1 + "' and Data <='" + Data2 + "' order by Data;";
                if (this.OpenConnection())
                {
                    var cmd = new MySqlCommand(query, connection);
                    var da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Testes");
                    this.CloseConnection();
                    gv1.DataSource = ds.Tables[0].DefaultView;
                }
                Msg = "Sucesso! ";
                return Msg;
            }

            catch (MySqlException ex)
            {
                this.CloseConnection();
                //Registo do erro
                System.Diagnostics.Debug.WriteLine(ex.Message);
                Msg = "Erro na ligação! ";
                return Msg;
            }
        }
    }
    
    //Metodo Bind para pesquisar por turma
    public string Bind(ref GridView gv1, string Ano, string Turma, string Escola, string Data1, string Data2)
    {
        string Msg;
        if (Data1.Equals("inserir/atualizar") || Data2.Equals("pesquisar"))
        {
            this.CloseConnection();
            Msg = "Inserir o intervalo de datas a vizualizar! ";
            return Msg;
        }
        else
        {
            DateTime data1 = Convert.ToDateTime(Data1);
            Data1 = data1.ToString("yyyy-MM-dd");
            DateTime data2 = Convert.ToDateTime(Data2);
            Data2 = data2.ToString("yyyy-MM-dd");
            try

            {
                string query = "Select * from teste where Ano ='" + Ano +
                    "'and Turma ='" + Turma + "' and Escola ='" + Escola +
                    "' and Data >='" + Data1 + "' and Data <='" + Data2 + "' order by Data;";
                if (this.OpenConnection())
                {
                    var cmd = new MySqlCommand(query, connection);
                    var da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Testes");
                    this.CloseConnection();
                    gv1.DataSource = ds.Tables[0].DefaultView;
                }
                Msg = "Sucesso! ";
                return Msg;
            }

            catch (MySqlException ex)
            {
                this.CloseConnection();
                //Registo do erro
                System.Diagnostics.Debug.WriteLine(ex.Message);
                Msg = "Erro na ligação! ";
                return Msg;
            }
        }
    }
    
    //Metodo Insert - falta colocar um unique na base de dados
    public bool Insert(string Data, string Disciplina, string Ano,string Turma, string Escola)
    {
        try
        {
            DateTime data = Convert.ToDateTime(Data);
            Data = data.ToString("yyyy-MM-dd");
        }
        catch (FormatException) { return false; }
        try
        {
            //Atenção às pelicas!
            string query = "Insert into teste (Data, Disciplina, Ano, Turma, Escola)" +
                "values ('" + Data + "','" + Disciplina + "','" + Ano + "','" + Turma + "','" + Escola + "');";
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command with ExecuteNonQuery() (Insert e Update)
                cmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }
        catch (MySqlException ex)
        {
            this.CloseConnection();
            //Registo do erro
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    //Metodo Update 
    public bool Update(string ID, string Data, string Disciplina, string Ano, string Turma, string Escola)
    {
        try {DateTime data = Convert.ToDateTime(Data);
        Data = data.ToString("yyyy-MM-dd"); }
        catch (FormatException) { return false;}
        try
        {
            string query = "Update teste set Data= '"+Data+"',Disciplina = '" +Disciplina+ "', Ano = '"+Ano+"',Turma='"+Turma+
                "',Escola='"+Escola+"' where ID = " + ID;
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        catch (MySqlException ex)
        {
            this.CloseConnection();
            //Registo do erro
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    //Metodo Delete
    public bool Delete(string id)
    {
        try
        {
            string query =
            "Delete From teste where ID = " + id;
            if (this.OpenConnection() == true)
            {

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        catch (MySqlException ex)
        {
            this.CloseConnection();
            //Registo do erro
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    //Metodo para aceder a informação do teste por ID
    public bool DevolverTeste(string id,
        ref Label Data, ref TextBox Ano, ref TextBox Turma, ref TextBox Escola, ref TextBox Disciplina)
    {
        try
        {
            string query = "SELECT ID, Data, Disciplina, Ano, Turma, Escola FROM teste where ID = " + id;
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Atribução ao reader da aplicação do ExecuteReader pelo "cmd"
                MySqlDataReader reader = cmd.ExecuteReader();

                //Enquanto o Read() retornar true o ciclo continua.
                while (reader.Read())
                {
                    //aplicação do GetString
                    Data.Text = reader.GetString(1);
                    Ano.Text = reader.GetString(3);
                    Turma.Text = reader.GetString(4);
                    Escola.Text = reader.GetString(5);
                    Disciplina.Text = reader.GetString(2);
                }
                Data.Text = reader.GetString(1);
            }
        }
        catch (MySqlException ex)
        {
            this.CloseConnection();
            //Registo do erro
            System.Diagnostics.Debug.WriteLine(ex.Message);
        return false;
        }
        return true;
    }

}
