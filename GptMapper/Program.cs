// See https://aka.ms/new-console-template for more information

using GptMapper;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .AddJsonFile("appsettings.json")
    .Build();


var mapperChat = new MapperChat(configuration);
await mapperChat.StartChatAsync();