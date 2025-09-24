using System;
using System.IO; 
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            try
            {
                double weight = (double)numericWeight.Value;
                double height = (double)numericHeight.Value / 100.0; 

                if (height <= 0)
                {
                    MessageBox.Show("Рост должен быть больше нуля!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                double bmi = weight / (height * height);

                
                string category;
                if (bmi < 18.5) category = "Недостаточный вес";
                else if (bmi < 25) category = "Норма";
                else if (bmi < 30) category = "Избыточный вес";
                else category = "Ожирение";

                
                double minNormalWeight = 18.5 * height * height;
                double maxNormalWeight = 24.9 * height * height;
                string normalRange = $"Норма для вашего роста: {minNormalWeight:F1}–{maxNormalWeight:F1} кг";

                
                string message = $"Ваш BMI: {bmi:F2}\nКатегория: {category}\n{normalRange}";

                
                labelResult.Text = message;

                
                MessageBox.Show(message, "Результат BMI",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                string filePath = "bmi_results.txt";
                string saveLine = $"{DateTime.Now}: Вес={weight} кг, Рост={height * 100} см, BMI={bmi:F2}, Категория={category}";
                File.AppendAllText(filePath, saveLine + Environment.NewLine);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода данных!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}