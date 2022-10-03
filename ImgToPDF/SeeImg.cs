using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
//using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImgToPDF
{
    public partial class SeeImg : Form
    {
        //public bool m_bOK = false;
        public string ImgPath
        {
            //get { return ; }
            set { pictureBox1.ImageLocation = value; this.Text = value; }
        }
        public SeeImg()
        {
            InitializeComponent();
        }

        private void startImg_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.File.Exists(pictureBox1.ImageLocation))
                {
                    //MessageBox.Show(pictureBox1.ImageLocation);
                    ProcessStartInfo pinf = new ProcessStartInfo("mspaint",pictureBox1.ImageLocation);            
                    Process pro = Process.Start(pinf);
                    this.Close();
                }
            }catch(Exception err)
            {
                MessageBox.Show("错误："+err);
            }
        }
    }
}
