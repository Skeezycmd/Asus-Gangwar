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
using System.Timers;
using MySql.Data.MySqlClient;
using AltV.Net.EntitySync;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class LPlayer : Player
{
    public string SocialclubName { get; set; }
    public string CharacterName { get; set; }
    public int AccountID { get; set; }
    public int SpielerID { get; set; }
    public int SpielerIngameId { get; set; }
    public string AccountName { get; set; }
    public bool BenutztGradeMedkit { get; set; }
    public bool BenutztGradeSchutzweste { get; set; }
    public bool Dead { get; set; }
    public bool AdminDienst { get; set; }
    public int Geld { get; set; }
    public bool openCef { get; set; }
    public int Team { get; set; }
    public bool isFfa { get; set; }
    public int ffaarena { get; set; }
    public bool Abbrechen { get; set; }
    public int Kills { get; set; }
    public int Deaths { get; set; }
    public int KillStreak { get; set; }
    public int AdminLevel { get; set; }
    public string AdminLevelName { get; set; }
    public int VDMWarn { get; set; }
    public int Muted { get; set; }
    public int Hitmaker { get; set; }
    public int DiscordID { get; set; }
    public int playerexp { get; set; }
    public int playerlevel { get; set; }
    public bool adminchatactive { get; set; }
    public bool LoggedIn { get; set; }
    public int playermoney { get; set; }

    public string CREATOR_GENDER { get; set; }
    public int CREATOR_MOTHER { get; set; }
    public int CREATOR_FATHER { get; set; }
    public int CREATOR_SKINCOLOR { get; set; }
    public int CREATOR_SHAPEMIX { get; set; }
    public int CREATOR_NASENBREITE { get; set; }
    public int CREATOR_NASENHOEHE { get; set; }
    public int CREATOR_NASENLAENGE { get; set; }
    public int CREATOR_NASENBRUECKE { get; set; }
    public int CREATOR_NASENSPITZE { get; set; }
    public int CREATOR_NASENBRUECKENVERSCHIEBUNG { get; set; }
    public int CREATOR_AUGENBRAUENHOEHE { get; set; }
    public int CREATOR_AUGENBRAUENBREITE { get; set; }
    public int CREATOR_LIPPEN { get; set; }
    public int CREATOR_NACKENBREITE { get; set; }
    public int CREATOR_AUGEN { get; set; }
    public int CREATOR_HAARE { get; set; }
    public int CREATOR_BART { get; set; }
    public int CREATOR_HAARFARBE { get; set; }
    public int CREATOR_BARTFARBE { get; set; }
    public int CREATOR_AUGENFARBE { get; set; }
    public int CREATOR_AUGENBRAUEN { get; set; }
    public int CREATOR_ALTER { get; set; }
    public int CREATOR_MAKEUP { get; set; }
    public int CREATOR_BLUSH { get; set; }
    public int CREATOR_LIPSTICK { get; set; }
    
    public LPlayer(ICore core, IntPtr nativePointer, ushort id) : base(core, nativePointer, id)
    {
        BenutztGradeSchutzweste = false;
        BenutztGradeMedkit = false;
        AdminDienst = false;
        Dead = false;
        AccountName = "";
        SocialclubName = "";
        CharacterName = "";
        CREATOR_GENDER = "";
        AdminLevelName = "";
        AdminLevel = 0;
        isFfa = false;
        ffaarena = 0;
        Abbrechen = false;
        Kills = 0;
        Deaths = 0;
        KillStreak = 0;
        VDMWarn = 0;
        Hitmaker = 0;
        DiscordID = 0;
        adminchatactive = true;
    }


    public void PlayerLaden(string AccountName)
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
                    while (reader.Read())
                    {
                        
                        this.AccountID = reader.GetInt32("id");
                        this.SpielerID = reader.GetInt32("id");
                        this.Kills = reader.GetInt32("kills");
                        this.Deaths = reader.GetInt32("deaths");
                        this.playerlevel = reader.GetInt32("level");
                        this.playerexp = reader.GetInt32("exp");
                        this.playermoney = reader.GetInt32("money");
                        this.KillStreak = 0;
                        this.Dimension = 0;
                        CreatorModule.LoadCharacter(this);
                        SetSyncedMetaData("NAME", AccountName);
                        SetSyncedMetaData("ID", AccountID);
                        Console.WriteLine("Der Spieler " + AccountName + " ist auf den Server Connected! | " + SocialclubName + " | " + SocialClubId);
                        //LoadWeapons();       
                        
                    }
                }
                else
                {
                    this.AccountID = reader.GetInt32("accountid");
                    this.SpielerID = reader.GetInt32("id");
                    this.Dimension = 0;
                    SetSyncedMetaData("NAME", AccountName);
                    //LoadWeapons();

                }

            }
            c.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine($"PlayerLaden: {e.Message}");
            return;
        }
    }

    public void PlayerUpdaten(LPlayer player)
    {
        try
        {
            MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
            c.Open();
            string cmdText = "SELECT * FROM accounts WHERE name=@name";
            MySqlCommand cmd = new MySqlCommand(cmdText, c);
            cmd.Parameters.AddWithValue("@name", player.AccountName);
            cmd.ExecuteNonQuery();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        this.Kills = reader.GetInt32("kills");
                        this.Deaths = reader.GetInt32("deaths");
                    }
                }
                else
                {
                    this.AccountID = reader.GetInt32("accountid");
                    this.SpielerID = reader.GetInt32("id");
                    this.Dimension = 0;

                }

            }
            c.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine($"PlayerLaden: {e.Message}");
            return;
        }
    }

    public void PlayerIdLaden(string AccountName)
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
                    while (reader.Read())
                    {

                        this.SpielerIngameId = reader.GetInt32("id");
                    }
                }
                c.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"PlayerLaden: {e.Message}");
            return;
        }
    }

    public void SendNotification(string type, string title, string message, int duration)
    {
        this.EmitLocked("Client:Notify:Show", type, duration, title, message);
    }

    public void SendGlobalNotify(string type, string title, string message, int duration)
    {
        foreach (LPlayer players in Alt.GetAllPlayers().Where(x => ((LPlayer)x).AccountID != -1))
        {
            Alt.Log("testglobal");
            players.EmitLocked("Client:GlobalNotify:Show", type, duration, title, message); 
        }
    }


    public void LoadWeapons()
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT * FROM weapons WHERE name=@name";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@name", this.AccountName);
        cmd.ExecuteNonQuery();
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                uint Weapon = Convert.ToUInt32(reader.GetString("weapon"));
                this.GiveWeapon(Weapon, 9999, false);
            }
        }
        c.Close();
    }
}