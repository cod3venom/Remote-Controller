using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remote_Control_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void Form1_Load(object sender, EventArgs e)
        {
         

        }
        private void check_user()
        {
            if (!string.IsNullOrEmpty(userTxt.Text) || !string.IsNullOrEmpty(passtxt.Text))
            {
                if (userTxt.Text == "admin" || passtxt.Text == "admin")
                {
                    UI.AdminControl _admin = new UI.AdminControl();
                    if (!_admin.IsDisposed)
                    {

                        _admin.Show();
                        _admin.WindowState = FormWindowState.Maximized;
                    }
                    if (_admin.IsDisposed)
                    {
                        _admin = new UI.AdminControl();
                        _admin.Show();
                        _admin.WindowState = FormWindowState.Maximized;

                    }
                    this.Hide();
                }
            }

        }
        private void closeControl_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (string.IsNullOrEmpty(userTxt.Text))
                {
                    errorLabel.Text = " Please enter username";
                    return;
                }
                if (string.IsNullOrEmpty(passtxt.Text))
                {
                    errorLabel.Text = " Please enter password";
                    return;
                }
                check_user();
            }

        }
    }
}
