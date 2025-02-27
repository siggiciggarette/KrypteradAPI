public class Program
{
public static void Main(string[] args)
{
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Välkommen till KrypteradAPI!");

/*//Encrypt Endpoint
app.MapGet("/encrypt", (EncryptionRequest request) => 
{
    const int shift = 8; // Fixed shift value
    string encrypted = Encrypt(request.Text, shift);
    return Results.Ok(new { EncryptedText = encrypted });
});

// Decrypt Endpoint
app.MapGet("/decrypt", (EncryptionRequest request) =>
{
    const int shift = 8; // Fixed shift value
    string decrypted = Encrypt(request.Text, -shift); // Use negative shift for decryption
    return Results.Ok(new { DecryptedText = decrypted });
});
 
static string Encrypt(string input, int shift)
{
    return new string(input.Select(c =>
        char.IsLetter(c) ? (char)((c + shift - (char.IsUpper(c) ? 'A' : 'a')) % 26 + (char.IsUpper(c) ? 'A' : 'a')) : c
    ).ToArray());
} 

app.Run(); 

record EncryptionRequest(string Text); 

/*app.MapGet("/", () => "Hello World!");

app.MapGet("/encrypt/{text}", (string text, EncryptionService encryptionService) =>
{
    return encryptionService.Encrypt(text);
});

app.MapGet("/decrypt/{text}", (string text, EncryptionService encryptionService) =>
{
    return encryptionService.Decrypt(text);
});

app.Run();
 public class EncryptionService
    {

        private const int ShiftKey = 5;
        public string Encrypt(string input)
        {

            return new string(input.Select(c => (char)(c + ShiftKey)).ToArray());

        }

        public string Decrypt(string input)
        {
            return new string(input.Select(c => (char)(c - ShiftKey)).ToArray());
        }
    }

//app.Run();

//return Results.Ok(new { Message = "Hello World" });
//app.Run(); */

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

