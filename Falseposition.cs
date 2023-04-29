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
    public partial class Falseposition : Form
    {
        private double f(double x)
        {
            string equationString = textBox1.Text;
            SymbolicExpression equation = SymbolicExpression.Parse(equationString);
            Dictionary<string, FloatingPoint> variables = new Dictionary<string, FloatingPoint> { { "x", x } };
            double result = equation.Evaluate(variables).RealValue;
            return result;
        }
        public Falseposition()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double XL = double.Parse(txtxlower.Text);
            double XU = double.Parse(txtxupper.Text);
            double eps = double.Parse(txttolerance.Text);
            int iteration = 0;
            double xr = 0;
            double xrOld = 0;
            double error = 0;

            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "Iteration";
            dataGridView1.Columns[1].Name = "xl";
            dataGridView1.Columns[2].Name = "F(XL)";
            dataGridView1.Columns[3].Name = "xu";
            dataGridView1.Columns[4].Name = "f(xu)";
            dataGridView1.Columns[5].Name = "xr";
            dataGridView1.Columns[6].Name = "f(xr)";
            dataGridView1.Columns[7].Name = "error%";



            while (true)
            {
                // Calculate the midpoint
                xrOld = xr;
                xr = XU - (f(XU) * (XL - XU)) / (f(XL) - f(XU));


                // Evaluate the function at the midpoint
                error = Math.Abs((xr - xrOld) / xr) * 100;

                // Add the iteration information to the data grid view
                dataGridView1.Rows.Add(iteration, XL, f(XL), XU, f(XU), xr, f(xr), error);

                iteration++;

                // Check if the root is in the left or right half of the interval
                if (f(XL) * f(xr) > 0)
                {
                    XL = xr;
                }
                else
                {
                    XU = xr;
                }

                if (error < eps)
                {
                    textBox2.Text = xr.ToString();
                    break;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    

