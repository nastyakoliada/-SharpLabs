namespace Testing;
using Music.Catalog;
/// <summary>
/// Класс для тестирования музыкального каталога к лабе 2
/// </summary>
public class MusicCatalogTesting
{
    MusicCatalog catalog = null!;
    /// <summary>
    /// Вспомогательный метод создает заполннный каталог
    /// </summary>
    private void CreateTestCatalog()
    {
        catalog = new MusicCatalog();

        catalog.AddComposition(new Composition()
        {
            Author = "Увула",
            SongName = "Отражение",
        });

        catalog.AddComposition(new Composition()
        {
            Author = "Источник",
            SongName = "2007",
        });

    }
    /// <summary>
    /// Тестирование заполнение каталога
    /// </summary>
    [Fact]
    public void AddTesting()
    {
        CreateTestCatalog();

        Assert.Collection<Composition>(catalog.ListAll(),
            c =>
            {
                Assert.Equal("Источник", c.Author);
                Assert.Equal("2007", c.SongName);
            },
            c => {
                Assert.Equal("Увула", c.Author);
                Assert.Equal("Отражение", c.SongName);
            }
            
            );
        Assert.Equal(2,catalog.ListAll().Count());
    }
    /// <summary>
    /// Тестирование удаления композиций из каталога
    /// </summary>
    [Fact]
    public void RemoveTesting()
    {
        CreateTestCatalog();

        catalog.Remove("Отр");
        Assert.Collection<Composition>(catalog.ListAll(),
            c =>
            {
                Assert.Equal("Источник", c.Author);
                Assert.Equal("2007", c.SongName);
            }
            );
        Assert.Single(catalog.ListAll());
    }
    /// <summary>
    /// Тестировнаие поиска в каталоге
    /// </summary>
    [Fact]
    public void SearchTesting()
    {
        CreateTestCatalog();

        var sch = catalog.Search("Ув");

        Assert.Collection<Composition>(sch,
            c =>
            {
                Assert.Equal("Увула", c.Author);
                Assert.Equal("Отражение", c.SongName);
            }
            );
        Assert.Single(sch);
    }
}