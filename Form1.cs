using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PictureEncoding64
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        int mousex, mousey;
        bool tut=false;
        string picturelocation;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult cv = new DialogResult();
            cv = MessageBox.Show("Çıkış Yapmak İstiyor Musunuz ?","Çıkış İşlemi!!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (cv==DialogResult.Yes)
            {
                MessageBox.Show("Çıkış İşlemi Başarılı..", "Çıkış İşlemi!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }      
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (tut==true)
            {
                this.SetDesktopLocation(MousePosition.X - mousex, MousePosition.Y - mousey);
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            tut = true;
            mousex = e.X;
            mousey = e.Y;
        }
        private void simpleButton1_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(simpleButton1, "Çıkış İşlemi!");
        }
        private void simpleButton2_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(simpleButton2, "Aşağı Al!");
        }
        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {
            picturelocation=pictureEdit1.GetLoadedImageLocation();
        }
        private void labelControl1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text=="")
            {
                MessageBox.Show("METİN KUTUSUNU BOŞ GEÇMEYİNİZ !!", "BOŞ GEÇMEYİNİZ !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox1.Focus();
            }
            else
            {
                try
                {
                    byte[] veri = Convert.FromBase64String(richTextBox1.Text);
                    string cöz = ASCIIEncoding.ASCII.GetString(veri);
                    richTextBox2.Text = cöz;
                    MessageBox.Show("BAŞARILI ŞEKİLDE ŞİFRE ÇÖZÜLDÜ!!", "BAŞARILI!!", MessageBoxButtons.OK, MessageBoxIcon
                        .Information);
                    richTextBox2.Focus();
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message, "HATALI!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    richTextBox1.Text = "";
                }
            }      
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (picturelocation == "")
                {
                    MessageBox.Show("RESİM BOŞ GEÇMEYİNİZ RESİM SEÇİNİZ !!", "BOŞ GEÇMEYİNİZ !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    byte[] imageBytes = System.IO.File.ReadAllBytes(picturelocation);
                    string base64Formatted = Convert.ToBase64String(imageBytes);
                    richTextBox2.Text = base64Formatted;
                    richTextBox2.Focus();
                    MessageBox.Show("BAŞARILI ŞEKİLDE RESİM ÇÖZÜLDÜ!", "BAŞARILI!", MessageBoxButtons.OK, MessageBoxIcon
                            .Information);
               }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message,"RESİM BOŞ GEÇMEYİNİZ RESİM SEÇİNİZ !!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void labelControl2_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(labelControl2, "Sade Metni Şifreleme Yap!");
        }
        private void labelControl1_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(labelControl1, "Şifreli Metni Çöz!");
        }
        private void simpleButton3_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(simpleButton3, "Resim Seçip Şifrelemesini Yapar!");
        }
        private void labelControl2_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox2.Text=="")
                {
                    MessageBox.Show("METİN KUTUSUNU BOŞ GEÇMEYİNİZ!!", "HATALI!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    richTextBox2.Focus();
                }
                else
                {
                    byte[] veri = ASCIIEncoding.ASCII.GetBytes(richTextBox2.Text);
                    string sifrele = Convert.ToBase64String(veri);
                    richTextBox1.Text = sifrele;
                    MessageBox.Show("BAŞARILI ŞEKİLDE ŞİFRELENDİ!", "BAŞARILI!!", MessageBoxButtons.OK, MessageBoxIcon
                            .Information);
                    richTextBox1.Focus();
                }              
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "HATALI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }
       private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            tut = false;         
        }
    }
}
