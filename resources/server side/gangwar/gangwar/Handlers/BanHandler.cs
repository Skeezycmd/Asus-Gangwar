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


public class BanHandler : IScript
{


    [Command("ban")]
    public static void BanCMD(LPlayer player, string AccountName, string Reason)
    {
        if (player.AdminLevel >= 4)
        {
            foreach (LPlayer target in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountName == AccountName))
            {
                //if (target.AdminLevel >= player.AdminLevel)
                //{
                //    player.SendNotification("4", "", "Der Spieler hat ein höheres Adminlevel als du!", 3);
                //}
                //else
                //{
                BanPlayer(player, AccountName, Reason);
                //}
            }
        }
    }

    [Command("banid")]
    public static void BanIDCMD(LPlayer player, int ID, string Reason)
    {
        if (player.AdminLevel >= 4)
        {
            foreach (LPlayer target in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountID == ID))
            {
                if (target.AdminLevel >= player.AdminLevel)
                {
                    player.SendNotification("4", "", "Der Spieler hat ein höheres Adminlevel als du!", 3);
                }
                else
                {
                    BanPlayerId(player, ID, Reason);
                }
            }
        }
    }

    [Command("mute")]
    public static void muteCMD(LPlayer player, string AccountName, string Reason)
    {
        if (player.AdminLevel >= 2)
        {
            foreach (LPlayer target in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountName == AccountName))
            {
                MutePlayer(player, AccountName, Reason);
                target.Muted = 1;
            }
        }
    }

    [Command("kick")]
    public static void KickCMD(LPlayer player, string AccoutName, string Reason)
    {
        if (player.AdminLevel >= 3)
        {
            KickPlayer(player, AccoutName, Reason);
        }
    }

    public static void MutePlayer(LPlayer player, string AccountName, string Reason)
    {
        try
        {
            MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
            c.Open();

            foreach (LPlayer target in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountName == AccountName))
            {
                target.SendChatMessage("{FF0000}" + $"Du wurdest vom Server Gemuted! Grund: {Reason}");
                string cmdText = "INSERT INTO accounts_mute (name, gemuted, reason, von, datum) VALUES (@name, @gemuted, @reason, @von, @datum)";
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = cmdText;
                cmd.Parameters.AddWithValue("@gemuted", 1);
                cmd.Parameters.AddWithValue("@reason", Reason);
                cmd.Parameters.AddWithValue("@name", AccountName);
                if (AccountName == player.AccountName)
                {
                    cmd.Parameters.AddWithValue("@von", "AutoMute");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@von", player.AccountName);

                }
                cmd.Parameters.AddWithValue("@datum", $"{DateTime.Now.ToShortDateString()} / {DateTime.Now.ToShortTimeString()}");
                cmd.ExecuteNonQuery();
                c.Close();
                return;
            }
            c.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine($"BanPlayer: {e.Message}");
            return;
        }
    }

    public static void KickPlayer(LPlayer player, string AccountName, string Reason)
    {
        foreach(LPlayer target in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountName == AccountName))
        {
            if (target.AdminLevel >= player.AdminLevel)
            {
                player.SendNotification("3", "", "Der Spieler hat ein höheres Adminlevel als du!", 6);
                return;
            }
            target.Kick($"Du wurdest vom Server Gekickt. Grund: {Reason}");
            player.SendGlobalNotify("3", "", $"{AccountName} wurde von {player.AccountName} gekickt.", 10);
            return;
        }
        return;
    }

    public static void BanPlayer(LPlayer player, string AccountName, string Reason)
    {
        try
        {
            MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
            c.Open();

            foreach (LPlayer target in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountName == AccountName))
            {
                if (AccountName == player.AccountName)
                {
                    player.SendGlobalNotify("2", "", $"Der Spieler {AccountName} wurde vom Anticheat gebannt.", 10);
                }
                else
                {
                    player.SendGlobalNotify("2", "Server-Ban", $"Der Spieler {AccountName} wurde von {player.AccountName} gebannt.", 10);
                }
                target.Kick($"Du wurdest vom Server Gebannt. Grund: {Reason}");
                string cmdText = "INSERT INTO accounts_ban (name, gebannt, reason, von, datum, scid, hwid, ip, discordid) VALUES (@name, @gebannt, @reason, @von, @datum, @scid, @hwid, @ip, @discordid)";
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = cmdText;
                cmd.Parameters.AddWithValue("@gebannt", "Ja");
                cmd.Parameters.AddWithValue("@reason", Reason);
                cmd.Parameters.AddWithValue("@name", AccountName);
                if (AccountName == player.AccountName)
                {
                    cmd.Parameters.AddWithValue("@von", "Anticheat");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@von", player.AccountName);

                }
                cmd.Parameters.AddWithValue("@datum", $"{DateTime.Now.ToShortDateString()} / {DateTime.Now.ToShortTimeString()}");
                cmd.Parameters.AddWithValue("@scid", GetSCIDByName(AccountName));
                cmd.Parameters.AddWithValue("@hwid", GetHWIDByName(AccountName));
                cmd.Parameters.AddWithValue("@ip", target.Ip);
                cmd.Parameters.AddWithValue("@discordid", target.DiscordId);
                cmd.ExecuteNonQuery();
                c.Close();
                return;
            }
            c.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine($"BanPlayer: {e.Message}");
            return;
        }
    }

    public static void BanPlayerId(LPlayer player, int ID, string Reason)
    {
        try
        {
            MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
            c.Open();

            foreach (LPlayer target in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountID == ID))
            {
                player.SendGlobalNotify("2", "Server-Ban", $"Der Spieler mit der ID {ID} wurde von {player.AccountName} gebannt.", 10);
                target.Kick($"Du wurdest vom Server Gebannt. Grund: {Reason}");
                string cmdText = "INSERT INTO accounts_ban (name, gebannt, reason, von, datum, scid, hwid, ip, discordid) VALUES (@name, @gebannt, @reason, @von, @datum, @scid, @hwid, @ip, @discordid)";
                MySqlCommand cmd = c.CreateCommand();
                cmd.CommandText = cmdText;
                cmd.Parameters.AddWithValue("@gebannt", "Ja");
                cmd.Parameters.AddWithValue("@reason", Reason);
                cmd.Parameters.AddWithValue("@name", target.AccountName);
                if (target.AccountName == player.AccountName)
                {
                    cmd.Parameters.AddWithValue("@von", "Anticheat");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@von", player.AccountName);

                }
                cmd.Parameters.AddWithValue("@datum", $"{DateTime.Now.ToShortDateString()} / {DateTime.Now.ToShortTimeString()}");
                cmd.Parameters.AddWithValue("@scid", GetSCIDByName(target.AccountName));
                cmd.Parameters.AddWithValue("@hwid", GetHWIDByName(target.AccountName));
                cmd.Parameters.AddWithValue("@ip", target.Ip);
                cmd.Parameters.AddWithValue("@discordid", target.DiscordId);
                cmd.ExecuteNonQuery();
                c.Close();
                return;
            }
            c.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine($"BanPlayer: {e.Message}");
            return;
        }
    }

    public static string GetSCIDByName(string AccountName)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT scid FROM accounts WHERE name=@name";
        MySqlCommand cmd = c.CreateCommand();
        cmd.CommandText = cmdText;
        cmd.Parameters.AddWithValue("@name", AccountName);
        cmd.ExecuteNonQuery();
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                string SCID = reader.GetString("scid");
                c.Close();
                return SCID;
            }
            c.Close();
            return "";
        }
    }

    public static string GetHWIDByName(string AccountName)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT hwid FROM accounts WHERE name=@name";
        MySqlCommand cmd = c.CreateCommand();
        cmd.CommandText = cmdText;
        cmd.Parameters.AddWithValue("@name", AccountName);
        cmd.ExecuteNonQuery();
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                string HWID = reader.GetString("hwid");
                return HWID;
            }
            return "";   
        }
    }



}