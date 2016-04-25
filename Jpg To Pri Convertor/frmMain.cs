using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Jpg_To_Pri_Convertor
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                ofg.ShowDialog();
                if(ofg.CheckFileExists)
                {
                    lbl.Text = ofg.FileName;
                    btnConvert.Enabled = true;
                    imgPre.Image = Image.FromFile(ofg.FileName);
                }
            }
            catch
            {
                lbl.Text = "";
                btnConvert.Enabled = false;
            }

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofg.CheckFileExists)
                {
                    Char[] arrjpg;

                    arrjpg = ".jpg".ToCharArray();
                    
                    if (!File.Exists(Path.Combine(Path.GetTempPath(), "temp.pri")))
                    {
                        //File.Copy(@"Resources\Windows.UI.Logon.pri", Path.Combine(Path.GetTempPath(), "temp.pri"));
                        File.Delete(Path.Combine(Path.GetTempPath(), "temp.pri"));
                    }
                    clsMain.WriteResourceToFile(Path.GetTempPath(), "Jpg_To_Pri_Convertor", "temp.pri");
                    clsMain.JpgToPri(Path.Combine(Path.GetTempPath(), "temp.pri"), ofg.FileName.TrimEnd(arrjpg) + ".pri", ofg.FileName);
                    btnConvert.Enabled = false;
                    imgPre.Image = null;
                    lbl.Text = "";
                    File.Delete(Path.Combine(Path.GetTempPath(), "temp.pri"));
                }


            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
