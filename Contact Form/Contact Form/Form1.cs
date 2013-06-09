using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Contact_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NetworkCredential cred = new NetworkCredential(txtEmail.Text, txtPass.Text);
            MailMessage msg = new MailMessage();
            msg.To.Add("admin@skillscape.org");
            msg.From = new MailAddress(txtEmail.Text);
            msg.Subject = txtTopic.Text;
            msg.Body = txtMsg.Text;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            client.Credentials = cred;
            client.EnableSsl = true;
            client.Send(msg);
            MessageBox.Show("You have successfully sent your email to the staff of SkillScape.", "Success");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
