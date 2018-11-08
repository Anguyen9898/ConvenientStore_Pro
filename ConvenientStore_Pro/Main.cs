using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvenientStore_Pro
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; //Tao doi tuong button cua chinh no
            Barcode_textBox.Text += btn.Text;
        }

        private void Enter_btn_Click(object sender, EventArgs e)
        {

        }

        private void Bksp_btn_Click(object sender, EventArgs e)
        {
            if (Barcode_textBox.Text != "")//o barcode khong rong
                Barcode_textBox.Text = Barcode_textBox.Text.Substring(0, Barcode_textBox.Text.Length - 1);
            else//o bracode rong
                return;
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            Barcode_textBox.Text = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            String s = dt.ToString("HH:mm:ss dd/MM/yyyy");
            infor_label.Text = s;
        }

        private void frm_Main_Shown(object sender, EventArgs e)
        {
            Barcode_textBox.Focus();
            timer1.Start();
        }
        
        private void frm_Main_Load(object sender, EventArgs e)
        {
            sC_Tool2.Panel2.Controls.Add(UC_SignOn.Instance);
            UC_SignOn.Instance.Dock = DockStyle.Fill;
            frm_SignOff signOff = new frm_SignOff();
            signOff.ShowDialog();
            frm_SignOn signOn = new frm_SignOn();
            signOn.ShowDialog();
            //UC_SignOn.Instance.btn_SignOn.Click += Btn_SignOn_Click;
        }

      /* private void Btn_SignOn_Click(object sender, EventArgs e)
        {
            sC_Tool2.Panel2.Controls.Remove(UC_SignOn.Instance);
            sC_Tool2.Panel2.Controls.Add(UC_Em.Instance);
            UC_Em.Instance.Dock = DockStyle.Fill;
            Barcode_textBox.Enabled = false;
            frm_SignOn frmSign = new frm_SignOn();
            lb_Note.Text = "Plese enter your ID";
            frmSign.ShowDialog();
        }*/

        private void Barcode_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Barcode_textBox_Enter(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.OK;
        }
    }
}
