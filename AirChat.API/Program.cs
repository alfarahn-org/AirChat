using AirChat.Contract;
using System.Collections.Generic;

List<Message> session = [];

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/", () => "Hello from Hot Reload");


app.MapGet("/messages", () => session);
app.MapPost("/messages", (string name, string text) =>
{
    var message = new Message(name, text, DateTime.Now);
    session.Add(message);
    return message;
});

app.Run();
