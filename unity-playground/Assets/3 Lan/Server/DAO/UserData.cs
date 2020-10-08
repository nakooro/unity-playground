using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SocketGameProtocol;

namespace Assets._3_Lan.DAO
{
    class UserData
    {
        MySqlConnection mysqlCon;

        public UserData()
        {
            ConnectMysql();
        }
        void ConnectMysql()
        {
            string connstr = "database=lan;data source=127.0.0.1;user=root;password=toor;pooling=false;charset=utf8;port=33306";

            try
            {
                mysqlCon = new MySqlConnection(connstr);
                mysqlCon.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("連接失敗 :: " + e.Message);

            }

        }
        public bool Logon(MainPack pack)
        {
            string username = pack.Loginpack.Username;
            string password = pack.Loginpack.Password;

            string sqlstr = string.Format("select * from lan.userdata where username='{0}'", username);
            MySqlCommand cmd = new MySqlCommand(sqlstr, mysqlCon);

            try
            {
                if (cmd.ExecuteReader().HasRows)
                {
                    Console.WriteLine("已經註冊");
                    return false;
                }
                else
                {
                    sqlstr = string.Format("insert into `lan`.`userdata` (`username`, `password`) values ('{0}', '{1}') ", username, password);
                    cmd = new MySqlCommand(sqlstr, mysqlCon);
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }
    }
}
