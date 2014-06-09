using System;

namespace LandScape
{
    /// <summary>
    /// Базовый класс, соответствующий природным объектам
    /// </summary>
    class LandScapeObject
    {
        /// <summary>
        /// Координата положения объекта на карте
        /// </summary>
        public int x, y;
        /// <summary>
        /// Код изображения, соответствующий конкретному объекту
        /// </summary>
        public int ImgNum;
        /// <summary>
        /// Флаг, отвечающий за проходимость объекта
        /// </summary>
        public bool IsPas;
        /// <summary>
        /// Природные объекты
        /// </summary>
        /// <param name="w">Координата по горизонтали</param>
        /// <param name="z">Координата по вертикали</param>
        /// <param name="Img">Код изображения</param>
        /// <param name="flag">Флаг проходимости</param>
        public LandScapeObject(int w, int z, int Img, bool flag)
        {
            x = w;
            y = z;
            ImgNum = Img;
            IsPas = flag;
        }
    }
    /// <summary>
    /// Класс, отвечающий за порталы
    /// </summary>
    class Gates : LandScapeObject
    {
        /// <summary>
        /// Порталы
        /// </summary>
        /// <param name="w">Координата по горизонтали</param>
        /// <param name="z">Координата по вертикали</param>
        /// <param name="Img">Код изображения</param>
        /// <param name="flag">Флаг проходимости</param>
        public Gates(int w, int z, int Img, bool flag)
            : base(w, z, Img, flag)
        { }
    }
    /// <summary>
    /// Класс, отвечающий за логова
    /// </summary>
    class Lair : LandScapeObject
    {
        /// <summary>
        /// Вид зверя
        /// </summary>
        int Beast;
        /// <summary>
        /// Логово зверя
        /// </summary>
        /// <param name="w">Координата по горизонтали</param>
        /// <param name="z">Координата по вертикали</param>
        /// <param name="Img">Код изображения</param>
        /// <param name="flag">Флаг проходимости</param>
        public Lair(int w, int z, int Img, bool flag)
            : base(w, z, Img, flag)
        {
            Random rnd = new Random();
            Beast = rnd.Next(0, 5); 
        }
    }
    /// <summary>
    /// Класс, отвечающий за артефакты
    /// </summary>
    class Artefact : LandScapeObject
    {
        /// <summary>
        /// Сила артефакта
        /// </summary>
        int Power;
        /// <summary>
        /// Вес артефакта
        /// </summary>
        int Weight;
        /// <summary>
        /// Артефакт
        /// </summary>
        /// <param name="w">Координата по горизонтали</param>
        /// <param name="z">Координата по вертикали</param>
        /// <param name="Img">Код изображения</param>
        /// <param name="flag">Флаг проходимости</param>
        public Artefact(int w, int z, int Img, bool flag)
            : base(w, z, Img, flag)
        {
            Random rnd = new Random();
            Power = rnd.Next(1, 10);
            Weight = 4 * Power;
        }
    }
}
