using System;

namespace LandScape
{
    class LandScapeObject
    {
        public int x, y;
        public int ImgNum;
        public bool IsPas;

        public LandScapeObject(int w, int z, int Img, bool flag)
        {
            x = w;
            y = z;
            ImgNum = Img;
            IsPas = flag;
        }
    }
    class Gates : LandScapeObject
    {
        public Gates(int w, int z, int Img, bool flag)
            : base(w, z, Img, flag)
        { }
    }
    class Lair : LandScapeObject
    {
        int Beast;
        public Lair(int w, int z, int Img, bool flag)
            : base(w, z, Img, flag)
        {
            Random rnd = new Random();
            Beast = rnd.Next(0, 5); 
        }
    }
    class Artefact : LandScapeObject
    {
        int Power;
        int Weight;
        public Artefact(int w, int z, int Img, bool flag)
            : base(w, z, Img, flag)
        {
            Random rnd = new Random();
            Power = rnd.Next(1, 10);
            Weight = 4 * Power;
        }
    }
}
