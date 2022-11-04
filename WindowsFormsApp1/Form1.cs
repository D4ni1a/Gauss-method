using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int n;
        Form2 A;
        public Form1()
        {
            InitializeComponent();
            button2.Hide();
            button3.Hide();
            A = new Form2();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                n = Int32.Parse(textBox1.Text);
                dataGridView1.RowCount = n;
                dataGridView1.ColumnCount = n+1;
                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Columns[i].Width = 30;
                    dataGridView1.Rows[i].Height = 30;
                    dataGridView1.Columns[i].HeaderText = "A"+System.Convert.ToString(i+1);
                }
                dataGridView1.Columns[n].Width = 30;
                dataGridView1.Columns[n].HeaderText = "B";
                dataGridView1.Width = 30*(n+3);
                dataGridView1.Height = 180;
                button2.Show();
                
                button1.Hide();
                textBox1.Hide();
                label1.Hide();

            }
            catch
            {
                MessageBox.Show("Неверный формат ввода данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        
         private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                Matrix Mass = new Matrix(n);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Mass[i, j] = Double.Parse(System.Convert.ToString(dataGridView1[j, i].Value));
                    }
                }
                if (n != dataGridView1.RowCount-1)
                {
                    MessageBox.Show("Для получения решения достаточно " + n.ToString()+
                        " уравнений, поэтому строки после "+ (n).ToString()+
                        " не учитывались", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                double[] B = new double[n];
                for (int j = 0; j < n; j++)
                {
                    B[j] = Double.Parse(System.Convert.ToString(dataGridView1[n, j].Value));
                }
                string[] X = Mass.Result(B);



                dataGridView2.RowCount = 1;
                dataGridView2.ColumnCount = n;
                for (int i = 0; i < n; i++)
                {
                    dataGridView2.Columns[i].Width = 55;
                    dataGridView2.Columns[i].HeaderText = "X" + System.Convert.ToString(i + 1);
                }

                dataGridView2.Width = 55 * (n + 3);
                dataGridView2.Height = 180;

                for (int i = 0; i < n; i++)
                {
                    dataGridView2[i, 0].Value = X[i];
                }
                button3.Show();
                button2.Hide();
            }
            catch
            {
                MessageBox.Show("Неверный формат ввода данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            A.Show();
        }
    }
}
