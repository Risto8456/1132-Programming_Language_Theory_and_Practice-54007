using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW8
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        public void getData(out string TriangleName, out string PictureName, out double tbase, out double height)
        {
            TriangleName = textBox1.Text;
            PictureName = textBox2.Text;
            try
            {
                tbase = Convert.ToDouble(textBox3.Text);
                height = Convert.ToDouble(textBox4.Text);
            }
            catch (Exception ex)
            {
                tbase = 0.0;
                height = 0.0;
                MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
