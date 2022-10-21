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
using AltV.Net.Client.Elements.Entities;

public class Waffenladen : IScript
{

    [ClientEvent("Keypress:E")]
    public void KeypressE(LPlayer player)
    {
        if (player.Position.Distance(new Position(21.019781f, -1106.6901f, 29.7854f)) < 2f && player.openCef == false)
        {
            player.Emit("openWaffenshop");
            player.openCef = true;
        }
        if (player.Position.Distance(new Position(252.87033f, -49.173626f, 69.93848f)) < 2f && player.openCef == false)
        {
            player.Emit("openWaffenshop");
            player.openCef = true;
        }
        if (player.Position.Distance(new Position(-1305.1912f, -393.2835f, 36.693726f)) < 2f && player.openCef == false)
        {
            player.Emit("openWaffenshop");
            player.openCef = true;
        }
        if (player.Position.Distance(new Position(-663.4154f, -934.9319f, 21.81543f)) < 2f && player.openCef == false)
        {
            player.Emit("openWaffenshop");
            player.openCef = true;
        }
    }

    [ClientEvent("closeWeaponshop")]
    public static void closeWeapon(LPlayer player)
    {
        player.openCef = false;
    }

    public static bool hasPlayerSpeziSchalli(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT spezischalli FROM accounts WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        object obj = cmd.ExecuteScalar();
        if (Convert.ToInt32(obj) > 0)
        {
            Console.WriteLine("true spezi");
            return true;
        }
        else
        {
            Console.WriteLine("false spezi");
            return false;
        }
        c.Close();
    }

