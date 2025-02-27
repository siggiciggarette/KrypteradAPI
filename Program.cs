public class Program
{
public static void Main(string[] args)
{
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Välkommen till KrypteradAPI!");

app.MapGet("/encrypt", (string input) => Encrypt(input));
app.MapGet("/decrypt", (string input) => Decrypt(input));
app.Run();

string Encrypt(string input)
{
    var encryptor = new Encryption();
    return $"Encrypt: {encryptor.Encrypt(input, 8)}";
}

string Decrypt(string input)
{
    var decryptor = new Encryption();
    return $"Decrypt: {decryptor.Decrypt(input, 8)}";
}
}
}

