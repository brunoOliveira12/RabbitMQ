using RabbitMQ.Client;
using RabbitMq.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RabbitMqOptions>(builder.Configuration.GetSection("RabbitMQ"));

builder.Services.AddSingleton<IConnectionFactory, RabbitMqConnectionFactory>();
builder.Services.AddSingleton<RabbitMqProducer>();
builder.Services.AddSingleton<RabbitMqConsumer>();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.GetRequiredService<RabbitMqProducer>();

var consumer = app.Services.GetRequiredService<RabbitMqConsumer>();
consumer.ConsumeMessages();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
