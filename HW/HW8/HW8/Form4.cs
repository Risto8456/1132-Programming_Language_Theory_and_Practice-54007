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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public void getData(out string CircleName, out string PictureName, out double radius)
        {
            CircleName = textBox1.Text;
            PictureName = textBox2.Text;
            try
            {
                radius = Convert.ToDouble(textBox3.Text);
            }
            catch (Exception ex)
            {
                radius = 0.0;
                MessageBox.Show(ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
