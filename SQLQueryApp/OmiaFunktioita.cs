using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SQLQueryApp
{
    public class OmiaFunktioita
    {
        public static void SuoritaSQLLauseTaulukkoon(SqlConnection conn, string SQLLause)
        {
            string sarakeNimi = "", sarakeArvo = "";
            int i = 0, j = 0, k = 0;
            SqlCommand cmd = new SqlCommand(SQLLause, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable schemaTable = reader.GetSchemaTable();   //using System.Data;


            foreach (DataRow rivi in schemaTable.Rows)
            {
                foreach (DataColumn column in schemaTable.Columns)
                {
                    if (column.ColumnName == "ColumnName")
                    {
                        j++;
                        sarakeNimi = rivi[column].ToString();
                        sarakeNimi = (sarakeNimi.PadRight(15).Substring(0, 15)) + " ";
                        Console.Write(sarakeNimi);
                    }

                }
            }
            Console.WriteLine();
            while (reader.Read())
            {
                i++;
                for (k = 0; k < j; k++)
                {
                    //sarakeArvo = reader.GetString(k).ToString();
                    sarakeArvo = reader.GetValue(k).ToString();
                    sarakeArvo = (sarakeArvo.PadRight(15).Substring(0, 15)) + " ";
                    if (k < j - 1)
                    {
                        Console.Write(sarakeArvo);
                    }
                    else Console.WriteLine(sarakeArvo);
                }
            }
            Console.WriteLine("Yhteensä " + i.ToString() + " riviä ");
            // resurssien vapautus
            reader.Close();
            cmd.Dispose();
        }
    }
}
