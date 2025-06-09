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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public void getData(out string RectangleName, out string PictureName, out double length, out double width)
        {
            RectangleName = textBox1.Text;
            PictureName = textBox2.Text;
            try
            {
                length = Convert.ToDouble(textBox3.Text);
                width = Convert.ToDouble(textBox4.Text);
            }
            catch (Exception ex)
            {
                length = 0.0;
                width = 0.0;
                MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
