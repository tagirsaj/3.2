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
            if (a == value) return;
            a = Clamp(value, 0, 100);
            NotifyObservers();
        }

        public void SetB(int value)
        {
            if (b == value) return;
            b = Clamp(value, 0, 100);
            NotifyObservers();
        }

        public void SetC(int value)
        {
            if (c == value) return;
            c = Clamp(value, 0, 100);
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