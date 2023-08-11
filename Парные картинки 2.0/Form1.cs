using System;
using System.Drawing;
using System.Windows.Forms;

namespace Парные_картинки_2._0
{
    public partial class Form1 : Form
    {
        //Звук.
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        static bool fn_enable = true;
        string Complexity="";
        string Tema="";

        public Form1()
        {
            InitializeComponent();

            //Имя проигрываемого звукового файла.
            player.SoundLocation = "1.wav";   
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Скрываем панель настроек
            panel1.Visible = false;
            panel1.Enabled = false;

            //По умолчанию выбираем сложность и тему, для быстрого начала игры
            Complexity = check_Easy.Text;
            Tema = check_Fruit.Text;
        }

        //Игра
        private void button1_Click(object sender, EventArgs e)
        {         
                Form2 form2 = new Form2(Complexity,Tema);
                form2.Show();           
        }

        //Настройки
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.Enabled = true;
        }

        //Выход
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Функция включения/выключения звука
        private void button4_Click(object sender, EventArgs e)
        {
            if (fn_enable == true)
            {
                //выключаем функцию
                button4.Text = "Выключить звук";               
                player.PlayLooping();
                fn_enable = false;
                button4.BackColor =Color.OliveDrab;
            }
            else
            {
                //включаем функцию
                button4.Text = "Включить звук";
                player.Stop();
                button4.BackColor = Color.DarkRed;
                fn_enable = true;
            }
        }



        //PanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanelPanel

        //Назад
        private void button5_Click(object sender, EventArgs e)
        {
            //Проверка на то, чтобы Сложность и Тема были выбраны
            if (check_Easy.Checked == false && check_Normal.Checked == false && check_Hard.Checked == false || check_Fruit.Checked==false && check_Animal.Checked==false && check_Car.Checked==false)
            {
                MessageBox.Show("Выберите сложность и тему картинок!");
                return;
            }
            panel1.Visible = false;
            panel1.Enabled = false;
        }

        //Сложность - легко
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Easy.Checked == true)
            {
                Complexity = check_Easy.Text;
                check_Normal.Checked = false;
                check_Hard.Checked = false;
            }
        }

        //Сложность - нормально
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Normal.Checked == true)
            {
                Complexity = check_Normal.Text;
                check_Easy.Checked = false;
                check_Hard.Checked = false;
            }
        }

        //Сложность - сложно
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Hard.Checked == true)
            {
                Complexity = check_Hard.Text;
                check_Easy.Checked = false;
                check_Normal.Checked = false;
            }
        }

        //Тема - Фрукты
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Fruit.Checked == true)
            {
                Tema = check_Fruit.Text;
                check_Animal.Checked = false;
                check_Car.Checked = false;
            }
        }

        //Тема - Звери
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Animal.Checked == true)
            {
                Tema = check_Animal.Text;
                check_Fruit.Checked = false;
                check_Car.Checked = false;
            }
        }

        //Тема - Машины
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Car.Checked == true)
            {
                Tema = check_Car.Text;
                check_Animal.Checked = false;
                check_Fruit.Checked = false;
            }
        }
    }
}
