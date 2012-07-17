$(document).ready(function () {
  if ($("#map_canvas")[0]) {
    initializeMap(); 
  };
});

function initializeMap() {
  var myLatlng = new google.maps.LatLng(lat, long);
  var myOptions = {
    center: myLatlng,
    zoom: 12,
    mapTypeId: google.maps.MapTypeId.SATELLITE
  };
  var map = new google.maps.Map(document.getElementById("map_canvas"),
            myOptions);
  var marker = new google.maps.Marker({
    position: myLatlng,
    map: map,
    title: breweryName,
    draggable: true,
    dragend: function () {
      alert(1);
    }
  });

}
