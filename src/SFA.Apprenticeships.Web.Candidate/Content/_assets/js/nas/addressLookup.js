﻿$(document).ready(function () {
    $("#address-select").change(function () {
        var option = $(this);
        var selected = $(this).find('option:selected');
        if (option && option.val() !== "") {
            $("#Address_AddressLine1").val(selected.text());
            $("#Address_AddressLine2").val(selected.data("address-line2"));
            $("#Address_AddressLine3").val(selected.data("address-line3"));
            $("#Address_AddressLine4").val(selected.data("address-line4"));
            $("#Address_Postcode").val(selected.data("post-code"));
            $("#Address_Uprn").val(selected.data("uprn"));
            $("#Address_GeoPoint_Latitude").val(selected.data("lat"));
            $("#Address_GeoPoint_Longitude").val(selected.data("lon"));
            $("#address-details").removeClass("toggle-content");
            $("#address-manual").addClass("hidden");
        }
    });

    $(".address-item").change(function() {
        $("#Address_Uprn").val("");
        $("#Address_GeoPoint_Latitude").val("");
        $("#Address_GeoPoint_Longitude").val("");
    });
});

// provides the matching addresses from postcode
(function ($) {

    $.fn.addressLookup = function (options) {

        var settings = $.extend({ url: '' }, options);

        this.click(function (e) {
            e.preventDefault();
            $("#address-manual").removeClass("hidden");
            $("#address-list").addClass("toggle-content");
            $("#address-details").addClass("toggle-content");
            getAddresses($("#post-code").val());
        });

        function getAddresses(postcode) {
            jQuery.support.cors = true;
            $.ajax({
                url: settings.url,
                type: 'GET',
                data: { postcode: postcode },
                success: function (response) {
                    if (response != null) {
                        var addressList = $("#address-select");
                        addressList.empty();

                        var opt = $('<option/>').val("").html("-- " + response.length + " found --").addClass("address-select-option");
                        addressList.append(opt);

                        $.each(response, function (i, item) {
                            var opt = $('<option/>')
                                            .val(item.AddressLine1)
                                            .html(item.AddressLine1)
                                            .addClass("address-select-option")
                                            .data("address-line2", _.escape(item.AddressLine2))
                                            .data("address-line3", _.escape(item.AddressLine3))
                                            .data("address-line4", _.escape(item.AddressLine4))
                                            .data("post-code", _.escape(item.Postcode))
                                            .data("uprn", item.Uprn)
                                            .data("lat", item.GeoPoint.Latitude)
                                            .data("lon", item.GeoPoint.Longitude);
                            addressList.append(opt);
                        });

                        $("#address-list").removeClass("toggle-content");
                    }
                },
                error: function (error) {
                    //Ignore, could be proxy issues so will work as 
                    //non-JS version.
                    //console.log(error);
                }
            });
            return true;
        };
    };
})(jQuery);