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

public class MoneyHandler : IScript
{
    [Command("test")]
    public static void testcmd(LPlayer player)
    {
        updateMoney(player, 25);
    }

    public static void updateMoney(LPlayer player, int money)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET money=@money WHERE id=@accountid";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@accountid", player.AccountID);
        cmd.Parameters.AddWithValue("@money", player.playermoney + money);
        cmd.ExecuteNonQuery();
        player.playermoney = player.playermoney + money;
        c.Close();
        player.Emit("setMoney", player.playermoney);
    }

    public static void updateMoneyMinus(LPlayer player, int money)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET money=@money WHERE id=@accountid";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@accountid", player.AccountID);
        cmd.Parameters.AddWithValue("@money", player.playermoney - money);
        cmd.ExecuteNonQuery();
        player.playermoney = player.playermoney - money;
        c.Close();
        player.Emit("setMoney", player.playermoney);
    }
}

