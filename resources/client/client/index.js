import * as alt from 'alt-client';
import * as native from 'natives';

alt.on("connectionComplete", () => {
    alt.emitServer("Server:Client:ConnectionComplete", native.scGetNickname()); //Kann Gespoofed werden
    loadBlips();
});

alt.requestIpl("RC12B_Fixed");

alt.setStat("stamina", 100);
alt.setStat("strength", 100);
alt.setStat("lung_capacity", 100);
alt.setStat("wheelie_ability", 100);
alt.setStat("flying_ability", 100);
alt.setStat("shooting_ability", 100);
alt.setStat("stealth_ability", 100);

//Login

let LoginWeb = null;
alt.onServer("Client:Login:Show", ShowLogin);
alt.onServer("Client:Login:Destroy", DestroyLogin);

function ShowLogin() {

    if (LoginWeb == null)
    {
        native.displayRadar(false);
        alt.setConfigFlag("DISABLE_IDLE_CAMERA", true);
        LoginWeb = new alt.WebView("http://resource/client/cef/login/register.html");
        LoginWeb.focus();
        alt.toggleGameControls(false);
        alt.showCursor(true);

        LoginWeb.on("Auth.Login", (name) => {
            alt.emitServer("Server:Login:Login", name);
        });

        LoginWeb.on("Auth.Register", (name) => {
            alt.emitServer("Server:Login:Register", name);
        });
    }
}

function DestroyLogin() {
    if (LoginWeb != null)
    {
        LoginWeb.unfocus();
        LoginWeb.destroy();
        alt.showCursor(false);
        alt.toggleGameControls(true);
    }
}


//Notify
alt.onServer("Client:Notify:Show", ShowNotify);
let NotifyGui = new alt.WebView("http://resource/client/cef/notify/html/index.html");

function ShowNotify(type, duration, title, message) {
    NotifyGui.focus();
    alt.setTimeout(() => {
        NotifyGui.unfocus();
    }, 6000);

    if (NotifyGui)
    {
        NotifyGui.emit('notifications:create', { 
            id: 0, 
            type: type, 
            duration: duration, 
            title: title, 
            message: message 
        });
    }
}

alt.onServer("Client:GlobalNotify:Show", showGlobalNotify);
let GlobalNotifyGui = new alt.WebView("http://resource/client/cef/globalnotify/html/index.html");

function showGlobalNotify(type, duration, title, message) {
    if (GlobalNotifyGui)
    {
        GlobalNotifyGui.emit('globalnotifications:create', { 
            id: 0, 
            type: type, 
            duration: duration, 
            title: title, 
            message: message 
        });
    }
}

//CharAuswahl

let charweb;

alt.onServer("Client:Char:ShowAuswahl", (charitems) => {
    native.displayRadar(false);
    charweb = new alt.WebView("http://resource/client/cef/char/characters.html");
    charweb.focus();
    charweb.emit("LoadCharacters", charitems);
    alt.showCursor(true);
    alt.toggleGameControls(false);
    native.taskSetBlockingOfNonTemporaryEvents(alt.Player.local, true);

    charweb.on("SelectCharacter", (name) => {
        alt.emitServer("Server:Client:SelectChar", name);
        alt.showCursor(false);
		charweb.unfocus();
        charweb.destroy();
        alt.setTimeout(() => {
            alt.toggleGameControls(true);
            native.setPlayerInvincible(alt.Player.local.scriptID, false);
            native.taskSetBlockingOfNonTemporaryEvents(alt.Player.local, false);
            native.displayRadar(true);
        }, 3000);
    });

    charweb.on("ClientPreviewCharacterID", (id) => {
        alt.emitServer("Server:Client:PreviewChar", id);
    });

    charweb.on("CreateCharacter", () => {
        alt.emitServer("Server:Client:ShowCharCreator");
        charweb.unfocus();
        charweb.destroy();
    });
});



//CharCreator
let charcreator = null,
charcreatorcam = null,
player = alt.Player.local;


