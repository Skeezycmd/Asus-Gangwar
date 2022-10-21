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

public class Playerstuff : IScript
{
    public static void updateKills(LPlayer player, int kills)
    {
        player.Emit("updateKills", kills);
    }

    public static void updateDeaths(LPlayer player, int deaths)
    {
        player.Emit("updateDeaths", deaths);
    }

    public static void updateKd(LPlayer player, int kills, int deaths)
    {
        player.Emit("updateKd", kills, deaths);
        player.Emit("updateLevel", player.playerlevel);
        player.Emit("setMoney", player.playermoney);
    }

    public static void updatedatakills(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET kills=@kills WHERE id=@accountid";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@accountid", player.AccountID);
        cmd.Parameters.AddWithValue("@kills", player.Kills + 1);
        cmd.ExecuteNonQuery();
        updateKills(player, player.Kills);
        c.Close();
    }

    public static void updatedatadeaths(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET deaths=@deaths WHERE id=@accountid";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@accountid", player.AccountID);
        cmd.Parameters.AddWithValue("@deaths", player.Deaths + 1);
        cmd.ExecuteNonQuery();
        updateDeaths(player, player.Deaths);
        c.Close();
    }

    [Command("resetkd")]
    public static void resetkd(LPlayer player)
    {
            MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
            c.Open();
            string cmdText = "UPDATE accounts SET deaths=@deaths, kills=@kills WHERE id=@accountid";
            MySqlCommand cmd = new MySqlCommand(cmdText, c);
            cmd.Parameters.AddWithValue("@accountid", player.AccountID);
            cmd.Parameters.AddWithValue("@deaths",0);
            cmd.Parameters.AddWithValue("@kills", 0);
            cmd.ExecuteNonQuery();
            player.Deaths = 0;
            player.Kills = 0;
            updateDeaths(player, player.Deaths);
            updateKd(player, 0, 0);
            updateKills(player, 0);
            c.Close();
    }

}

