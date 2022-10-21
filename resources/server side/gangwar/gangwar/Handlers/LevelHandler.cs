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
using System.Text.RegularExpressions;


public class LevelHandler : IScript
{
    public static void updateLevel(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET level=@level WHERE id=@accountid";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@accountid", player.AccountID);
        cmd.Parameters.AddWithValue("@level", player.playerlevel);
        cmd.ExecuteNonQuery();
        c.Close();

        player.Emit("updateLevel", player.playerlevel);
        player.SendNotification("2", "", $"Du hast ein LevelUP erhalten!", 6);
    }

    public static void updateExp(LPlayer player, int exp)
    {
        if (player.playerlevel == 100) return;
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET exp=@exp WHERE id=@accountid";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@accountid", player.AccountID);
        cmd.Parameters.AddWithValue("@exp", player.playerexp + exp);
        cmd.ExecuteNonQuery();
        player.playerexp = player.playerexp + exp;
        c.Close();
        if (player.playerexp >= player.playerlevel * 500)
        {
            player.playerexp = 0;
            player.playerlevel = player.playerlevel + 1;
            updateLevel(player);
        }
    }

    [Command("prestige")]
    public static void prestigecmd(LPlayer player)
    {
        if(player.playerlevel == 100)
        {
            MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
            c.Open();
            string cmdText = "UPDATE accounts SET level=@level WHERE id=@accountid";
            MySqlCommand cmd = new MySqlCommand(cmdText, c);
            cmd.Parameters.AddWithValue("@accountid", player.AccountID);
            cmd.Parameters.AddWithValue("@level", 0);
            cmd.ExecuteNonQuery();
            player.playerlevel = 0;
            player.playerexp = 0;
            c.Close();

            foreach(LPlayer player2 in Alt.GetAllPlayers())
            {
                player2.SendChatMessage("{#EEEE00}[PRESTIGE] Der Spieler " + player.AccountName + " wurde soeben Prestige!");
            }
        }
        else
        {
            player.SendChatMessage("Du bist nicht Level 100!");
        }
    }
}

