using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games =
    [
        new()
        {
            Id = 1,
            Name = "Street Fighter II",
            Genre = "fighting",
            Price = 19.99M,
            ReleaseDate = new DateOnly(1922, 7, 15)
        },
        new (){
            Id = 2,
            Name = "Final Fantasy XIV",
            Genre = "Roleplaying",
            Price = 59.99M,
            ReleaseDate = new DateOnly(2010, 9, 30) },
        new (){
            Id = 3,
            Name = "FIFA 23",
            Genre = "Sports",
            Price = 69.99M,
            ReleaseDate = new DateOnly(2022, 9, 27) 
        },
        new(){
            Id=4,
            Name="Spider man",
            Genre="Roleplaying",
            Price = 60.00M,
            ReleaseDate = new DateOnly(2023,9,27)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [..games];

    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrEmpty(game.GenreId);
        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));
        
        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        
        games.Add(gameSummary);
    }
}