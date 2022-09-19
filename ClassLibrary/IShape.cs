namespace ClassLibrary
{

    // Сущность-интерфейс для создания геометрических фигуры
    public interface IShape
    {
        // Метод для присвоения имени
        string Name();

        // Метод для подсчета
        float Volume();

        // Метод, преобразовывающий объект класса в строку с данными
        string Show();
    }
}
