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

public class CreatorModule : IScript
{

    [ClientEvent("Keypress:E")]
    public void keypresse(LPlayer player)
    {
        if (player.Position.Distance(new Position(356.26813f, -593.34064f, 28.774414f)) < 2f && player.openCef == false)
        {
            player.Visible = true;
            player.Frozen = false;

            int RandomDemi = new Random().Next(1, 9999999);
            player.Dimension = RandomDemi;
            player.Position = new Position(-1084.1934f, -2720.1758f, 0.80371094f);
            player.Rotation = new Rotation(0, 0, -2.2757995f);
            player.EmitLocked("Crimelife:CharCreator:Open");
            player.SetClothes(3, 15, 0, 0); //Torso
            player.SetClothes(4, 21, 0, 0); //Hose
            player.SetClothes(6, 34, 0, 0); //Schuhe
            player.SetClothes(11, 15, 0, 0); //Top
            player.SetClothes(8, 15, 0, 0); //Undershift
            player.SetClothes(1, 0, 0, 0); // Maske
            player.openCef = true;
        }
    }

    [ClientEvent("Server:Client:ShowCharCreator")]
    public static void ServerClientShowCharCreator(LPlayer player)
    {
        if(player.LoggedIn == true)
        {
            player.EmitLocked("character:Edit", "");

        }
    }

