using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DeathHandler : IScript
{

    [ScriptEvent(ScriptEventType.PlayerDead)]
    public static async void PlayerDead(LPlayer player, AltV.Net.Elements.Entities.IEntity killer, uint weapon)
    {
        if (!player.BenutztGradeSchutzweste || !player.BenutztGradeMedkit || !player.Dead || !player.IsInVehicle)
        {
            LPlayer killerFixed = null;
            if (killer != null)
            {
                if (killer.Type == BaseObjectType.Player)
                {
                    killerFixed = killer as LPlayer;
                }

                if (killerFixed != null)
                {
                    if(player.Dead == false)
                    {
                        Console.WriteLine($"DeathLog: {player.AccountName} <- {killerFixed.AccountName} Waffe: {weapon}");
                        killerFixed.SendNotification("2", "", $"Du hast den Spieler {player.AccountName} getötet.", 6);
                        player.SendNotification("4", "", $"Du wurdest von dem Spieler {killerFixed.AccountName} getötet. [{killerFixed.Health + killerFixed.Armor - 100}HP]", 6);

                        Playerstuff.updatedatakills(killerFixed);
                        killerFixed.PlayerUpdaten(killerFixed);
                        Playerstuff.updateKills(killerFixed, killerFixed.Kills);

                        Playerstuff.updatedatadeaths(player);
                        player.PlayerUpdaten(player);
                        Playerstuff.updateDeaths(player, player.Deaths);

                        Playerstuff.updateKd(player, player.Kills, player.Deaths);
                        Playerstuff.updateKd(killerFixed, killerFixed.Kills, killerFixed.Deaths);
                        LevelHandler.updateExp(killerFixed, 100);
                        MoneyHandler.updateMoney(killerFixed, 25);
                    }

                    player.Dead = true;

                    if (killerFixed.IsInVehicle)
                    {
                        if (player.IsInVehicle)
                        {
                            return;
                        }
                        else
                        {
                            killerFixed.VDMWarn = killerFixed.VDMWarn + 1;
                            killerFixed.SendNotification("3", "", $"Du hast im Auto einen Spieler getötet! (Warn " + killerFixed.VDMWarn + "/3)", 6);
                            if (killerFixed.VDMWarn == 3)
                            {
                                killerFixed.Kick("Du wurdest Gekickt! Grund: 3/3 Warns");
                            }
                        }
                    }

                    if(killerFixed.Team == player.Team){
                        if(killerFixed.isFfa == false){
                            killerFixed.VDMWarn = killerFixed.VDMWarn + 1;
                            killerFixed.SendNotification("3", "", $"Du hast einen Spieler aus deinem Team getötet! (Warn " + killerFixed.VDMWarn + "/3)", 6);
                            if (killerFixed.VDMWarn == 3)
                            {
                                killerFixed.Kick("Du wurdest Gekickt! Grund: 3/3 Warns");
                            }
                        }
                    }

                    if(weapon == 911657153)
                    {
                        BanHandler.BanPlayer(killerFixed, killerFixed.AccountName, "Cheating(Tazer)");
                    }

                    killerFixed.KillStreak = killerFixed.KillStreak + 1;
                    player.KillStreak = 0;
                    if (killerFixed.KillStreak == 5)
                    {
                        foreach (LPlayer target in Alt.GetAllPlayers())
                        {
                            target.SendChatMessage("[{FFAA00}KILLSTREAK{FFFFFF}] " + $"Der spieler {killerFixed.AccountName} [{player.SpielerIngameId}] ist nun auf einer Killstreak von {killerFixed.KillStreak}");
                        }
                    }
                    if (killerFixed.KillStreak == 10)
                    {
                        foreach (LPlayer target in Alt.GetAllPlayers())
                        {
                            target.SendChatMessage("[{FFAA00}KILLSTREAK{FFFFFF}] " + $"Der spieler {killerFixed.AccountName} [{player.SpielerIngameId}] ist nun auf einer Killstreak von {killerFixed.KillStreak}");
                        }
                    }
                    if (killerFixed.KillStreak == 15)
                    {
                        foreach (LPlayer target in Alt.GetAllPlayers())
                        {
                            target.SendChatMessage("[{FFAA00}KILLSTREAK{FFFFFF}] " + $"Der spieler {killerFixed.AccountName} [{player.SpielerIngameId}] ist nun auf einer Killstreak von {killerFixed.KillStreak}");
                        }
                    }
                    if (killerFixed.KillStreak == 20)
                    {
                        foreach (LPlayer target in Alt.GetAllPlayers())
                        {
                            target.SendChatMessage("[{FFAA00}KILLSTREAK{FFFFFF}] " + $"Der spieler {killerFixed.AccountName} [{player.SpielerIngameId}] ist nun auf einer Killstreak von {killerFixed.KillStreak}");
                        }
                    }
                    if (killerFixed.KillStreak == 25)
                    {
                        foreach (LPlayer target in Alt.GetAllPlayers())
                        {
                            target.SendChatMessage("[{FFAA00}KILLSTREAK{FFFFFF}] " + $"Der spieler {killerFixed.AccountName} [{player.SpielerIngameId}] ist nun auf einer Killstreak von {killerFixed.KillStreak}");
                        }
                    }
                    if (killerFixed.KillStreak == 30)
                    {
                        foreach (LPlayer target in Alt.GetAllPlayers())
                        {
                            target.SendChatMessage("[{FFAA00}KILLSTREAK{FFFFFF}] " + $"Der spieler {killerFixed.AccountName} [{player.SpielerIngameId}] ist nun auf einer Killstreak von {killerFixed.KillStreak}");
                        }
                    }
                    if (killerFixed.KillStreak == 40)
                    {
                        foreach (LPlayer target in Alt.GetAllPlayers())
                        {
                            target.SendChatMessage("[{FFAA00}KILLSTREAK{FFFFFF}] " + $"Der spieler {killerFixed.AccountName} [{player.SpielerIngameId}] ist nun auf einer Killstreak von {killerFixed.KillStreak}");
                        }
                    }
                    if (killerFixed.KillStreak == 50)
                    {
                        foreach (LPlayer target in Alt.GetAllPlayers())
                        {
                            target.SendChatMessage("[{FFAA00}KILLSTREAK{FFFFFF}] " + $"Der spieler {killerFixed.AccountName} [{player.SpielerIngameId}] ist nun auf einer Killstreak von {killerFixed.KillStreak}");
                        }
                    }
                    if (killerFixed.KillStreak == 70)
                    {
                        foreach (LPlayer target in Alt.GetAllPlayers())
                        {
                            target.SendChatMessage("[{FFAA00}KILLSTREAK{FFFFFF}] " + $"Der spieler {killerFixed.AccountName} [{player.SpielerIngameId}] ist nun auf einer Killstreak von {killerFixed.KillStreak}");
                        }
                    }
                    if (killerFixed.KillStreak == 90)
                    {
                        foreach (LPlayer target in Alt.GetAllPlayers())
                        {
                            target.SendChatMessage("[{FFAA00}KILLSTREAK{FFFFFF}] " + $"Der spieler {killerFixed.AccountName} [{player.SpielerIngameId}] ist nun auf einer Killstreak von {killerFixed.KillStreak}");
                        }
                    }
                    if (killerFixed.KillStreak == 100)
                    {
                        foreach (LPlayer target in Alt.GetAllPlayers())
                        {
                            target.SendChatMessage("[{FFAA00}KILLSTREAK{FFFFFF}] " + $"Der spieler {killerFixed.AccountName} ist nun auf einer Killstreak von {killerFixed.KillStreak}");
                        }
                    }
                    if (player.isFfa == true)
                    {
                        killerFixed.Health = 200;
                        killerFixed.Armor = 100;
                    }
                }
            }

            //respawn
            await Task.Delay(2000);
            {
                if (player.Exists)
                {
                    player.Dead = false;
                    player.ClearBloodDamage();
                    #region ffa
                    if (player.isFfa == true)
                    {
                        player.Dimension = 187;
                        player.Armor = 100;

                        if (player.ffaarena == 1)
                        {
                            int randomspawn = new Random().Next(1, 6);
                            player.Dimension = 187;
                            player.isFfa = true;
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

                            if (randomspawn == 1)
                            {
                                player.Spawn(new Position(213.54726f, -946.74725f, 30.678345f), 0);
                                player.Rotation = new Rotation(0, 0, 0.94000417f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 2)
                            {
                                player.Spawn(new Position(155.05055f, -973.4242f, 30.088623f), 0);
                                player.Rotation = new Rotation(0, 0, -0.69263464f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 3)
                            {
                                player.Spawn(new Position(159.25714f, -913.8461f, 30.156006f), 0);
                                player.Rotation = new Rotation(0, 0, -1.9789561f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 4)
                            {
                                player.Spawn(new Position(186.65933f, -850.61536f, 31.150146f), 0);
                                player.Rotation = new Rotation(0, 0, -2.7705386f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 5)
                            {
                                player.Spawn(new Position(245.85495f, -871.767f, 30.290894f), 0);
                                player.Rotation = new Rotation(0, 0, 2.473695f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 6)
                            {
                                player.Spawn(new Position(215.06374f, -938.5846f, 24.140625f), 0);
                                player.Rotation = new Rotation(0, 0, 2.1768517f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                        }
                        if (player.ffaarena == 2)
                        {
                            int randomspawn = new Random().Next(1, 6);
                            player.Dimension = 187;
                            player.isFfa = true;
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
                            if (randomspawn == 1)
                            {
                                player.Spawn(new Position(-948.25055f, -800.7297f, 15.917969f), 0);
                                player.Rotation = new Rotation(0, 0, -0.5936868f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 2)
                            {
                                player.Spawn(new Position(-897.16486f, -798.52747f, 15.917969f), 0);
                                player.Rotation = new Rotation(0, 0, 0.34631732f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 3)
                            {
                                player.Spawn(new Position(-950.7165f, -708.65936f, 19.911377f), 0);
                                player.Rotation = new Rotation(0, 0, 3.017908f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 4)
                            {
                                player.Spawn(new Position(-984.87036f, -745.5956f, 20.922363f), 0);
                                player.Rotation = new Rotation(0, 0, -3.017908f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 5)
                            {
                                player.Spawn(new Position(-985.87256f, -775.4374f, 16.204346f), 0);
                                player.Rotation = new Rotation(0, 0, 3.017908f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 6)
                            {
                                player.Spawn(new Position(-962.1363f, -777.62634f, 16.153809f), 0);
                                player.Rotation = new Rotation(0, 0, -2.7210646f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                        }
                        if (player.ffaarena == 3)
                        {
                            int randomspawn = new Random().Next(1, 6);
                            player.Dimension = 187;
                            player.isFfa = true;
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
                            if (randomspawn == 1)
                            {
                                player.Spawn(new Position(-1559.5253f, 73.45055f, 57.536987f), 0);
                                player.Rotation = new Rotation(0, 0, 1.6821126f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 2)
                            {
                                player.Spawn(new Position(-1584.0659f, 83.6967f, 59.20508f), 0);
                                player.Rotation = new Rotation(0, 0, -0.7421085f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 3)
                            {
                                player.Spawn(new Position(-1637.8154f, 111.57362f, 62.490845f), 0);
                                player.Rotation = new Rotation(0, 0, -1.484217f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 4)
                            {
                                player.Spawn(new Position(-1586.9143f, 143.59122f, 58.935547f), 0);
                                player.Rotation = new Rotation(0, 0, 3.1168559f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 5)
                            {
                                player.Spawn(new Position(-1535.9736f, 105.29671f, 56.77881f), 0);
                                player.Rotation = new Rotation(0, 0, -2.3252733f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 6)
                            {
                                player.Spawn(new Position(-1471.7539f, 73.27912f, 53.526733f), 0);
                                player.Rotation = new Rotation(0, 0, 1.0884259f);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                        }
                        if (player.ffaarena == 5)
                        {
                            int randomspawn = new Random().Next(1, 6);
                            player.Dimension = 187;
                            player.isFfa = true;
                            player.ffaarena = 5;

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
                            if (randomspawn == 1)
                            {
                                player.Spawn(new Position(1457.7362f, 1147.3978f, 114.32092f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 2)
                            {
                                player.Spawn(new Position(1406.9275f, 1155.0198f, 114.43884f), 0);

                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 3)
                            {
                                player.Spawn(new Position(1390.3121f, 1154.7164f, 114.32092f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 4)
                            {
                                player.Spawn(new Position(1463.8813f, 1134.9626f, 114.32092f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 5)
                            {
                                player.Spawn(new Position(1480.2197f, 1081.4769f, 114.32092f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 6)
                            {
                                player.Spawn(new Position(1497.9297f, 1120.4703f, 114.32092f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                        }
                        if (player.ffaarena == 6)
                        {
                            int randomspawn = new Random().Next(1, 6);
                            player.Dimension = 187;
                            player.isFfa = true;
                            player.ffaarena = 6;

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
                            if (randomspawn == 1)
                            {
                                player.Spawn(new Position(-327.36264f, 2793.4153f, 58.96924f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 2)
                            {
                                player.Spawn(new Position(-295.75385f, 2783.156f, 61.10913f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 3)
                            {
                                player.Spawn(new Position(-303.46814f, 2804.9011f, 59.508423f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 4)
                            {
                                player.Spawn(new Position(-282.778f, 2845.7935f, 54.01538f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 5)
                            {
                                player.Spawn(new Position(-282.778f, 2845.7935f, 54.01538f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 6)
                            {
                                player.Spawn(new Position(-349.08133f, 2799.956f, 58.059326f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                        }
                        if (player.ffaarena == 4)
                        {
                            int randomspawn = new Random().Next(1, 6);
                            player.Dimension = 187;
                            player.isFfa = true;
                            player.ffaarena = 4;

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
                            if (randomspawn == 1)
                            {
                                player.Spawn(new Position(-1159.8989f, 4910.11f, 220.1377f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 2)
                            {
                                player.Spawn(new Position(-1108.2197f, 4961.723f, 218.7561f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 3)
                            {
                                player.Spawn(new Position(-1087.701f, 4894.8394f, 214.40881f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 4)
                            {
                                player.Spawn(new Position(-1071.5209f, 4932.791f, 212.20142f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 5)
                            {
                                player.Spawn(new Position(-1130.6505f, 4904.611f, 219.02563f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                            if (randomspawn == 6)
                            {
                                player.Spawn(new Position(-1092.2241f, 4946.413f, 218.33484f), 0);
                                player.Health = 200;
                                player.Armor = 100;
                            }
                        }
                    }
                    #endregion

                    else
                    {
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
            }
        }
                
    }
}