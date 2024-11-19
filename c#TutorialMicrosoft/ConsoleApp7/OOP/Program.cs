// See https://aka.ms/new-console-template for more information

using System;

Console.WriteLine("Hello oop");

var p1 = new Person("Scott", "Hanselman", new DateOnly(1970, 1, 1));
var p2 = new Person("Sunny", "Thapa", new DateOnly(1990, 1, 1));

p1.Pets.Add(new Dog("Fred"));
p1.Pets.Add(new Dog("Barney"));

p2.Pets.Add(new Cat("Beyonce"));


// public class Person
// {
//just an example think like person is like a menu showing what you have and private is like the kitchen where you don't show what things you have kitchen and what going on in the kitchen.

//Constructor
// public Person(string first, string last, DateOnly bd)
// {
//     firstName = first;
//     lastName = last;
//     birthday = bd;
// }
//
//
// private string firstName;
//
// private string lastName;
//
// private DateOnly birthday;

// }


// New way

//use primary constructor
//c# 12 not exposing get method to the outside work
// read

// var people = new List<Person> { p1, p2 };
// or
List<Person> people = [p1, p2];

foreach (var person in people)
{
    Console.WriteLine($"{person}");
    foreach (var pet in person.Pets)
    {
        Console.Write($"{      pet}");
    }
}

Console.WriteLine(people.Count);

public class Person(string firstname, string lastname, DateOnly birthday)
{
    //here we leave only get so that we can only get the information but no one can set it 
    public string First { get; } = firstname;
    public string Last { get; } = lastname;
    public DateOnly Birthday { get; } = birthday;

    public List<Pet> Pets { get; } = new();

    public override string ToString()
    {
        return $"{firstname} {lastname}";
    }
}

public abstract class Pet(string firstname)
{
    public string First { get; } = firstname;

    public abstract string MakeNoise();

    public override string ToString()
    {
        return $"{firstname} and I am a {GetType().Name} and I make {MakeNoise()}";
    }
}


public class Cat(string firstname) : Pet(firstname)
{
    // public string First { get; } = firstname;

    public override string MakeNoise()
    {
        return "Meow";
    }
}

public class Dog(string firstname) : Pet(firstname)
{
    // public string First { get; } = firstname;

    // public string Bark()
    // {
    //     return "bark";
    // }

    // since it only returns a string we can use arrow syntax
    public override string MakeNoise()
    {
        return "Bark";
    }
}