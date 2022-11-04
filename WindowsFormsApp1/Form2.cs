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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            richTextBox1.Text = "Циклически для всех строк от первой до предпоследней \n" +
                "вычитаем данную строку из каждой \n" +
                "идущей после нее, умноженной на соответсвующий коэффициент так, \n" +
                "чтобы получить все нули ниже главной диагонали. (Шаги 1 и 2)";
            richTextBox2.Text = "После этого матрица может: \n1.Иметь бесконечно много решений - Если нижняя строчка \n" +
                "состоит только из нулей;\n2.Не иметь решений - Если все значения \n" +
                "нижней строчки, кроме последнего, равны нулю;\n3.Иметь единственное решение - \n" +
                "В ином случае. \n"+
                "Если решение есть, то корни находятся от последнего к первому путем подстановки";
        }
    }
}
