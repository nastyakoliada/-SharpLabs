﻿
namespace Music.Catalog;
/// <summary>
/// Запись о музыкальной композиции
/// </summary>
public record Composition
{
    /// <summary>
    /// Автор композиции
    /// </summary>
    public required string Author { get; set; }
    /// <summary>
    /// Название композиции
    /// </summary>
    public required string SongName { get; set; }
}