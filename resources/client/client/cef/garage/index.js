function selectVehicle(vehicleId) {
    alt.emit("selectedVehicle", vehicleId)
    hideGarage();
  }

  function hideGarage() {
    alt.emit("closeGarage");
  }