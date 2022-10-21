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


public class playercommands : IScript
{

    [Command("report")]
    public static void reportcmd(LPlayer player, string target, string reason)
    {
        foreach (LPlayer players in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountName == target))
        {
            if(players.Exists)
            {
                player.SendNotification("2", "", $"Du hast den Spieler: {players.AccountName} mit dem Grund: {reason} reportet!", 6);
                foreach (LPlayer players2 in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AdminLevel >= 1))
                {
                    players2.SendChatMessage("{FF0000}-----------------");
                    players2.SendChatMessage("{FF0000}Der Spieler " + player.AccountName + " hat den Spieler " + players.AccountName + " Gemeldet! Grund: " + reason);
                    players2.SendChatMessage("{FF0000}-----------------");
                }
            }
        }
    }

    [Command("players")]
    public static void playercmd(LPlayer player)
    {
        player.SendChatMessage("[{0056E4}INFO{FFFFFF}] " + $"Aktuelle Spieleranzahl: {Alt.GetAllPlayers().Count}");
    }

    [Command("time")]
    public void timeCMD(LPlayer player, int time)
    {
        try
        {
            player.SetDateTime(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, time, time, 0);
        }
        catch (Exception e)
        {
            Alt.Log($"{e}");
        }
    }

    [Command("quitffa")]
    public void quitffaCMD(LPlayer player)
    {
        if (player.isFfa == true)
        {
            player.isFfa = false;
            player.ffaarena = 0;
            player.Dimension = 0;
            if (player.Team == 1)
            {
                Teamauswahl.teamSelectedTeam1(player);
                return;
            }

            if (player.Team == 2)
            {
                Teamauswahl.teamSelectedTeam2(player);
                return;
            }
            if (player.Team == 3)
            {
                Teamauswahl.teamSelectedTeam3(player);
                return;
            }
            if (player.Team == 4)
            {
                Teamauswahl.teamSelectedTeam4(player);
                return;
            }
            if (player.Team == 5)
            {
                Teamauswahl.teamSelectedTeam5(player);
                return;
            }
            if (player.Team == 6)
            {
                Teamauswahl.teamSelectedTeam6(player);
                return;
            }
            if (player.Team == 7)
            {
                Teamauswahl.teamSelectedTeam7(player);
                return;
            }
            if (player.Team == 8)
            {
                Teamauswahl.teamSelectedTeam8(player);
                return;
            }
            if (player.Team == 9)
            {
                Teamauswahl.teamSelectedTeam9(player);
                return;
            }
            if (player.Team == 10)
            {
                Teamauswahl.teamSelectedTeam10(player);
                return;
            }
        }
    }

    [Command("ffa")]
    public void ffacmd(LPlayer player)
    {
        if (player.openCef == false && player.isFfa == false)
        {
            player.Emit("FFA:Showmenu");
            player.openCef = true;
            FFA.updateFFACounter(player);
        }
    }

    [Command("team")]
    public void teamcmd(LPlayer player)
    {
        if (player.BenutztGradeSchutzweste && player.BenutztGradeMedkit && player.Dead && player.IsInVehicle && player.openCef == false && player.isFfa == false)
        {
            player.Emit("OpenTeamSelect");
            player.openCef = true;
            Teamauswahl.updateTeamCounter(player);
        }
    }

    [Command("weather")]
    public void weathercmd(LPlayer player, int weather)
    {
        try
        {
            player.SetWeather((uint)weather);
        }
        catch (Exception e)
        {
            Alt.Log($"{e}");
        }
    }
}