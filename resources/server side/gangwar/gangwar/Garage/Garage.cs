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

public class Garage : IScript
{

    [ClientEvent("Keypress:E")]
    public static void keypressegarage(LPlayer player)
    {
        if (player.Position.Distance(new Position(102.738464f, -1958.8484f, 20.787598f)) < 2f && player.openCef == false)
        {
            if (player.Team == 1)
            {
                var vehicle = Alt.GetAllVehicles().Cast<LVehicle>().Where(x => x.HasData("hasveh")).FirstOrDefault(x => x.GetData("hasveh", out string owner) && owner == player.AccountName);
                if (vehicle != null)
                {
                    vehicle.Remove();
                }
                player.Emit("openGarageServer");
                player.openCef = true;
            }
        }
        else if (player.Position.Distance(new Position(1408.6022f, 3618.2769f, 34.89087f)) < 2f && player.openCef == false)
        {
            if (player.Team == 2)
            {
                var vehicle = Alt.GetAllVehicles().Cast<LVehicle>().Where(x => x.HasData("hasveh")).FirstOrDefault(x => x.GetData("hasveh", out string owner) && owner == player.AccountName);
                if (vehicle != null)
                {
                    vehicle.Remove();
                }
                player.Emit("openGarageServer");
                player.openCef = true;

            }
        }
        else if (player.Position.Distance(new Position(1382.9802f, 1138.2594f, 114.32092f)) < 2f && player.openCef == false)
        {
            if (player.Team == 3)
            {
                var vehicle = Alt.GetAllVehicles().Cast<LVehicle>().Where(x => x.HasData("hasveh")).FirstOrDefault(x => x.GetData("hasveh", out string owner) && owner == player.AccountName);
                if (vehicle != null)
                {
                    vehicle.Remove();
                }
                player.Emit("openGarageServer");
                player.openCef = true;
            }
        }
        else if (player.Position.Distance(new Position(-1520.5187f, 849.0989f, 181.58533f)) < 2f && player.openCef == false)
        {
            if (player.Team == 4)
            {
                var vehicle = Alt.GetAllVehicles().Cast<LVehicle>().Where(x => x.HasData("hasveh")).FirstOrDefault(x => x.GetData("hasveh", out string owner) && owner == player.AccountName);
                if (vehicle != null)
                {
                    vehicle.Remove();
                }
                player.Emit("openGarageServer");
                player.openCef = true;
            }
        }
        else if (player.Position.Distance(new Position(1378.3912f, -585.5868f, 74.369995f)) < 2f && player.openCef == false)
        {
            if (player.Team == 5)
            {
                var vehicle = Alt.GetAllVehicles().Cast<LVehicle>().Where(x => x.HasData("hasveh")).FirstOrDefault(x => x.GetData("hasveh", out string owner) && owner == player.AccountName);
                if (vehicle != null)
                {
                    vehicle.Remove();
                }
                player.Emit("openGarageServer");
                player.openCef = true;
            }
        }
        else if (player.Position.Distance(new Position(1279.5428f, -1595.1956f, 54.21753f)) < 2f && player.openCef == false)
        {
            if (player.Team == 6)
            {
                var vehicle = Alt.GetAllVehicles().Cast<LVehicle>().Where(x => x.HasData("hasveh")).FirstOrDefault(x => x.GetData("hasveh", out string owner) && owner == player.AccountName);
                if (vehicle != null)
                {
                    vehicle.Remove();
                }
                player.Emit("openGarageServer");
                player.openCef = true;
            }
        }
        else if (player.Position.Distance(new Position(-1528.5758f, 78.55385f, 56.77881f)) < 2f && player.openCef == false)
        {
            if (player.Team == 7)
            {
                var vehicle = Alt.GetAllVehicles().Cast<LVehicle>().Where(x => x.HasData("hasveh")).FirstOrDefault(x => x.GetData("hasveh", out string owner) && owner == player.AccountName);
                if (vehicle != null)
                {
                    vehicle.Remove();
                }
                player.Emit("openGarageServer");
                player.openCef = true;
            }
        }
        else if (player.Position.Distance(new Position(1987.9517f, 3060.5803f, 47.073242f)) < 2f && player.openCef == false)
        {
            if (player.Team == 8)
            {
                var vehicle = Alt.GetAllVehicles().Cast<LVehicle>().Where(x => x.HasData("hasveh")).FirstOrDefault(x => x.GetData("hasveh", out string owner) && owner == player.AccountName);
                if (vehicle != null)
                {
                    vehicle.Remove();
                }
                player.Emit("openGarageServer");
                player.openCef = true;
            }
        }
        else if (player.Position.Distance(new Position(-51.23077f, 348.3956f, 112.38318f)) < 2f && player.openCef == false)
        {
            if (player.Team == 9)
            {
                var vehicle = Alt.GetAllVehicles().Cast<LVehicle>().Where(x => x.HasData("hasveh")).FirstOrDefault(x => x.GetData("hasveh", out string owner) && owner == player.AccountName);
                if (vehicle != null)
                {
                    vehicle.Remove();
                }
                player.Emit("openGarageServer");
                player.openCef = true;
            }
        }
        else if (player.Position.Distance(new Position(-17.986813f, -1451.0505f, 30.57727f)) < 2f && player.openCef == false)
        {
            if (player.Team == 10)
            {
                var vehicle = Alt.GetAllVehicles().Cast<LVehicle>().Where(x => x.HasData("hasveh")).FirstOrDefault(x => x.GetData("hasveh", out string owner) && owner == player.AccountName);
                if (vehicle != null)
                {
                    vehicle.Remove();
                }
                player.Emit("openGarageServer");
                player.openCef = true;
            }
        }
    }

