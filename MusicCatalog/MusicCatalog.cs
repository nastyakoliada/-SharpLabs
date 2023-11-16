namespace Music.Catalog;
/// <summary>
/// Класс содержит перечень музыкальных композиций и предоставляет методы по работе с ним
/// </summary>
public class MusicCatalog
{
    /// <summary>
    /// Перечень композиций
    /// </summary>
    private List<Composition> Compositions { get; set; } = new List<Composition>();
    /// <summary>
    /// Метод доавляет композицию к перечню
    /// </summary>
    /// <param name="composition">Композиция, которую следует добавить</param>
    public void AddComposition(Composition composition)
    {
        Compositions.Add(composition);
    }
    /// <summary>
    /// Метод возвращает enumerator для перебора всех композици каталога.
    /// Композиции отсортированы сначала по автору, потом по названию
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Composition>  ListAll()
    {
        return Compositions.OrderBy(c => c.Author).ThenBy(c => c.SongName);
    }
    /// <summary>
    /// Метод возвращает enumerator для перебора композиций, удовлетворяющих
    /// критерию поиска
    /// </summary>
    /// <param name="query">Критерий поиска композиций</param>
    /// <returns>Enumerator для перебора</returns>
    public IEnumerable<Composition> Search(string query)
    {
        return Compositions
            .Where(c => c.Author.ToLower().Contains(query.ToLower()) 
            || c.SongName.ToLower().Contains(query.ToLower()))
            .OrderBy(c => c.Author)
            .ThenBy(c => c.SongName);
    }
    /// <summary>
    /// Метод удаляет из каталога композиции, удовлетворяющие критерию поиска
    /// </summary>
    /// <param name="query">Критерий поиска</param>
    /// <returns>Количество удаленных композиций</returns>
    public int Remove(string query)
    {
        var removeList = Search(query).ToList();
        
        foreach(var item in removeList)
        {
            Compositions.Remove(item);
        }

        return removeList.Count;
       
    }
}