alt.onServer("Client:SetChar", SetChar);

function SetChar (arr)
{
    let gender = arr[0];
    alt.log(gender)
}



alt.onServer("Crimelife:CharCreator:Open", OpenCreator);
alt.onServer("Crimelife:CharCreator:Close", CloseCreator);
alt.onServer("Crimelife:CharCreator:Create", CreateChar);
function OpenCreator()
{
    setTimeout(() => {

        if (!charcreator)
        {
            charcreator = new alt.WebView("http://resource/client/cef/creator/index.html");
            charcreator.focus();
    
    
            charcreator.on("UpdateParents", UpdateParents);
            charcreator.on("Changegender", Changegender);
            charcreator.on("UpdateFace", UpdateFace);
            charcreator.on("UpdateFrisur", UpdateFrisur);
            charcreator.on("UpdateFrisurFarbe", UpdateFrisurFarbe);
            charcreator.on("UpdateEyeColor", UpdateEyeColor);
            charcreator.on("UpdateEyeBrow", UpdateEyeBrow);
            charcreator.on("UpdateAlter", UpdateAlter);
            charcreator.on("UpdateMakeUp", UpdateMakeUp);
            charcreator.on("UpdateBlush", UpdateBlush);
            charcreator.on("UpdateLipstick", UpdateLipstick);
            charcreator.on("TryCreateChar", CreateChar);
    
    
            
            setTimeout(() => {
                alt.showCursor(true);
                alt.toggleGameControls(false);
            }, 500);
    
            if (!charcreatorcam)
            {
                charcreatorcam = native.createCamWithParams('DEFAULT_SCRIPTED_CAMERA', -1083.0725, -2720.9539, 1.40371094, 0, 0, 50, 50, false, 0);
                //charcreatorcam.pointAtCoord(402.8664, -994.4108, -98.5);
                native.setCamActive(charcreatorcam, true);
                //mp.game.cam.renderScriptCams(true, false, 0, true, false);
                native.renderScriptCams(true, false, 0, true, false, 0);
            }
        }
    }, 200);
    
}
alt.onServer("ToggleAn", () => {

    alt.toggleGameControls(true);
    native.displayRadar(true);
});

function CloseCreator() 
{
    if (charcreator)
    {
        charcreator.destroy();
        charcreator = null;
        alt.showCursor(false);
        alt.toggleGameControls(true);
        native.displayRadar(true);

        if (charcreatorcam)
        {
            native.destroyCam(charcreatorcam, true);
            charcreatorcam = null;
            native.renderScriptCams(false, false, 0, false, false, 0);
        }
    }
}

function CreateChar(arr) 
{
    if (charcreator)
    {
        let gender = arr[0];
        let mother = arr[1];
        let father = arr[2];
        let skinColor = arr[3];
        let shapeMix = arr[4];
        let nasenbreite = arr[5];
        let nasenhoehe = arr[6];
        let nasenlaenge = arr[7];
        let nasenbruecke = arr[8];
        let nasenspitze = arr[9];
        let nasenbrueckenverschiebung = arr[10];
        let augenbrauenhoehe = arr[11];
        let augenbrauenbreite = arr[12];
        let lippen = arr[13];
        let nackenbreite = arr[14];
        let augen = arr[15];
        let haare = arr[16];
        let bart = arr[17];
        let haarfarbe = arr[18];
        let bartfarbe = arr[19];
        let augenfarbe = arr[20];
        let augenbrauen = arr[21];
        let alter = arr[22];
        let makeup = arr[23];
        let blush = arr[24];
        let lipstick = arr[25];



        alt.log(arr);
        alt.emitServer("Client:Creator:STEP_1", gender, mother, father, skinColor, shapeMix, nasenbreite, nasenhoehe, nasenlaenge, nasenbruecke, nasenspitze);
        alt.emitServer("Client:Creator:STEP_2", nasenbrueckenverschiebung, augenbrauenhoehe, augenbrauenbreite, lippen, nackenbreite, augen, haare, bart, haarfarbe, bartfarbe, augenfarbe);
        alt.emitServer("Client:Creator:STEP_3", augenbrauen, alter, makeup, blush, lipstick);
    
    }
}


