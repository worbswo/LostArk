using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using System.IO;

namespace Http.Code.DataBase
{
    public class DataBase
    {
        internal string DataSourcePath { get; set; }

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
            sql = "CREATE TABLE target (Ablity1 nText,Ablity2 nText,Ablity3 nText,Ablity4 nText,Ablity5 nText,Ablity6 nText,Ablity7 nText," +
                                        "AblityValue1 int,AblityValue2 int,AblityValue3 int,AblityValue4 int,AblityValue5 int,AblityValue6 int,AblityValue7 int );";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "CREATE TABLE equip (Ablity1 nText,Ablity2 nText,Ablity3 nText,Ablity4 nText,Ablity5 nText," +
                                        "AblityValue1 int,AblityValue2 int,AblityValue3 int,AblityValue4 int,AblityValue5 int);";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            sql = "CREATE TABLE accesory (qualty1 int,qualty2 int,qualty3 int,qualty4 int,qualty5 int," +
                                         "char1 nText, char2 nText, char3 nText, char4 nText, char5 nText, char6 nText);";
            cmd.CommandText = sql;
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
    }
}
