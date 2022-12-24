using Casino.MainCode;
using System;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Xml.Linq;

namespace Casino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string money = Player.Money.ToString();
            label8.Text = money;
        }

        private void CheckName(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            string nameButton = name.Trim('N', 'u', 'm', 'B', 't', 'n');
            int nameButtonInt = int.Parse(nameButton);
            ActiveRate.Rate = nameButtonInt;
            label6.Text = nameButton;
        }

        private void StartRandom_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var randomNumber = random.Next(1, 36);
            string randomGlek = randomNumber.ToString();
            RandomNumber.NumberRandom = random.Next(1, 36);
            int palyerNumInt = ActiveRate.Rate; // Активная ставка в инт
            int playerNumInt = ActiveRate.Rate; // Активная ставка
            int textBoxInt = int.Parse(textBox1.Text); // Деньги которые ввёл игрок
            int playerMoneyInt = Player.Money; // Деньги игрока


            if (textBoxInt <= playerMoneyInt && playerNumInt != 0)
            {
                label3.Text = randomGlek;
                RandomNumber.NumberRandom = randomNumber;

                if (playerNumInt > 36)
                {
                    MessageBox.Show("Вы вели число более 36");
                }
                else
                {
                    if (palyerNumInt == randomNumber)
                    {
                        textBoxInt *= 36;
                        Player.Money += textBoxInt;
                        string money = Player.Money.ToString();
                        label8.Text = money;
                        label4.Text = "Вы победили!";
                        label4.BackColor = Color.Green;
                        label6.Text = " ";

                    }
                    else
                    {
                        Player.Money -= textBoxInt;
                        string money = Player.Money.ToString();
                        int moneyInt = Player.Money;
                        label8.Text = money;
                        label4.Text = "Вы проебали!";
                        label4.BackColor = Color.Red;
                        label6.Text = " ";
                        if (moneyInt == 0)
                        {
                            MessageBox.Show("Вы проебали все деньги в казино");
                            Process.Start(new ProcessStartInfo("https://www.youtube.com/watch?v=mqsMVBrsPG0") { UseShellExecute = true });
                        }
                    }
                }
                textBox1.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("У вас недостаточно денег или вы не поставили ставку.");
            }
        }
    }
}