using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLQueryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection TkYhteys;
            string SQL = "";
            TkYhteys = AvaaTietokanta();
            SQL = KysySQLLause();
            Console.WriteLine(SQL);
            //SuoritaSQLLauseb(TkYhteys, SQL);
            OmiaFunktioita.SuoritaSQLLauseTaulukkoon(TkYhteys, SQL);
            Console.ReadLine();
            TkYhteys.Dispose();

        }

        private static SqlConnection AvaaTietokanta()
        {
            //using System.Data.SqlClient;
            string connStr = "Server=L17HE01A\\SQLEXPRESS;Database=Northwind;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }

        private static string KysySQLLause()
        {
            string SQL = "";
            Console.Write("Anna SQL-lause: ");
            SQL = Console.ReadLine();
            return SQL;
        }

        private static void SuoritaSQLLause(SqlConnection conn, string SQLLause)
        {
            int i = 0;
            SqlCommand cmd = new SqlCommand(SQLLause, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                i++;
                string kentta0 = reader.GetValue(0).ToString();
                string kentta1 = reader.GetString(1);
                string kentta2 = reader.GetString(2);
                Console.WriteLine("Löytyi rivi: " + kentta0 + " " + kentta1 + " " + kentta2);
            }
            Console.WriteLine("Yhteensä " + i.ToString() + " riviä ");

            // resurssien vapautus
            reader.Close();
            cmd.Dispose();
        }

    }
}
