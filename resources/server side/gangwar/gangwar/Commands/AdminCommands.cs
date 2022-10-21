using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltV.Net;
using AltV;
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
using AltV.Net.Resources.Chat;
using AltV.Net.Resources;
using MySql.Data.MySqlClient;


public class AdminCommands : IScript
{

    [Command("tc", greedyArg: true)]
    public static void tccmd(LPlayer player, string msg)
    {
        foreach (LPlayer player2 in Alt.GetAllPlayers())
        {
            if (player.AdminLevel >= 1)
            {
                if (player2.adminchatactive == true)
                {
                    if (player2.AdminLevel >= 1)
                    {
                        player2.SendChatMessage("{FF0000}[TC]{FFFFFF} " + player.AccountName + ": " + msg);
                    }

                }
            }
        }
    }

    [Command("logip")]
    public static void logip(LPlayer player, string target)
    {
        foreach (LPlayer target2 in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountName == target))
        {
            Console.WriteLine(target2.AccountName + " | " + target2.Ip);
        }
    }

    [Command("toggletc")]
    public static void toggletc(LPlayer player)
    {
        if (player.AdminLevel >= 1)
        {
            if (player.adminchatactive == true)
            {
                player.adminchatactive = false;
                player.SendChatMessage("Teamchat Deaktiviert!");

            }
            else
            {
                player.adminchatactive = true;
                player.SendChatMessage("Teamchat Aktiviert!");
            }
        }
    }

    [Command("dv")]
    public static void dvcmd(LPlayer player)
    {
        if (player.AdminLevel >= 3)
        {
            player.Vehicle.Remove();
        }
    }

    [Command("dvall")]
    public static void dvall(LPlayer player)
    {
        if (player.AdminLevel >= 8)
        {
            foreach (LVehicle veh3 in Alt.GetAllVehicles())
            {
                veh3.Remove();
            }
        }
    }

    [Command("pos")]
    public static void PosCMD(LPlayer player)
    {
        if (player.AdminLevel >= 10)
        {
            float PosX = player.Position.X;
            float PosY = player.Position.Y;
            float PosZ = player.Position.Z;
            float Rot = player.Rotation.Yaw;

            Console.WriteLine($"{PosX.ToString().Replace(",", ".")}f, {PosY.ToString().Replace(",", ".")}f, {PosZ.ToString().Replace(",", ".")}f ROT: {Rot.ToString().Replace(",", ".")}f");
        }
    }

    [Command("clearchat")]
    public static void clearchat(LPlayer player)
    {
        if (player.AdminLevel >= 3)
        {
            foreach (LPlayer target in Alt.GetAllPlayers())
            {
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
                player.SendChatMessage($" ");
            }
        }
    }

    [Command("tppos")]
    public static void tppos(LPlayer player, int posx, int posy, int posz)
    {
        if (player.AdminLevel == 10)
        {
            player.Position = (new Position(posx, posy, posz));
        }
    }

    [Command("veh")]
    public static void VehCMD(LPlayer player, string vehhash)
    {
        if (player.AdminLevel >= 3)
        {
            foreach (LVehicle veh2 in Alt.GetAllVehicles())
            {
                if (veh2.GetData("hasadminveh", out string vehTestValue))
                {
                    veh2.Remove();
                }
            }
            LVehicle veh = (LVehicle)Alt.CreateVehicle(Alt.Hash(vehhash), player.Position, player.Rotation);
            veh.SetData("hasadminveh", player.AccountName);
            player.SetIntoVehicle(veh, 1);
        }
    }

    [Command("announce", true)]
    public void announceCMD(LPlayer player, string message)
    {
        if (player.AdminLevel >= 8)
        {
            player.SendGlobalNotify("1", "", message, 15);
        }
    }

    [Command("setadmin")]
    public void SetAdminCMD(LPlayer player, string Name, int Rang)
    {
        if (player.AdminLevel == 10)
        {
            foreach (LPlayer players in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountName == Name))
            {
                players.AdminLevel = Rang;

                player.SendNotification("2", "", $"Du hast dem Spieler: {Name} den Rang: {Rang} gegeben.", 6);

                MySql.Data.MySqlClient.MySqlConnection c = new MySql.Data.MySqlClient.MySqlConnection(DatenbankMain.ConnectionString);
                c.Open();
                string cmdText = "UPDATE accounts SET adminlevel=@adminlevel WHERE name=@name";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(cmdText, c);
                cmd.Parameters.AddWithValue("@adminlevel", Rang);
                cmd.Parameters.AddWithValue("@name", Name);
                cmd.ExecuteNonQuery();
                c.Close();

                return;
            }
            return;
        }
    }

    [Command("SetClothes")]
    public void SetClothesCMD(LPlayer player, byte com, ushort col, byte set)
    {
        if (player.AdminLevel >= 8)
        {
            player.SetClothes(com, col, set, 0);
        }
    }

    [Command("tp")]
    public void TPCMD(LPlayer player, string Name)
    {
        if (player.AdminLevel >= 1)
        {
            foreach (LPlayer target in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountName == Name))
            {
                player.Position = target.Position;
            }
            return;
        }
    }

    [Command("tphere")]
    public void TPHERECMD(LPlayer player, string Name)
    {
        if (player.AdminLevel >= 3)
        {
            foreach (LPlayer target in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountName == Name))
            {
                target.Position = player.Position;
            }
            player.SendNotification("3", "", "Es wurde kein Spieler mit dem Namen gefunden.", 6);
            return;
        }
    }

    [Command("revive")]
    public void ReviveCMD(LPlayer player, string Name)
    {
        if (player.AdminLevel >= 6)
        {
            foreach (LPlayer target in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountName == Name))
            {
                target.Spawn(target.Position, 0);
                target.ClearBloodDamage();
                target.Dead = false;
            }
        }
    }

    [Command("reportaccept")]
    public void reportacceptcmd(LPlayer player, string target)
    {
        if (player.AdminLevel >= 1)
        {
            foreach (LPlayer players in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountName == target))
            {
                if (players.Exists)
                {
                    player.Position = players.Position;
                    foreach (LPlayer players2 in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AdminLevel >= 1))
                    {
                        players2.SendChatMessage("{00E437} Das Teammitglied " + player.AccountName + " hat den Report gegen " + players.AccountName + " angenommen!");
                    }
                }
            }
        }
    }
}