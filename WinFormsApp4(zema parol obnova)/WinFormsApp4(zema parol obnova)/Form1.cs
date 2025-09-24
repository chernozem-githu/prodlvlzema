
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp4_zema_parol_obnova_
{
    public class Form1 : Form
    {
        private TextBox poleParolya;      
        private Button knopkaPokazat;     
        private Label nadpisDlina;        
        private Label nadpisSlozhnost;    

        public Form1()
        {
            SozdatFormu();
        }

        private void SozdatFormu()
        {
            
            poleParolya = new TextBox();
            poleParolya.Location = new Point(30, 30);
            poleParolya.Size = new Size(200, 23);
            poleParolya.PasswordChar = '*'; 
            poleParolya.TextChanged += ProverkaParolya; 

           
            knopkaPokazat = new Button();
            knopkaPokazat.Location = new Point(30, 70);
            knopkaPokazat.Size = new Size(200, 30);
            knopkaPokazat.Text = "Показать пароль";
            knopkaPokazat.Click += SmenitVid;

            
            nadpisDlina = new Label();
            nadpisDlina.Location = new Point(30, 110);
            nadpisDlina.Size = new Size(250, 23);
            nadpisDlina.Text = "Длина: 0";

            
            nadpisSlozhnost = new Label();
            nadpisSlozhnost.Location = new Point(30, 140);
            nadpisSlozhnost.Size = new Size(250, 23);
            nadpisSlozhnost.Text = "Сложность: -";

            
            this.ClientSize = new Size(320, 200);
            this.Controls.Add(poleParolya);
            this.Controls.Add(knopkaPokazat);
            this.Controls.Add(nadpisDlina);
            this.Controls.Add(nadpisSlozhnost);
            this.Text = "Пароль";
        }

        
        private void SmenitVid(object sender, EventArgs e)
        {
            if (poleParolya.PasswordChar == '*')
            {
                poleParolya.PasswordChar = '\0';
                knopkaPokazat.Text = "Скрыть пароль";
            }
            else
            {
                poleParolya.PasswordChar = '*'; 
                knopkaPokazat.Text = "Показать пароль";
            }
        }

        
        private void ProverkaParolya(object sender, EventArgs e)
        {
            string text = poleParolya.Text;

            
            nadpisDlina.Text = $"Длина: {text.Length}";

            
            string slozhnost;
            if (text.Length < 4)
            {
                slozhnost = "Слабый";
                nadpisSlozhnost.ForeColor = Color.Red;
            }
            else if (text.Length < 8)
            {
                slozhnost = "Средний";
                nadpisSlozhnost.ForeColor = Color.Orange;
            }
            else
            {
                slozhnost = "Сильный";
                nadpisSlozhnost.ForeColor = Color.Green;
            }

            nadpisSlozhnost.Text = $"Сложность: {slozhnost}";
        }

    }
}
