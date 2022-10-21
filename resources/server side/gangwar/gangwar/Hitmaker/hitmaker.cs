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

public class hitmaker : IScript
{
    [ScriptEvent(ScriptEventType.WeaponDamage)]
    public void OnWeaponDamage(IPlayer player, IEntity target, uint weapon, ushort damage, Position offset, BodyPart bodyPart)
    {
        
    }
}
