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
using System.Timers;
using MySql.Data.MySqlClient;
using AltV.Net.EntitySync;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class MainCrimelife : Resource
{

    static void Main(string[] args)
    {
    }

    public override void OnStart()
    {
        Console.WriteLine(">> GW | Gestartet");

        DiscordBot.StartBot();
        ChatTimer();
    }

    public override void OnStop()
    {
        Console.WriteLine(">> GW | Gestoppt");
        DiscordBot.StopBot();
    }


    public override IEntityFactory<IPlayer> GetPlayerFactory()
    {
        Console.WriteLine("> GW | LPlayer Factory Geladen.");
        return new LPlayerFactory();
    }

    public override IEntityFactory<IVehicle> GetVehicleFactory()
    {
        Console.WriteLine("> GW | LVehicle Factory Geladen.");
        return new LVehicleFactory();
    }

    public static void ChatTimer()
    {
        System.Timers.Timer DeathAnimTimer = new System.Timers.Timer();
        DeathAnimTimer.Elapsed += new ElapsedEventHandler(ChatHandler.SendGlobalMessage);
        DeathAnimTimer.Interval += 500000;
        DeathAnimTimer.Enabled = true;
        DeathAnimTimer.Start();
        Console.WriteLine("timer started");
    }
}