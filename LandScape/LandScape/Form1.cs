using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace LandScape
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Всплывающее окно с подсказкой
        /// </summary>
        /// <param name="hint">Текст подсказки</param>
        private static void Oops(string hint)
        {
            //реакция на неадекватное поведение пользователя
            Notification alarm = new Notification();
            alarm.hint_label.Text = hint;
            alarm.Show();
        }

        /// <summary>
        /// Перечисление элементов карты через набор именованных констант
        /// </summary>
        public enum ListOfImg : int
        {
            Rock = 1, Grass = 2, Water = 3, Land = 4, Tree = 5, Gates = 6, Artefact = 7, Lair = 8
        }


        /// <summary>
        /// Массив, в котором хранятся пути к изображениям необходимым для отрисовки карты
        /// </summary>
        Image[] LoI = new Image[8]; 
        List<LandScapeObject> LandScape = new List<LandScapeObject>();

        /// <summary>
        /// Двумерный массив, по которому строится карта
        /// </summary>
        private static int[][] MapLsc;
        /// <summary>
        ///Вспомогательная переменная - размерность матрицы
        /// </summary>
        private static string[] FLine;

        /// <summary>
        /// Функция для очистки матрицы игровой карты
        /// </summary>
        /// <param name="Matrix">Матрица карты</param>
        private static void ResetMatrix(int[][] Matrix)
        {
            StreamReader SR = new StreamReader(Environment.CurrentDirectory + @"\maps\variable.txt");
            int n = int.Parse(SR.ReadLine());
            int m = int.Parse(SR.ReadLine());
            SR.Close();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matrix[i][j] = -1;
                }
            }
        }

        /// <summary>
        ///Функция для заполнения игровой матрицы кодами элементов ландшафта
        /// </summary>
        /// <param name="FileName">Путь к файлу, в котором хранится начальная матрица</param>
        private static void MapMatrix(string FileName)
        {
            FLine = System.IO.File.ReadAllLines(FileName);
            MapLsc = new int[FLine.Length][];
            for (int i = 0; i < FLine.Length; i++)
            {
                MapLsc[i] = new int[FLine[0].Length];
                for (int j = 0; j < FLine[0].Length; j++)
                {
                    MapLsc[i][j] = (int)char.GetNumericValue(FLine[i][j]);
                    if ((MapLsc[i][j] > 9) || (MapLsc[i][j] < 0))
                    {
                        Oops("Игровая матрица \n содержит \n недопустимые элементы.");
                        break;
                    }
                }
            }
            int Rcnt = 0;
            int ArtCnt = 0;
            Random rnd = new Random();
            while (Rcnt < 15) 
            {
                for (int i = 0; i < FLine.Length; i++)
                {
                    for (int j = 0; j < FLine[0].Length; j++)
                    {
                        int a = rnd.Next(0, FLine.Length);
                        int b = rnd.Next(0, FLine[0].Length);
                        if ((MapLsc[a][b] != 2) && (MapLsc[a][b] != 3) && (MapLsc[a][b] != 7) && (MapLsc[a][b] != 4) && (MapLsc[a][b] != 0))
                        {
                            MapLsc[a][b] = 8; //"код" дерева 
                            Rcnt++;
                            break;
                        }
                        a = rnd.Next(0, FLine.Length);
                        b = rnd.Next(0, FLine[0].Length);
                        if ((MapLsc[a][b] != 2) && (MapLsc[a][b] != 3) && (MapLsc[a][b] != 8) && (MapLsc[a][b] != 0) && (MapLsc[a][b] != 4))
                        {
                            MapLsc[a][b] = 7; //"код" камня
                            Rcnt++;
                            break;
                        }
                        a = rnd.Next(1, FLine.Length - 1);
                        b = rnd.Next(1, FLine[0].Length - 1);
                        if ((ArtCnt < 4) && (MapLsc[a][b] != 2) && (MapLsc[a][b] != 3) && (MapLsc[a][b] != 0) && (MapLsc[a][b] != 4))
                        {
                            MapLsc[a][b] = 9; // код артефакта
                            ArtCnt++;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Функция для создания конкретных объектов на игровой карте
        /// </summary>
        /// <param name="Matrix">Матрица игровой карты</param>
        private void FillMap(int[][] Matrix)
        {
            int w = 0;
            int z = 0;
            for (int i = 0; i < FLine.Length; i++)
            {
                w = 0;
                for (int j = 0; j < FLine[0].Length; j++)
                {
                    if (Matrix[i][j] == 1)
                    {
                        LandScape.Add(new LandScapeObject(w, z, (int)ListOfImg.Grass, true));
                    }
                    if (Matrix[i][j] == 2)
                    {
                        LandScape.Add(new LandScapeObject(w, z, (int)ListOfImg.Water, false));
                    }
                    if (Matrix[i][j] == 3)
                    {
                        LandScape.Add(new LandScapeObject(w, z, (int)ListOfImg.Land, true));
                    }
                    if (Matrix[i][j] == 7)
                    {
                        LandScape.Add(new LandScapeObject(w, z, (int)ListOfImg.Rock, false));
                    }
                    if (Matrix[i][j] == 8)
                    {
                        LandScape.Add(new LandScapeObject(w, z, (int)ListOfImg.Tree, false));
                    }
                    if (Matrix[i][j] == 4)
                    {
                        LandScape.Add(new LandScapeObject(w, z, (int)ListOfImg.Land, true));
                        LandScape.Add(new LandScapeObject(w, z, (int)ListOfImg.Gates, true));
                    }
                    if (Matrix[i][j] == 9)
                    {
                        LandScape.Add(new LandScapeObject(w, z, (int)ListOfImg.Grass, true));
                        LandScape.Add(new LandScapeObject(w, z, (int)ListOfImg.Artefact, true));
                    }
                    if (Matrix[i][j] == 0)
                    {
                        LandScape.Add(new LandScapeObject(w, z, (int)ListOfImg.Grass, true));
                        LandScape.Add(new LandScapeObject(w, z, (int)ListOfImg.Lair, false));
                    }
                    w += 40;
                }
                if (w == 640)
                    z += 40;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Флаг, устанавливающий факт генерации карты
        /// </summary>
        bool Used = false;
        private void Level_1_button_Click(object sender, EventArgs e)
        {
            Map_pictureBox.Image = null;
            this.Refresh();
            label1.Text = "You've chosen Rise. \n Chapter 1 \n It's gonna be easy.";
            if (Used)
                ResetMatrix(MapLsc);
            if (!File.Exists(Environment.CurrentDirectory + @"\maps\map1.txt"))
                Oops("Файл 'map1.txt' не найден. \n Обратитесь к поставщику.");
            else
            {
                MapMatrix(Environment.CurrentDirectory + @"\maps\map1.txt");
                FillMap(MapLsc);
                Used = true;
            }
                this.Refresh();
        }
        private void Level_2_button_Click(object sender, EventArgs e)
        {
            Map_pictureBox.Image = null;
            this.Refresh();
            label1.Text = "You've chosen Earth. \n Chapter 2 \n It's medium.";
            if (Used)
                ResetMatrix(MapLsc);
            if (!File.Exists(Environment.CurrentDirectory + @"\maps\map2.txt"))
                Oops("Файл 'map2.txt' не найден. \n Обратитесь к поставщику.");
            else
            {
                MapMatrix(Environment.CurrentDirectory + @"\maps\map2.txt");
                FillMap(MapLsc);
                Used = true;
            }
            this.Refresh();
        }
        private void Level_3_button_Click(object sender, EventArgs e)
        {
            Map_pictureBox.Image = null;
            this.Refresh();
            label1.Text = "You've chosen Down. \n Chapter 3 \n It's hard.";
            if (Used)
                ResetMatrix(MapLsc);
            if (!File.Exists(Environment.CurrentDirectory + @"\maps\map3.txt"))
                Oops("Файл 'map3.txt' не найден. \n Обратитесь к поставщику.");
            else
            {
                MapMatrix(Environment.CurrentDirectory + @"\maps\map3.txt");
                FillMap(MapLsc);
                Used = true;
            }
            this.Refresh();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                LoI[0] = Image.FromFile(Environment.CurrentDirectory + @"\img\Rock.bmp");
                LoI[1] = Image.FromFile(Environment.CurrentDirectory + @"\img\Grass.bmp");
                LoI[2] = Image.FromFile(Environment.CurrentDirectory + @"\img\Water.bmp");
                LoI[3] = Image.FromFile(Environment.CurrentDirectory + @"\img\Land.bmp");
                LoI[4] = Image.FromFile(Environment.CurrentDirectory + @"\img\Tree.bmp");
                LoI[5] = Image.FromFile(Environment.CurrentDirectory + @"\img\Gates.png");
                LoI[6] = Image.FromFile(Environment.CurrentDirectory + @"\img\Artefact.png");
                LoI[7] = Image.FromFile(Environment.CurrentDirectory + @"\img\Lair.png");
            }
            catch (FileNotFoundException)
            {
                Oops("Изображения, необходимые \n для построения карты \n отсутствуют.");
            }
            Bitmap startImg = new Bitmap(Environment.CurrentDirectory + @"\img\Start.bmp");
            Map_pictureBox.Image = startImg;
        }
        private void Map_pictureBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < LandScape.Count; i++)
            {
                if (i == 5)
                { continue; }
                e.Graphics.DrawImage(LoI[LandScape[i].ImgNum - 1], LandScape[i].x, LandScape[i].y);
            }

            for (int i = 0; i < LandScape.Count; i++)
            {
                if (i != 5)
                { continue; }
                e.Graphics.DrawImage(LoI[LandScape[i].ImgNum - 1], LandScape[i].x, LandScape[i].y);
            }
        }
    }
}
