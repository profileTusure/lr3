using System;

namespace ClassLibrary
{
    [Serializable]
    // Класс для реализации фигуры "шар"
    public class Ball : IShape
    {
        // Свойство класса - радиус
        private float rad;

        // Метод для инициализации свойства класса
        public float Radius
        {
            get { return rad; }
            set
            {
                if (value > 0)
                    rad = value;
                else throw new ArgumentOutOfRangeException("Радиус меньше нуля");
            }
        }

        // Конструкторы класса
        public Ball() { rad = 0; }
        public Ball(float r)
        {
            if (r < 10000)
                Radius = r;
            else throw new ArgumentException("Передано значние радиуса, превышающее допустимое");
        }

        // Метод для подсчета 
        public float Volume() { return (float)(1.0 / 3.0 * Math.PI * Radius * Radius * Radius); }

        // Метод для преобразования данных в строку
        public string Show()
        {
            return ($"Шар с радиусом {Radius}. Объем: {Volume()}");
        }

        public string Name() { return "Шар"; }
    }
}
