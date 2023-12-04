using KafkaServices.Api.Consumers.Handlers;
using KafkaServices.Api.Consumers.Models;
using KafkaServices.Kafka;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.


#region Producers Config

//services.AddKafkaMessageBus();

//services.AddKafkaProducer<string, User>(p =>
//{
//    p.Topic = "users";
//    p.BootstrapServers = "localhost:9092";
//});

#endregion


#region Consumers Configs

//services.AddKafkaConsumer<string, User, UserCreatedHandler>(p =>
//{
//    p.Topic = "users";
//    p.GroupId = "users_group";
//    p.BootstrapServers = "localhost:9092";
//});

#endregion







builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
