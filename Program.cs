var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Välkommen till KrypteradAPI!");

// Encrypt Endpoint
app.MapPost("/encrypt", (EncryptionRequest request) => 
{
    string encrypted = Encrypt(request.Text, request.Shift);
    return Results.Ok(new { EncryptedText = encrypted });
});

// Decrypt Endpoint
app.MapPost("/decrypt", (EncryptionRequest request) =>
{
    string decrypted = Encrypt(request.Text, -request.Shift); // Reuse the Encrypt function for decryption
    return Results.Ok(new { DecryptedText = decrypted });
});

static string Encrypt(string input, int shift)
{
    return new string(input.Select(c =>
        char.IsLetter(c) ? (char)((c + shift - (char.IsUpper(c) ? 'A' : 'a')) % 26 + (char.IsUpper(c) ? 'A' : 'a')) : c
    ).ToArray());
}


app.Run();
record EncryptionRequest(string Text, int Shift);


