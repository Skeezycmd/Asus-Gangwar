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

public class RegisterModule : IScript
{

    [ClientEvent("Server:Login:Register")]
    public static void CreatePlayerAccount(LPlayer player, string AccountName)
    {
        try
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regexItem.IsMatch(AccountName))
            {
                player.Kick("Dein Name hat Sonderzeichen!");
                return;
            }
            if(AccountName.Contains(" "))
            {
                player.Kick("Dein Name hat Sonderzeichen!");
                return;
            }
            if(player.DiscordId == null)
            {
                player.Kick("Öffne Discord!");
                return;
            }
            if (IsPlayerAccountExist(player) == false)
            {
                if (IsNameVergeben(AccountName) == false)
                {
                    MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
                    c.Open();
                    string cmdText = "INSERT INTO accounts (name, scid, scname, hwid, adminlevel, exp, level, discordid, ip) VALUES (@name, @scid, @scname, @hwid, @adminlevel, @exp, @level, @discordid, @ip)";
                    MySqlCommand cmd = new MySqlCommand(cmdText, c);
                    cmd.Parameters.AddWithValue("@name", AccountName);
                    cmd.Parameters.AddWithValue("@scid", player.SocialClubId);
                    cmd.Parameters.AddWithValue("@scname", player.SocialclubName);
                    cmd.Parameters.AddWithValue("@hwid", player.HardwareIdHash);
                    cmd.Parameters.AddWithValue("@adminlevel", 0);
                    cmd.Parameters.AddWithValue("@level", 0);
                    cmd.Parameters.AddWithValue("@exp", 0);
                    cmd.Parameters.AddWithValue("@discordid", player.DiscordId);
                    cmd.Parameters.AddWithValue("@ip", player.Ip);

                    cmd.ExecuteNonQuery();
                    player.SendNotification("2", "", "Du hast dich erfolgreich Registriert!", 6);


                    c.Close();
                }
                else
                {
                    player.SendNotification("4", "", "Der Name ist bereits vergeben.", 6);
                }
                
            }
            else
            {
                player.SendNotification("4", "", "Du hast bereits einen Account.", 6);
                return;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"CreatePlayerAccount: {e.Message}");
            return;
        }
    }


    private static bool IsPlayerAccountExist(LPlayer player)
    {
        try
        {
            MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
            c.Open();
            string cmdText = "SELECT scid FROM accounts WHERE scid=@scid";
            MySqlCommand cmd = new MySqlCommand(cmdText, c);
            cmd.Parameters.AddWithValue("@scid", player.SocialClubId);
            cmd.ExecuteNonQuery();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    c.Close();
                    return true;
                }
                c.Close();
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"IsPlayerAccountExist: {e.Message}");
            return false;
        }
    }


    private static bool IsNameVergeben(string AccountName)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT name FROM accounts WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", AccountName);
        cmd.ExecuteNonQuery();
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                c.Close();
                return true;
            }
            c.Close();
            return false;
        }
    }

}