    public static bool hasPlayerSpeziGriff(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT spezigriff FROM accounts WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        object obj = cmd.ExecuteScalar();
        if (Convert.ToInt32(obj) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        c.Close();
    }
    public static bool hasPlayerSpeziVisier(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT spezivisier FROM accounts WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        object obj = cmd.ExecuteScalar();
        if (Convert.ToInt32(obj) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        c.Close();
    }
    public static bool hasPlayerBulliSchalli(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT bullischalli FROM accounts WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        object obj = cmd.ExecuteScalar();
        if (Convert.ToInt32(obj) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        c.Close();
    }
    public static bool hasPlayerBulliVisier(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT bullivisier FROM accounts WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        object obj = cmd.ExecuteScalar();
        if (Convert.ToInt32(obj) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        c.Close();
    }
    public static bool hasPlayerBulliGriff(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT bulligriff FROM accounts WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        object obj = cmd.ExecuteScalar();
        if (Convert.ToInt32(obj) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        c.Close();
    }

    public static bool hasPlayerAdvSchalli(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT advschalli FROM accounts WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        object obj = cmd.ExecuteScalar();
        if (Convert.ToInt32(obj) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        c.Close();
    }
    public static bool hasPlayerAdvVisier(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT advvisier FROM accounts WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        object obj = cmd.ExecuteScalar();
        if (Convert.ToInt32(obj) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        c.Close();
    }
    public static bool hasPlayerAdvLicht(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT advlicht FROM accounts WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        object obj = cmd.ExecuteScalar();
        if (Convert.ToInt32(obj) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        c.Close();
    }

    public static void setPlayerAdvSchalli(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET advschalli='1' WHERE name=@name";
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        c.Close();
    }
    public static void setPlayerAdvVisier(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET advvisier='1' WHERE name=@name";
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        c.Close();
    }
    public static void setPlayerAdvLicht(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET advlicht='1' WHERE name=@name";
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        c.Close();
    }
    public static void setPlayerSpeziSchalli(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET spezischalli='1' WHERE name=@name";
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        c.Close();
    }
    public static void setPlayerSpeziGriff(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET spezigriff='1' WHERE name=@name";
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        c.Close();
    }
    public static void setPlayerSpeziVisier(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET spezivisier='1' WHERE name=@name";
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        c.Close();
    }
    public static void setPlayerBulliSchalli(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET bullischalli='1' WHERE name=@name";
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        c.Close();
    }
    public static void setPlayerBulliGriff(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET bulligriff='1' WHERE name=@name";
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        c.Close();
    }
    public static void setPlayerBulliVisier(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE accounts SET bullivisier='1' WHERE name=@name";
        MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        c.Close();
    }

    [ClientEvent("WeaponComp")]
    public static void WeaponComp(LPlayer player, int weapon, int comp)
    {
        if (weapon == 1)
        {
            if (comp == 1)
            {
                if (player.playermoney >= 10000)
                {
                    player.AddWeaponComponent((uint)WeaponModel.AdvancedRifle, 0x837445AA);
                    setPlayerAdvSchalli(player);
                    MoneyHandler.updateMoneyMinus(player, 10000);
                }
            }
            if (comp == 2)
            {
                if (player.playermoney >= 5000)
                {
                    player.AddWeaponComponent((uint)WeaponModel.AdvancedRifle, 0xAA2C45B4);
                    setPlayerAdvVisier(player);
                    MoneyHandler.updateMoneyMinus(player, 5000);
                }
            }
            if (comp == 3)
            {
                if (player.playermoney >= 5000)
                {
                    player.AddWeaponComponent((uint)WeaponModel.AdvancedRifle, 0x7BC4CDDC);
                    setPlayerAdvLicht(player);
                    MoneyHandler.updateMoneyMinus(player, 5000);
                }
            }
        }
        if (weapon == 2)
        {
            if (comp == 1)
            {
                if (player.playermoney >= 15000)
                {
                    player.AddWeaponComponent((uint)WeaponModel.BullpupRifleMkII, 0x837445AA);
                    setPlayerBulliSchalli(player);
                    MoneyHandler.updateMoneyMinus(player, 15000);
                }
            }
            if (comp == 2)
            {
                if (player.playermoney >= 5000)
                {
                    player.AddWeaponComponent((uint)WeaponModel.BullpupRifleMkII, 0x3F3C8181);
                    setPlayerBulliVisier(player);
                    MoneyHandler.updateMoneyMinus(player, 5000);
                }
            }
            if (comp == 3)
            {
                if (player.playermoney >= 5000)
                {
                    player.AddWeaponComponent((uint)WeaponModel.BullpupRifleMkII, 0x9D65907A);
                    setPlayerBulliGriff(player);
                    MoneyHandler.updateMoneyMinus(player, 5000);
                }
            }
        }
        if (weapon == 3)
        {
            if (comp == 1)
            {
                if (player.playermoney >= 15000)
                {
                    player.AddWeaponComponent((uint)WeaponModel.SpecialCarbineMkII, 0xA73D4664);
                    setPlayerSpeziSchalli(player);
                    MoneyHandler.updateMoneyMinus(player, 15000);

                }
            }
            if (comp == 2)
            {
                if (player.playermoney >= 5000)
                {
                    player.AddWeaponComponent((uint)WeaponModel.SpecialCarbineMkII, 0x420FD713);
                    setPlayerSpeziVisier(player);
                    MoneyHandler.updateMoneyMinus(player, 5000);
                }
            }
            if (comp == 3)
            {
                if (player.playermoney >= 5000)
                {
                    player.AddWeaponComponent((uint)WeaponModel.SpecialCarbineMkII, 0x9D65907A);
                    setPlayerSpeziGriff(player);
                    MoneyHandler.updateMoneyMinus(player, 5000);
                }
            }
        }
    }
    
    public static void SetPlayerComps(LPlayer player, int weapon, int comp)
    {
        if (weapon == 1)
        {
            if (comp == 1)
            {
                player.AddWeaponComponent((uint)WeaponModel.AdvancedRifle, 0x837445AA);
            }
            if (comp == 2)
            {
                player.AddWeaponComponent((uint)WeaponModel.AdvancedRifle, 0xAA2C45B4);
            }
            if (comp == 3)
            {
                player.AddWeaponComponent((uint)WeaponModel.AdvancedRifle, 0x7BC4CDDC);
            }
        }
        if (weapon == 2)
        {
            if (comp == 1)
            {
                player.AddWeaponComponent((uint)WeaponModel.BullpupRifleMkII, 0x837445AA);
            }
            if (comp == 2)
            {
                player.AddWeaponComponent((uint)WeaponModel.BullpupRifleMkII, 0x3F3C8181);
            }
            if (comp == 3)
            {
                player.AddWeaponComponent((uint)WeaponModel.BullpupRifleMkII, 0x9D65907A);
            }
        }
        if (weapon == 3)
        {
            if (comp == 1)
            {
                player.AddWeaponComponent((uint)WeaponModel.SpecialCarbineMkII, 0xA73D4664);
            }
            if (comp == 2)
            {
                player.AddWeaponComponent((uint)WeaponModel.SpecialCarbineMkII, 0x420FD713);
            }
            if (comp == 3)
            {
                player.AddWeaponComponent((uint)WeaponModel.SpecialCarbineMkII, 0x9D65907A);
            }
        }
    }
    


    public static void InsertPlayerWeapon(LPlayer player, uint Weapon)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "INSERT INTO weapons (name, weapon) VALUES (@name, @weapon)";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.Parameters.AddWithValue("@weapon", Weapon.ToString());
        cmd.ExecuteNonQuery();
        c.Close();
    }

    public static void RemovePlayerWeapon(LPlayer player, uint Weapon)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "DELETE FROM weapons WHERE name=@name AND weapon=@weapon";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.Parameters.AddWithValue("@weapon", Weapon.ToString());
        cmd.ExecuteNonQuery();
        c.Close();
    }

    public static void RemoveAllPlayerWeapon(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "DELETE FROM weapons WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        player.RemoveAllWeapons();
        c.Close();
    }
}