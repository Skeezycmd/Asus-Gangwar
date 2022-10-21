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

public class AdminHandler : IScript
{


    [ClientEvent("NoClip")]
    public void Noclip(LPlayer player)
    {
        if (player.AdminLevel >= 1)
        { 
                if (player.Visible == false)
                {
                    player.Visible = true;
                }
                else
                {
                    player.Visible = false;
                }
                player.Emit("ToggleNoClip");
            
        }
    }

    [ClientEvent("Keypress:F6")]
    public void KeypressF6(LPlayer player)
    {
        if (player.AdminLevel != 0)
        {
            if (player.AdminDienst == false)
            {
                player.Emit("openAdminWindow");
                player.SetSyncedMetaData("ADUTY", true);
                player.Emit("nametags", true);
                player.AdminDienst = true;
                player.Invincible = true;

                int AdminLevel = player.AdminLevel;
                if (AdminLevel == 1)
                {
                    if (player.Model == (uint)PedModel.FreemodeMale01)
                    {
                        player.SetClothes(1, 135, 0, 0);
                        player.SetClothes(11, 287, 0, 0);
                        player.SetClothes(3, 3, 0, 0);
                        player.SetClothes(8, 15, 0, 0);
                        player.SetClothes(4, 114, 0, 0);
                        player.SetClothes(6, 78, 0, 0);
                    }
                    else
                    {
                        player.SetClothes(1, 135, 0, 0);
                        player.SetClothes(11, 300, 0, 0);
                        player.SetClothes(3, 10, 0, 0);
                        player.SetClothes(8, 14, 0, 0);
                        player.SetClothes(4, 121, 0, 0);
                        player.SetClothes(6, 82, 0, 0);
                    }
                }

                if (AdminLevel == 2)
                {
                    if (player.Model == (uint)PedModel.FreemodeMale01)
                    {
                        player.SetClothes(1, 135, 5, 0);
                        player.SetClothes(11, 287, 5, 0);
                        player.SetClothes(3, 3, 0, 0);
                        player.SetClothes(8, 15, 5, 0);
                        player.SetClothes(4, 114, 5, 0);
                        player.SetClothes(6, 78, 5, 0);


                    }
                    else
                    {
                        player.SetClothes(1, 135, 5, 0);
                        player.SetClothes(11, 300, 5, 0);
                        player.SetClothes(3, 10, 0, 0);
                        player.SetClothes(8, 14, 5, 0);
                        player.SetClothes(4, 121, 5, 0);
                        player.SetClothes(6, 82, 5, 0);
                    }
                }
                if (AdminLevel == 3)
                {
                    if (player.Model == (uint)PedModel.FreemodeMale01)
                    {
                        player.SetClothes(1, 135, 4, 0);
                        player.SetClothes(11, 287, 4, 0);
                        player.SetClothes(3, 3, 0, 0);
                        player.SetClothes(8, 15, 4, 0);
                        player.SetClothes(4, 114, 4, 0);
                        player.SetClothes(6, 78, 4, 0);


                    }
                    else
                    {
                        player.SetClothes(1, 135, 4, 0);
                        player.SetClothes(11, 300, 4, 0);
                        player.SetClothes(3, 10, 0, 0);
                        player.SetClothes(8, 14, 4, 0);
                        player.SetClothes(4, 121, 4, 0);
                        player.SetClothes(6, 82, 4, 0);
                    }
                }
                if (AdminLevel == 4)
                {
                    if (player.Model == (uint)PedModel.FreemodeMale01)
                    {
                        player.SetClothes(1, 135, 4, 0);
                        player.SetClothes(11, 287, 4, 0);
                        player.SetClothes(3, 3, 0, 0);
                        player.SetClothes(8, 15, 4, 0);
                        player.SetClothes(4, 114, 4, 0);
                        player.SetClothes(6, 78, 4, 0);


                    }
                    else
                    {
                        player.SetClothes(1, 135, 4, 0);
                        player.SetClothes(11, 300, 4, 0);
                        player.SetClothes(3, 10, 0, 0);
                        player.SetClothes(8, 14, 4, 0);
                        player.SetClothes(4, 121, 4, 0);
                        player.SetClothes(6, 82, 4, 0);
                    }
                }
                if (AdminLevel == 5)
                {
                    if (player.Model == (uint)PedModel.FreemodeMale01)
                    {
                        player.SetClothes(1, 135, 7, 0);
                        player.SetClothes(11, 287, 7, 0);
                        player.SetClothes(3, 3, 0, 0);
                        player.SetClothes(8, 15, 7, 0);
                        player.SetClothes(4, 114, 7, 0);
                        player.SetClothes(6, 78, 7, 0);


                    }
                    else
                    {
                        player.SetClothes(1, 135, 7, 0);
                        player.SetClothes(11, 300, 7, 0);
                        player.SetClothes(3, 10, 0, 0);
                        player.SetClothes(8, 14, 7, 0);
                        player.SetClothes(4, 121, 7, 0);
                        player.SetClothes(6, 82, 7, 0);
                    }
                }
                if (AdminLevel == 6)
                {
                    if (player.Model == (uint)PedModel.FreemodeMale01)
                    {
                        player.SetClothes(1, 135, 3, 0);
                        player.SetClothes(11, 287, 3, 0);
                        player.SetClothes(3, 3, 0, 0);
                        player.SetClothes(8, 15, 3, 0);
                        player.SetClothes(4, 114, 3, 0);
                        player.SetClothes(6, 78, 3, 0);


                    }
                    else
                    {
                        player.SetClothes(1, 135, 3, 0);
                        player.SetClothes(11, 300, 3, 0);
                        player.SetClothes(3, 10, 0, 0);
                        player.SetClothes(8, 14, 3, 0);
                        player.SetClothes(4, 121, 3, 0);
                        player.SetClothes(6, 82, 3, 0);
                    }
                }
                if (AdminLevel == 7)
                {
                    if (player.Model == (uint)PedModel.FreemodeMale01)
                    {
                        player.SetClothes(1, 135, 12, 0);
                        player.SetClothes(11, 287, 12, 0);
                        player.SetClothes(3, 3, 0, 0);
                        player.SetClothes(8, 15, 12, 0);
                        player.SetClothes(4, 114, 12, 0);
                        player.SetClothes(6, 78, 12, 0);


                    }
                    else
                    {
                        player.SetClothes(1, 135, 12, 0);
                        player.SetClothes(11, 300, 12, 0);
                        player.SetClothes(3, 10, 0, 0);
                        player.SetClothes(8, 14, 12, 0);
                        player.SetClothes(4, 121, 12, 0);
                        player.SetClothes(6, 82, 12, 0);
                    }
                }
                if (AdminLevel == 8)
                {
                    if (player.Model == (uint)PedModel.FreemodeMale01)
                    {
                        player.SetClothes(1, 135, 7, 0);
                        player.SetClothes(11, 287, 7, 0);
                        player.SetClothes(3, 3, 0, 0);
                        player.SetClothes(8, 15, 7, 0);
                        player.SetClothes(4, 114, 7, 0);
                        player.SetClothes(6, 78, 7, 0);


                    }
                    else
                    {
                        player.SetClothes(1, 135, 7, 0);
                        player.SetClothes(11, 300, 7, 0);
                        player.SetClothes(3, 10, 0, 0);
                        player.SetClothes(8, 14, 7, 0);
                        player.SetClothes(4, 121, 7, 0);
                        player.SetClothes(6, 82, 7, 0);
                    }
                }
                if (AdminLevel == 9)
                {
                    if (player.Model == (uint)PedModel.FreemodeMale01)
                    {
                        player.SetClothes(1, 135, 2, 0);
                        player.SetClothes(11, 287, 2, 0);
                        player.SetClothes(3, 3, 0, 0);
                        player.SetClothes(8, 15, 2, 0);
                        player.SetClothes(4, 114, 2, 0);
                        player.SetClothes(6, 78, 2, 0);


                    }
                    else
                    {
                        player.SetClothes(1, 135, 2, 0);
                        player.SetClothes(11, 300, 2, 0);
                        player.SetClothes(3, 10, 0, 0);
                        player.SetClothes(8, 14, 2, 0);
                        player.SetClothes(4, 121, 2, 0);
                        player.SetClothes(6, 82, 2, 0);
                    }
                }
                if (AdminLevel == 10)
                {
                    if (player.Model == (uint)PedModel.FreemodeMale01)
                    {
                        player.SetClothes(1, 135, 2, 0);
                        player.SetClothes(11, 287, 2, 0);
                        player.SetClothes(3, 3, 0, 0);
                        player.SetClothes(8, 15, 2, 0);
                        player.SetClothes(4, 114, 2, 0);
                        player.SetClothes(6, 78, 2, 0);


                    }
                    else
                    {
                        player.SetClothes(1, 135, 2, 0);
                        player.SetClothes(11, 300, 2, 0);
                        player.SetClothes(3, 10, 0, 0);
                        player.SetClothes(8, 14, 2, 0);
                        player.SetClothes(4, 121, 2, 0);
                        player.SetClothes(6, 82, 2, 0);
                    }
                }
            }
            else
            {
                player.Emit("closeAdminWindow");
                player.SetSyncedMetaData("ADUTY", false);
                player.Emit("nametags", false);
                player.AdminDienst = false;
                player.Invincible = false;
                if (player.Team == 1)
                {
                    Teamauswahl.teamSelectedTeam1(player);
                    player.Position = player.Position;
                    player.Dimension = player.Dimension;
                    return;
                }

                if (player.Team == 2)
                {
                    Teamauswahl.teamSelectedTeam2(player);
                    player.Position = player.Position;
                    player.Dimension = player.Dimension;
                    return;
                }
                if (player.Team == 3)
                {
                    Teamauswahl.teamSelectedTeam3(player);
                    player.Position = player.Position;
                    player.Dimension = player.Dimension;
                    return;
                }
                if (player.Team == 4)
                {
                    Teamauswahl.teamSelectedTeam4(player);
                    player.Position = player.Position;
                    player.Dimension = player.Dimension;
                    return;
                }
                if (player.Team == 5)
                {
                    Teamauswahl.teamSelectedTeam5(player);
                    player.Position = player.Position;
                    player.Dimension = player.Dimension;
                    return;
                }
                if (player.Team == 6)
                {
                    Teamauswahl.teamSelectedTeam6(player);
                    player.Position = player.Position;
                    player.Dimension = player.Dimension;
                    return;
                }
                if (player.Team == 7)
                {
                    Teamauswahl.teamSelectedTeam7(player);
                    player.Position = player.Position;
                    player.Dimension = player.Dimension;
                    return;
                }
                if (player.Team == 8)
                {
                    Teamauswahl.teamSelectedTeam8(player);
                    player.Position = player.Position;
                    player.Dimension = player.Dimension;
                    return;
                }
                if (player.Team == 9)
                {
                    Teamauswahl.teamSelectedTeam9(player);
                    player.Position = player.Position;
                    player.Dimension = player.Dimension;
                    return;
                }
                if (player.Team == 10)
                {
                    Teamauswahl.teamSelectedTeam10(player);
                    player.Position = player.Position;
                    player.Dimension = player.Dimension;
                    return;
                }
            }
        }
    }
}
