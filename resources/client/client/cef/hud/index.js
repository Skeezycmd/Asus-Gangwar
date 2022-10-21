alt.on('setKills', (kills) => setKills(kills));

function setKills(kills)
{
    $('#kills').text("Kills: " + kills);
}

alt.on('setKd', (kills, deaths) => setKd(kills, deaths));

function setKd(kills, deaths)
{
    let kd = parseFloat((kills / deaths)).toFixed(1)

    if (isNaN(kd)) {
        kd = 0
    }

    if (kd == Infinity) {
        kd = 0
    }

    $('#KDlol').text("KD: " + kd)
}

alt.on('setdeaths', (Deaths) => setDeaths(Deaths));

function setDeaths(Deaths)
{
    $('#deaths').text("Deaths: " + Deaths);
}

alt.on('setLevel', (level) => setLevel2(level));

function setLevel2(level)
{
    $('#levellol').text("Level: " + level);
}

alt.on('setMoney', (money) => setMoney2(money));

function setMoney2(money)
{
    $('#money').text("Money: " + money);
}