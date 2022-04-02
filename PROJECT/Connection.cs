using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Forms;

namespace PROJECT
{
    class Connection
    {
        //public static MySqlConnection connect = new MySqlConnection("server=CAV-DT-TSG36A;user id=newuser;password=onemigso101996;database=boards_for_verification");
        //public static MySqlConnection ConnectBoards = new MySqlConnection("server=CAV-DT-TSG36A;user id=newuser;password=onemigso101996;database=boards_of_testers");
        public static MySqlConnection connect = new MySqlConnection("server=localhost;user id=root;password=onemigso101996;database=boards_for_verification;persistsecurityinfo=True");
        public static MySqlConnection ConnectBoards = new MySqlConnection("server=localhost;user id=root;password=onemigso101996;database=boards_of_testers");

        public static bool OpenConnection()
        {
            try
            {
                connect.Open();
                return true;
            }
            catch (MySqlException me)
            {
                switch (me.Number)
                {
                    case 0:
                        MessageBox.Show("CANNOT CONNECT TO THE SERVER, CHECK THE NETWORK OR CONTACT ADMINISTRATOR");
                        break;
                    default:
                        MessageBox.Show(me.ToString());
                        break;
                }
                return false;
            }
        }
        public static bool CloseConnection()
        {
            try
            {
                connect.Close();
                return true;
            }
            catch (MySqlException me)
            {
                MessageBox.Show(me.ToString());
                return false;
            }
        }
        public static bool OpenConnectionForBoards()
        {
            try
            {
                ConnectBoards.Open();
                return true;
            }
            catch (MySqlException me)
            {
                MessageBox.Show(me.ToString());
                switch (me.Number)
                {
                    case 0:
                        MessageBox.Show("CANNOT CONNECT TO THE SERVER, CHECK THE NETWORK OR CONTACT ADMINISTRATOR");
                        break;
                    default:
                        MessageBox.Show(me.ToString());
                        break;
                }
                return false;
            }
        }
        public static bool CloseConnectionForBoards()
        {
            try
            {
                ConnectBoards.Close();
                return true;
            }
            catch (MySqlException me)
            {
                MessageBox.Show(me.ToString());
                return false;
            }
        }
    }
}
