using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.UI.DataVisualization.Charting;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace PROJECT
{
    class Connection
    {
        public static readonly MailMessage mail = new MailMessage();

        public static string[] F2_Sub_Factories = { "", "BMS", "LTX", "NBMS (B3)", "NI", "ETS88", "NBMS (B1)" };
        public static string[] F1_Sub_Factories = { "", "HPCA", "HPCC", "HPCS", "INT", "COM", "STR", "RFC", "MPD", "MIC_WIL", "MIC_SC", "AERO" };

        public static string[] LTX_Emails = { "LTXTS88PETechnicians@analog.com", "LTXTS88PETestEngineers@analog.com", "LTXTS88ProductEngineers@analog.com", "servil.saulog@analog.com" };
        public static string[] BMS_Emails = { "ADPhilsLinearBMSTPE@analog.com", "ADPhilsLinearBMSTPETech@analog.com", "bms_linetechnician@analog.com", "MayanaJoy.Duran@analog.com" };
        public static string[] NbmsNIETS88_Emails = { "ADPhils_Linear_nBMSB3_ETS88_NI@analog.com", "ADPhilsLinearBMSTPETech@analog.com", "bms_linetechnician@analog.com", "MayanaJoy.Duran@analog.com" };
        public static string[] Nbms_B1_Emails = { "Nadinejean.Ebarle@analog.com", "ADPhils_Linear_PE_ETS_NonBMS@analog.com", "NMBS_PE_TECH@analog.com" };
        public static string[] ComIntStrip = { "COM_INT_PROD-TECH@analog.com", "Strip_ProductTechnicians@analog.com", "Joefer.Joven@analog.com" };
        public static string[] HPC = { "HPCC_PROD-TECH@analog.com", "HPCS_PROD-TECH@analog.com", "Dexter.Guevarra@analog.com" };
        public static string[] RFC_SUB = { "ADGT_COMTG_PE@analog.com ", "COM_INT_PROD-TECH@analog.com" };
        public static string[] MpdAutoAeroMic = { "ADGT_ADEF_PE@analog.com", "ADGTAutoEng@analog.com" , "AEGTGPE@analog.com" };
        public static string[] PAG = { "ADGT_PAG_TPE@analog.com", "COM_INT_PROD-TECH@analog.com" };
        public static string[] Converters = { "Converters_TPE_F1_Phils@analog.com" };
        public static string[] POWER = { "ADGT_PPGTG_PE@analog.com"};
        public static string[] ISOLATOR = { "AEGTGPE@analog.com" };
        public static string[] VET = { "adgtautoeng@analog.com", "ADGTB3ProdTech@analog.com" };
        public static string[] RFC = { "ADGT_MCG_PE@analog.com", "rfcprodtech@analog.com" };    

        // LOCAL HOST
        // public static MySqlConnection connect = new MySqlConnection("server=localhost;user id=root;password=onemigso1013;database=hit;persistsecurityinfo=True");

        // OLD SERVER
        // public static MySqlConnection connect = new MySqlConnection("server=CAV-BMS-D01;user id=root;password=onemigso1013;database=hit");

        // NEW SERVER
        public static MySqlConnection connect = new MySqlConnection("server=CAV-LTC-D09;user id=root;password=Adgt1234;database=hit");

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
                        if (cb.Name == "SUB_FACTORY" || cb.Name == "BU_STRAT") continue;
                        cb.SelectedIndex = -1;
                        cb.Text = "";
                        break;
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
