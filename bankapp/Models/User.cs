namespace Models;

public class User{
    public string? Name {get; set;}

    public string? LastName {get; set;}

    public string? NIF {get; set;}

    public User(string name, string lastname){
        Name = name;
        LastName = lastname;
    }

    public User(){}

    public override string ToString()
    {
        return (Name ?? "NoName") + " " + (LastName ?? "NoLastName") + " " + NIF;
    } 
}