//Gender
function Changegender(newgender)
{
    alt.log(newgender);
    if (charcreator)
    {
        
        alt.emitServer("Server:Client:Creator:ChangeGender", newgender);
        
        
    }
}
//Parents
function UpdateParents(mother, father, skinColor, shapeMix)
{
    if (charcreator)
    {
        native.setPedHeadBlendData(player, parseInt(father), parseInt(mother), 0, parseInt(skinColor), 0, 0, parseFloat(shapeMix), 0, 0, false);
    }
}

//Face Features
function UpdateFace(nasenbreite, nasenhoehe, nasenlaenge, nasenbruecke, nasenspitze, nasenbrueckenverschiebung, augenbrauenhoehe, augenbrauenbreite, augen, lippen, nackenbreite)
{
    if (charcreator)
    {
        native.setPedFaceFeature(player, 0, parseInt(nasenbreite));
        native.setPedFaceFeature(player, 1, parseInt(nasenhoehe));
        native.setPedFaceFeature(player, 2, parseInt(nasenlaenge));
        native.setPedFaceFeature(player, 3, parseInt(nasenbruecke));
        native.setPedFaceFeature(player, 4, parseInt(nasenspitze));
        native.setPedFaceFeature(player, 5, parseInt(nasenbrueckenverschiebung));
        native.setPedFaceFeature(player, 6, parseInt(augenbrauenhoehe));
        native.setPedFaceFeature(player, 7, parseInt(augenbrauenbreite));
        native.setPedFaceFeature(player, 11, parseInt(augen));
        native.setPedFaceFeature(player, 12, parseInt(lippen));
        native.setPedFaceFeature(player, 19, parseInt(nackenbreite));
    }
}


//Frisur

function UpdateFrisur(haare, bart, haarfarbe, bartfarbe)
{
    native.setPedComponentVariation(alt.Player.local, 2, parseInt(haare), 0, 0);
    native.setPedHeadOverlay(alt.Player.local, 1, parseInt(bart), 1);
    native.setPedHairColor(alt.Player.local, parseInt(haarfarbe), 0);
    native.setPedHeadOverlayColor(alt.Player.local, 1, 1, parseInt(bartfarbe), 0);
}

//Frisurfarbe
function UpdateFrisurFarbe (haarfarbe, bartfarbe)
{
    if (charcreator)
    {
        native.setPedHairColor(alt.Player.local, parseInt(haarfarbe), 0);
        native.setPedHeadOverlayColor(alt.Player.local, 1, 1, parseInt(bartfarbe), 0);
    }
}

//Augenfarbe
function UpdateEyeColor(augenfarbe)
{
    native.setPedEyeColor(alt.Player.local, parseInt(augenfarbe));
}


//Augenbrauen
function UpdateEyeBrow(augenbrauen)
{
    native.setPedHeadOverlay(alt.Player.local, 2, parseInt(augenbrauen), 1);
}


//Alter
function UpdateAlter(alter)
{
    native.setPedHeadOverlay(alt.Player.local, 3, parseInt(alter), 1);
}

//MakeUp
function UpdateMakeUp(makeup)
{
    native.setPedHeadOverlay(alt.Player.local, 4, parseInt(makeup), 1);
}

//Blush
function UpdateBlush(blush)
{
    native.setPedHeadOverlay(alt.Player.local, 5, parseInt(blush), 1);
}

//Lipstick
function UpdateLipstick(lipstick)
{
    native.setPedHeadOverlay(alt.Player.local, 8, parseInt(lipstick), 1);
}


// Speedo
let speedoWindow = null;

alt.on('enteredVehicle', playerEnterVehicleHandler);
alt.on('leftVehicle', () =>
{
    if(speedoWindow != null)
    {
        speedoWindow.destroy();
        speedoWindow = null;
    }
});

