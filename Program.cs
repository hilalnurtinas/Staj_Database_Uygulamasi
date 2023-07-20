global using global::System;
global using global::System.Collections.Generic;
global using global::System.IO;
global using global::System.Linq;
global using global::System.Net.Http;
global using global::System.Threading;
global using global::System.Threading.Tasks;
using System.Data.SqlClient;

namespace İlkDBOrnek
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Connect();
            Console.ReadKey();

        }

        static void Connect()
        {
            String constr;

            SqlConnection conn;

            constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoDB";

            conn = new SqlConnection(constr);

            conn.Open();

            Console.WriteLine("Connection Open");

            //1. işlem : okuma işlemi
            SqlCommand cmd;

            SqlDataReader reader;

            string sql, output = "";

            sql = "Select article_ID, article_Name from demo"; //Select * from demo

            cmd = new SqlCommand(sql, conn);

            reader = cmd.ExecuteReader();

            //1. satır 1 - C#
            //2. satır 2 - C++
            //3. satır 3 - Python
            while (reader.Read())
            {
                //output = output + reader.GetValue(0) + " ---> " + reader.GetValue(1) + "\n";
                output +=reader.GetValue(0) + " ---> " + reader.GetValue(1) + "\n";

            }

            Console.WriteLine(output);

            reader.Close();
            cmd.Dispose();


            ////2. işlem : INSERT (ekleme) işlemi

            //SqlCommand cmd1;

            //SqlDataAdapter adapter1 = new SqlDataAdapter();

            //string sql1 = "insert into demo values(4, 'Java')";

            //cmd1 = new SqlCommand(sql1, conn);
            //adapter1.InsertCommand = cmd1;
            //adapter1.InsertCommand.ExecuteNonQuery();


            //adapter1.Dispose();
            //cmd1.Dispose();


            //3. işlem : UPDATE

            SqlCommand cmd2;
            SqlDataAdapter adapter2 = new SqlDataAdapter();

            string sql2 = "update demo set article_Name ='Django' where article_ID = 3 ";

            cmd2 = new SqlCommand(sql2, conn);
            adapter2.InsertCommand = cmd2;
            adapter2.InsertCommand.ExecuteNonQuery();

            cmd2.Dispose();

            // 4. işlem : DELETE

            SqlCommand cmd3;

            string sql3 = "delete demo where article_ID = 3";

            cmd3 = new SqlCommand(sql3, conn);
            adapter2.InsertCommand = cmd3;
            adapter2.InsertCommand.ExecuteNonQuery();

            cmd3.Dispose();


            adapter2.Dispose();

            conn.Close();
        }
    }
}
