using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using AltV.Net.Resources.Chat.Api;

public class KeyHandler : IScript
{
    [ClientEvent("punktkeypressed")]
    public static async void punktkeypressed(LPlayer player)
    {
        if (player.Exists == false) return;
        if (player.BenutztGradeSchutzweste || player.BenutztGradeMedkit || player.Dead || player.IsInVehicle || player.IsInRagdoll)
        {

        }
        else
        {
            player.Emit("openProgressbar");
            player.BenutztGradeSchutzweste = true;
            player.BenutztGradeMedkit = true;
            player.Emit("PlayAnimation", "anim@heists@narcotics@funding@gang_idle", "gang_chatting_idle01", 4200, 3);
            player.Frozen = true;

            await Task.Delay(4200);
            {
                if (player.Exists == false) return;
                if (player.Abbrechen == true)
                {
                    player.BenutztGradeMedkit = false;
                    player.BenutztGradeSchutzweste = false;
                    player.Frozen = false;
                    player.Abbrechen = false;
                }
                else
                {
                    player.SendNotification("1", "", "Du hast erfolgreich eine Schutzweste verwendet!", 6);

                    player.BenutztGradeSchutzweste = false;
                    player.BenutztGradeMedkit = false;

                    player.Frozen = false;

                    player.Armor = 100;

                    player.Emit("closeprogessbar");
                }
            }
        }
    }

    [ClientEvent("commakeypressed")]
    public static async void commakeypressed(LPlayer player)
    {
        if (player.Exists == false) return;
        if (player.BenutztGradeSchutzweste || player.BenutztGradeMedkit || player.Dead || player.IsInVehicle || player.IsInRagdoll)
        {
        }
        else
        {
            player.Emit("openProgressbar");
            player.BenutztGradeMedkit = true;
            player.BenutztGradeSchutzweste = true;
            player.Emit("PlayAnimation", "amb@medic@standing@tendtodead@idle_a", "idle_a", 4200, 3);
            player.Frozen = true;

            await Task.Delay(4200);
            {
                if (player.Exists == false) return;
                if (player.Abbrechen == true)
                {
                    player.BenutztGradeMedkit = false;
                    player.BenutztGradeSchutzweste = false;
                    player.Frozen = false;
                    player.Abbrechen = false;
                }
                else
                {
                    player.SendNotification("1", "", "Du hast erfolgreich eine Medkit verwendet!", 6);
                    player.BenutztGradeMedkit = false;
                    player.BenutztGradeSchutzweste = false;
                    player.Frozen = false;
                    player.Health = 200;
                    player.Abbrechen = false;
                    player.Emit("closeprogessbar");
                }
            }
        }
    }

    [ClientEvent("Keypress:E")]
    public void KeypressE(LPlayer player)
    {
        if (player.BenutztGradeMedkit == true && player.BenutztGradeSchutzweste == true)
        {
            player.Abbrechen = true;
            player.Frozen = false;
            player.Emit("clearPedTasks");
            player.Emit("closeprogessbar");
        }
    }

    [ClientEvent("Keypress:F2")]
    public void KeypressF2(LPlayer player)
    {
        if (player.openCef == false && player.isFfa == false && player.Dead == false && player.IsInVehicle == false)
        {
            player.Emit("OpenTeamSelect");
            player.openCef = true;
            Teamauswahl.updateTeamCounter(player);
        }
    }

    [ClientEvent("Keypress:F1")]
    public void KeypressF1(LPlayer player)
    {
        if (player.Hitmaker == 0)
        {
            player.SendChatMessage("Hitmaker Aktiviert!");
            player.Hitmaker = 1;
        }
        else
        {
            player.Hitmaker = 0;
            player.SendChatMessage("Hitmaker Deaktiviert!");
        }
    }

    /*[ClientEvent("Keypress:F4")]
    public static async void keypressf4(LPlayer player)
    {
        if (player.IsInVehicle)
        {
            player.Emit("openProgressbar");
            player.Frozen = true;
            await Task.Delay(4200);
            {
                player.Vehicle.Repair();
                player.Emit("closeprogessbar");
                player.Frozen = false;
            }
        }
    }*/
}