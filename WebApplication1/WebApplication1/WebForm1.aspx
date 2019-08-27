<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style> 
  	#map {
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
    <div id ="map"> </div> 
    <form id="form1" runat="server">
        
    </form>
    <script>
 
        var map;
        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: -33.4372, lng: -70.6506  },
                zoom: 13,
                
            });

            let marker = new google.maps.Marker({
                position: { lat: -33.4372, lng: -70.6506 },
                title: 'Tu ubicacion'
            })
            marker.setMap(map)

            let marker1 = new google.maps.Marker({
                position: { lat: -32.4372, lng: -70.6506 },
                title: 'Tu ubicacion1'
            })
            marker1.setMap(map)

            new google.maps.Marker({
                position: { lat: -33.4172, lng: -70.6506 },
                title: 'Tu ubicacion2'
                
            }).setMap(map)
           
                //return new google.maps.Marker({
                //    position: { lat: -33.4372, lng: -70.6506 },
                //    map: map,
                //    title: 'tata'
                //})
           
        }
	</script>
     <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCzrphY4O6zeUElla3wcUV_Ngz5oBkTR78&callback=initMap"></script>
</body>
</html>
