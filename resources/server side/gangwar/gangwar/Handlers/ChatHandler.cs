using AltV.Net;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

class ChatHandler : IScript
{
    [ClientEvent("chat:message")]
    public void onchatmessage(LPlayer player, string msg)
    {
        if(player.LoggedIn == false) return;
        if (player.Muted == 1)
        {
            player.SendChatMessage("Du bist gemuted!");
            return;
        }
        if(msg.Contains("hurensohn") || msg.Contains("ritzen") || msg.Contains("schwul") || msg.Contains("selbstmord") || msg.Contains("hure") || msg.Contains("bastard") || msg.Contains("nigga"))
        {
            BanHandler.MutePlayer(player, player.AccountName, "Blacklisted Wort");
            return;
        }

        if (msg.Length == 0 || msg[0] == '/') return;

        foreach(LPlayer target in Alt.GetAllPlayers())
        {
            target.SendChatMessage($"[{player.AdminLevelName}] [{player.AccountID}] {player.AccountName}: {msg}");
        }
    }

    public static void SendGlobalMessage(object sender, ElapsedEventArgs e)
    {
        int Random = new Random().Next(1, 2);
        if(Random == 1)
        {
            foreach (LPlayer target in Alt.GetAllPlayers())
            {
                target.SendChatMessage("[{008EC3}INFO{FFFFFF}] discord: https://discord.gg/AaTdW6FC");
            }
        }
        if (Random == 2)
        {
            foreach (LPlayer target in Alt.GetAllPlayers())
            {
                target.SendChatMessage("[{008EC3}INFO{FFFFFF}] discord: https://discord.gg/AaTdW6FC");
            }
        }
    }
}