using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public class Form2 : Form
    {
        private TextBox textBoxC;
        private TextBox textBoxF;
        private TextBox textBoxK;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label labelArrow1;
        private Label labelArrow2;
        private Label labelArrow3;
        private Button button1;
        private Button button2;
        private Button button3;
        private ProgressBar tempBar; // шкала

        public Form2()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.textBoxC = new TextBox();
            this.textBoxF = new TextBox();
            this.textBoxK = new TextBox();

            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();

            this.labelArrow1 = new Label();
            this.labelArrow2 = new Label();
            this.labelArrow3 = new Label();

            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();

            this.tempBar = new ProgressBar();

            // --- поля ввода ---
            this.textBoxC.Location = new Point(120, 30);
            this.textBoxC.Size = new Size(100, 23);

            this.textBoxF.Location = new Point(120, 70);
            this.textBoxF.Size = new Size(100, 23);

            this.textBoxK.Location = new Point(120, 110);
            this.textBoxK.Size = new Size(100, 23);

            // --- подписи ---
            this.label1.AutoSize = true;
            this.label1.Location = new Point(30, 33);
            this.label1.Text = "Цельсий °C";

            this.label2.AutoSize = true;
            this.label2.Location = new Point(30, 73);
            this.label2.Text = "Фаренгейт °F";

            this.label3.AutoSize = true;
            this.label3.Location = new Point(30, 113);
            this.label3.Text = "Кельвин K";

            // --- надписи "перевод в" ---
            this.labelArrow1.AutoSize = true;
            this.labelArrow1.Location = new Point(230, 33);
            this.labelArrow1.Text = "перевод в";

            this.labelArrow2.AutoSize = true;
            this.labelArrow2.Location = new Point(230, 73);
            this.labelArrow2.Text = "перевод в";

            this.labelArrow3.AutoSize = true;
            this.labelArrow3.Location = new Point(230, 113);
            this.labelArrow3.Text = "перевод в";

            // --- кнопки ---
            this.button1.Location = new Point(320, 30);
            this.button1.Size = new Size(60, 23);
            this.button1.Text = "°F";
            this.button1.Click += this.button1_Click;

            this.button2.Location = new Point(320, 70);
            this.button2.Size = new Size(60, 23);
            this.button2.Text = "°C";
            this.button2.Click += this.button2_Click;

            this.button3.Location = new Point(320, 110);
            this.button3.Size = new Size(60, 23);
            this.button3.Text = "K";
            this.button3.Click += this.button3_Click;

            // --- шкала ---
            this.tempBar.Location = new Point(30, 150);
            this.tempBar.Size = new Size(350, 25);
            this.tempBar.Minimum = 0;
            this.tempBar.Maximum = 100; // шкала от 0 до 100°C
            this.tempBar.Value = 0;

            // --- форма ---
            this.ClientSize = new Size(420, 200);
            this.Controls.Add(this.tempBar);
            this.Controls.Add(this.labelArrow1);
            this.Controls.Add(this.labelArrow2);
            this.Controls.Add(this.labelArrow3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxK);
            this.Controls.Add(this.textBoxF);
            this.Controls.Add(this.textBoxC);
            this.Text = "Конвертер градусов";
        }

        // °C → °F и K
        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxC.Text, out double celsius))
            {
                double fahrenheit = (celsius * 9 / 5) + 32;
                double kelvin = celsius + 273.15;

                textBoxF.Text = fahrenheit.ToString("0.##");
                textBoxK.Text = kelvin.ToString("0.##");

                UpdateBar(celsius);
            }
            else
            {
                MessageBox.Show("Введите число в поле °C!");
            }
        }

        // °F → °C и K
        private void button2_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxF.Text, out double fahrenheit))
            {
                double celsius = (fahrenheit - 32) * 5 / 9;
                double kelvin = celsius + 273.15;

                textBoxC.Text = celsius.ToString("0.##");
                textBoxK.Text = kelvin.ToString("0.##");

                UpdateBar(celsius);
            }
            else
            {
                MessageBox.Show("Введите число в поле °F!");
            }
        }

        // K → °C и °F
        private void button3_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxK.Text, out double kelvin))
            {
                double celsius = kelvin - 273.15;
                double fahrenheit = (celsius * 9 / 5) + 32;

                textBoxC.Text = celsius.ToString("0.##");
                textBoxF.Text = fahrenheit.ToString("0.##");

                UpdateBar(celsius);
            }
            else
            {
                MessageBox.Show("Введите число в поле K!");
            }
        }

        // Обновляем шкалу (ProgressBar)
        private void UpdateBar(double celsius)
        {
            if (celsius < 0) tempBar.Value = 0;
            else if (celsius > 100) tempBar.Value = 100;
            else tempBar.Value = (int)celsius;
        }
    }
}

