/// <reference types ="@altv/types-client" />
/// <reference types ="@altv/types-natives" />

import * as alt from "alt-client";
import * as native from "natives";

alt.onServer("nametags", (state) => nametags(state));
var interval;

function nametags(state) {
  if (!alt.Player.local.hasSyncedMeta("ADUTY")) return;
  if (state) {
    interval = alt.setInterval(drawNametags, 0);
  } else {
    if (interval) {
      alt.clearInterval(interval);
      interval = null;
    }
  }
}

function drawNametags() {
  var drawDistance = 60;

  for (let i = 0, n = alt.Player.all.length; i < n; i++) {
    let player = alt.Player.all[i];
    if (!player.valid) {
      continue;
    }

    if (player.scriptID === alt.Player.local.scriptID) {
      continue;
    }

    const name = player.getSyncedMeta("NAME");
    if (!name) {
      continue;
    }

    // if (
    //   !native.hasEntityClearLosToEntity(
    //     alt.Player.local.scriptID,
    //     player.scriptID,
    //     17
    //   )
    // ) {
    //   continue;
    // }

    let dist = distance2d(player.pos, alt.Player.local.pos);
    if (dist > drawDistance) {
      continue;
    }

    const pos = { ...native.getPedBoneCoords(player.scriptID, 12844, 0, 0, 0) };
    pos.z += 0.6;

    let scale = 1 - (0.8 * dist) / drawDistance;
    let fontSize = 0.4 * scale;

    const entity = player.vehicle ? player.vehicle.scriptID : player.scriptID;
    const vector = native.getEntityVelocity(entity);
    const frameTime = native.getFrameTime();

    // Names
    native.setDrawOrigin(
      pos.x + vector.x * frameTime,
      pos.y + vector.y * frameTime,
      pos.z + vector.z * frameTime,
      0
    );
    native.beginTextCommandDisplayText("STRING");
    native.setTextFont(4);
    native.setTextScale(fontSize, fontSize);
    native.setTextProportional(true);
    native.setTextCentre(true);
    native.setTextColour(255, 255, 255, 255);
    native.setTextOutline();
    native.addTextComponentSubstringPlayerName(
      `~g~${native.getEntityHealth(player.scriptID)} ~w~${name} ~b~${native.getPedArmour(player.scriptID)}`
    );
    native.endTextCommandDisplayText(0, 0, 0);
    native.clearDrawOrigin();
  }
}

function distance2d(vector1, vector2) {
  return Math.sqrt(
    Math.pow(vector1.x - vector2.x, 2) + Math.pow(vector1.y - vector2.y, 2)
  );
}
