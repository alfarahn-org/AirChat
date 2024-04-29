using AirChat.Contract;
using System.Collections.Generic;

List<Message> session = [];

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "policy", policy =>
    {
        policy.WithOrigins("*");
    });
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseCors(builder => builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);

app.MapGet("/", () => "Hello from Hot Reload");


app.MapGet("/messages", () => session);
app.MapPost("/messages", (string name, string text) =>
{
    var message = new Message(name, text, DateTime.Now);
    session.Add(message);
    return message;
});

app.Run();
