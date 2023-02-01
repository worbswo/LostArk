using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using LostArkAction.Model;
using Newtonsoft.Json.Bson;
using System.Data.SQLite;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace LostArkAction.Code.DataBase
{
    public class DataBase
    {
        internal string DataSourcePath { get; set; }
        public static string FinalStateStr = "finalStateSaveName";
        SqliteConnection conn;
        public DataBase(string productDataFile)
        {
            FileInfo fileInfo = new FileInfo(productDataFile);
            DataSourcePath = "Data Source=" + productDataFile;
            if (fileInfo.Exists)
            {
                conn = new SQLiteConnection(DataSourcePath);
                conn.Open();
            }
            else
            {
                // SQLiteConnection.Create(productDataFile);
                SQLiteConnection.CreateFile(productDataFile);
                conn = new SQLiteConnection(DataSourcePath);
                conn.Open();
                createDb();

            }
           
        }
        void createDb()
        {
            
            string sql = "CREATE TABLE API (APIKey nText);";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();


            sql = "CREATE TABLE Engrave (id int, Name nText,Target nText, Equip nText, Acc nText, Possession nText, PRIMARY KEY(id) );";
            cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
            sql = "INSERT INTO Engrave (id , Name,Target, Equip, Acc, possession) " +
                                    "VALUES ('"+ FinalStateStr.GetHashCode() +"','"+ FinalStateStr+ "','미사용-0_미사용-0_미사용-0_미사용-0_미사용-0_미사용-0_미사용-0','미사용-0_미사용-0_미사용-0_미사용-0_미사용-0','0_0_0_0_0_없음_없음_없음_없음_없음_없음','미사용-0_미사용-0_미사용-0_미사용-0');";
            cmd = new SQLiteCommand(sql, conn);

            cmd.ExecuteNonQuery();
           
        }
        public List<string> getAPIKey()
        {
            List<string> apiKey = new List<string>();


            string sql = "select * from API";
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        string key = (string)rdr["APIKey"];
                        apiKey.Add(key);
                    }
                }
            }
            catch
            {
                sql = "CREATE TABLE API (APIKey nText);";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("API Table이 존재 하지 않습니다. 재 생성하겠습니다.");
            }
            return apiKey;
        }
        public void AddAPIKey(string apikey)
        {
            string sql = "INSERT INTO API(APIKey) " +
                                    "VALUES ('"+ apikey + "');";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
     
        }
        public void AddEngrave(SetEngrave setEngrave)
        {
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Engrave (id , Name,Target, Equip, Acc,Possesion) " +
                                    "VALUES ("+ setEngrave.Name.GetHashCode() +",'"+
                                    setEngrave.Name +"','"+ setEngrave.Target + "','" + setEngrave.Equip + "','" + setEngrave.Acc + "','" + setEngrave.Possession + "');";


            cmd.ExecuteNonQuery();
       
        }
        public void UpdateEngrave(SetEngrave setEngrave)
        {
            SQLiteConnection conn = new SQLiteConnection(DataSourcePath);
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update Engrave set Name='" + setEngrave.Name +
                                               "',Target='" + setEngrave.Target +
                                               "',Equip='" + setEngrave.Equip +
                                               "',Acc='" + setEngrave.Acc +
                                               "',Possesion='" + setEngrave.Possession + "' where id =" + setEngrave.Key;

            cmd.ExecuteNonQuery();
        
        }
        public List<SetEngrave> GetEngrave()
        {
            List<SetEngrave> engraves= new List<SetEngrave>();
            SQLiteConnection conn = new SQLiteConnection(DataSourcePath);
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            string sql;
            if (!CheckIfColumnExists("Engrave", "Possesion"))
            {
                sql = "ALTER TABLE Engrave ADD Possesion nText";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                List<int> ids = new List<int>();
                sql = "select * from Engrave";
                cmd.CommandText = sql;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        int id;
                        id = (int)rdr["id"];
                        ids.Add(id);
                    }
                }
                cmd = conn.CreateCommand();
                for (int i = 0; i < ids.Count; i++)
                {
                    cmd.CommandText = "update Engrave set Possesion='미사용-0_미사용-0_미사용-0_미사용-0' where id =" + ids[i];

                    cmd.ExecuteNonQuery();
                }
            }

            sql = "select * from Engrave";
            try
            {
                cmd.CommandText = sql;
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    while (rdr.Read())
                    {
                        SetEngrave engrave = new SetEngrave();
                        engrave.Name = (string)rdr["Name"];
                        engrave.Target = (string)rdr["Target"];
                        engrave.Equip = (string)rdr["Equip"];
                        engrave.Acc = (string)rdr["Acc"];
                        engrave.Possession = (string)rdr["Possesion"];
                        engraves.Add(engrave);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Engrave Table이 존재 하지 않습니다. 재 생성하겠습니다.");

                sql = "CREATE TABLE Engrave (id int, Name nText,Target nText, Equip nText, Acc nText, Possession nText, PRIMARY KEY(id) );";
                cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();
                sql = "INSERT INTO Engrave (id , Name,Target, Equip, Acc, possession) " +
                                        "VALUES ('" + FinalStateStr.GetHashCode() + "','" + FinalStateStr + "','미사용-0_미사용-0_미사용-0_미사용-0_미사용-0_미사용-0_미사용-0','미사용-0_미사용-0_미사용-0_미사용-0_미사용-0','0_0_0_0_0_없음_없음_없음_없음_없음_없음','미사용-0_미사용-0_미사용-0_미사용-0');";
                cmd = new SQLiteCommand(sql, conn);

                cmd.ExecuteNonQuery();
                sql = "select * from Engrave";
    
                    cmd.CommandText = sql;
                    SQLiteDataReader rdr = cmd.ExecuteReader();
                    if (rdr != null)
                    {
                        while (rdr.Read())
                        {
                            SetEngrave engrave = new SetEngrave();
                            engrave.Name = (string)rdr["Name"];
                            engrave.Target = (string)rdr["Target"];
                            engrave.Equip = (string)rdr["Equip"];
                            engrave.Acc = (string)rdr["Acc"];
                            engrave.Possession = (string)rdr["Possesion"];
                            engraves.Add(engrave);
                        }
                    }
                }
            return engraves;
        }
        public void DeleteEngrave(int Key)
        {
            SQLiteConnection conn = new SQLiteConnection(DataSourcePath);
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            string sql = "delete from Engrave where id = " + Key;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
       
        }
        private bool CheckIfColumnExists(string tableName, string columnName)
        {
            using (var conn = new SQLiteConnection(DataSourcePath))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("PRAGMA table_info({0})", tableName);

                var reader = cmd.ExecuteReader();
                int nameIndex = reader.GetOrdinal("Name");
                while (reader.Read())
                {
                    if (reader.GetString(nameIndex).Equals(columnName))
                    {
                        conn.Close();
                        return true;
                    }
                }
                conn.Close();
            }
            return false;
        }
    }
}