function playerEnterVehicleHandler(vehicle, seat)
{
    if(speedoWindow != null)
    {
        speedoWindow.destroy();
        speedoWindow = null;
    }
    speedoWindow = new alt.WebView("http://resource/client/cef/speedo/index.html");
}

alt.everyTick(() =>{
    let vehicle = player.vehicle;

    if(player.vehicle != null && speedoWindow != null)
    {
        let speed = vehicle.speed*3.6;
        speedoWindow.emit(`updateSpeed`, speed);

        let gear = vehicle.gear;
        speedoWindow.emit(`updateGear`, gear);
    }
});

//Progressbar
let progressbar = null;

alt.onServer("openProgressbar", openProgressbarBrowser)

let freeze = false;

alt.everyTick(() => {
            native.disableControlAction(0, 140, true); 
            native.disableControlAction(0, 141, true); 
            native.disableControlAction(0, 142, true); 
            native.disableControlAction(0, 143, true);
});

function openProgressbarBrowser()
{
    freeze = true;
    progressbar = new alt.WebView("http://resource/client/cef/progressbar/index.html");
}

alt.onServer("closeprogessbar", hideProgressbarBrowser);

function hideProgressbarBrowser()
{
    freeze = false;
    progressbar.destroy();
}

//weste und medkit

alt.on('keyup', (key) => {
    if(key == 0xBC) { // komma
      alt.emitServer("commakeypressed");
    }
    if (key == 117)
    {
        alt.emitServer("Keypress:F6");
    }
    if (key == 69)
    {
        alt.emitServer("Keypress:E");
    }
    if (key == 113)
    {
        alt.emitServer("Keypress:F2");
    }
    if (key == 114)
    {
        alt.emitServer("Keypress:F3");
    }
    if (key == 115)
    {
        alt.emitServer("Keypress:F4");
    }
    if (key == 112)
    {
        alt.emitServer("Keypress:F1");
    }
});

alt.on('keyup', (key) => {
    if(key == 0xBE) { // punkt
      alt.emitServer("punktkeypressed");
    }
});

//Animation

alt.onServer('PlayAnimation', (animDict, animName, duration, flag) => {
    native.requestAnimDict(animDict);
    let interval = alt.setInterval(() => {
        if (native.hasAnimDictLoaded(animDict)) {
            alt.clearInterval(interval);
            native.taskPlayAnim(alt.Player.local.scriptID, animDict, animName, 8.0, 8.0, duration, flag, 1, false, false, false);
        }
    }, 0);
});

alt.onServer("clearPedTasks", () =>{
    native.clearPedTasks(player)
})

//admintext

alt.onServer("openAdminWindow", openAdminWindow);
alt.onServer("closeAdminWindow", closeAdminWindow);

let AdminWindow = null;

function openAdminWindow()
{
    AdminWindow = new alt.WebView("http://resource/client/cef/adminwindow/index.html");
}

function closeAdminWindow()
{
    AdminWindow.destroy();
}


alt.onServer("FreezeMe", () => {
	
	alt.toggleGameControls(false);
	
});

alt.onServer("FFA:Showmenu", showFFAMenu)

let FFAMenu = null;

function showFFAMenu ()
{
    FFAMenu = new alt.WebView("http://resource/client/cef/ffa/index.html")
    alt.showCursor(true);
    alt.toggleGameControls(false);
    FFAMenu.focus();

    FFAMenu.on("FFA:ChooseFFA", (ffa) => {
        alt.emitServer("server:ffa:chooseffa", ffa);
    });

    FFAMenu.on("FFA:close", () => {
        alt.emitServer("ffa:closeweb");
        FFAMenu.destroy();
        alt.showCursor(false);
        alt.toggleGameControls(true);
    });
}

