using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Symbolics;

namespace Numrical_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bisection bisection = new Bisection();
            bisection.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Falseposition falseposition = new Falseposition();
            falseposition.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fixedpoint fixedpoint = new Fixedpoint(); 
            fixedpoint.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Newton newton = new Newton();       
            newton.Show();  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Scant scant = new Scant();  
            scant.Show();       
        }
    }
}
