
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


public class PlayerConnectEvent : IScript
{

    [ClientEvent("Server:Client:ConnectionComplete")]
    public static void ScriptEventPlayerConnectEvent(LPlayer player, string SCName)
    {
        //if (player.DiscordId == "" || player.DiscordId == null)
        //{
        //    player.Kick("Öffne Discord!");
        //    return;
        //}
        //if (DiscordBot.isPlayerInDiscord(player) == false)
        //{
        //    player.Kick("Du bist nicht berechtigt auf den Server zu Connecten! | Melde dich im Support!");
        //    Console.WriteLine("Ein Spieler hat versucht zu connecten ohne auf dem DC zu sein" + player.DiscordId);
        //}
        //if (DiscordBot.isPlayerInDiscord(player) == true)
        //{
        //    Console.WriteLine("Der Spieler mit der DiscordID " + player.DiscordId + " ist gejoint.");
        //}
        if (IsPlayerBanned(player) == false)
        {
            int RandomDemi = new Random().Next(1, 9999999);
            player.Dimension = RandomDemi;
            player.RemoveAllWeapons();
            player.Model = (uint)PedModel.FreemodeMale01;
            player.Spawn(new Position(100, 60, 200), 0);
            player.SocialclubName = SCName;
            player.Emit("Client:Login:Show");
            player.Visible = false;
            player.Frozen = true;
            player.openCef = true;
        }
        else
        {
            player.Kick("Du bist vom Server gebannt.");
            return;
        }
    }


    [ClientEvent("öffneHud")]
    public static void öffnehud(LPlayer player)
    {
        player.Emit("openHud");
    }

    public static bool IsPlayerBanned(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT * FROM accounts_ban WHERE scid=@scid OR hwid=@hwid";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@scid", player.SocialClubId);
        cmd.Parameters.AddWithValue("@hwid", player.HardwareIdHash);
        
        cmd.ExecuteNonQuery();
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                return true;
            }
            return false;
        }
    }
}