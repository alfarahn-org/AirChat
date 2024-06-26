using AirChat.Contract;
using System.Collections.Generic;
using AirChat.API;
using Microsoft.AspNetCore.Builder;

// this session should be from your repository pattern
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
builder.Services.AddHostedService<FlightWorker>();
builder.Services.AddSignalR();

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
app.MapPost("/messages", (Message msg) =>
{
    session.Add(msg);
    return msg;
});

app.MapHub<FlightHub>(nameof(FlightHub));

app.Run();