    [ClientEvent("Server:Client:Creator:ChangeGender")]
    public static void ChangeGender(LPlayer player, string Model)
    {
        if (Model == "mp_m_freemode_01")
        {

            player.Model = (uint)PedModel.FreemodeMale01;

            player.SetClothes(3, 15, 0, 0); //Torso
            player.SetClothes(4, 21, 0, 0); //Hose
            player.SetClothes(6, 34, 0, 0); //Schuhe
            player.SetClothes(11, 15, 0, 0); //Top
            player.SetClothes(8, 15, 0, 0); //Undershift


        }
        else
        {
            player.Model = (uint)PedModel.FreemodeFemale01;
            player.SetClothes(3, 15, 0, 0); //Torso
            player.SetClothes(4, 17, 0, 0); //Hose
            player.SetClothes(6, 35, 0, 0); //Schuhe
            player.SetClothes(11, 18, 0, 0); //Top
            player.SetClothes(8, 14, 0, 0); //Undershift
        }
    }


   
    public static void LoadCharacter(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "SELECT * FROM character_aussehen WHERE accountid=@accountid";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@accountid", player.AccountID);
        cmd.ExecuteNonQuery();
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                reader.Read();

                if (reader.GetString("CREATOR_GENDER") == "mp_m_freemode_01")
                {
                    player.Model = (uint)PedModel.FreemodeMale01;
                }
                else
                {
                    player.Model = (uint)PedModel.FreemodeFemale01;
                }



                player.SetHeadBlendData(reader.GetUInt32("CREATOR_MOTHER"), reader.GetUInt32("CREATOR_FATHER"), 0, reader.GetUInt32("CREATOR_SKINCOLOR"), 0, 0, reader.GetUInt32("CREATOR_SHAPEMIX"), 0, 0);
                player.SetFaceFeature(0, float.Parse(reader.GetString("CREATOR_NASENBREITE")));
                player.SetFaceFeature(1, float.Parse(reader.GetString("CREATOR_NASENHOEHE")));
                player.SetFaceFeature(2, float.Parse(reader.GetString("CREATOR_NASENLAENGE")));
                player.SetFaceFeature(3, float.Parse(reader.GetString("CREATOR_NASENBRUECKE")));
                player.SetFaceFeature(4, float.Parse(reader.GetString("CREATOR_NASENSPITZE")));
                player.SetFaceFeature(5, float.Parse(reader.GetString("CREATOR_NASENBRUECKENVERSCHIEBUNG")));
                player.SetFaceFeature(6, float.Parse(reader.GetString("CREATOR_AUGENBRAUENHOEHE")));
                player.SetFaceFeature(7, float.Parse(reader.GetString("CREATOR_AUGENBRAUENBREITE")));
                player.SetFaceFeature(11, float.Parse(reader.GetString("CREATOR_LIPPEN")));
                player.SetFaceFeature(12, float.Parse(reader.GetString("CREATOR_NACKENBREITE")));
                player.SetFaceFeature(19, float.Parse(reader.GetString("CREATOR_AUGEN")));
                player.SetClothes(2, reader.GetUInt16("CREATOR_HAARE"), 0, 0);
                player.SetHeadOverlay(1, Convert.ToByte(reader.GetInt32("CREATOR_BART")), 1);
                player.SetHeadOverlayColor(1, 1, Convert.ToByte(reader.GetInt32("CREATOR_BARTFARBE")), 0);
                player.SetEyeColor(reader.GetUInt16("CREATOR_AUGENFARBE"));

                if (reader.GetInt32("CREATOR_AUGENBRAUEN") == -1)
                {
                    player.SetHeadOverlay(2, 0, 0);
                }
                else
                {
                    player.SetHeadOverlay(2, Convert.ToByte(reader.GetInt32("CREATOR_AUGENBRAUEN")), 1);
                }

                
                if (reader.GetInt32("CREATOR_ALTER") == -1)
                {
                    player.SetHeadOverlay(3, 0, 0);
                }
                else
                {
                    player.SetHeadOverlay(3, Convert.ToByte(reader.GetInt32("CREATOR_ALTER")), 1);
                }


                if (reader.GetInt32("CREATOR_BLUSH") == -1)
                {
                    player.SetHeadOverlay(5, 0, 0);
                }
                else
                {
                    player.SetHeadOverlay(5, Convert.ToByte(reader.GetInt32("CREATOR_BLUSH")), 1);
                }

                if (reader.GetInt32("CREATOR_MAKEUP") == -1)
                {
                    player.SetHeadOverlay(4, 0, 0);
                }
                else
                {
                    player.SetHeadOverlay(4, Convert.ToByte(reader.GetInt32("CREATOR_MAKEUP")), 1);
                }


                


                if (reader.GetInt32("CREATOR_LIPSTICK") == -1)
                {
                    player.SetHeadOverlay(8, 0, 0);
                }
                else
                {
                    player.SetHeadOverlay(8, Convert.ToByte(reader.GetInt32("CREATOR_LIPSTICK")), 1);
                }

                
                
                

            }
        }
        c.Close();
    }




    [ClientEvent("Client:Creator:STEP_1")]
    public static void ClientCreatorStep_1(LPlayer player, string GENDER, int MOTHER, int FATHER, int SKINCOLOR, int SHAPEMIX, int NASENBREITE, int NASENHOEHE, int NASENLAENGE, int NASENBRUECKE, int NASENSPITZE)
    {
        player.CREATOR_GENDER = GENDER;
        player.CREATOR_MOTHER = MOTHER;
        player.CREATOR_FATHER = FATHER;
        player.CREATOR_SKINCOLOR = SKINCOLOR;
        player.CREATOR_SHAPEMIX = SHAPEMIX;
        player.CREATOR_NASENBREITE = NASENBREITE;
        player.CREATOR_NASENHOEHE = NASENHOEHE;
        player.CREATOR_NASENLAENGE = NASENLAENGE;
        player.CREATOR_NASENBRUECKE = NASENBRUECKE;
        player.CREATOR_NASENSPITZE = NASENSPITZE;
    }

    [ClientEvent("Client:Creator:STEP_2")]
    public static void ClientCreatorStep_2(LPlayer player, int NASENBRUECKENVERSCHIEBUNG, int AUGENBRAUENHÖHE, int AUGENBRAUENBREITE, int LIPPEN, int NACKENBREITE, int AUGEN, int HAARE, int BART, int HAARFARBE, int BARTFARBE, int AUGENFARBE)
    {
        player.CREATOR_NASENBRUECKENVERSCHIEBUNG = NASENBRUECKENVERSCHIEBUNG;
        player.CREATOR_AUGENBRAUENHOEHE = AUGENBRAUENHÖHE;
        player.CREATOR_AUGENBRAUENBREITE = AUGENBRAUENBREITE;
        player.CREATOR_LIPPEN = LIPPEN;
        player.CREATOR_NACKENBREITE = NACKENBREITE;
        player.CREATOR_AUGEN = AUGEN;
        player.CREATOR_HAARE = HAARE;
        player.CREATOR_BART = BART;
        player.CREATOR_HAARFARBE = HAARFARBE;
        player.CREATOR_BARTFARBE = BARTFARBE;
        player.CREATOR_AUGENFARBE = AUGENFARBE;
    }


    [ClientEvent("Client:Creator:STEP_3")]
    public static void ClientCreatorStep_3(LPlayer player, int AUGENBRAUEN, int ALTER, int MAKEUP, int BLUSH, int LIPSTICK)
    {
        player.CREATOR_AUGENBRAUEN = AUGENBRAUEN;
        player.CREATOR_ALTER = ALTER;
        player.CREATOR_MAKEUP = MAKEUP;
        player.CREATOR_BLUSH = BLUSH;
        player.CREATOR_LIPSTICK = LIPSTICK;
        player.Emit("Crimelife:CharCreator:Close");
        player.Dimension = 0;
        player.SendNotification("1", "", "Dein Character wurde erfolgreich erstellt.", 6);
        if (PlayerHasChar(player) == false)
        {
            CreateNewChar(player);
            player.Emit("OpenTeamSelect");
            player.openCef = false;
        }
        else
        {
            UpdateChar(player);
            player.Emit("OpenTeamSelect");
            player.openCef = false;
        }

    }

    public static void UpdateChar(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "UPDATE character_aussehen SET CREATOR_GENDER=@CREATOR_GENDER, " +
            "CREATOR_MOTHER=@CREATOR_MOTHER, " +
            "CREATOR_FATHER=@CREATOR_FATHER, " +
            "CREATOR_SKINCOLOR=@CREATOR_SKINCOLOR," +
            "CREATOR_SHAPEMIX=@CREATOR_SHAPEMIX, " +
            "CREATOR_NASENBREITE=@CREATOR_NASENBREITE, " +
            "CREATOR_NASENHOEHE=@CREATOR_NASENHOEHE, " +
            "CREATOR_NASENLAENGE=@CREATOR_NASENLAENGE, " +
            "CREATOR_NASENBRUECKE=@CREATOR_NASENBRUECKE, " +
            "CREATOR_NASENSPITZE=@CREATOR_NASENSPITZE, " +
            "CREATOR_NASENBRUECKENVERSCHIEBUNG=@CREATOR_NASENBRUECKENVERSCHIEBUNG, " +
            "CREATOR_AUGENBRAUENHOEHE=@CREATOR_AUGENBRAUENHOEHE, " +
            "CREATOR_AUGENBRAUENBREITE=@CREATOR_AUGENBRAUENBREITE, " +
            "CREATOR_LIPPEN=@CREATOR_LIPPEN, " +
            "CREATOR_NACKENBREITE=@CREATOR_NACKENBREITE, " +
            "CREATOR_AUGEN=@CREATOR_AUGEN, " +
            "CREATOR_HAARE=@CREATOR_HAARE, " +
            "CREATOR_BART=@CREATOR_BART, " +
            "CREATOR_HAARFARBE=@CREATOR_HAARFARBE, " +
            "CREATOR_BARTFARBE=@CREATOR_BARTFARBE, " +
            "CREATOR_AUGENFARBE=@CREATOR_AUGENFARBE, " +
            "CREATOR_AUGENBRAUEN=@CREATOR_AUGENBRAUEN, " +
            "CREATOR_ALTER=@CREATOR_ALTER, " +
            "CREATOR_MAKEUP=@CREATOR_MAKEUP, " +
            "CREATOR_BLUSH=@CREATOR_BLUSH, " +
            "CREATOR_LIPSTICK=@CREATOR_LIPSTICK" +
            " WHERE id=@accountid";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@accountid", player.AccountID);
        cmd.Parameters.AddWithValue("@CREATOR_GENDER", player.CREATOR_GENDER);
        cmd.Parameters.AddWithValue("@CREATOR_MOTHER", player.CREATOR_MOTHER);
        cmd.Parameters.AddWithValue("@CREATOR_FATHER", player.CREATOR_FATHER);
        cmd.Parameters.AddWithValue("@CREATOR_SKINCOLOR", player.CREATOR_SKINCOLOR);
        cmd.Parameters.AddWithValue("@CREATOR_SHAPEMIX", player.CREATOR_SHAPEMIX);
        cmd.Parameters.AddWithValue("@CREATOR_NASENBREITE", player.CREATOR_NASENBREITE);
        cmd.Parameters.AddWithValue("@CREATOR_NASENHOEHE", player.CREATOR_NASENHOEHE);
        cmd.Parameters.AddWithValue("@CREATOR_NASENLAENGE", player.CREATOR_NASENLAENGE);
        cmd.Parameters.AddWithValue("@CREATOR_NASENBRUECKE", player.CREATOR_NASENBRUECKE);
        cmd.Parameters.AddWithValue("@CREATOR_NASENSPITZE", player.CREATOR_NASENSPITZE);
        cmd.Parameters.AddWithValue("@CREATOR_NASENBRUECKENVERSCHIEBUNG", player.CREATOR_NASENBRUECKENVERSCHIEBUNG);
        cmd.Parameters.AddWithValue("@CREATOR_AUGENBRAUENHOEHE", player.CREATOR_AUGENBRAUENHOEHE);
        cmd.Parameters.AddWithValue("@CREATOR_AUGENBRAUENBREITE", player.CREATOR_AUGENBRAUENBREITE);
        cmd.Parameters.AddWithValue("@CREATOR_LIPPEN", player.CREATOR_LIPPEN);
        cmd.Parameters.AddWithValue("@CREATOR_NACKENBREITE", player.CREATOR_NACKENBREITE);
        cmd.Parameters.AddWithValue("@CREATOR_AUGEN", player.CREATOR_AUGEN);
        cmd.Parameters.AddWithValue("@CREATOR_HAARE", player.CREATOR_HAARE);
        cmd.Parameters.AddWithValue("@CREATOR_BART", player.CREATOR_BART);
        cmd.Parameters.AddWithValue("@CREATOR_HAARFARBE", player.CREATOR_HAARFARBE);
        cmd.Parameters.AddWithValue("@CREATOR_BARTFARBE", player.CREATOR_BARTFARBE);
        cmd.Parameters.AddWithValue("@CREATOR_AUGENFARBE", player.CREATOR_AUGENFARBE);
        cmd.Parameters.AddWithValue("@CREATOR_AUGENBRAUEN", player.CREATOR_AUGENBRAUEN);
        cmd.Parameters.AddWithValue("@CREATOR_ALTER", player.CREATOR_ALTER);
        cmd.Parameters.AddWithValue("@CREATOR_MAKEUP", player.CREATOR_MAKEUP);
        cmd.Parameters.AddWithValue("@CREATOR_BLUSH", player.CREATOR_BLUSH);
        cmd.Parameters.AddWithValue("@CREATOR_LIPSTICK", player.CREATOR_LIPSTICK);
        cmd.ExecuteNonQuery();
        c.Close();
    }


    public static void CreateNewChar(LPlayer player)
    {
        MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
        c.Open();
        string cmdText = "INSERT INTO character_aussehen (accountid, " +
            "CREATOR_GENDER, " +
            "CREATOR_MOTHER, " +
            "CREATOR_FATHER, " +
            "CREATOR_SKINCOLOR, " +
            "CREATOR_SHAPEMIX, " +
            "CREATOR_NASENBREITE, " +
            "CREATOR_NASENHOEHE, " +
            "CREATOR_NASENLAENGE, " +
            "CREATOR_NASENBRUECKE, " +
            "CREATOR_NASENSPITZE, " +
            "CREATOR_NASENBRUECKENVERSCHIEBUNG, " +
            "CREATOR_AUGENBRAUENHOEHE, " +
            "CREATOR_AUGENBRAUENBREITE, " +
            "CREATOR_LIPPEN, " +
            "CREATOR_NACKENBREITE, " +
            "CREATOR_AUGEN, " +
            "CREATOR_HAARE, " +
            "CREATOR_BART, " +
            "CREATOR_HAARFARBE, " +
            "CREATOR_BARTFARBE, " +
            "CREATOR_AUGENFARBE, " +
            "CREATOR_AUGENBRAUEN, " +
            "CREATOR_ALTER, " +
            "CREATOR_MAKEUP, " +
            "CREATOR_BLUSH, " +
            "CREATOR_LIPSTICK" +
            ") VALUES (@accountid, " +
            "@CREATOR_GENDER, " +
            "@CREATOR_MOTHER, " +
            "@CREATOR_FATHER, " +
            "@CREATOR_SKINCOLOR, " +
            "@CREATOR_SHAPEMIX, " +
            "@CREATOR_NASENBREITE, " +
            "@CREATOR_NASENHOEHE, " +
            "@CREATOR_NASENLAENGE, " +
            "@CREATOR_NASENBRUECKE, " +
            "@CREATOR_NASENSPITZE, " +
            "@CREATOR_NASENBRUECKENVERSCHIEBUNG, " +
            "@CREATOR_AUGENBRAUENHOEHE, " +
            "@CREATOR_AUGENBRAUENBREITE, " +
            "@CREATOR_LIPPEN, " +
            "@CREATOR_NACKENBREITE, " +
            "@CREATOR_AUGEN, " +
            "@CREATOR_HAARE, " +
            "@CREATOR_BART, " +
            "@CREATOR_HAARFARBE, " +
            "@CREATOR_BARTFARBE, " +
            "@CREATOR_AUGENFARBE, " +
            "@CREATOR_AUGENBRAUEN, " +
            "@CREATOR_ALTER, " +
            "@CREATOR_MAKEUP, " +
            "@CREATOR_BLUSH, " +
            "@CREATOR_LIPSTICK)";
        MySqlCommand cmd = new MySqlCommand(cmdText, c);
        cmd.Parameters.AddWithValue("@accountid", player.AccountID);
        cmd.Parameters.AddWithValue("@CREATOR_GENDER", player.CREATOR_GENDER);
        cmd.Parameters.AddWithValue("@CREATOR_MOTHER", player.CREATOR_MOTHER);
        cmd.Parameters.AddWithValue("@CREATOR_FATHER", player.CREATOR_FATHER);
        cmd.Parameters.AddWithValue("@CREATOR_SKINCOLOR", player.CREATOR_SKINCOLOR);
        cmd.Parameters.AddWithValue("@CREATOR_SHAPEMIX", player.CREATOR_SHAPEMIX);
        cmd.Parameters.AddWithValue("@CREATOR_NASENBREITE", player.CREATOR_NASENBREITE);
        cmd.Parameters.AddWithValue("@CREATOR_NASENHOEHE", player.CREATOR_NASENHOEHE);
        cmd.Parameters.AddWithValue("@CREATOR_NASENLAENGE", player.CREATOR_NASENLAENGE);
        cmd.Parameters.AddWithValue("@CREATOR_NASENBRUECKE", player.CREATOR_NASENBRUECKE);
        cmd.Parameters.AddWithValue("@CREATOR_NASENSPITZE", player.CREATOR_NASENSPITZE);
        cmd.Parameters.AddWithValue("@CREATOR_NASENBRUECKENVERSCHIEBUNG", player.CREATOR_NASENBRUECKENVERSCHIEBUNG);
        cmd.Parameters.AddWithValue("@CREATOR_AUGENBRAUENHOEHE", player.CREATOR_AUGENBRAUENHOEHE);
        cmd.Parameters.AddWithValue("@CREATOR_AUGENBRAUENBREITE", player.CREATOR_AUGENBRAUENBREITE);
        cmd.Parameters.AddWithValue("@CREATOR_LIPPEN", player.CREATOR_LIPPEN);
        cmd.Parameters.AddWithValue("@CREATOR_NACKENBREITE", player.CREATOR_NACKENBREITE);
        cmd.Parameters.AddWithValue("@CREATOR_AUGEN", player.CREATOR_AUGEN);
        cmd.Parameters.AddWithValue("@CREATOR_HAARE", player.CREATOR_HAARE);
        cmd.Parameters.AddWithValue("@CREATOR_BART", player.CREATOR_BART);
        cmd.Parameters.AddWithValue("@CREATOR_HAARFARBE", player.CREATOR_HAARFARBE);
        cmd.Parameters.AddWithValue("@CREATOR_BARTFARBE", player.CREATOR_BARTFARBE);
        cmd.Parameters.AddWithValue("@CREATOR_AUGENFARBE", player.CREATOR_AUGENFARBE);
        cmd.Parameters.AddWithValue("@CREATOR_AUGENBRAUEN", player.CREATOR_AUGENBRAUEN);
        cmd.Parameters.AddWithValue("@CREATOR_ALTER", player.CREATOR_ALTER);
        cmd.Parameters.AddWithValue("@CREATOR_MAKEUP", player.CREATOR_MAKEUP);
        cmd.Parameters.AddWithValue("@CREATOR_BLUSH", player.CREATOR_BLUSH);
        cmd.Parameters.AddWithValue("@CREATOR_LIPSTICK", player.CREATOR_LIPSTICK);
        cmd.ExecuteNonQuery();
        c.Close();
    }

    public static bool PlayerHasChar(LPlayer player)
    {
        try
        {
            MySqlConnection c = new MySqlConnection(DatenbankMain.ConnectionString);
            c.Open();
            string cmdText = "SELECT accountid FROM character_aussehen WHERE accountid=@accountid";
            MySqlCommand cmd = new MySqlCommand(cmdText, c);
            cmd.Parameters.AddWithValue("@accountid", player.AccountID);
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

    public static void CreateModuleDoActions(LPlayer player)
    {
        player.Position = new Position(-1039.0022f, -2740.721f, 13.862305f);
        player.Rotation = new Rotation(0, 0, -0.49473903f);
        
    }
}