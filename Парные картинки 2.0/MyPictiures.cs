//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Парные_картинки_2._0
//{
//    class MyPictiures
//    {
//        PictureBox[,] P;
//        ImageList I = new ImageList();
//        int n;

//        //Количество пар картинок
//        int[] pairs;

//       // Количество картинок на игровом поле
//        int[] pictures;

//        public MyPictiures(int complexity, Panel panel, ImageList L)
//        {

//            if (complexity == 1) //легко
//            {
//                n = 4;
//                pairs = new int[8];
//                pictures = new int[16];
//            }
//            if (complexity == 2) //нормально
//            {
//                n = 5;
//                pairs = new int[10];
//                pictures = new int[20];
//            }
//            if (complexity == 3) //сложно
//            {
//                n = 6;
//                pairs = new int[12];
//                pictures = new int[24];
//            }

//            P = new PictureBox[4, n];
//            for (int i = 0; i < 4; i++)
//            {
//                for (int j = 0; j <n; j++)
//                {
//                    P[i, j].Parent = panel;

//                    P[i, j].Top = i; //отступ сверху i
//P[i, j].Left = i / n; //отступ слева in
//                    P[i, j].Width = panel.Width/  n; //ширина = 1n ширины формы
//              P[i, j].Height = panel.Height / 4;// высота = 14 высоты формы
//                    I = L;

//                }
//            }
//        }
//        public void HidePictures()
//        {
//            for (int i = 0; i  4; i++)
//            {
//                for (int j = 0; j  n; j++)
//                {
//                    P[i, j].BackgroundImage = I.Images[14];
//                }
//            }
//        }

//    }
//}
