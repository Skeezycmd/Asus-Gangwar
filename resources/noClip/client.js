import * as alt from 'alt-client';
import * as game from 'natives';

// DO NOT EDIT //
let NoclipActive = false;
let MovingSpeed = 0;
let Scale = -1;
let FollowCamMode = true;

// THIS CAN YOU EDIT //
const PlayerVisible = false;

const SpeedsCount = 7;

const KeyControls = {
    ToggleAltV: 116,
    ToggleGTA: 166,

    MoveUpOnly: 32,
    MoveDownOnly: 17,
    MoveLeftOnly: 65,
    MoveRightOnly: 68,

    MoveUP: 32,
    MoveDown: 17,
    MoveLeft: 65,
    MoveRight: 68,

    MoveUD: 31,
    MoveLR: 30,

    Cover: 44,
    Spring: 21,
    RadioWheel: 85,
    Horn: 86,
    HeadLight: 74
}

// CODE - DO NOT EDIT

alt.everyTick(() => {
    if (NoclipActive)
    {
        

        let noclipEntity = alt.Player.local.vehicle ? alt.Player.local.vehicle : alt.Player.local;
        let newPos;

        game.disableControlAction(0, KeyControls.MoveUpOnly, true);
        game.disableControlAction(0, KeyControls.MoveUP, true);
        game.disableControlAction(0, KeyControls.MoveUD, true);
        game.disableControlAction(0, KeyControls.MoveDown, true);
        game.disableControlAction(0, KeyControls.MoveDownOnly, true);
        game.disableControlAction(0, KeyControls.MoveLeft, true);
        game.disableControlAction(0, KeyControls.MoveLeftOnly, true);
        game.disableControlAction(0, KeyControls.MoveLR, true);
        game.disableControlAction(0, KeyControls.MoveRight, true);
        game.disableControlAction(0, KeyControls.MoveRightOnly, true);
        game.disableControlAction(0, KeyControls.Cover, true);
        game.disableControlAction(0, KeyControls.Horn, true);
        game.disableControlAction(0, KeyControls.HeadLight, true);
        if (alt.Player.local.vehicle)
            game.disableControlAction(0, KeyControls.RadioWheel, true);

        let yoff = 0.0;
        let zoff = 0.0;

        if (game.updateOnscreenKeyboard() !== 0 && alt.isGameFocused()) {
            

            if (game.isDisabledControlPressed(0,KeyControls.MoveUpOnly))
            {
                yoff = 0.5;
            }
            if (game.isDisabledControlPressed(0, KeyControls.MoveDownOnly))
            {
                yoff = -0.5;
            }
            if (!FollowCamMode && game.isDisabledControlPressed(0, KeyControls.MoveLeftOnly))
            {
                game.setEntityHeading(alt.Player.local.scriptID, game.getEntityHeading(alt.Player.local.scriptID) + 3);
            }
            if (!FollowCamMode && game.isDisabledControlPressed(0, KeyControls.MoveRightOnly))
            {
                game.setEntityHeading(alt.Player.local.scriptID, game.getEntityHeading(alt.Player.local.scriptID) - 3);
            }
            if (game.isDisabledControlPressed(0, KeyControls.Cover))
            {
                zoff = 0.21;
            }
            if (game.isDisabledControlPressed(0, KeyControls.Horn))
            {
                zoff = -0.21;
            }
            if (game.isDisabledControlJustPressed(0, KeyControls.HeadLight))
            {
                FollowCamMode = !FollowCamMode;
            }
        }

        let moveSpeed = MovingSpeed;
        if (MovingSpeed > SpeedsCount / 2)
        {
            moveSpeed *= 1.8;
        }
        moveSpeed = moveSpeed / (1 / game.getFrameTime()) * 60;
        newPos = game.getOffsetFromEntityInWorldCoords(noclipEntity.scriptID, 0, yoff * (moveSpeed + 0.3), zoff * (moveSpeed + 0.3));

        let heading = game.getEntityHeading(noclipEntity.scriptID);
        game.setEntityVelocity(noclipEntity.scriptID, 0, 0, 0);
        game.setEntityRotation(noclipEntity.scriptID, 0, 0, 0, 0, false);
        game.setEntityHeading(noclipEntity.scriptID, FollowCamMode ? game.getGameplayCamRelativeHeading() : heading);
        game.setEntityCoordsNoOffset(noclipEntity.scriptID, newPos.x, newPos.y, newPos.z, true, true, true);
    }
});

function NoClip() {
    NoclipActive = !NoclipActive;

    let noclipEntity = alt.Player.local.vehicle ? alt.Player.local.vehicle : alt.Player.local;
    if(NoclipActive) {
        game.freezeEntityPosition(noclipEntity.scriptID, true);
        game.setEntityCollision(noclipEntity.scriptID, false, false);

        if(PlayerVisible) alt.emitServer("NoClip:PlayerVisible", true);

    } else {
        game.freezeEntityPosition(noclipEntity.scriptID, false);
        game.setEntityCollision(noclipEntity.scriptID, true, true);

        if(PlayerVisible) alt.emitServer("NoClip:PlayerVisible", false);

    }
}

alt.on("keyup", (key) => {
    if(key === KeyControls.ToggleAltV) {
        alt.emitServer("NoClip");
    }
});

alt.onServer("ToggleNoClip", () => {
    NoClip();
});

alt.on("keydown", (key) => {
    if(key === 16) {
        MovingSpeed = 7;
    }
});

alt.on("keyup", (key) => {
    if(key === 16) {
        MovingSpeed = 3;
    }
});