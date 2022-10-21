using System;
using AltV;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Async.Elements;
using AltV.Net.Async.Elements.Entities;
using AltV.Net.Async.Elements.Pools;
using AltV.Net.Async.Elements.Refs;
using AltV.Net.Async.Events;
using AltV.Net.ColoredConsole;
using AltV.Net.Data;
using AltV.Net.Elements;
using AltV.Net.Elements.Args;
using AltV.Net.Elements.Entities;
using AltV.Net.Elements.Factories;
using AltV.Net.Elements.Pools;
using AltV.Net.Elements.Refs;
using AltV.Net.EntitySync.Events;
using AltV.Net.EntitySync.ServerEvent;
using AltV.Net.EntitySync.SpatialPartitions;
using AltV.Net.Enums;
using AltV.Net.Events;
using AltV.Net.Exceptions;
using AltV.Net.FunctionParser;
using AltV.Net.Interactions;
using AltV.Net.Native;
using AltV.Net.ResourceLoaders;
using AltV.Net.Resources.Chat.Api;
using AltV.Net.Resources.Chat;
using AltV.Net.Resources;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Discord;
using Discord.WebSocket;
using System.Timers;

public class DiscordBot : IScript
{
    public static string Token = "MTAxNzgxODg3OTA4NDQ3ODQ4NA.Gxr1pM.PBzfdjAL5PrRU0MrmxqkbVracUuDRzF3gWskEU";
    private static DiscordSocketClient _client;
    public static void MainAsync()
    {
        _client = new DiscordSocketClient();

        _client.LoginAsync(TokenType.Bot, Token);
        _client.StartAsync();
    }

    public static void updateStatus()
    {
        _client = new DiscordSocketClient();
        _client.LoginAsync(TokenType.Bot, Token);
        _client.StartAsync();
        _client.SetGameAsync("Server Online mit " + Alt.GetAllPlayers().Count + " Spieler/n");
    }

    public static bool isPlayerInDiscord(LPlayer player)
    { 
        var guild = _client.GetGuild(959076822430121994);
        var user = guild.GetUser(ulong.Parse(player.DiscordId));
        if(user == null)
        {
            Console.WriteLine(player.DiscordId);
            return false;
        }
        else
        {
            Console.WriteLine(player.DiscordId);
            return true;
            
        }
    }

    private static Task Log(LogMessage msg)
    {
        Console.WriteLine($"Alyx BOT: {msg.ToString()}");
        return Task.CompletedTask;
    }

    public static void StartBot()
    {
        MainAsync();
        updateStatus();
    }

    public static void StopBot()
    {
        _client.LogoutAsync();
        _client.StopAsync();
    }

}