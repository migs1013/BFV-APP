using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PROJECT
{
    class Connection
    {
        // LOCAL HOST
        public static MySqlConnection connect = new MySqlConnection("server=localhost;user id=root;password=onemigso1013;database=hit;persistsecurityinfo=True");

        // OLD SERVER
        // public static MySqlConnection connect = new MySqlConnection("server=CAV-BMS-D01;user id=root;password=onemigso1013;database=hit");

        // NEW SERVER
        // public static MySqlConnection connect = new MySqlConnection("server=CAV-LTC-D09;user id=root;password=Adgt1234;database=hit");

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
