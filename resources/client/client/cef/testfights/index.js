function selectTeam(teamId) {
  alt.emit("teamSelected", teamId)
  hideTeamSelect();
}

function hideTeamSelect() {
  alt.emit("closeTeamSelect");
}

if ('alt' in window) {
  alt.on('updateTeamCount', (Team1, Team2, Team3, Team4, Team5, Team6, Team7, Team8, Team9, Team10) => {
    $('#ballaspop').text(Team1);
    $('#aztecaspop').text(Team2);
    $('#orgapop').text(Team3);
    $('#ykzpop').text(Team4);
    $('#grovepop').text(Team5);
    $('#hooverpop').text(Team6);
    $('#lcnpop').text(Team7);
    $('#lostpop').text(Team8);
    $('#bloodspop').text(Team9);
    $('#ballaspop').text(Team10);
  });
}