alt.onServer("updateFFACount", (FFA1Count, FFA2Count, FFA3Count, FFA4Count, FFA5Count, FFA6Count) => {
    if(FFAMenu == null) return;

    FFAMenu.emit('setFfaCount', FFA1Count, FFA2Count, FFA3Count, FFA4Count, FFA5Count, FFA6Count);
})

// Markers
alt.onServer("drawMarker", drawMarker);

function drawMarker(type, pos, rot, r, g, b, alpha) {
    native.drawMarker(
        type,
        pos.x,
        pos.y,
        pos.z,
        1,1,1,
        rot.x,
        rot.y,
        rot.z,
        1,1,1,
        r,
        g,
        b,
        alpha,
        false,
        true,
        2,
        false,
        undefined,
        undefined,
        false
    );
}

alt.setStat("stamina", 100);

alt.everyTick(() => {
    native.setPedSuffersCriticalHits(alt.Player.local, false);
    native.setAiWeaponDamageModifier(0.5);
    native.setWeaponDamageModifierThisFrame(alt.Player.local.currentWeapon, 0.4);
});

alt.everyTick(() => {
    if (native.isPedArmed(alt.Player.local.scriptID, 6)) {
      native.disableControlAction(0, 140, true); 
      native.disableControlAction(0, 141, true); 
      native.disableControlAction(0, 142, true); 
      native.disableControlAction(0, 143, true); 
    }
  });

alt.onServer('Client:Pedcreator:spawnPed', (model, x, y, z, heading) => {
	
	let modelHash = native.getHashKey(model);
	let pedHandle = native.createPed(5, modelHash, x, y, z, heading, false, false);
    native.setEntityHeading(pedHandle, heading);
	native.setEntityInvincible(pedHandle, true);
	native.disablePedPainAudio(pedHandle, true);
	native.freezeEntityPosition(pedHandle, true);
	native.taskSetBlockingOfNonTemporaryEvents(pedHandle, true);
});

function loadBlips()
{
    //waffenläden
    createBlip(21.059341, -1106.4396, 29.7854, 110, 0, 0.7, true, "Waffenladen")
    createBlip(-663.2967, -934.9319, 21.81543, 110, 0, 0.7, true, "Waffenladen")
    createBlip(252.85715, -49.2, 69.93848, 110, 0, 0.7, true, "Waffenladen")
    createBlip(811.0022, -2157.6792, 29.616821, 110, 0, 0.7, true, "Waffenladen")
    createBlip(-1305.2043, -393.33627, 36.693726, 110, 0, 0.7, true, "Waffenladen")

    //fraktionen
    createBlip(1415.4989, 3633.2966, 34.654907, 40, 26, 0.7, true, "Aztecas")
    createBlip(85.147255, -1958.4264, 21.107666, 40, 27, 0.7, true, "Ballas")
    createBlip(1287.3627, -1604.3077, 54.82422, 40, 51, 0.7, true, "Hoover Crips") 
    createBlip(1383.1252, -591.3099, 74.3363, 40, 25, 0.7, true, "Grove Street")
    createBlip(-14.189011, -1444.299, 30.644653, 40, 1, 0.7, true, "Bloods")
    createBlip(-51.34945, 356.13626, 113.04028, 40, 29, 0.7, true, "Triaden")
    createBlip(1389.9429, 1139.3802, 114.32092, 40, 62, 0.7, true, "Organisazija")
    createBlip(1991.1296, 3054.6858, 47.191162, 40, 31, 0.7, true, "LostMC")
    createBlip(-1535.9604, 97.76703, 56.761963, 40, 40, 0.7, true, "La Cosa Nostra")
    createBlip(-1516.8923, 851.5121, 181.58533, 40, 76, 0.7, true, "Yakuza")

    createBlip(-1520.2549, 849.0857, 181.58533, 473, 0, 0.4, true, "Yakuza Garage")
    createBlip(1408.6022, 3618.2769, 34.89087, 473, 0, 0.4, true, "Aztecas Garage")
    createBlip(102.738464, -1958.8484, 20.787598, 473, 0, 0.4, true, "Ballas Garage")
    createBlip(1279.5428, -1595.1956, 54.21753, 473, 0, 0.4, true, "Hoover Crips Garage")
    createBlip(1378.3912, -585.5868, 74.369995, 473, 0, 0.4, true, "Grove Street Garage")
    createBlip(-17.986813, -1451.0505, 30.57727, 473, 0, 0.4, true, "Bloods Garage")
    createBlip(-51.23077, 348.3956, 112.38318, 473, 0, 0.4, true, "Triaden Garage")
    createBlip(1382.9802, 1138.2594, 114.32092, 473, 0, 0.4, true, "Organisazija Garage")
    createBlip(1987.9517, 3060.5803, 47.073242, 473, 0, 0.4, true, "LostMC Garage")
    createBlip(-1528.5758, 78.55385, 56.77881, 473, 0, 0.4, true, "La Cosa Nostra Garage")

    //klinik
    createBlip(356.26813, -593.34064, 28.774414, 489, 1, 1.0, true, "Schönheitsklinik")
}

