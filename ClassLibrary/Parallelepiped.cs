using System;

namespace ClassLibrary
{
    [Serializable]
    // Класс для реализации фигуры "параллелепипед"
    public class Parallelepiped : IShape
    {
        // Свойства класса - стороны
        private float Side1, Side2, Side3;

        // Метод для проверки свойств класса
        private void Check()
        {
            if (Side1 < 0 || Side2 < 0 || Side3 < 0)
                throw new ArgumentOutOfRangeException("Стороны не корректны");
        }

        // Конструкторы класса
        public Parallelepiped() { Side1 = 0; Side2 = 0; Side3 = 0; }
        public Parallelepiped(float s1, float s2, float s3)
        {
            if (s1 < 10000 && s2 < 10000 && s3 < 10000)
            {
                Side1 = s1;
                Side2 = s2;
                Side3 = s3;
                Check();
            }
            else throw new ArgumentException("Передано значние ширины или высоты, превышающее допустимое");
        }

        // Метод для подсчета
        public float Volume()
        {
            return Side1 * Side2 * Side3;
        }

        // Метод для преобразования данных в строку
        public string Show()
        {
            return ($"Параллелепипед со сторонами {Side1}, {Side2} и {Side3}. Объем: {Volume()}");
        }

        // Имя фигуры
        public string Name() { return "Параллелепипед"; }
    }
}
