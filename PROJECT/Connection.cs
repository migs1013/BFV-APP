using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Web.UI.DataVisualization.Charting;

namespace PROJECT
{
    class Connection
    {
        public static string[] F2_Sub_Factories = { "BMS", "LTX", "NBMS/NI/ETS88" };
        public static string[] F3_Sub_Factories = { "NBMS", "HPCA", "HPCC", "HPCS", "INT", "COM", "STR", "RFC", "MPD", "PRB", "WLT", "STD", "MIC_WIL", "MIC_SC", "AERO" };

        public static string[] LTX_Emails = { "LTXTS88PETechnicians@analog.com", "LTXTS88PETestEngineers@analog.com", "LTXTS88ProductEngineers@analog.com", "servil.saulog@analog.com" };
        public static string[] BMS_Emails = { "ADPhilsLinearBMSTPE@analog.com", "ADPhilsLinearBMSTPETech@analog.com", "MayanaJoy.Duran@analog.com" };
        public static string[] NbmsNIETS88_Emails = { "ADPhilsLinearBMSTPETech@analog.com", "MayanaJoy.Duran@analog.com", "ADPhils_Linear_nBMSB3_ETS88_NI@analog.com" };
        public static string[] Nbms_B1_Emails = { "Nadinejean.Ebarle@analog.com", "ADPhils_Linear_PE_ETS_NonBMS@analog.com", "NMBS_PE_TECH@analog.com" };
        public static string[] Legacy_B1_Emails = { "COM_INT_PROD-TECH@analog.com", "Strip_ProductTechnicians@analog.com", "Joefer.Joven@analog.com" };

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

        public static void ClearAll(Control CheckControl)
        {
            foreach (Control check in CheckControl.Controls)
            {
                switch (check)
                {
                    case TextBox tb:
                        tb.Clear(); break;
                    case ComboBox cb:
                        cb.SelectedIndex = -1; break;
                    case LinkLabel lb:
                        lb.Text = null; break;
                    case Label label:
                        if (label.Name == "FirstDate")
                            label.Text = null;
                        break;
                    default:
                        if (check.HasChildren)
                        {
                            ClearAll(check);
                        }
                        break;
                }
            }
        }
        
    }
}
