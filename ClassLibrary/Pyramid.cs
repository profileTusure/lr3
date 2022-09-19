using System;

namespace ClassLibrary
{
    [Serializable]
    // Класс для реализации фигуры "пирамида"
    public class Pyramid : IShape
    {
        // Свойства класса - стороны прямоугольника
        private float s, h;

        // Методы для инициализации свойств класса

        public float Squere
        {
            get => s;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Площадь меньше нуля");
                else s = value;
            }
        }

        public float Height
        {
            get => h;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Высота меньше нуля");
                else h = value;
            }
        }

        // Конструкторы класса
        public Pyramid() { Squere = 0; Height = 0; }
        public Pyramid(float w, float h)
        {
            if (w < 10000 && h < 10000)
            {
                Squere = w;
                Height = h;
            }
            else throw new ArgumentException("Передано значние ширины или площади, превышающее допустимое");
        }

        // Метод для подсчета площади прямоугольника
        public float Volume() { return (float)(1.0 / 3.0 * Squere * Height); }

        // Метод для преобразования данных в строку
        public string Show()
        {
            return ($"Пирамида с площадью основания {Squere} и высотой {Height}. Объем: {Volume()}");
        }

        public string Name() { return "Пирамида"; }
    }
}
