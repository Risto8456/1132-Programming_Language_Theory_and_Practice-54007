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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public void getData(out string PictureName, out string ContainerName)
        {
            PictureName = textBox1.Text;
            ContainerName = textBox2.Text;
        }
    }
}
