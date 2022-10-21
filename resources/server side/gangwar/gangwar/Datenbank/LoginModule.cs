using System;
using System.Text.RegularExpressions;
using AltV;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Data;
using AltV.Net.Enums;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

public class LoginModule : IScript
{

    [ClientEvent("Server:Login:Login")]
    public static void LoginPlayer(LPlayer player, string AccountName)
    {
        try
        {
            var regexItem = new Regex("^[a-zA-Z0-9-_]*$");
            
            if(!regexItem.IsMatch(AccountName))
            {
                player.Kick("Dein Name hat Sonderzeichen!");
                return;
            }
            if (AccountName.Contains(" "))
            {
                player.Kick("Dein Name hat Sonderzeichen!");
                return;
            }
            if (IsPlayerOwnAccount(player, AccountName) == true)
            {
                if (IsPlayerBanned(player) == false)
                {
                    if (player.Exists == false) return;
                    player.AccountID = GetAccountID(AccountName);
                    player.AccountName = AccountName;
                    player.AdminLevel = GetAdminLevel(AccountName);
                    if(player.AdminLevel == 0)
                    {
                        player.AdminLevelName = "{008EC3}USER{FFFFFF}";
                    }
                    if (player.AdminLevel == 1)
                    {
                        player.AdminLevelName = "{00E437}Test-Supporter{FFFFFF}";
                    }
                    if (player.AdminLevel == 2)
                    {
                        player.AdminLevelName = "{00E437}Supporter{FFFFFF}";
                    }
                    if (player.AdminLevel == 3)
                    {
                        player.AdminLevelName = "{0056E4}Gamedesigner{FFFFFF}";
                    }
                    if (player.AdminLevel == 4)
                    {
                        player.AdminLevelName = "{0056E4}Moderator{FFFFFF}";
                    }
                    if (player.AdminLevel == 5)
                    {
                        player.AdminLevelName = "{EBEB00}Administrator{FFFFFF}";
                    }
                    if (player.AdminLevel == 6)
                    {
                        player.AdminLevelName = "{00ECDE}Entwickler{FFFFFF}";
                    }
                    if (player.AdminLevel == 7)
                    {
                        player.AdminLevelName = "{FFAA00}Teamverwaltung{FFFFFF}";
                    }
                    if (player.AdminLevel == 8)
                    {
                        player.AdminLevelName = "{7B00C1}Headadmin{FFFFFF}";
                    }
                    if (player.AdminLevel == 9)
                    {
                        player.AdminLevelName = "{C10000}Manager{FFFFFF}";
                    }
                    if (player.AdminLevel == 10)
                    {
                        player.AdminLevelName = "{FF0000}Projektleiter{FFFFFF}";
                    }
                    //player.EmitLocked("Client:Char:ShowAuswahl", GetCharItems(AccountName));
                    player.EmitLocked("Client:Login:Destroy");
                    player.SendNotification("2", "", "Du hast dich erfolgreich eingeloggt.", 6);
                    player.PlayerLaden(AccountName);
                    player.PlayerIdLaden(AccountName);                    
                    player.Emit("Client:Pedcreator:spawnPed", "a_m_y_busicas_01", 1408.022f, 3618.3823f, 34.89087f - 1, 2f); // Aztecas
                    player.Emit("Client:Pedcreator:spawnPed", "s_m_y_autopsy_01", 356.26813f, -593.34064f, 28.774414f - 1, 2f); // Klinik
                    player.Emit("Client:Pedcreator:spawnPed", "u_m_y_antonb", 102.85715f, -1959.4945f, 20.804443f - 1, 0f); //Ballas
                    player.openCef = true;
                    player.Emit("OpenTeamSelect");
                    player.Dimension = 0;
                    Teamauswahl.updateTeamCounter(player);
                    player.LoggedIn = true;

                    DiscordBot.updateStatus();

                    if (IsPlayerMuted(player) == true)
                    {
                        player.Muted = 1;
                    }

                    if (PlayerHasWeapons(player) == false)
                    {
                        Waffenladen.InsertPlayerWeapon(player, Alt.Hash("weapon_specialcarbine_mk2"));
                        Waffenladen.InsertPlayerWeapon(player, (uint)WeaponModel.BullpupRifleMkII);
                        Waffenladen.InsertPlayerWeapon(player, (uint)WeaponModel.AdvancedRifle);
                        Waffenladen.InsertPlayerWeapon(player, (uint)WeaponModel.GusenbergSweeper);
                        Waffenladen.InsertPlayerWeapon(player, (uint)WeaponModel.AssaultSMG);
                        Waffenladen.InsertPlayerWeapon(player, (uint)WeaponModel.PistolMkII);
                        Waffenladen.InsertPlayerWeapon(player, (uint)WeaponModel.Pistol50);
                        Waffenladen.InsertPlayerWeapon(player, (uint)WeaponModel.HeavyPistol);
                        Waffenladen.InsertPlayerWeapon(player, (uint)WeaponModel.BaseballBat);
                        Waffenladen.InsertPlayerWeapon(player, (uint)WeaponModel.PoolCue);
                        Waffenladen.InsertPlayerWeapon(player, (uint)WeaponModel.GolfClub);
                    }
                }
                else
                {
                    player.Kick("Du bist vom Server gebannt.");
                    return;
                }


            }
            else
            {
                player.SendNotification("4", "", "Dieser Account gehört nicht dir.", 6);
                return;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"LoginPlayer: {e.Message}");
            return;
        }
    }

