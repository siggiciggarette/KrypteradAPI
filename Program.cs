var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Välkommen till KrypteradAPI!");

// Encrypt Endpoint
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


