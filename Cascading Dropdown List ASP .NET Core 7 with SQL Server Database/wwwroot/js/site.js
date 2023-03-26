// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.YouTube Tutrail  https://www.youtube.com/watch?v=vvJhflLovEs

function Fillcities(stCountryCtrl, UstCityId) {
    var lsCities = $("#" + LstCityId);
    LstCityId.empty();
    var selectedCountry = lstCountryCtrl.options[LstCountryCtrl.selectedIndex].value;

    If(selectedCountry != null && selectedCountry != ''){ 
        $.getJSON("/Home/GetCitiesByCountry",{ countryId: selectedCountry }, function (cities) {
                if (cities != null && !jQuery.isEmptyObject(cities)) {
                    $.each(cities, function (index, city) {

                        lsCities.append($('<option/>',
                            {
                            value: city.value,
                            text: city.text
                        }));
                 });
        };
     });
}

return;
}