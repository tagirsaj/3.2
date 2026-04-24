using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_lab3._2
{
    public partial class Form1 : Form
    {
        private Model model;
        private bool isUpdating = false;

        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.ModelChanged += Model_ModelChanged;

            this.Load += (s, e) => model.Load();
            this.FormClosing += (s, e) => model.Save();

            // Привязка событий NumericUpDown
            numA.ValueChanged += (s, e) => { if (!isUpdating) model.SetA((int)numA.Value); };
            numB.ValueChanged += (s, e) => { if (!isUpdating) model.SetB((int)numB.Value); };
            numC.ValueChanged += (s, e) => { if (!isUpdating) model.SetC((int)numC.Value); };

            // Привязка событий TrackBar
            trackBar1.ValueChanged += (s, e) => { if (!isUpdating) model.SetA(trackBar1.Value); };
            trackBar2.ValueChanged += (s, e) => { if (!isUpdating) model.SetB(trackBar2.Value); };
            trackBar3.ValueChanged += (s, e) => { if (!isUpdating) model.SetC(trackBar3.Value); };

            // Привязка событий TextBox (потеря фокуса или Enter)
            textBoxA.Leave += (s, e) => UpdateA();
            textBoxA.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) UpdateA(); };
            textBoxB.Leave += (s, e) => UpdateB();
            textBoxB.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) UpdateB(); };
            textBoxC.Leave += (s, e) => UpdateC();
            textBoxC.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) UpdateC(); };
        }
        // МОДЕЛЬ: Хранит данные, логику и счётчик
        public class Model
        {
            private int a, b, c;
            private int changeCount = 0; // Переменная счётчика
            private readonly string saveFile = "model_data.txt";

            public event EventHandler ModelChanged;

            public int A => a;
            public int B => b;
            public int C => c;
            public int ChangeCount => changeCount; // Свойство для получения значения счётчика

            public Model()
            {
                a = 0; b = 50; c = 100;
            }

            public void Load()
            {
                if (File.Exists(saveFile))
                {
                    try
                    {
                        string[] parts = File.ReadAllText(saveFile).Split(',');
                        if (parts.Length == 3 &&
                            int.TryParse(parts[0], out int loadedA) &&
                            int.TryParse(parts[1], out int loadedB) &&
                            int.TryParse(parts[2], out int loadedC))
                        {
                            a = Clamp(loadedA, 0, 100);
                            c = Clamp(loadedC, 0, 100);
                            b = Clamp(loadedB, a, c);
                        }
                    }
                    catch { }
                }
                NotifyObservers();
            }

            public void Save()
            {
                try { File.WriteAllText(saveFile, $"{a},{b},{c}"); } catch { }
            }

            public void SetA(int value)
            {
                int newA = Clamp(value, 0, 100);
                if (newA == a) return;
                a = newA;
                if (a > c) c = a;
                if (a > b) b = a;
                NotifyObservers();
            }

            public void SetB(int value)
            {
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
                if (c < a) a = c;
                if (c < b) b = c;
                NotifyObservers();
            }

            private int Clamp(int value, int min, int max)
            {
                if (value < min) return min;
                if (value > max) return max;
                return value;
            }

            private void NotifyObservers()
            {
                changeCount++; // Увеличиваем счётчик при каждом изменении
                ModelChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        // ВЬЮ (ФОРМА): Отображает данные и отправляет ввод в модель


        // Обновление всех элементов интерфейса при изменении модели
        private void Model_ModelChanged(object sender, EventArgs e)
        {
            isUpdating = true;

            // Обновляем значения
            textBoxA.Text = model.A.ToString();
            numA.Value = model.A;
            trackBar1.Value = model.A;

            textBoxB.Text = model.B.ToString();
            numB.Value = model.B;
            trackBar2.Value = model.B;

            textBoxC.Text = model.C.ToString();
            numC.Value = model.C;
            trackBar3.Value = model.C;

            // Обновляем надпись счётчика
            lblCounter.Text = $"Изменений: {model.ChangeCount}";

            isUpdating = false;
        }

        private void UpdateA() { if (int.TryParse(textBoxA.Text, out int r)) model.SetA(r); else textBoxA.Text = model.A.ToString(); }
        private void UpdateB() { if (int.TryParse(textBoxB.Text, out int r)) model.SetB(r); else textBoxB.Text = model.B.ToString(); }
        private void UpdateC() { if (int.TryParse(textBoxC.Text, out int r)) model.SetC(r); else textBoxC.Text = model.C.ToString(); }
    }
}