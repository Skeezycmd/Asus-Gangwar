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


public class Teamauswahl : IScript
{
    public static int Team1Count { get; set; }
    public static int Team2Count { get; set; }
    public static int Team3Count { get; set; }
    public static int Team4Count { get; set; }
    public static int Team5Count { get; set; }
    public static int Team6Count { get; set; }
    public static int Team7Count { get; set; }
    public static int Team8Count { get; set; }
    public static int Team9Count { get; set; }
    public static int Team10Count { get; set; }
    public static void updateTeamCounter(LPlayer player)
    {
        Team1Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.Team == 1).Count();
        Team2Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.Team == 2).Count();
        Team3Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.Team == 3).Count();
        Team4Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.Team == 4).Count();
        Team5Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.Team == 5).Count();
        Team6Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.Team == 6).Count();
        Team7Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.Team == 7).Count();
        Team8Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.Team == 8).Count();
        Team9Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.Team == 9).Count();
        Team10Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.Team == 10).Count();

        player.Emit("updateTeamCount", Team1Count, Team2Count, Team3Count, Team4Count, Team5Count, Team6Count, Team7Count, Team8Count, Team9Count, Team10Count);
    }

    [ClientEvent("closeteamauswahl")]
    public void closeteamauswahl(LPlayer player)
    {
        player.openCef = false;
        player.Frozen = false;
        player.Visible = true;
        player.Emit("openHud");
        player.Emit("ToggleAn");
        Playerstuff.updateKills(player, player.Kills);
        Playerstuff.updateDeaths(player, player.Deaths);
        Playerstuff.updateKd(player, player.Kills, player.Deaths);
        if (Waffenladen.hasPlayerSpeziSchalli(player) == true)
        {
            Waffenladen.SetPlayerComps(player, 3, 1);
        }
        if (Waffenladen.hasPlayerSpeziGriff(player) == true)
        {
            Waffenladen.SetPlayerComps(player, 3, 3);
        }
        if (Waffenladen.hasPlayerSpeziVisier(player) == true)
        {
            Waffenladen.SetPlayerComps(player, 3, 2);
        }
        if (Waffenladen.hasPlayerBulliSchalli(player) == true)
        {
            Waffenladen.SetPlayerComps(player, 2, 1);
        }
        if (Waffenladen.hasPlayerBulliVisier(player) == true)
        {
            Waffenladen.SetPlayerComps(player, 2, 2);
        }
        if (Waffenladen.hasPlayerBulliGriff(player) == true)
        {
            Waffenladen.SetPlayerComps(player, 2, 3);
        }
        if (Waffenladen.hasPlayerAdvSchalli(player) == true)
        {
            Waffenladen.SetPlayerComps(player, 1, 1);
        }
        if (Waffenladen.hasPlayerAdvVisier(player) == true)
        {
            Waffenladen.SetPlayerComps(player, 1, 2);
        }
        if (Waffenladen.hasPlayerAdvLicht(player) == true)
        {
            Waffenladen.SetPlayerComps(player, 1, 3);
        }

    }

    [ClientEvent("teamSelectedTeam1")]
    public static void teamSelectedTeam1(LPlayer player)
    {
        player.Team = 1;
        player.SetClothes(1, 118, 2, 0);
        player.SetClothes(4, 5, 9, 0);
        player.SetClothes(11, 111, 3, 0);
        player.SetClothes(8, 15, 0, 0);
        player.SetClothes(6, 34, 0, 0);
        player.SetClothes(3, 4, 0, 0);
        player.SetClothes(9, 16, 2, 0);
        player.SetProps(0, 3, 1);
        player.Position = new Position(84.64616f, -1958.3737f, 21.107666f);
        player.Rotation = new Rotation(0, 0, -0.64316076f);
        player.Spawn(new Position(84.64616f, -1958.3737f, 21.107666f), 0);
        player.Health = 200;
        player.Armor = 100;

        player.GiveWeapon(Alt.Hash("weapon_specialcarbine_mk2"), 1000, false);
        player.GiveWeapon((uint)WeaponModel.BullpupRifleMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AdvancedRifle, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GusenbergSweeper, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AssaultSMG, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PistolMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.Pistol50, 1000, false);
        player.GiveWeapon((uint)WeaponModel.HeavyPistol, 1000, false);
        player.GiveWeapon((uint)WeaponModel.BaseballBat, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PoolCue, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GolfClub, 1000, false);
    }

    [ClientEvent("teamSelectedTeam2")]
    public static void teamSelectedTeam2(LPlayer player)
    {
        player.Team = 2;
        player.SetClothes(1, 54, 0, 0);
        player.SetClothes(4, 5, 3, 0);
        player.SetClothes(11, 134, 2, 0);
        player.SetClothes(8, 15, 0, 0);
        player.SetClothes(6, 34, 0, 0);
        player.SetClothes(3, 1, 0, 0);
        player.SetClothes(9, 16, 2, 0);
        player.SetProps(0, 12, 0);
        player.Position = new Position(1415.4989f, 3633.2966f, 34.654907f);
        player.Spawn(new Position(1415.4989f, 3633.2966f, 34.654907f), 0);
        player.Rotation = new Rotation(0, 0, -2.8694863f);
        player.Health = 200;
        player.Armor = 100;

        player.GiveWeapon(Alt.Hash("weapon_specialcarbine_mk2"), 1000, false);
        player.GiveWeapon((uint)WeaponModel.BullpupRifleMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AdvancedRifle, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GusenbergSweeper, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AssaultSMG, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PistolMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.Pistol50, 1000, false);
        player.GiveWeapon((uint)WeaponModel.HeavyPistol, 1000, false);
        player.GiveWeapon((uint)WeaponModel.BaseballBat, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PoolCue, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GolfClub, 1000, false);
    }

    [ClientEvent("teamSelectedTeam3")]
    public static void teamSelectedTeam3(LPlayer player)
    {
        player.Team = 3;
        player.SetClothes(1, 118, 0, 0); // Maske
        player.SetClothes(4, 49, 4, 0); //Hose
        player.SetClothes(11, 305, 7, 0); // Oberteil
        player.SetClothes(8, 15, 0, 0); // Undershirt
        player.SetClothes(6, 34, 0, 0); // Schuhe
        player.SetClothes(3, 12, 0, 0); //Torso
        player.SetClothes(9, 16, 2, 0); // weste
        player.SetProps(0, 11, 0); // Hut
        player.Position = new Position(1392.422f, 1141.7274f, 114.43884f);
        player.Spawn(new Position(1392.422f, 1141.7274f, 114.43884f), 0);
        player.Rotation = new Rotation(0, 0, 1.5336909f);
        player.Health = 200;
        player.Armor = 100;

        player.GiveWeapon(Alt.Hash("weapon_specialcarbine_mk2"), 1000, false);
        player.GiveWeapon((uint)WeaponModel.BullpupRifleMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AdvancedRifle, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GusenbergSweeper, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AssaultSMG, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PistolMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.Pistol50, 1000, false);
        player.GiveWeapon((uint)WeaponModel.HeavyPistol, 1000, false);
        player.GiveWeapon((uint)WeaponModel.BaseballBat, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PoolCue, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GolfClub, 1000, false);
    }

    [ClientEvent("teamSelectedTeam4")]
    public static void teamSelectedTeam4(LPlayer player)
    {
        player.Team = 4;
        player.SetClothes(1, 111, 5, 0); // Maske
        player.SetClothes(4, 24, 4, 0); //Hose
        player.SetClothes(11, 134, 1, 0); // Oberteil
        player.SetClothes(8, 15, 0, 0); // Undershirt
        player.SetClothes(6, 34, 0, 0); // Schuhe
        player.SetClothes(3, 4, 0, 0); //Torso
        player.SetClothes(9, 16, 2, 0); // weste
        player.SetProps(0, 11, 0); // Hut
        player.Position = new Position(-1521.4286f, 853.1868f, 181.58533f);
        player.Spawn(new Position(-1521.4286f, 853.1868f, 181.58533f), 0);
        player.Rotation = new Rotation(0, 0, 0.44526514f);
        player.Health = 200;
        player.Armor = 100;

        player.GiveWeapon(Alt.Hash("weapon_specialcarbine_mk2"), 1000, false);
        player.GiveWeapon((uint)WeaponModel.BullpupRifleMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AdvancedRifle, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GusenbergSweeper, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AssaultSMG, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PistolMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.Pistol50, 1000, false);
        player.GiveWeapon((uint)WeaponModel.HeavyPistol, 1000, false);
        player.GiveWeapon((uint)WeaponModel.BaseballBat, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PoolCue, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GolfClub, 1000, false);
    }

    [ClientEvent("teamSelectedTeam5")]
    public static void teamSelectedTeam5(LPlayer player)
    {
        player.Team = 5;
        player.SetClothes(1, 118, 0, 0); // Maske
        player.SetClothes(4, 5, 6, 0); //Hose
        player.SetClothes(11, 305, 7, 0); // Oberteil
        player.SetClothes(8, 15, 0, 0); // Undershirt
        player.SetClothes(6, 6, 0, 0); // Schuhe
        player.SetClothes(3, 4, 0, 0); //Torso
        player.SetClothes(9, 16, 2, 0); // weste
        player.SetProps(0, 11, 0); // Hut
        player.Position = new Position(1382.7693f, -590.53186f, 74.3363f);
        player.Spawn(new Position(1382.7693f, -590.53186f, 74.3363f), 0);
        player.Rotation = new Rotation(0, 0, 0.8905303f);
        player.Health = 200;
        player.Armor = 100;

        player.GiveWeapon(Alt.Hash("weapon_specialcarbine_mk2"), 1000, false);
        player.GiveWeapon((uint)WeaponModel.BullpupRifleMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AdvancedRifle, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GusenbergSweeper, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AssaultSMG, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PistolMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.Pistol50, 1000, false);
        player.GiveWeapon((uint)WeaponModel.HeavyPistol, 1000, false);
        player.GiveWeapon((uint)WeaponModel.BaseballBat, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PoolCue, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GolfClub, 1000, false);
    }

    [ClientEvent("teamSelectedTeam6")]
    public static void teamSelectedTeam6(LPlayer player)
    {
        player.Team = 6;
        player.SetClothes(1, 118, 1, 0); // Maske
        player.SetClothes(4, 5, 7, 0); //Hose
        player.SetClothes(11, 96, 0, 0); // Oberteil
        player.SetClothes(8, 15, 0, 0); // Undershirt
        player.SetClothes(6, 34, 0, 0); // Schuhe
        player.SetClothes(3, 4, 0, 0); //Torso
        player.SetClothes(9, 16, 2, 0); // weste
        player.SetProps(0, 11, 0); // Hut
        player.Position = new Position(1286.5319f, -1603.5692f, 54.82422f);
        player.Spawn(new Position(1286.5319f, -1603.5692f, 54.82422f), 0);
        player.Rotation = new Rotation(0, 0, 0.24736951f);
        player.Health = 200;
        player.Armor = 100;

        player.GiveWeapon(Alt.Hash("weapon_specialcarbine_mk2"), 1000, false);
        player.GiveWeapon((uint)WeaponModel.BullpupRifleMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AdvancedRifle, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GusenbergSweeper, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AssaultSMG, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PistolMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.Pistol50, 1000, false);
        player.GiveWeapon((uint)WeaponModel.HeavyPistol, 1000, false);
        player.GiveWeapon((uint)WeaponModel.BaseballBat, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PoolCue, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GolfClub, 1000, false);
    }

    [ClientEvent("teamSelectedTeam7")]
    public static void teamSelectedTeam7(LPlayer player)
    {
        player.Team = 7;
        player.SetClothes(1, 111, 17, 0); // Maske
        player.SetClothes(4, 24, 0, 0); //Hose
        player.SetClothes(11, 111, 3, 0); // Oberteil
        player.SetClothes(8, 15, 0, 0); // Undershirt
        player.SetClothes(6, 34, 0, 0); // Schuhe
        player.SetClothes(3, 12, 0, 0); //Torso
        player.SetClothes(9, 16, 2, 0); // weste
        player.SetProps(0, 61, 9); // Hut
        player.Position = new Position(-1535.7627f, 97.63516f, 56.761963f);
        player.Spawn(new Position(-1535.7627f, 97.63516f, 56.761963f), 0);
        player.Rotation = new Rotation(0, 0, -2.2757995f);
        player.Health = 200;
        player.Armor = 100;

        player.GiveWeapon(Alt.Hash("weapon_specialcarbine_mk2"), 1000, false);
        player.GiveWeapon((uint)WeaponModel.BullpupRifleMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AdvancedRifle, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GusenbergSweeper, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AssaultSMG, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PistolMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.Pistol50, 1000, false);
        player.GiveWeapon((uint)WeaponModel.HeavyPistol, 1000, false);
        player.GiveWeapon((uint)WeaponModel.BaseballBat, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PoolCue, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GolfClub, 1000, false);
    }

    [ClientEvent("teamSelectedTeam8")]
    public static void teamSelectedTeam8(LPlayer player)
    {
        player.Team = 8;
        player.SetClothes(1, 115, 9, 0); // Maske
        player.SetClothes(4, 1, 1, 0); //Hose
        player.SetClothes(11, 251, 20, 0); // Oberteil
        player.SetClothes(8, 15, 0, 0); // Undershirt
        player.SetClothes(6, 34, 0, 0); // Schuhe
        player.SetClothes(3, 4, 0, 0); //Torso
        player.SetClothes(9, 16, 2, 0); // weste
        player.SetProps(0, 11, 0); // Hut
        player.Position = new Position(1991.1824f, 3054.554f, 47.208008f);
        player.Spawn(new Position(1991.1824f, 3054.554f, 47.208008f), 0);
        player.Rotation = new Rotation(0, 0, -0.54421294f);
        player.Health = 200;
        player.Armor = 100;

        player.GiveWeapon(Alt.Hash("weapon_specialcarbine_mk2"), 1000, false);
        player.GiveWeapon((uint)WeaponModel.BullpupRifleMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AdvancedRifle, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GusenbergSweeper, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AssaultSMG, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PistolMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.Pistol50, 1000, false);
        player.GiveWeapon((uint)WeaponModel.HeavyPistol, 1000, false);
        player.GiveWeapon((uint)WeaponModel.BaseballBat, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PoolCue, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GolfClub, 1000, false);
    }

    [ClientEvent("teamSelectedTeam9")]
    public static void teamSelectedTeam9(LPlayer player)
    {
        player.Team = 9;
        player.SetClothes(1, 118, 8, 0); // Maske
        player.SetClothes(4, 49, 1, 0); //Hose
        player.SetClothes(11, 111, 3, 0); // Oberteil
        player.SetClothes(8, 15, 0, 0); // Undershirt
        player.SetClothes(6, 8, 0, 0); // Schuhe
        player.SetClothes(3, 4, 0, 0); //Torso
        player.SetClothes(9, 16, 2, 0); // weste
        player.SetProps(0, 3, 1); // Hut
        player.Position = new Position(-51.784615f, 355.47693f, 113.04028f);
        player.Spawn(new Position(-51.784615f, 355.47693f, 113.04028f), 0);
        player.Rotation = new Rotation(0, 0, 2.7705386f);
        player.Health = 200;
        player.Armor = 100;

        player.GiveWeapon(Alt.Hash("weapon_specialcarbine_mk2"), 1000, false);
        player.GiveWeapon((uint)WeaponModel.BullpupRifleMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AdvancedRifle, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GusenbergSweeper, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AssaultSMG, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PistolMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.Pistol50, 1000, false);
        player.GiveWeapon((uint)WeaponModel.HeavyPistol, 1000, false);
        player.GiveWeapon((uint)WeaponModel.BaseballBat, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PoolCue, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GolfClub, 1000, false);
    }

    [ClientEvent("teamSelectedTeam10")]
    public static void teamSelectedTeam10(LPlayer player)
    {
        player.Team = 10;
        player.SetClothes(1, 118, 9, 0);
        player.SetClothes(4, 5, 5, 0);
        player.SetClothes(11, 111, 3, 0);
        player.SetClothes(8, 15, 0, 0);
        player.SetClothes(6, 34, 0, 0);
        player.SetClothes(3, 17, 0, 0);
        player.SetClothes(9, 16, 2, 0);
        player.SetProps(0, 3, 1);
        player.Position = new Position(-14.294506f, -1442.6373f, 31.09961f);
        player.Spawn(new Position(-14.294506f, -1442.6373f, 31.09961f), 0);
        player.Rotation = new Rotation(0, 0, -3.0673819f);
        player.Health = 200;
        player.Armor = 100;

        player.GiveWeapon(Alt.Hash("weapon_specialcarbine_mk2"), 1000, false);
        player.GiveWeapon((uint)WeaponModel.BullpupRifleMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AdvancedRifle, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GusenbergSweeper, 1000, false);
        player.GiveWeapon((uint)WeaponModel.AssaultSMG, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PistolMkII, 1000, false);
        player.GiveWeapon((uint)WeaponModel.Pistol50, 1000, false);
        player.GiveWeapon((uint)WeaponModel.HeavyPistol, 1000, false);
        player.GiveWeapon((uint)WeaponModel.BaseballBat, 1000, false);
        player.GiveWeapon((uint)WeaponModel.PoolCue, 1000, false);
        player.GiveWeapon((uint)WeaponModel.GolfClub, 1000, false);
    }
}
