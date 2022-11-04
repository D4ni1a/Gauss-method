using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    class Matrix //Класс Massiv
    {
        double[,] a; //Строковый массив
        public int len; //Переменная для размера массива
        string name; //Имя массива
        public Matrix(int N, string M) //Конструктор для его размера, имени и элементов
        {
            len = N;
            name = M;
            a = new double[N,N];
        }
        public Matrix(int N) //Конструктор для его размера, имени и элементов
        {
            len = N;
            a = new double[N, N];
        }
        public double this[int index1, int index2] //Индексатор для добавления и извлечения элементов
        {
            get
            {
                return a[index1, index2]; //Извлечение
            }
            set
            {
                a[index1, index2] = value; //Добавление
            }
        }
        public double[] Changer(double[] b, int num)
        {
            double c;
            int delta;
            for (int i = num; i < len; i++)
                {
                    c = 0;
                delta = 0;
                    if (a[i, i] == 0)
                    {
                    if (i + 1 == len) delta = num + 1;
                    else delta = 0;
                    for (int j = 0; j < len; j++)
                    {

                        c = a[i, j];
                        a[i, j] = a[(i + 1) % len+delta, j];
                        a[(i + 1) % len + delta, j] = c;

                    }
                    c = b[i];
                    b[i] = b[(i + 1) % len +delta];
                    b[(i + 1) % len + delta] = c;
                
                }
            }
            
            return b;
        }


        public void Shower(double[] b, int  k)
        {
            if (k == 3)
            {
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < len; j++)
                    {
                        Form2.richTextBox3.Text += (Math.Round(a[i, j], 3).ToString() + "\t");
                    }
                    Form2.richTextBox3.Text += Math.Round(b[i], 3).ToString() + "\n\n\n\n";
                }
            }
            else
            {
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < len; j++)
                    {
                        Form2.richTextBox4.Text += (Math.Round(a[i, j], 3).ToString() + "\t");
                    }
                    Form2.richTextBox4.Text += Math.Round(b[i], 3).ToString() + "\n\n\n\n";
                }
            }
            
        }



        public string[] Result(double[] b)
        {
            b = Changer(b, 0);
            for (int i = 0; i < len - 1; i++)
            {
                b = Changer(b, i);
                for (int j = i + 1; j < len; j++)
                {
                    
                    double l = a[j, i];
                    for (int k = 0; k < len+1; k++)
                    {
                        if (k!=len) a[j, k] = a[j, k] - a[i, k] * (l / a[i, i]);
                        else b[j] = b[j] - b[i] * (Math.Round((l / a[i, i]),5));
                    }
                    
                }
                b = Changer(b, i);
                if (i == 0) Shower(b, 0);
            }
            Shower(b, 3);

            string[] x = new string[len];
            if ((a[len - 1, len-1] == 0) && (b[len-1] == 0))
            {
                for (int i = len - 1; i >= 0; i--)
                {
                    x[i] = "Беск.";
                }
            }
            else
            {
                if ((a[len - 1, len - 1] == 0) && (b[len-1] != 0))
                {
                    for (int i = len - 1; i >= 0; i--)
                    {
                        x[i] = "-";
                    }
                }
                else
                {
                    for (int j = 0; j < len; j++)
                    {
                        x[j] = 0.ToString();
                    }
                        for (int i = len - 1; i >= 0; i--)
                    {
                        double sum = 0;
                        for (int j = 0; j < len; j++)
                        {
                            if (j != i)
                            {
                                sum += a[i, j] *Double.Parse(x[j]);
                            }
                        }
                        x[i] = System.Convert.ToString(Math.Round((b[i] - sum) / a[i, i],5));
                    }
                }
            }
            return x;
        }
    }
}
