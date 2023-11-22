using static System.Console;

namespace Music.Catalog;
/// <summary>
/// Класс представляет собой взаимеодействие с пользователем по работе с музыкальным каталогом
/// через консоль
/// </summary>
public class MusicCatalogCommander
{
    /// <summary>
    /// Метод запускает работу
    /// </summary>
    public static void Run()
    {
        WriteLine("""
            Программа Музыкальный каталог. 
            Для работы с программой используйте следующие команды: 
                Add - добавляет композицию в каталог;
                List - выводит в консоль все композиции из каталога; 
                Search - выводит в консоль композиции, удовлетворяющие критерию поиска; 
                Remove - удаляет из каталога композиции, удовлетворяющие критерию поиска; 
                Quit - завершает работу с каталогом. 
            Все команды не чувствительны к регистру.
            """);

        var musicCatalog = new MusicCatalogCommander();

        while(!musicCatalog.IsReadyToExit)
        {
            WriteLine("\nВведите команду: ");

            if (musicCatalog.Commands.TryGetValue(
                (ReadLine() ?? "").ToUpper(),
                out Action? action))
            {
                action();
            }
            else
            {
                WriteLine("Введена неверная команда. Попробуйте снова.");
            }
        }
    }

    /// <summary>
    /// Экземпляр музыкального каталога
    /// </summary>
    private readonly MusicCatalog catalog = new MusicCatalog();
    /// <summary>
    /// Сопоставление команд пользователя методам класса
    /// </summary>
    private Dictionary<string, Action> Commands;
    /// <summary>
    /// Конструктор по умолчанию. Заполняет сопоставление команд методам класса
    /// </summary>
    public MusicCatalogCommander()
    {
        Commands = new Dictionary<string, Action>();
        Commands.Add("ADD", Add);
        Commands.Add("LIST", List);
        Commands.Add("REMOVE", Remove);
        Commands.Add("SEARCH", Search);
        Commands.Add("QUIT", Quit);
    }
    /// <summary>
    /// Выполнение команды пользователя по занесени композиции в каталог
    /// </summary>
    public void Add()
    {
        catalog.AddComposition(
            new Composition
            {
                Author = ReadString("Имя автора:"),
                SongName = ReadString("Название композиции:"),
            });
    }
    /// <summary>
    /// Ввозвращает запрашиваемую строку у пользователя
    /// </summary>
    /// <param name="question">Текст того, что пользователь должен ввести</param>
    /// <returns>Введенная пользователем строка</returns>
    private static string ReadString(string question)
    {
        string line;
        do
        {
            WriteLine(question);
        }
        while (string.IsNullOrEmpty(line = ReadLine()!));
        return line;

    }
    /// <summary>
    /// Выполняет команду вывода полного содержимого каталога
    /// </summary>
    public void List()
    {
        PrintSongs("\nСписок всех песен:", catalog.EnumerateAllCompositions());
    }
    /// <summary>
    /// Метод выводит на консоль перечнь композиций
    /// </summary>
    /// <param name="header">Заголовок перечня композиций</param>
    /// <param name="songs">Enumerator для перебора композиций</param>
    private static void PrintSongs(string header,IEnumerable<Composition> songs)
    {
        WriteLine(header);
        foreach (var comp in songs)
        {
            WriteLine($"{comp.Author} - {comp.SongName}");
        }
    }
    /// <summary>
    /// Выполняет команду пользователя на удаление композиций из каталога, удовлетворяющих
    /// заданному критерию поиска
    /// </summary>
    public void Remove()
    {
        WriteLine($"Удалено {catalog.Remove(ReadString("Что удаляем?:"))} песен.");
    }
    /// <summary>
    ///  Выполняет команду пользователя на вывод на консоль перечня комспозиций, удовлетворяющих
    ///  заданному критерию поиска
    /// </summary>
    public void Search()
    {
        PrintSongs("\nРезультат поиска:", catalog.Search(ReadString("Что ищем ?:")));
    }
    /// <summary>
    /// Выполняет команду пользователя о завершении работы
    /// </summary>
    public void Quit()
    {
        IsReadyToExit = true;
    }

    public bool IsReadyToExit
    {
        get; private set;
    }
}

