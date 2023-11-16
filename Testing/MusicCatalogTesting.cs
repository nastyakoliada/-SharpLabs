namespace Testing;
using Music.Catalog;
/// <summary>
/// ����� ��� ������������ ������������ �������� � ���� 2
/// </summary>
public class MusicCatalogTesting
{
    MusicCatalog catalog = null!;
    /// <summary>
    /// ��������������� ����� ������� ���������� �������
    /// </summary>
    private void CreateTestCatalog()
    {
        catalog = new MusicCatalog();

        catalog.AddComposition(new Composition()
        {
            Author = "�����",
            SongName = "���������",
        });

        catalog.AddComposition(new Composition()
        {
            Author = "��������",
            SongName = "2007",
        });

    }
    /// <summary>
    /// ������������ ���������� ��������
    /// </summary>
    [Fact]
    public void AddTesting()
    {
        CreateTestCatalog();

        Assert.Collection<Composition>(catalog.ListAll(),
            c =>
            {
                Assert.Equal("��������", c.Author);
                Assert.Equal("2007", c.SongName);
            },
            c => {
                Assert.Equal("�����", c.Author);
                Assert.Equal("���������", c.SongName);
            }
            
            );
        Assert.Equal(2,catalog.ListAll().Count());
    }
    /// <summary>
    /// ������������ �������� ���������� �� ��������
    /// </summary>
    [Fact]
    public void RemoveTesting()
    {
        CreateTestCatalog();

        catalog.Remove("���");
        Assert.Collection<Composition>(catalog.ListAll(),
            c =>
            {
                Assert.Equal("��������", c.Author);
                Assert.Equal("2007", c.SongName);
            }
            );
        Assert.Single(catalog.ListAll());
    }
    /// <summary>
    /// ������������ ������ � ��������
    /// </summary>
    [Fact]
    public void SearchTesting()
    {
        CreateTestCatalog();

        var sch = catalog.Search("��");

        Assert.Collection<Composition>(sch,
            c =>
            {
                Assert.Equal("�����", c.Author);
                Assert.Equal("���������", c.SongName);
            }
            );
        Assert.Single(sch);
    }
}