    public static bool PlayerHasWeapons(LPlayer player)
    {
        try
        {
            MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
            c.Open();
            string cmdText = "SELECT name FROM weapons WHERE name=@name";
            MySqlCommand cmd = new MySqlCommand(cmdText, c);
            cmd.Parameters.AddWithValue("@name", player.AccountName);
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
            Console.WriteLine($"IsPlayerAccountExist: {e.Message}");
            return false;
        }
    }

    public static bool IsPlayerBanned(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT gebannt FROM accounts_ban WHERE scid=@scid AND hwid=@hwid AND discordid=@discordid AND ip=@ip";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@scid", player.SocialClubId);
        cmd.Parameters.AddWithValue("@hwid", player.HardwareIdHash);
        cmd.Parameters.AddWithValue("@discordid", player.DiscordId);
        cmd.Parameters.AddWithValue("@ip", player.Ip);
        cmd.ExecuteNonQuery();
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                return true;
                c.Close();
            }
            return false;
            c.Close();
        }


    }

    public static bool IsPlayerMuted(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT gemuted FROM accounts_mute WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", player.AccountName);
        cmd.ExecuteNonQuery();
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                return true;
                c.Close();
            }
            return false;
            c.Close();
        }
    }

    public static int GetAccountID (string AccountName)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT id FROM accounts WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", AccountName);
        cmd.ExecuteNonQuery();
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                reader.Read();
                return reader.GetInt32("id");

            }
            return -1;
           
        }
    }
    public static int GetAdminLevel(string AccountName)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT adminlevel FROM accounts WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", AccountName);
        cmd.ExecuteNonQuery();
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                reader.Read();
                return reader.GetInt32("adminlevel");
                c.Close();

            }
            return 0;
            c.Close();

        }
    }

    public static bool IsPlayerOwnAccount(LPlayer player, string AccountName)
    {
        try
        {
            MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
            c.Open();
            string cmdText = "SELECT * FROM accounts WHERE name=@name";
            MySqlCommand cmd = new MySqlCommand(cmdText, c);
            cmd.Parameters.AddWithValue("@name", AccountName);
            cmd.ExecuteNonQuery();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    if (player.SocialClubId == Convert.ToUInt64(reader.GetString("scid")) && player.HardwareIdHash == Convert.ToUInt64(reader.GetString("hwid")))
                    {
                        return true;
                        c.Close();
                    }
                    return false;
                    c.Close();

                }
                return false;
                c.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"IsPlayerOwnAccount: {e.Message}");
            return false;
        }
    }
}