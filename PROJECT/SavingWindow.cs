using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT
{
    public partial class SavingWindow : Form
    {
        public static int CheckForm {  get; set; }
        public static string CheckSubFactory { get; set; }
        public static string BU_STRAT { get; set; }
        public static bool email_sent;

        public SavingWindow(int WindowOption,string SubFactory,String BU)
        {
            InitializeComponent();
            CheckForm = WindowOption;
            CheckSubFactory = SubFactory;
            BU_STRAT = BU;
            Send_email();
        }

        private async void Send_email()
        {   
            Connection.mail.To.Clear();
            
            if (CheckSubFactory == "BMS")
            {
                foreach (string Email in Connection.BMS_Emails)
                    Connection.mail.To.Add(Email);
            }
            else if (CheckSubFactory == "LTX")
            {

                foreach (string Email in Connection.LTX_Emails)
                    Connection.mail.To.Add(Email);
            }
            else if (CheckSubFactory == "NBMS/NI/ETS88")
            {
                foreach (string Email in Connection.NbmsNIETS88_Emails)
                    Connection.mail.To.Add(Email);
            }
            else if (CheckSubFactory == "NBMS")
            {
                foreach (string Email in Connection.Nbms_B1_Emails)
                    Connection.mail.To.Add(Email);
            }
            else if (CheckSubFactory == "HPCA" || CheckSubFactory == "HPCC" || CheckSubFactory == "HPCS")
            {
                foreach (string Email in Connection.HPC)
                    Connection.mail.To.Add(Email);
            }
            else if (CheckSubFactory == "RFC" )
            {
                foreach (string Email in Connection.RFC_SUB)
                    Connection.mail.To.Add(Email);
            }
            else if (CheckSubFactory == "MPD" || CheckSubFactory == "AUTO" || CheckSubFactory == "AERO" || CheckSubFactory == "MIC_WIL" || CheckSubFactory == "MIC_SC")
            {
                foreach (string Email in Connection.MpdAutoAeroMic)
                    Connection.mail.To.Add(Email);
            }
            else if (CheckSubFactory == "INT" || CheckSubFactory == "COM" || CheckSubFactory == "STR")
            {
                foreach (string Email in Connection.ComIntStrip)
                    Connection.mail.To.Add(Email);
            }
            else if (BU_STRAT == "PAG")
            {
                foreach (string Email in Connection.PAG)
                    Connection.mail.To.Add(Email);
            }
            else if (BU_STRAT == "CONVERTERS")
            {
                foreach (string Email in Connection.Converters)
                    Connection.mail.To.Add(Email);
            }
            else if (BU_STRAT == "POWER")
            {
                foreach (string Email in Connection.POWER)
                    Connection.mail.To.Add(Email);
            }
            else if (BU_STRAT == "ISOLATOR")
            {
                foreach (string Email in Connection.ISOLATOR)
                    Connection.mail.To.Add(Email);
            }
            else if (BU_STRAT == "VET")
            {
                foreach (string Email in Connection.VET)
                    Connection.mail.To.Add(Email);
            }
            else if (BU_STRAT == "RFC")
            {
                foreach (string Email in Connection.RFC)
                    Connection.mail.To.Add(Email);
            }

            Connection.mail.From = new MailAddress("HIT.APP@analog.com");

            Connection.mail.To.Add("RalphYaz.Diaz@analog.com");
            
            Connection.mail.To.Add("johnmichael.so@analog.com");

            email_sent = await Task.Run(async () => await SavingWindow.Email_send(CheckForm));

            if (email_sent)
            {
                MessageBox.Show("FILE SAVED SUCCESSFULLY");
            }
            this.Close();
        }

        public static async Task<bool> Email_send(int checkform)
        {
            // Configure SMTP client for Outlook
            SmtpClient smtpClient = new SmtpClient("mail.analog.com", 25)
            {
                EnableSsl = false,
                Credentials = new NetworkCredential("HIT.APP@analog.com", "Ana-@og123"),
                Timeout = 10000
            };
            switch (checkform)
            {
                case 1:
                   
                    Connection.mail.Subject = ADD.subject;

                    Connection.mail.IsBodyHtml = true;

                    Connection.mail.Body = ADD.body;

                    foreach (string file in ADD.Files)
                    {
                        Attachment ADDFiles = new Attachment(file);
                        Connection.mail.Attachments.Add(ADDFiles);
                    }
                    ADD.Files.Clear();
                    await smtpClient.SendMailAsync(Connection.mail);
                    Connection.mail.Attachments.Clear();
                    break;
                case 2:

                    Connection.mail.Subject = BOARD_DETAILS.subject;

                    Connection.mail.IsBodyHtml = true;

                    Connection.mail.Body = BOARD_DETAILS.body;

                    await smtpClient.SendMailAsync(Connection.mail);
                    break;
                case 3:

                    Connection.mail.Subject = BOARD_DETAILS.subject;

                    Connection.mail.IsBodyHtml = true;

                    Connection.mail.Body = BOARD_DETAILS.body;


                    Attachment AttachFile = new Attachment(BOARD_DETAILS.New_File_Link);
                    Connection.mail.Attachments.Add(AttachFile);

                    await smtpClient.SendMailAsync(Connection.mail);
                    Connection.mail.Attachments.Clear();
                    break;
            }
            return true;
            //MessageBox.Show("email sent!");

        }

        private void SavingWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            var boardForm = Application.OpenForms
                .OfType<BOARD_DETAILS>()
                .FirstOrDefault();

            boardForm?.Close();
        }
    }

}