function createBlip(x,y,z,sprite,color,scale=1.0,shortRange=false,name="")
{
    const tempBlip = new alt.PointBlip(x,y,z);

    tempBlip.sprite = sprite;
    tempBlip.color = color;
    tempBlip.scale = scale;
    tempBlip.shortRange = shortRange;
    if(name.length > 0)
    tempBlip.name = name;
}

alt.setInterval(() => { 
    native.hideHudComponentThisFrame(6);
    native.hideHudComponentThisFrame(7);
    native.hideHudComponentThisFrame(8);
    native.hideHudComponentThisFrame(9);
    native.hideHudComponentThisFrame(2);
    native.setRunSprintMultiplierForPlayer(alt.Player.local.scriptID, 1.1)
}, 0);

let TeamSelect = null;

alt.onServer("OpenTeamSelect", TeamSelectServer)

function TeamSelectServer() {
    TeamSelect = new alt.WebView("http://resource/client/cef/testfights/index.html");
    alt.showCursor(true);
    TeamSelect.focus();

    TeamSelect.on("teamSelected", (teamId) => {
        if (teamId == 1)
        {
            alt.emitServer("teamSelectedTeam1");
        } 
        if (teamId == 2)
        {
            alt.emitServer("teamSelectedTeam2");
        }
        if (teamId == 3)
        {
            alt.emitServer("teamSelectedTeam3");
        }  
        if (teamId == 4)
        {
            alt.emitServer("teamSelectedTeam4");
        }  
        if (teamId == 5)
        {
            alt.emitServer("teamSelectedTeam5");
        }  
        if (teamId == 6)
        {
            alt.emitServer("teamSelectedTeam6");
        }  
        if (teamId == 7)
        {
            alt.emitServer("teamSelectedTeam7");
        }  
        if (teamId == 8)
        {
            alt.emitServer("teamSelectedTeam8");
        }  
        if (teamId == 9)
        {
            alt.emitServer("teamSelectedTeam9");
        }  
        if (teamId == 10)
        {
            alt.emitServer("teamSelectedTeam10");
        }    
    });

    TeamSelect.on("closeTeamSelect", () => {
        TeamSelect.destroy();
        alt.showCursor(false);
        alt.toggleGameControls(true);
        alt.emitServer("closeteamauswahl");
        alt.emitServer("öffneHud");
    });

    TeamSelect.on("teamauswahl:close", () => {
        TeamSelect.destroy();
        alt.showCursor(false);
        alt.toggleGameControls(true);
        alt.emitServer("closeteamauswahl");
    });

    alt.setTimeout(() => {
        alt.toggleGameControls(false);

    }, 100);
}



alt.onServer("updateTeamCount", (BallasCount, AztecasCount, OrgaCount, YakuzaCount, GroveCount, HooverCount, LCNCount, LostCount, TriadenCount, BloodsCount) => {
TeamSelect.emit('updateTeamCount', BallasCount, AztecasCount, OrgaCount, YakuzaCount, GroveCount, HooverCount, LCNCount, LostCount, TriadenCount, BloodsCount)
})

