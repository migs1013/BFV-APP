using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PROJECT
{
    class Connection
    {
        // OLD SERVER:
        //public static MySqlConnection connect = new MySqlConnection("server=CAV-DT-TSG36A;user id=newuser;password=onemigso101996;database=boards_for_verification");
        //public static MySqlConnection ConnectBoards = new MySqlConnection("server=CAV-DT-TSG36A;user id=newuser;password=onemigso101996;database=boards_of_testers");

        // LOCAL HOST
        // public static MySqlConnection connect = new MySqlConnection("server=localhost;user id=root;password=onemigso1013;database=hit;persistsecurityinfo=True");

        // NEW SERVER
        public static MySqlConnection connect = new MySqlConnection("server=CAV-BMS-D01;user id=root;password=onemigso1013;database=hit");

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
                        MessageBox.Show("CANNOT CONNECT TO THE SERVER, CHECK THE NETWORK");
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
    }
}