    [ClientEvent("closegarage")]
    public static void closegarage(LPlayer player)
    {
        player.openCef = false;
    }
    //Hier muss noch was gemacht werden wegen ausparkpunkt!!!
    #region veh1
    [ClientEvent("vehicle1")]
    public static void vehicle1(LPlayer player)
    {
        if (player.LoggedIn == false) return;
        if (player.playerlevel >= 0)
        {
            if (player.Team == 1)
            {
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("bati"), new Position(86.50549f, -1929.4286f, 20.686401f), new Rotation(0, 0, 0.7915824f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 148;
                car1.SecondaryColor = 148;
                car1.PearlColor = 0;
                car1.Dimension = player.Dimension;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 2)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1423.1736f, 3616.1406f, 34.36853f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("bati"), new Position(1423.1736f, 3616.1406f, 34.36853f), new Rotation(0, 0, -2.7705386f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 70;
                car1.SecondaryColor = 70;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 9)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-58.101097f, 336.76483f, 111.557495f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("bati"), new Position(-58.101097f, 336.76483f, 111.557495f), new Rotation(0, 0, 2.6715908f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 83;
                car1.SecondaryColor = 83;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 8)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1988.3341f, 3069.3494f, 46.972168f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("bati"), new Position(1988.3341f, 3069.3494f, 46.972168f), new Rotation(0, 0, 0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 99;
                car1.SecondaryColor = 99;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 7)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1521.9692f, 88.32527f, 56.40808f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("bati"), new Position(-1521.9692f, 88.32527f, 56.40808f), new Rotation(0, 0, -1.6821126f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 0;
                car1.SecondaryColor = 0;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 6)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1274.611f, -1586.9539f, 52.34729f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("bati"), new Position(1274.611f, -1586.9539f, 52.34729f), new Rotation(0, 0, -0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 41;
                car1.SecondaryColor = 41;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 10)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-15.2703285f, -1461.6132f, 30.610962f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("bati"), new Position(-15.2703285f, -1461.6132f, 30.610962f), new Rotation(0, 0, -1.5831648f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 44;
                car1.SecondaryColor = 44;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 3)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1374.0923f, 1123.411f, 114.20288f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("bati"), new Position(1374.0923f, 1123.411f, 114.20288f), new Rotation(0, 0, 0.44526514f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 106;
                car1.SecondaryColor = 106;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 4)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1506.4615f, 886.9187f, 182.04028f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("bati"), new Position(-1506.4615f, 886.9187f, 182.04028f), new Rotation(0, 0, -1.3357954f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 43;
                car1.SecondaryColor = 43;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 5)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1363.5165f, -578.4923f, 74.369995f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("bati"), new Position(1363.5165f, -578.4923f, 74.369995f), new Rotation(0, 0, 1.0884259f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 55;
                car1.SecondaryColor = 55;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
        }
    }

    #endregion

    #region veh2
    [ClientEvent("vehicle2")]
    public static void vehicle2(LPlayer player)
    {
        if (player.LoggedIn == false) return;

        if (player.playerlevel >= 0)
        {
            if (player.Team == 6)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1274.611f, -1586.9539f, 52.34729f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("primo2"), new Position(1274.611f, -1586.9539f, 52.34729f), new Rotation(0, 0, -0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 41;
                car1.SecondaryColor = 41;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 9)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-58.101097f, 336.76483f, 111.557495f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("primo2"), new Position(-58.101097f, 336.76483f, 111.557495f), new Rotation(0, 0, 2.6715908f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 83;
                car1.SecondaryColor = 83;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 8)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1988.3341f, 3069.3494f, 46.972168f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("primo2"), new Position(1988.3341f, 3069.3494f, 46.972168f), new Rotation(0, 0, 0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 99;
                car1.SecondaryColor = 99;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 7)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1521.9692f, 88.32527f, 56.40808f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("primo2"), new Position(-1521.9692f, 88.32527f, 56.40808f), new Rotation(0, 0, -1.6821126f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 0;
                car1.SecondaryColor = 0;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 1)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("primo2"), new Position(86.50549f, -1929.4286f, 20.686401f), new Rotation(0, 0, 0.7915824f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 148;
                car1.SecondaryColor = 148;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 2)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("primo2"), new Position(1423.1736f, 3616.1406f, 34.36853f), new Rotation(0, 0, -2.7705386f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 70;
                car1.SecondaryColor = 70;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 10)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-15.2703285f, -1461.6132f, 30.610962f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("primo2"), new Position(-15.2703285f, -1461.6132f, 30.610962f), new Rotation(0, 0, -1.5831648f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 44;
                car1.SecondaryColor = 44;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 3)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1374.0923f, 1123.411f, 114.20288f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("primo2"), new Position(1374.0923f, 1123.411f, 114.20288f), new Rotation(0, 0, 0.44526514f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 106;
                car1.SecondaryColor = 106;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 4)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1506.4615f, 886.9187f, 182.04028f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("primo2"), new Position(-1506.4615f, 886.9187f, 182.04028f), new Rotation(0, 0, -1.3357954f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 43;
                car1.SecondaryColor = 43;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 5)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1363.5165f, -578.4923f, 74.369995f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("primo2"), new Position(1363.5165f, -578.4923f, 74.369995f), new Rotation(0, 0, 1.0884259f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 55;
                car1.SecondaryColor = 55;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
        }
    }
    #endregion

    #region veh3
    [ClientEvent("vehicle3")]
    public static void vehicl32(LPlayer player)
    {
        if (player.LoggedIn == false) return;

        if (player.playerlevel >= 5)
        {
            if (player.Team == 5)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1363.5165f, -578.4923f, 74.369995f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("sultan"), new Position(1363.5165f, -578.4923f, 74.369995f), new Rotation(0, 0, 1.0884259f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 55;
                car1.SecondaryColor = 55;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 9)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-58.101097f, 336.76483f, 111.557495f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("sultan"), new Position(-58.101097f, 336.76483f, 111.557495f), new Rotation(0, 0, 2.6715908f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 83;
                car1.SecondaryColor = 83;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 8)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1988.3341f, 3069.3494f, 46.972168f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("sultan"), new Position(1988.3341f, 3069.3494f, 46.972168f), new Rotation(0, 0, 0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 99;
                car1.SecondaryColor = 99;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 7)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1521.9692f, 88.32527f, 56.40808f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("sultan"), new Position(-1521.9692f, 88.32527f, 56.40808f), new Rotation(0, 0, -1.6821126f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 0;
                car1.SecondaryColor = 0;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 6)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1274.611f, -1586.9539f, 52.34729f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("sultan"), new Position(1274.611f, -1586.9539f, 52.34729f), new Rotation(0, 0, -0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 41;
                car1.SecondaryColor = 41;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 1)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("sultan"), new Position(86.50549f, -1929.4286f, 20.686401f), new Rotation(0, 0, 0.7915824f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 148;
                car1.SecondaryColor = 148;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 2)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("sultan"), new Position(1423.1736f, 3616.1406f, 34.36853f), new Rotation(0, 0, -2.7705386f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 70;
                car1.SecondaryColor = 70;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 10)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-15.2703285f, -1461.6132f, 30.610962f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("sultan"), new Position(-15.2703285f, -1461.6132f, 30.610962f), new Rotation(0, 0, -1.5831648f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 44;
                car1.SecondaryColor = 44;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 3)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1374.0923f, 1123.411f, 114.20288f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("sultan"), new Position(1374.0923f, 1123.411f, 114.20288f), new Rotation(0, 0, 0.44526514f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 106;
                car1.SecondaryColor = 106;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 4)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1506.4615f, 886.9187f, 182.04028f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("sultan"), new Position(-1506.4615f, 886.9187f, 182.04028f), new Rotation(0, 0, -1.3357954f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 43;
                car1.SecondaryColor = 43;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
        }
    }
    #endregion

    #region veh4
    [ClientEvent("vehicle4")]
    public static void vehicl4(LPlayer player)
    {
        if (player.LoggedIn == false) return;

        if (player.playerlevel >= 5)
        {
            if (player.Team == 1)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("dominator"), new Position(86.50549f, -1929.4286f, 20.686401f), new Rotation(0, 0, 0.7915824f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 148;
                car1.SecondaryColor = 148;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 9)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-58.101097f, 336.76483f, 111.557495f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("dominator"), new Position(-58.101097f, 336.76483f, 111.557495f), new Rotation(0, 0, 2.6715908f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 83;
                car1.SecondaryColor = 83;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 8)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1988.3341f, 3069.3494f, 46.972168f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("dominator"), new Position(1988.3341f, 3069.3494f, 46.972168f), new Rotation(0, 0, 0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 99;
                car1.SecondaryColor = 99;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 7)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1521.9692f, 88.32527f, 56.40808f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("dominator"), new Position(-1521.9692f, 88.32527f, 56.40808f), new Rotation(0, 0, -1.6821126f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 0;
                car1.SecondaryColor = 0;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 6)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1274.611f, -1586.9539f, 52.34729f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("dominator"), new Position(1274.611f, -1586.9539f, 52.34729f), new Rotation(0, 0, -0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 41;
                car1.SecondaryColor = 41;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 2)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("dominator"), new Position(1423.1736f, 3616.1406f, 34.36853f), new Rotation(0, 0, -2.7705386f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 70;
                car1.SecondaryColor = 70;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 5)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1363.5165f, -578.4923f, 74.369995f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("dominator"), new Position(1363.5165f, -578.4923f, 74.369995f), new Rotation(0, 0, 1.0884259f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 55;
                car1.SecondaryColor = 55;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 10)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-15.2703285f, -1461.6132f, 30.610962f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("dominator"), new Position(-15.2703285f, -1461.6132f, 30.610962f), new Rotation(0, 0, -1.5831648f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 44;
                car1.SecondaryColor = 44;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 3)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1374.0923f, 1123.411f, 114.20288f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("dominator"), new Position(1374.0923f, 1123.411f, 114.20288f), new Rotation(0, 0, 0.44526514f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 106;
                car1.SecondaryColor = 106;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 4)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1506.4615f, 886.9187f, 182.04028f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("dominator"), new Position(-1506.4615f, 886.9187f, 182.04028f), new Rotation(0, 0, -1.3357954f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 43;
                car1.SecondaryColor = 43;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
        }
    }
    #endregion

    #region veh5
    [ClientEvent("vehicle5")]
    public static void vehicl5(LPlayer player)
    {
        if (player.LoggedIn == false) return;

        if (player.playerlevel >= 10)
        {
            if (player.Team == 1)
            {


                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("elegy"), new Position(86.50549f, -1929.4286f, 20.686401f), new Rotation(0, 0, 0.7915824f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 148;
                car1.SecondaryColor = 148;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 9)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-58.101097f, 336.76483f, 111.557495f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("elegy"), new Position(-58.101097f, 336.76483f, 111.557495f), new Rotation(0, 0, 2.6715908f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 83;
                car1.SecondaryColor = 83;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 8)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1988.3341f, 3069.3494f, 46.972168f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("elegy"), new Position(1988.3341f, 3069.3494f, 46.972168f), new Rotation(0, 0, 0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 99;
                car1.SecondaryColor = 99;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 7)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1521.9692f, 88.32527f, 56.40808f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("elegy"), new Position(-1521.9692f, 88.32527f, 56.40808f), new Rotation(0, 0, -1.6821126f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 0;
                car1.SecondaryColor = 0;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 6)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1274.611f, -1586.9539f, 52.34729f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("elegy"), new Position(1274.611f, -1586.9539f, 52.34729f), new Rotation(0, 0, -0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 41;
                car1.SecondaryColor = 41;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 2)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("elegy"), new Position(1423.1736f, 3616.1406f, 34.36853f), new Rotation(0, 0, -2.7705386f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 70;
                car1.SecondaryColor = 70;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 5)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1363.5165f, -578.4923f, 74.369995f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("elegy"), new Position(1363.5165f, -578.4923f, 74.369995f), new Rotation(0, 0, 1.0884259f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 55;
                car1.SecondaryColor = 55;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 10)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-15.2703285f, -1461.6132f, 30.610962f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("elegy"), new Position(-15.2703285f, -1461.6132f, 30.610962f), new Rotation(0, 0, -1.5831648f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 44;
                car1.SecondaryColor = 44;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 3)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1374.0923f, 1123.411f, 114.20288f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("elegy"), new Position(1374.0923f, 1123.411f, 114.20288f), new Rotation(0, 0, 0.44526514f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 106;
                car1.SecondaryColor = 106;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 4)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1506.4615f, 886.9187f, 182.04028f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("elegy"), new Position(-1506.4615f, 886.9187f, 182.04028f), new Rotation(0, 0, -1.3357954f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 43;
                car1.SecondaryColor = 43;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
        }
    }
    #endregion

    #region veh6
    [ClientEvent("vehicle6")]
    public static void vehicl6(LPlayer player)
    {
        if (player.LoggedIn == false) return;

        if (player.playerlevel >= 15)
        {
            if (player.Team == 5)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1363.5165f, -578.4923f, 74.369995f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("drafter"), new Position(1363.5165f, -578.4923f, 74.369995f), new Rotation(0, 0, 1.0884259f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 55;
                car1.SecondaryColor = 55;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 9)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-58.101097f, 336.76483f, 111.557495f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("drafter"), new Position(-58.101097f, 336.76483f, 111.557495f), new Rotation(0, 0, 2.6715908f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 83;
                car1.SecondaryColor = 83;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 8)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1988.3341f, 3069.3494f, 46.972168f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("drafter"), new Position(1988.3341f, 3069.3494f, 46.972168f), new Rotation(0, 0, 0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 99;
                car1.SecondaryColor = 99;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 7)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1521.9692f, 88.32527f, 56.40808f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("drafter"), new Position(-1521.9692f, 88.32527f, 56.40808f), new Rotation(0, 0, -1.6821126f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 0;
                car1.SecondaryColor = 0;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 6)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1274.611f, -1586.9539f, 52.34729f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("drafter"), new Position(1274.611f, -1586.9539f, 52.34729f), new Rotation(0, 0, -0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 41;
                car1.SecondaryColor = 41;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 1)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("drafter"), new Position(86.50549f, -1929.4286f, 20.686401f), new Rotation(0, 0, 0.7915824f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 148;
                car1.SecondaryColor = 148;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 2)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("drafter"), new Position(1423.1736f, 3616.1406f, 34.36853f), new Rotation(0, 0, -2.7705386f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 70;
                car1.SecondaryColor = 70;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 10)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-15.2703285f, -1461.6132f, 30.610962f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("drafter"), new Position(-15.2703285f, -1461.6132f, 30.610962f), new Rotation(0, 0, -1.5831648f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 44;
                car1.SecondaryColor = 44;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 3)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1374.0923f, 1123.411f, 114.20288f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("drafter"), new Position(1374.0923f, 1123.411f, 114.20288f), new Rotation(0, 0, 0.44526514f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 106;
                car1.SecondaryColor = 106;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 4)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1506.4615f, 886.9187f, 182.04028f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("drafter"), new Position(-1506.4615f, 886.9187f, 182.04028f), new Rotation(0, 0, -1.3357954f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 43;
                car1.SecondaryColor = 43;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
        }
    }
    #endregion

    #region veh7
    [ClientEvent("vehicle7")]
    public static void vehicl7(LPlayer player)
    {
        if (player.LoggedIn == false) return;

        if (player.playerlevel >= 15)
        {
            if (player.Team == 1)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("jugular"), new Position(86.50549f, -1929.4286f, 20.686401f), new Rotation(0, 0, 0.7915824f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 148;
                car1.SecondaryColor = 148;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 9)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-58.101097f, 336.76483f, 111.557495f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("jugular"), new Position(-58.101097f, 336.76483f, 111.557495f), new Rotation(0, 0, 2.6715908f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 83;
                car1.SecondaryColor = 83;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 8)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1988.3341f, 3069.3494f, 46.972168f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("jugular"), new Position(1988.3341f, 3069.3494f, 46.972168f), new Rotation(0, 0, 0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 99;
                car1.SecondaryColor = 99;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 7)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1521.9692f, 88.32527f, 56.40808f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("jugular"), new Position(-1521.9692f, 88.32527f, 56.40808f), new Rotation(0, 0, -1.6821126f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 0;
                car1.SecondaryColor = 0;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 6)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1274.611f, -1586.9539f, 52.34729f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("jugular"), new Position(1274.611f, -1586.9539f, 52.34729f), new Rotation(0, 0, -0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 41;
                car1.SecondaryColor = 41;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 5)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1363.5165f, -578.4923f, 74.369995f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("jugular"), new Position(1363.5165f, -578.4923f, 74.369995f), new Rotation(0, 0, 1.0884259f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 55;
                car1.SecondaryColor = 55;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 2)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("jugular"), new Position(1423.1736f, 3616.1406f, 34.36853f), new Rotation(0, 0, -2.7705386f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 70;
                car1.SecondaryColor = 70;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 10)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-15.2703285f, -1461.6132f, 30.610962f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("jugular"), new Position(-15.2703285f, -1461.6132f, 30.610962f), new Rotation(0, 0, -1.5831648f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 44;
                car1.SecondaryColor = 44;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 3)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1374.0923f, 1123.411f, 114.20288f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("jugular"), new Position(1374.0923f, 1123.411f, 114.20288f), new Rotation(0, 0, 0.44526514f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 106;
                car1.SecondaryColor = 106;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 4)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1506.4615f, 886.9187f, 182.04028f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("jugular"), new Position(-1506.4615f, 886.9187f, 182.04028f), new Rotation(0, 0, -1.3357954f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 43;
                car1.SecondaryColor = 43;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
        }
    }

    #endregion

    #region veh8
    [ClientEvent("vehicle8")]
    public static void vehicl8(LPlayer player)
    {
        if (player.LoggedIn == false) return;

        if (player.playerlevel >= 25)
        {
            if (player.Team == 1)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("iwagen"), new Position(86.50549f, -1929.4286f, 20.686401f), new Rotation(0, 0, 0.7915824f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 148;
                car1.SecondaryColor = 148;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 9)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-58.101097f, 336.76483f, 111.557495f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("iwagen"), new Position(-58.101097f, 336.76483f, 111.557495f), new Rotation(0, 0, 2.6715908f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 83;
                car1.SecondaryColor = 83;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 8)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1988.3341f, 3069.3494f, 46.972168f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("iwagen"), new Position(1988.3341f, 3069.3494f, 46.972168f), new Rotation(0, 0, 0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 99;
                car1.SecondaryColor = 99;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 7)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1521.9692f, 88.32527f, 56.40808f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("iwagen"), new Position(-1521.9692f, 88.32527f, 56.40808f), new Rotation(0, 0, -1.6821126f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 0;
                car1.SecondaryColor = 0;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 6)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1274.611f, -1586.9539f, 52.34729f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("iwagen"), new Position(1274.611f, -1586.9539f, 52.34729f), new Rotation(0, 0, -0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 41;
                car1.SecondaryColor = 41;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 2)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("iwagen"), new Position(1423.1736f, 3616.1406f, 34.36853f), new Rotation(0, 0, -2.7705386f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 70;
                car1.SecondaryColor = 70;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 5)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1363.5165f, -578.4923f, 74.369995f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("iwagen"), new Position(1363.5165f, -578.4923f, 74.369995f), new Rotation(0, 0, 1.0884259f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 55;
                car1.SecondaryColor = 55;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 10)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-15.2703285f, -1461.6132f, 30.610962f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("iwagen"), new Position(-15.2703285f, -1461.6132f, 30.610962f), new Rotation(0, 0, -1.5831648f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 44;
                car1.SecondaryColor = 44;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 3)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1374.0923f, 1123.411f, 114.20288f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("iwagen"), new Position(1374.0923f, 1123.411f, 114.20288f), new Rotation(0, 0, 0.44526514f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 106;
                car1.SecondaryColor = 106;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 4)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1506.4615f, 886.9187f, 182.04028f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("iwagen"), new Position(-1506.4615f, 886.9187f, 182.04028f), new Rotation(0, 0, -1.3357954f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 43;
                car1.SecondaryColor = 43;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
        }
    }
    #endregion

    #region veh9
    [ClientEvent("vehicle9")]
    public static void vehicl9(LPlayer player)
    {
        if (player.LoggedIn == false) return;

        if (player.playerlevel >= 25)
        {
            if (player.Team == 1)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("omnisegt"), new Position(86.50549f, -1929.4286f, 20.686401f), new Rotation(0, 0, 0.7915824f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 148;
                car1.SecondaryColor = 148;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 9)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-58.101097f, 336.76483f, 111.557495f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("omnisegt"), new Position(-58.101097f, 336.76483f, 111.557495f), new Rotation(0, 0, 2.6715908f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 83;
                car1.SecondaryColor = 83;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 8)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1988.3341f, 3069.3494f, 46.972168f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("omnisegt"), new Position(1988.3341f, 3069.3494f, 46.972168f), new Rotation(0, 0, 0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 99;
                car1.SecondaryColor = 99;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 7)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1521.9692f, 88.32527f, 56.40808f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("omnisegt"), new Position(-1521.9692f, 88.32527f, 56.40808f), new Rotation(0, 0, -1.6821126f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 0;
                car1.SecondaryColor = 0;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 6)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1274.611f, -1586.9539f, 52.34729f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("omnisegt"), new Position(1274.611f, -1586.9539f, 52.34729f), new Rotation(0, 0, -0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 41;
                car1.SecondaryColor = 41;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 2)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("omnisegt"), new Position(1423.1736f, 3616.1406f, 34.36853f), new Rotation(0, 0, -2.7705386f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 70;
                car1.SecondaryColor = 70;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 5)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1363.5165f, -578.4923f, 74.369995f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("omnisegt"), new Position(1363.5165f, -578.4923f, 74.369995f), new Rotation(0, 0, 1.0884259f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 55;
                car1.SecondaryColor = 55;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 10)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-15.2703285f, -1461.6132f, 30.610962f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("omnisegt"), new Position(-15.2703285f, -1461.6132f, 30.610962f), new Rotation(0, 0, -1.5831648f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 44;
                car1.SecondaryColor = 44;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 3)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1374.0923f, 1123.411f, 114.20288f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("omnisegt"), new Position(1374.0923f, 1123.411f, 114.20288f), new Rotation(0, 0, 0.44526514f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 106;
                car1.SecondaryColor = 106;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 4)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1506.4615f, 886.9187f, 182.04028f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("omnisegt"), new Position(-1506.4615f, 886.9187f, 182.04028f), new Rotation(0, 0, -1.3357954f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 43;
                car1.SecondaryColor = 43;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
        }
    }
    #endregion

    #region veh10
    [ClientEvent("vehicle10")]
    public static void vehicl10(LPlayer player)
    {
        if (player.LoggedIn == false) return;

        if (player.playerlevel >= 30)
        {
            if (player.Team == 1)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("cyclone"), new Position(86.50549f, -1929.4286f, 20.686401f), new Rotation(0, 0, 0.7915824f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 148;
                car1.SecondaryColor = 148;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 9)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-58.101097f, 336.76483f, 111.557495f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("cyclone"), new Position(-58.101097f, 336.76483f, 111.557495f), new Rotation(0, 0, 2.6715908f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 83;
                car1.SecondaryColor = 83;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 8)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1988.3341f, 3069.3494f, 46.972168f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("cyclone"), new Position(1988.3341f, 3069.3494f, 46.972168f), new Rotation(0, 0, 0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 99;
                car1.SecondaryColor = 99;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 7)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1521.9692f, 88.32527f, 56.40808f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("cyclone"), new Position(-1521.9692f, 88.32527f, 56.40808f), new Rotation(0, 0, -1.6821126f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 0;
                car1.SecondaryColor = 0;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 6)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1274.611f, -1586.9539f, 52.34729f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("cyclone"), new Position(1274.611f, -1586.9539f, 52.34729f), new Rotation(0, 0, -0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 41;
                car1.SecondaryColor = 41;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 5)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1363.5165f, -578.4923f, 74.369995f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("cyclone"), new Position(1363.5165f, -578.4923f, 74.369995f), new Rotation(0, 0, 1.0884259f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 55;
                car1.SecondaryColor = 55;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 2)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("cyclone"), new Position(1423.1736f, 3616.1406f, 34.36853f), new Rotation(0, 0, -2.7705386f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 70;
                car1.SecondaryColor = 70;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 10)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-15.2703285f, -1461.6132f, 30.610962f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("cyclone"), new Position(-15.2703285f, -1461.6132f, 30.610962f), new Rotation(0, 0, -1.5831648f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 44;
                car1.SecondaryColor = 44;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 3)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1374.0923f, 1123.411f, 114.20288f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("cyclone"), new Position(1374.0923f, 1123.411f, 114.20288f), new Rotation(0, 0, 0.44526514f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 106;
                car1.SecondaryColor = 106;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 4)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1506.4615f, 886.9187f, 182.04028f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("cyclone"), new Position(-1506.4615f, 886.9187f, 182.04028f), new Rotation(0, 0, -1.3357954f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 43;
                car1.SecondaryColor = 43;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
        }
    }
    #endregion

    #region veh11
    [ClientEvent("vehicle11")]
    public static void vehicl11(LPlayer player)
    {
        if (player.LoggedIn == false) return;

        if (player.playerlevel >= 35)
        {
            if (player.Team == 1)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("emerus"), new Position(86.50549f, -1929.4286f, 20.686401f), new Rotation(0, 0, 0.7915824f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 148;
                car1.SecondaryColor = 148;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 9)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-58.101097f, 336.76483f, 111.557495f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("emerus"), new Position(-58.101097f, 336.76483f, 111.557495f), new Rotation(0, 0, 2.6715908f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 83;
                car1.SecondaryColor = 83;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 8)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1988.3341f, 3069.3494f, 46.972168f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("emerus"), new Position(1988.3341f, 3069.3494f, 46.972168f), new Rotation(0, 0, 0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 99;
                car1.SecondaryColor = 99;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 7)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1521.9692f, 88.32527f, 56.40808f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("emerus"), new Position(-1521.9692f, 88.32527f, 56.40808f), new Rotation(0, 0, -1.6821126f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 0;
                car1.SecondaryColor = 0;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 6)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1274.611f, -1586.9539f, 52.34729f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("emerus"), new Position(1274.611f, -1586.9539f, 52.34729f), new Rotation(0, 0, -0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 41;
                car1.SecondaryColor = 41;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 5)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1363.5165f, -578.4923f, 74.369995f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("emerus"), new Position(1363.5165f, -578.4923f, 74.369995f), new Rotation(0, 0, 1.0884259f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 55;
                car1.SecondaryColor = 55;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 2)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("emerus"), new Position(1423.1736f, 3616.1406f, 34.36853f), new Rotation(0, 0, -2.7705386f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 70;
                car1.SecondaryColor = 70;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 10)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-15.2703285f, -1461.6132f, 30.610962f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("emerus"), new Position(-15.2703285f, -1461.6132f, 30.610962f), new Rotation(0, 0, -1.5831648f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 44;
                car1.SecondaryColor = 44;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 3)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1374.0923f, 1123.411f, 114.20288f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("emerus"), new Position(1374.0923f, 1123.411f, 114.20288f), new Rotation(0, 0, 0.44526514f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 106;
                car1.SecondaryColor = 106;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 4)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1506.4615f, 886.9187f, 182.04028f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("emerus"), new Position(-1506.4615f, 886.9187f, 182.04028f), new Rotation(0, 0, -1.3357954f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 43;
                car1.SecondaryColor = 43;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
        }
    }
    #endregion

    #region veh12
    [ClientEvent("vehicle12")]
    public static void vehicl12(LPlayer player)
    {
        if (player.LoggedIn == false) return;

        if (player.AdminLevel >= 1)
        {
            if (player.Team == 1)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("rumpo3"), new Position(86.50549f, -1929.4286f, 20.686401f), new Rotation(0, 0, 0.7915824f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 148;
                car1.SecondaryColor = 148;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 9)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-58.101097f, 336.76483f, 111.557495f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("rumpo3"), new Position(-58.101097f, 336.76483f, 111.557495f), new Rotation(0, 0, 2.6715908f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 83;
                car1.SecondaryColor = 83;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 8)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1988.3341f, 3069.3494f, 46.972168f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("rumpo3"), new Position(1988.3341f, 3069.3494f, 46.972168f), new Rotation(0, 0, 0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 99;
                car1.SecondaryColor = 99;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 7)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1521.9692f, 88.32527f, 56.40808f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("rumpo3"), new Position(-1521.9692f, 88.32527f, 56.40808f), new Rotation(0, 0, -1.6821126f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 0;
                car1.SecondaryColor = 0;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 6)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1274.611f, -1586.9539f, 52.34729f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("rumpo3"), new Position(1274.611f, -1586.9539f, 52.34729f), new Rotation(0, 0, -0.98947805f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 41;
                car1.SecondaryColor = 41;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 5)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1363.5165f, -578.4923f, 74.369995f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("rumpo3"), new Position(1363.5165f, -578.4923f, 74.369995f), new Rotation(0, 0, 1.0884259f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 55;
                car1.SecondaryColor = 55;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 2)
            {

                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("rumpo3"), new Position(1423.1736f, 3616.1406f, 34.36853f), new Rotation(0, 0, -2.7705386f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 70;
                car1.SecondaryColor = 70;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);

            }
            if (player.Team == 10)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-15.2703285f, -1461.6132f, 30.610962f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("rumpo3"), new Position(-15.2703285f, -1461.6132f, 30.610962f), new Rotation(0, 0, -1.5831648f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 44;
                car1.SecondaryColor = 44;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 3)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(1374.0923f, 1123.411f, 114.20288f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("rumpo3"), new Position(1374.0923f, 1123.411f, 114.20288f), new Rotation(0, 0, 0.44526514f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 106;
                car1.SecondaryColor = 106;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
            if (player.Team == 4)
            {
                foreach (LVehicle veh3 in Alt.GetAllVehicles())
                {
                    if (veh3.Position.Distance(new Position(-1506.4615f, 886.9187f, 182.04028f)) < 5f)
                    {
                        player.SendNotification("4", "", $"Der Ausparkpunkt ist aktuell bereits vergeben.", 6);
                        return;
                    }
                }
                LVehicle car1 = (LVehicle)Alt.CreateVehicle(Alt.Hash("rumpo3"), new Position(-1506.4615f, 886.9187f, 182.04028f), new Rotation(0, 0, -1.3357954f));
                player.SetIntoVehicle(car1, 1);
                car1.NumberplateText = player.AccountName;
                car1.PrimaryColor = 43;
                car1.SecondaryColor = 43;
                car1.PearlColor = 0;
                car1.SetData("hasveh", player.AccountName);
            }
        }
    }
    #endregion
}