function clearAllBTN(){
    document.getElementById("genderbtn").style.color = "white"
    document.getElementById("facebtn").style.color = "white"
    document.getElementById("hairbtn").style.color = "white"
    document.getElementById("haricolorbtn").style.color = "white"
    document.getElementById("eyecolorbtn").style.color = "white"
    document.getElementById("eyebrowbtn").style.color = "white"
    document.getElementById("agebtn").style.color = "white"
    document.getElementById("makeupbtn").style.color = "white"
    document.getElementById("blushbtn").style.color = "white"
    document.getElementById("lipstickbtn").style.color = "white"

    document.getElementById("genderbtn-tab").style.display = "none"
    document.getElementById("facebtn-tab").style.display = "none"
    document.getElementById("hairbtn-tab").style.display = "none"
    document.getElementById("haricolorbtn-tab").style.display = "none"
    document.getElementById("eyecolorbtn-tab").style.display = "none"
    document.getElementById("eyebrowbtn-tab").style.display = "none"
    document.getElementById("agebtn-tab").style.display = "none"
    document.getElementById("makeupbtn-tab").style.display = "none"
    document.getElementById("blushbtn-tab").style.display = "none"
    document.getElementById("lipstickbtn-tab").style.display = "none"
}

function selectTab(tabname) {
    document.getElementById("subtab").style.display = "block";
    clearAllBTN();
    document.getElementById(tabname).style.color = "#8a8a8a";
    document.getElementById(tabname+"-tab").style.display = "block"

    switch (tabname) {
        case "genderbtn":
            document.getElementById("subtabname").innerText = "Geschlecht und Eltern";
            document.getElementById("subtab").style.height = "25vw";
        break;
        case "facebtn":
            document.getElementById("subtabname").innerText = "Gesicht";
            document.getElementById("subtab").style.height = "45vw";
        break;
        case "hairbtn":
            document.getElementById("subtabname").innerText = "Haare und Baerte";
            document.getElementById("subtab").style.height = "12.5vw";
        break;
        case "haricolorbtn":
            document.getElementById("subtabname").innerText = "Haarfarbe";
            document.getElementById("subtab").style.height = "12.5vw";
        break;
        case "eyecolorbtn":
            document.getElementById("subtabname").innerText = "Augenfarbe";
            document.getElementById("subtab").style.height = "10vw";
        break;
        case "eyebrowbtn":
            document.getElementById("subtabname").innerText = "Augenbrauen";
            document.getElementById("subtab").style.height = "10vw";
        break;
        case "agebtn":
            document.getElementById("subtabname").innerText = "Alter";
            document.getElementById("subtab").style.height = "10vw";
        break;
        case "makeupbtn":
            document.getElementById("subtabname").innerText = "Make Up";
            document.getElementById("subtab").style.height = "10vw";
        break;
        case "blushbtn":
            document.getElementById("subtabname").innerText = "Blush";
            document.getElementById("subtab").style.height = "10vw";
        break;
        case "lipstickbtn":
            document.getElementById("subtabname").innerText = "Lippenstift";
            document.getElementById("subtab").style.height = "10vw";
        break;
    }
}