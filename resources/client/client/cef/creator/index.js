/*let charcreator = null,
charcreatorcam = null,
player = alt.p;

mp.events.add("LimitV:ClientEvent:UI:Open:Charcreator", () => {
    if (!charcreator)
    {
        charcreator = mp.browsers.new("package://CEF/Charcreator/index.html");
        setTimeout(() => {
            mp.gui.cursor.visible = true;
            mp.game.ui.displayRadar(false);
            mp.game.ui.displayHud(false);
            mp.players.local.freezePosition(true);
            mp.gui.chat.activate(false);
        }, 500);

        if (!charcreatorcam)
        {
            charcreatorcam = mp.cameras.new('default', new mp.Vector3(402.8664, -997.5515, -98.5), new mp.Vector3(0,0,0), 40);

            charcreatorcam.pointAtCoord(402.8664, -994.4108, -98.5);
            charcreatorcam.setActive(true);
            mp.game.cam.renderScriptCams(true, false, 0, true, false);
        }
    }
});

mp.events.add("LimitV:ClientEvent:UI:Close:Charcreator", () => {
    if (charcreator)
    {
        charcreator.destroy();
        charcreator = null;

        if (charcreatorcam)
        {
            charcreatorcam.destroy();
            charcreatorcam = null;
            mp.game.cam.renderScriptCams(false, false, 0, false, false);
        }
    }
});

mp.events.add("LimitV:ClientEvent:UI:TryCreateChar", (arr) => {
    if (charcreator)
    {
        mp.events.callRemote("LimitV:ServerEvent:UI:TryCreateChar", arr);
    }
});

//Gender

mp.events.add("LimitV:UIEvent:Trigger:Charcreator:Changegender", (newgender) => {
    if (charcreator)
    {
        player.model = mp.game.joaat(newgender);
    }
});

//Parents

mp.events.add("LimitV:UIEvent:Trigger:Charcreator:UpdateParents", (mother, father, skinColor, shapeMix) => {
    if (charcreator)
    {
        mp.players.local.setHeadBlendData(parseInt(father), parseInt(mother), 0, parseInt(skinColor), 0, 0, parseFloat(shapeMix), 0, 0, false);
    }
});

//Face Features

mp.events.add("LimitV:UIEvent:Trigger:Charcreator:UpdateFace", (nasenbreite, nasenhoehe, nasenlaenge, nasenbruecke, nasenspitze, nasenbrueckenverschiebung, augenbrauenhoehe, augenbrauenbreite, augen, lippen, nackenbreite) => {
    if (charcreator)
    {
        mp.players.local.setFaceFeature(0, parseInt(nasenbreite));
        mp.players.local.setFaceFeature(1, parseInt(nasenhoehe));
        mp.players.local.setFaceFeature(2, parseInt(nasenlaenge));
        mp.players.local.setFaceFeature(3, parseInt(nasenbruecke));
        mp.players.local.setFaceFeature(4, parseInt(nasenspitze));
        mp.players.local.setFaceFeature(5, parseInt(nasenbrueckenverschiebung));
        mp.players.local.setFaceFeature(6, parseInt(augenbrauenhoehe));
        mp.players.local.setFaceFeature(7, parseInt(augenbrauenbreite));
        mp.players.local.setFaceFeature(11, parseInt(augen));
        mp.players.local.setFaceFeature(12, parseInt(lippen));
        mp.players.local.setFaceFeature(19, parseInt(nackenbreite));
    }
});

//Frisur

mp.events.add("LimitV:UIEvent:Trigger:Charcreator:UpdateFrisur", (haare, bart) => {
    if (charcreator)
    {
        mp.players.local.setComponentVariation(2, parseInt(haare), 0, 2);
        mp.players.local.setHeadOverlay(1, parseInt(bart), 255, 0, 0);
    }
});

//Frisurfarbe

mp.events.add("LimitV:UIEvent:Trigger:Charcreator:UpdateFrisurFarbe", (haarfarbe, bart, bartfarbe) => {
    if (charcreator)
    {
        mp.players.local.setHairColor(parseInt(haarfarbe), parseInt(haarfarbe));
        mp.players.local.setHeadOverlay(1, parseInt(bart), 255, parseInt(bartfarbe), parseInt(bartfarbe));
    }
});

//Augenfarbe

mp.events.add("LimitV:UIEvent:Trigger:Charcreator:UpdateEyeColor", (augenfarbe) => {
    if (charcreator)
    {
        mp.players.local.setEyeColor(parseInt(augenfarbe));
    }
});

//Augenbrauen

mp.events.add("LimitV:UIEvent:Trigger:Charcreator:UpdateEyeBrow", (augenbrauen) => {
    if (charcreator)
    {
        mp.players.local.setHeadOverlay(2, parseInt(augenbrauen), 255, 0, 0);
    }
});

//Alter

mp.events.add("LimitV:UIEvent:Trigger:Charcreator:UpdateAlter", (alter) => {
    if (charcreator)
    {
        mp.players.local.setHeadOverlay(3, parseInt(alter), 255, 0, 0);
    }
});

//MakeUp

mp.events.add("LimitV:UIEvent:Trigger:Charcreator:UpdateMakeUp", (makeup) => {
    if (charcreator)
    {
        mp.players.local.setHeadOverlay(4, parseInt(makeup), 255, 0, 0);
    }
});

//Blush

mp.events.add("LimitV:UIEvent:Trigger:Charcreator:UpdateBlush", (blush) => {
    if (charcreator)
    {
        mp.players.local.setHeadOverlay(5, parseInt(blush), 255, 0, 0);
    }
});

//Lipstick

mp.events.add("LimitV:UIEvent:Trigger:Charcreator:UpdateLipstick", (lipstick) => {
    if (charcreator)
    {
        mp.players.local.setHeadOverlay(8, parseInt(lipstick), 255, 0, 0);
    }
});*/