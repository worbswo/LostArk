using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using System.IO;
using Http.Model;
using Newtonsoft.Json.Bson;

namespace Http.Code.DataBase
{
    public class DataBase
    {
        internal string DataSourcePath { get; set; }
        public static string FinalStateStr = "finalStateSaveName";
        public DataBase(string productDataFile)
        {
            FileInfo fileInfo = new FileInfo(productDataFile);
            DataSourcePath = "Data Source=" + productDataFile;
            if (fileInfo.Exists)
            {
            }
            else
            {
                createDb();
            }
        }
        void createDb()
        {
            SqlCeEngine engine = new SqlCeEngine(DataSourcePath);
            engine.CreateDatabase();
            engine.Dispose();

            SqlCeConnection conn = new SqlCeConnection(DataSourcePath);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();
            string sql = "CREATE TABLE API (APIKey nText);";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "CREATE TABLE Engrave (id int, Name nText,Target nText, Equip nText, Acc nText, PRIMARY KEY(id) );";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Engrave (id , Name,Target, Equip, Acc) " +
                                    "VALUES (@id, @Name,@Target, @Equip, @Acc);";
            SqlCeParameter Key = cmd.Parameters.Add("id", SqlDbType.Int);

            SqlCeParameter Name = cmd.Parameters.Add("Name", SqlDbType.NText);
            SqlCeParameter Target = cmd.Parameters.Add("Target", SqlDbType.NText);
            SqlCeParameter Equip = cmd.Parameters.Add("Equip", SqlDbType.NText);
            SqlCeParameter Acc = cmd.Parameters.Add("Acc", SqlDbType.NText);
            Key.Value = FinalStateStr.GetHashCode();

            Name.Value = FinalStateStr;
            Target.Value = "미사용-0_미사용-0_미사용-0_미사용-0_미사용-0_미사용-0_미사용-0";
            Equip.Value = "미사용-0_미사용-0_미사용-0_미사용-0_미사용-0";
            Acc.Value = "0_0_0_0_0_없음_없음_없음_없음_없음_없음";
            cmd.ExecuteNonQuery();

        }
        public List<string> getAPIKey()
        {
            List<string> apiKey = new List<string>();
            SqlCeConnection conn = new SqlCeConnection(DataSourcePath);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();


            string sql = "select * from API";
            cmd.CommandText = sql;
            SqlCeDataReader rdr = cmd.ExecuteReader();
            if (rdr!=null){
                while (rdr.Read())
                {
                    string key = (string)rdr["APIKey"];
                    apiKey.Add(key);
                }
            }
            return apiKey;
        }
        public void AddAPIKey(string apikey)
        {
            SqlCeConnection conn = new SqlCeConnection(DataSourcePath);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO API(APIKey) " +
                                    "VALUES (@APIKey);";
            SqlCeParameter ApiKeyParam = cmd.Parameters.Add("APIKey", SqlDbType.NText);
            ApiKeyParam.Value = apikey;
            cmd.ExecuteNonQuery();
            conn.Dispose();
            conn.Close();
        }
        public void AddEngrave(SetEngrave setEngrave)
        {
            SqlCeConnection conn = new SqlCeConnection(DataSourcePath);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Engrave (id , Name,Target, Equip, Acc) " +
                                    "VALUES (@id, @Name,@Target, @Equip, @Acc);";
            SqlCeParameter Key = cmd.Parameters.Add("id", SqlDbType.Int);

            SqlCeParameter Name = cmd.Parameters.Add("Name",SqlDbType.NText);
            SqlCeParameter Target = cmd.Parameters.Add("Target", SqlDbType.NText);
            SqlCeParameter Equip = cmd.Parameters.Add("Equip", SqlDbType.NText);
            SqlCeParameter Acc = cmd.Parameters.Add("Acc", SqlDbType.NText);
            Key.Value = setEngrave.Name.GetHashCode() ;

            Name.Value = setEngrave.Name;
            Target.Value = setEngrave.Target;
            Equip.Value = setEngrave.Equip;
            Acc.Value = setEngrave.Acc;
            cmd.ExecuteNonQuery();
            conn.Dispose();
            conn.Close();
        }
        public void UpdateEngrave(SetEngrave setEngrave)
        {
            SqlCeConnection conn = new SqlCeConnection(DataSourcePath);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();
            cmd.CommandText = "update Engrave set Name='" + setEngrave.Name +
                                               "',Target='" + setEngrave.Target +
                                               "',Equip='" + setEngrave.Equip +
                                               "',Acc='" + setEngrave.Acc + "' where id =" + setEngrave.Key;

            cmd.ExecuteNonQuery();
            conn.Dispose();
            conn.Close();
        }
        public List<SetEngrave> GetEngrave()
        {
            List<SetEngrave> engraves= new List<SetEngrave>();
            SqlCeConnection conn = new SqlCeConnection(DataSourcePath);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();


            string sql = "select * from Engrave";
            cmd.CommandText = sql;
            SqlCeDataReader rdr = cmd.ExecuteReader();
            if (rdr != null)
            {
                while (rdr.Read())
                {
                    SetEngrave engrave= new SetEngrave();
                    engrave.Name = (string)rdr["Name"];
                    engrave.Target = (string)rdr["Target"];
                    engrave.Equip = (string)rdr["Equip"];
                    engrave.Acc = (string)rdr["Acc"];
                    engraves.Add(engrave);
                }
            }
            return engraves;
        }
        public void DeleteEngrave(int Key)
        {
            SqlCeConnection conn = new SqlCeConnection(DataSourcePath);
            conn.Open();
            SqlCeCommand cmd = conn.CreateCommand();
            string sql = "delete from Engrave where id = " + Key;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            conn.Dispose();
            conn.Close();
        }
    }
}