alt.onServer("openHud", openHudWindow);

alt.onServer("updateKd", (kills, deaths) => {
    HudWindow.emit('setKd', kills, deaths);
})


alt.onServer("updateKills", (kills) => {
    HudWindow.emit('setKills', kills);
})

alt.onServer("updateDeaths", (deaths) => {
    HudWindow.emit('setdeaths', deaths);
})

alt.onServer("updateLevel", (level) => {
    HudWindow.emit('setLevel', level);
})

alt.onServer("setMoney", (money) => {
    HudWindow.emit('setMoney', money);
})

let HudWindow = null;

function openHudWindow()
{
    if(HudWindow != null)
    {
        HudWindow.destroy();
        HudWindow = null;
    }
    HudWindow = new alt.WebView("http://resource/client/cef/hud/index.html");
}


let Garage = null;

alt.onServer("openGarageServer", openGarage)

function openGarage() {
    Garage = new alt.WebView("http://resource/client/cef/Garage/index.html");
    alt.showCursor(true);
    Garage.focus();
    alt.toggleGameControls(false);

    Garage.on("selectedVehicle", (vehicleId) => {
        if (vehicleId == 1)
        {
            alt.toggleGameControls(true);
            alt.emitServer("vehicle1");
        }
        if (vehicleId == 2)
        {
            alt.toggleGameControls(true);
            alt.emitServer("vehicle2");
        }
        if (vehicleId == 3)
        {
            alt.toggleGameControls(true);
            alt.emitServer("vehicle3");
        }
        if (vehicleId == 4)
        {
            alt.toggleGameControls(true);
            alt.emitServer("vehicle4");
        }
        if (vehicleId == 5)
        {
            alt.toggleGameControls(true);
            alt.emitServer("vehicle5");
        }
        if (vehicleId == 6)
        {
            alt.toggleGameControls(true);
            alt.emitServer("vehicle6");
        }
        if (vehicleId == 7)
        {
            alt.toggleGameControls(true);
            alt.emitServer("vehicle7");
        }
        if (vehicleId == 8)
        {
            alt.toggleGameControls(true);
            alt.emitServer("vehicle8");
            
        }
        if (vehicleId == 9)
        {
            alt.emitServer("vehicle9");
            alt.toggleGameControls(true);

        }
        if (vehicleId == 10)
        {
            alt.emitServer("vehicle10");
            alt.toggleGameControls(true);

        }
        if (vehicleId == 11)
        {
            alt.emitServer("vehicle11");
            alt.toggleGameControls(true);

        }
        if (vehicleId == 12)
        {
            alt.emitServer("vehicle12");
            alt.toggleGameControls(true);
        }
    });

    Garage.on("closeGarage", () => {
        Garage.destroy();
        alt.showCursor(false);
        alt.toggleGameControls(true);
        alt.emitServer("closegarage");
    });
}

alt.onServer("hitmaker", openHitmaker);

let hitmaker = null;

function openHitmaker()
{
    if(hitmaker === null)
    {
        hitmaker = new alt.WebView("http://resource/client/cef/hitmaker/index.html");
    }

    if (hitmaker != null) {
        hitmaker.emit("showHitmarker");
    }
}

let Waffenshop = null;

alt.onServer("openWaffenshop", openWaffenshop)

function openWaffenshop() {
    Waffenshop = new alt.WebView("http://resource/client/cef/Aufsatz/index.html");
    alt.showCursor(true);
    Waffenshop.focus();
    alt.toggleGameControls(false);

    Waffenshop.on("WeaponComp", (weapon, comp) => {
        alt.emitServer("WeaponComp", weapon, comp)
    })

    Waffenshop.on("closeWaffenshop", () => {
        Waffenshop.destroy();
        alt.showCursor(false);
        alt.toggleGameControls(true);
        alt.emitServer("closeWeaponshop");
    });
}