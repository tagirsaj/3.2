using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_lab3._2
{
    public class Model
    {
        private int a, b, c;
        public event EventHandler ModelChanged;

        public int A => a;
        public int B => b;
        public int C => c;

        public Model()
        {
            a = 0; b = 50; c = 100;
        }

        public void SetA(int value)
        {
            int newA = Clamp(value, 0, 100);
            if (newA == a) return;

            a = newA;
            // Разрешающее поведение: подтягиваем C и B, если A стало больше них
            if (a > c) c = a;
            if (a > b) b = a;

            NotifyObservers(); // Одно уведомление на все изменения
        }

        public void SetB(int value)
        {
            // Ограничивающее поведение: B не может выйти за пределы A и C
            int newB = Clamp(value, a, c);
            if (newB == b) return;

            b = newB;
            NotifyObservers();
        }

        public void SetC(int value)
        {
            int newC = Clamp(value, 0, 100);
            if (newC == c) return;

            c = newC;
            // Разрешающее поведение: опускаем A и B, если C стало меньше них
            if (c < a) a = c;
            if (c < b) b = c;

            NotifyObservers();
        }

        protected int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        protected void NotifyObservers()
        {
            ModelChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public partial class Form1 : Form
    {
        private Model model;
        private bool isUpdating = false;

        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.ModelChanged += Model_ModelChanged;

            this.Load += (s, e) => Model_ModelChanged(this, EventArgs.Empty);

            numA.ValueChanged += (s, e) => { if (!isUpdating) model.SetA((int)numA.Value); };
            numB.ValueChanged += (s, e) => { if (!isUpdating) model.SetB((int)numB.Value); };
            numC.ValueChanged += (s, e) => { if (!isUpdating) model.SetC((int)numC.Value); };

            trackBar1.ValueChanged += (s, e) => { if (!isUpdating) model.SetA(trackBar1.Value); };
            trackBar2.ValueChanged += (s, e) => { if (!isUpdating) model.SetB(trackBar2.Value); };
            trackBar3.ValueChanged += (s, e) => { if (!isUpdating) model.SetC(trackBar3.Value); };
        }

        private void Model_ModelChanged(object sender, EventArgs e)
        {
            isUpdating = true;

            textBoxA.Text = model.A.ToString();
            numA.Value = model.A;
            trackBar1.Value = model.A;

            textBoxB.Text = model.B.ToString();
            numB.Value = model.B;
            trackBar2.Value = model.B;

            textBoxC.Text = model.C.ToString();
            numC.Value = model.C;
            trackBar3.Value = model.C;

            isUpdating = false;
        }
    }
}