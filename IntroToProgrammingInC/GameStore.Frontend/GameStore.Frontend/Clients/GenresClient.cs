using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient
{
    private readonly Genre[] genres =
    [
        new()
        {
            Id = 1,
            Name = "Fighting"
        },
        new()
        {
            Id = 2,
            Name = "Roleplaying"
        },
        new()
        {
            Id = 3,
            Name = "Sports"
        },
        new()
        {
            Id = 4,
            Name = "Racing"
        },
        new()
        {
            Id = 5,
            Name = "Kids and Family"
        }
    ];
    
    //Property Declaration
    // This line declares a public property called GetGenres. The Genre[] return type indicates that the property returns an array of Genre objects.
    //     The property uses the => operator, which is called an "expression-bodied member". It's a shorthand way to define a property that has a simple return statement.
    //     The genres field is accessed directly, and its value is returned as the result of the property.
    public Genre[] GetGenres() => genres;
}