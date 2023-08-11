using System;
using System.Windows.Forms;

namespace Парные_картинки_2._0
{
    public partial class Form2 : Form
    {
        //Сложность игры
        string complexity = "";

        //Тема картинок
        string tema = "";

        //Количество картинок в строке
        int width;

        //Количество пар картинок
        int[] pairs;        

        //Количество картинок на игровом поле
        int[] pictures;
        
        //Пара открытых картинок в данный момент
        int[] opened;

        //Количество открытых картинок в данный момент
        int opened_counter;

        //Количество ходов. Две одновременно открытые карточки = один ход.
        int moves;

        //Количество открытых пар
        int count;

        //Размер массива PictureBox
        int picturebox_size;

        PictureBox[] P;


        public Form2(string Complexity, string Tema)
        {
            //Задаём начальное расположение формы по центру
            this.StartPosition = FormStartPosition.CenterScreen;
            //Задаём отступ сверху 0
            this.Top = 0;

            InitializeComponent();

            complexity = Complexity;
            tema = Tema;

            if (complexity == "Легко")
            {
                picturebox_size = 16;
                pairs = new int[8];
                pictures = new int[16];
                width = 4;
                this.Width = 750;
                this.Height = 1000;
            }
            if (complexity == "Нормально")
            {
                picturebox_size = 20;
                pairs = new int[10];
                pictures = new int[20];
                width = 5;
                this.Width = 950;
                this.Height = 1050;
            }
            if (complexity == "Сложно")
            {
                picturebox_size = 24;
                pairs = new int[12];
                pictures = new int[24];
                width = 6;
                this.Width = 1100;
                this.Height = 1050;
            }


            moves = 0;
            count = 0;
            opened = new int[2];
            opened_counter = 0;
            P = new PictureBox[picturebox_size];
            int j = 0;  //Переменная для подсчёта количества кортинок в столбце
            int s = 0;  //Переменная для подсчёта количества картинок в строке

            for (int i = 0; i < picturebox_size; i++)
            {
                if (s == width)
                {
                    s = 0;
                    j++;
                } 

                P[i] = new PictureBox();
                P[i].Tag = i;
                P[i].Parent = panel1;
                P[i].BackgroundImageLayout = ImageLayout.Stretch;
                P[i].Top = panel1.Height * j / 4;
                P[i].Left = panel1.Width * s / width;
                P[i].Width = panel1.Width / width;
                P[i].Height = panel1.Height / 4;
                    
                s++;

                P[i].Click += new System.EventHandler(this.pictureBox1_Click);   
            }           
        }

        //Метод отображения Рубашки на картинках
        public void HidePictures()
        {
            for (int i = 0; i < picturebox_size; i++)
            {
                P[i].BackgroundImage = imageList1.Images[14];
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
                новаяИграToolStripMenuItem_Click(null, null);       //При загрузке формы начинается новая игра
                HidePictures();                                     //При загрузке формы Карточки поернуты рубашкой
        }

        //Метод перемешивания картинок и создания пар
        public void MIX()
        {         
            Random R;
            R = new Random();

            //Колличество открытых пар
            int used = 0;

            //Цикл создания пар
            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = i;   //Таким образом кажая пара будет уникальна в данной игровой сессии
            }
            for (int i = 0; i < picturebox_size; i++)
            {
                P[i].Visible = true;
            }

            for (int i = 0; i < pictures.Length; i++)
            {
                //Означает что ячейка не занята
                pictures[i] = -1;
            }

            while (used != pairs.Length)
            {
                int n1 = R.Next(pictures.Length);            //Генерируем номер первого pictureBox
                int n2 = R.Next(pictures.Length);            //Генерируем номер второго pictureBox

                if (n1 == n2) continue;

                //Проверяем, свободны ли две ячейки, чтоы образовать пару
                if (pictures[n1] == -1 && pictures[n2] == -1)
                {
                    //Создаём пару
                    pictures[n1] = pictures[n2] = pairs[used];
                    used++;
                }
            }
            HidePictures();
        }

        //Метод начала новой игры
        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moves = 0;
            opened_counter = 0;
            MIX();
        }

        //Метод открытия картинок
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Вводим переменную типа picturebox
            PictureBox p = (PictureBox)sender;

            //Вводим переменную для Идентификации picturebox
            int index = Convert.ToInt32(p.Tag);

            //Если в данный момент открыта одна картинка
            if (opened_counter == 1)
            {
                if (opened[0] == index) return;     //Присваеваем первой открытой картинке index открытого pictгrebox
            }

            //Если открыты две картинки(не важно, одинаковые или нет)
            if (opened_counter == 2)
            {
                HidePictures();         //Все картинки поворачиваем рубашкой
                opened_counter = 0;     //Обнуляем количество открытых в данный момент картинок
            }

            opened[opened_counter] = index;
            opened_counter++;

            //Так же, при двух открытых картинках
            if (opened_counter == 2)
            {
                moves++;                                                //Увеличиваем количество ходов             
                if(pictures[opened[0]] == pictures[opened[1]])          //Проверяем на схожеть
                {
                    P[opened[0]].Visible = false;
                    P[opened[1]].Visible = false;
                    opened_counter = 0;
                    count++;
                    HidePictures();
                }
                        
                           
            }
            if (tema == "Фрукты")
            {
                p.BackgroundImage = imageList1.Images[pictures[index]];
            }
            if (tema == "Звери")
            {
                p.BackgroundImage = imageList2.Images[pictures[index]];
            }
            if (tema == "Машины")
            {
                p.BackgroundImage = imageList3.Images[pictures[index]];
            }

            //Метод вывода текущего количества ходов и Рекорда
            if (count == pairs.Length)
            {
                Record record = new Record(moves, complexity);

                int max = Record.record_max();
                int min = Record.record_min();

                if (MessageBox.Show("Вы сделали ходов: " + moves + '\n' + "Максимальное количество ходов: " + max.ToString() + '\n' + "Рекордное количество ходов: " + min.ToString()) == DialogResult.OK)
                {
                    новаяИграToolStripMenuItem_Click(null, null);
                    HidePictures();
                }
                count = 0;
            }
        }

        //Метод выхода в меню настроек
        private void менюToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About form3 = new About();
            form3.ShowDialog();
        }
    }
}
