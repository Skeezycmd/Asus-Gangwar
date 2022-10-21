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

public class AnticheatHandler : IScript
{

    public static List<WeaponModel> BlacklistedWeapons = new List<WeaponModel>();

    public AnticheatHandler()
    {
        BlacklistedWeapons.Add(WeaponModel.RPG);
        BlacklistedWeapons.Add(WeaponModel.Minigun);
        BlacklistedWeapons.Add(WeaponModel.StickyBomb);
        BlacklistedWeapons.Add(WeaponModel.Grenade);
        BlacklistedWeapons.Add(WeaponModel.GrenadeLauncher);
        BlacklistedWeapons.Add(WeaponModel.MolotovCocktail);
        BlacklistedWeapons.Add(WeaponModel.ProximityMines);
        BlacklistedWeapons.Add(WeaponModel.GrenadeLauncher);
        BlacklistedWeapons.Add(WeaponModel.GrenadeLauncherSmoke);
        BlacklistedWeapons.Add(WeaponModel.FireworkLauncher);
        BlacklistedWeapons.Add(WeaponModel.Railgun);
        BlacklistedWeapons.Add(WeaponModel.HomingLauncher);
        BlacklistedWeapons.Add(WeaponModel.CompactGrenadeLauncher);
        BlacklistedWeapons.Add(WeaponModel.EMPLauncher);
    }

    [ScriptEvent(ScriptEventType.Explosion)]
    public void OnExplosion(LPlayer player, AltV.Net.Data.ExplosionType explosionType, Position position, uint explosionFx, IEntity targetEntity)
    {
        if (explosionType == AltV.Net.Data.ExplosionType.PetrolPump || explosionType == AltV.Net.Data.ExplosionType.Bike || explosionType == AltV.Net.Data.ExplosionType.Car || explosionType == AltV.Net.Data.ExplosionType.DirWaterHydrant || explosionType == AltV.Net.Data.ExplosionType.DirFlame || explosionType == AltV.Net.Data.ExplosionType.DirFlameExplode || explosionType == AltV.Net.Data.ExplosionType.DirGasCanister || explosionType == AltV.Net.Data.ExplosionType.GasTank || explosionType == AltV.Net.Data.ExplosionType.Plane)
        {
            Console.WriteLine("fix");
        }
        else
        {
            BanHandler.BanPlayer(player, player.AccountName, "Cheating(Explosion " + explosionType + ")");
            Console.WriteLine("Der Spieler " + player.AccountName + " hat eine Explosion gecallt! : " + explosionType + " " + position + explosionFx + targetEntity);
            return;
        }
    }

    [ScriptEvent(ScriptEventType.PlayerDamage)]
    public static async void PlayerDamage(LPlayer player, IEntity killer, uint Weapon, ushort healthDamage, ushort armorDamage)
    {
        try
        {
            LPlayer killerFixed = null;
            if (killer != null)
            {
                if (killer.Type == BaseObjectType.Player)
                {
                    killerFixed = killer as LPlayer;
                }
                //if(armorDamage > 60)
                //{
                //    if (armorDamage > 100) return;
                //    BanHandler.BanPlayer(killerFixed, killerFixed.AccountName, "Cheating(DMG Modifier)");
                //}
                //if (healthDamage > 60)
                //{
                //    if (healthDamage > 100) return;
                //    BanHandler.BanPlayer(killerFixed, killerFixed.AccountName, "Cheating(DMG Modifier)");
                //}
                if (player != null && killerFixed != null)
                {
                    if(killerFixed.Hitmaker == 1)
                    {
                        killerFixed.Emit("hitmaker");
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"PlayerDamage: {e.Message}");
            return;
        }
    }


    [ScriptEvent(ScriptEventType.PlayerWeaponChange)]
    public void WeaponChange(LPlayer player, uint oldWeapon, uint newWeapon)
    {
        if (player.AccountName != "")
        {
            foreach (var blackListedWeapons in BlacklistedWeapons)
            {
                if (newWeapon == (uint)blackListedWeapons)
                {
                    Console.WriteLine($"> : {player.AccountName} wurde gebannt. (BLACKLISTED WEAPON) -> {newWeapon}");
                    BanHandler.BanPlayer(player, player.AccountName, "Cheating(Weapon Cheating");
                }
            }
            if (IsWeaponExistInDB(player.AccountName, newWeapon) == false && newWeapon != (uint)WeaponModel.Fist)
            {
                Console.WriteLine($"> : {player.AccountName} wurde gebannt. (WEAPON NOT IN DB) -> {newWeapon}");
                BanHandler.BanPlayer(player, player.AccountName, "Cheating(Weapon Cheating)");
            }
            player.GiveWeapon(newWeapon, 9999, false);
            player.GiveWeapon(oldWeapon, 9999, false);
        }
    }



    public static bool IsWeaponExistInDB(string AccountName, uint Weapon)
    {
        try
        {
            MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
            c.Open();
            string cmdText = "SELECT * FROM weapons WHERE name=@name AND weapon=@weapon";
            MySqlCommand cmd = new MySqlCommand(cmdText, c);
            cmd.Parameters.AddWithValue("@name", AccountName);
            cmd.Parameters.AddWithValue("@weapon", Weapon.ToString());
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
            Console.WriteLine($"IsWeaponExistInDB: {e.Message}");
            return true;
        }
    }


    
}