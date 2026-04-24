using System;
using System.Windows.Forms;

namespace OOP_lab3._2
{
    // ... (Класс Model полностью идентичен коду из Этапа 2) ...
    public class Model
    {
        private int a, b, c;
        public event EventHandler ModelChanged;
        public int A => a; public int B => b; public int C => c;
        public Model() { a = 0; b = 50; c = 100; }
        public void SetA(int value) { int newA = Clamp(value, 0, 100); if (newA == a) return; a = newA; if (a > c) c = a; if (a > b) b = a; NotifyObservers(); }
        public void SetB(int value) { int newB = Clamp(value, a, c); if (newB == b) return; b = newB; NotifyObservers(); }
        public void SetC(int value) { int newC = Clamp(value, 0, 100); if (newC == c) return; c = newC; if (c < a) a = c; if (c < b) b = c; NotifyObservers(); }
        protected int Clamp(int value, int min, int max) { if (value < min) return min; if (value > max) return max; return value; }
        protected void NotifyObservers() { ModelChanged?.Invoke(this, EventArgs.Empty); }
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

            // Обработка текстовых полей (потеря фокуса и нажатие Enter)
            textBoxA.Leave += (s, e) => UpdateModelFromTextBoxA();
            textBoxA.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) UpdateModelFromTextBoxA(); };

            textBoxB.Leave += (s, e) => UpdateModelFromTextBoxB();
            textBoxB.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) UpdateModelFromTextBoxB(); };

            textBoxC.Leave += (s, e) => UpdateModelFromTextBoxC();
            textBoxC.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) UpdateModelFromTextBoxC(); };

            numA.ValueChanged += (s, e) => { if (!isUpdating) model.SetA((int)numA.Value); };
            numB.ValueChanged += (s, e) => { if (!isUpdating) model.SetB((int)numB.Value); };
            numC.ValueChanged += (s, e) => { if (!isUpdating) model.SetC((int)numC.Value); };

            trackBar1.ValueChanged += (s, e) => { if (!isUpdating) model.SetA(trackBar1.Value); };
            trackBar2.ValueChanged += (s, e) => { if (!isUpdating) model.SetB(trackBar2.Value); };
            trackBar3.ValueChanged += (s, e) => { if (!isUpdating) model.SetC(trackBar3.Value); };
        }

        private void UpdateModelFromTextBoxA()
        {
            if (isUpdating) return;
            if (int.TryParse(textBoxA.Text, out int result)) model.SetA(result);
            else textBoxA.Text = model.A.ToString(); // Откат при неверном вводе
        }

        private void UpdateModelFromTextBoxB()
        {
            if (isUpdating) return;
            if (int.TryParse(textBoxB.Text, out int result)) model.SetB(result);
            else textBoxB.Text = model.B.ToString();
        }

        private void UpdateModelFromTextBoxC()
        {
            if (isUpdating) return;
            if (int.TryParse(textBoxC.Text, out int result)) model.SetC(result);
            else textBoxC.Text = model.C.ToString();
        }

        private void Model_ModelChanged(object sender, EventArgs e)
        {
            isUpdating = true;
            textBoxA.Text = model.A.ToString(); numA.Value = model.A; trackBar1.Value = model.A;
            textBoxB.Text = model.B.ToString(); numB.Value = model.B; trackBar2.Value = model.B;
            textBoxC.Text = model.C.ToString(); numC.Value = model.C; trackBar3.Value = model.C;
            isUpdating = false;
        }
    }
}