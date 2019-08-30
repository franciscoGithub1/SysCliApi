<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.5.1/dist/leaflet.css" integrity="sha512-xwE/Az9zrjBIphAcBb3F6JVqxf46+CDLwfLMHloNu6KEQCAWi6HcDUbeOfBIptF7tcCzusKFjFw2yuvEpDL9wQ==" crossorigin="">
     <!-- Make sure you put this AFTER Leaflet's CSS -->
 <script src="https://unpkg.com/leaflet@1.5.1/dist/leaflet.js" integrity="sha512-GffPMF3RvMeYyc1LWMHtK8EbPv0iNZ8/oTtHPx9/cc2ILxQ+u905qIwdpULaqDkyBKgOaB57QTMg7ztg8Jm2Og==" crossorigin=""></script>
    <script>
        ACCESS_TOKEN = 'pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw';
        MB_ATTR = 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, ' +
            '<a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, ' +
            'Imagery © <a href="https://www.mapbox.com/">Mapbox</a>';
        MB_URL = 'https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=' + ACCESS_TOKEN;
        OSM_URL = 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png';
        OSM_ATTRIB = '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors';
	</script>
    <style> 
  	#mapid {
        height: 100%;
        }
     
        html, body {
        height: 100%;
        margin: 0;
        padding: 0;
        }
	</style> 
</head>
<body>
     <div id="mapid"></div>
    <form id="form1" runat="server">
        
    </form>
    <script>
        var mymap = L.map('mapid').setView([-33.4372, -70.6506], 13);

        var colores = new Array(-33.4372, -70.6506);
        //colores = new Array(-33.4372, -70.6506);
        debugger;
        //colores.forEach(function () {
        //    console.log(element);
        //});
        var miArray = ['-33.4372, -70.6506', '-33.4172, -70.6506'];
        for (var indice in miArray) {
            console.log("En el índice '" + indice + "' hay este valor: " + miArray[indice]);
            var general = miArray[indice].split(',');
            var lat = general[0];
            var lon = general[1];
            L.marker([lat, lon]).addTo(mymap).bindPopup('A pretty CSS3 popup.<br> Easily customizable.')
                .openPopup();
        }

        //for (var i = 0; i =< colores.length; i +) {
        //    console.log("En el índice '" + i + "' hay este valor: " + colores[i]);
        //}

        //L.marker([colores[0], -70.6506]).addTo(mymap).bindPopup('A pretty CSS3 popup.<br> Easily customizable.')
        //    .openPopup();
        //L.marker(['-33.4272', '-70.6506']).addTo(mymap).bindPopup('A pretty CSS3 popup.<br> Easily customizable.')
        //    .openPopup();

        L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
            attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
            maxZoom: 18,
            id: 'mapbox.streets',
            accessToken: 'pk.eyJ1IjoiZnJhbmNpc2NvZmlkbnMiLCJhIjoiY2p6dWU5cXVrMGY4bjNibnk3MTFyd3FveCJ9.N1I5Vz0sqAEbTQXmC7RYSg'
        }).addTo(mymap);
        //L.popup()
        //    .setLatLng([-33.4372, -70.6506])
        //    .setContent("I am a standalone popup.")
        //    .openOn(mymap);
       
        </script>
</body>
</html>
