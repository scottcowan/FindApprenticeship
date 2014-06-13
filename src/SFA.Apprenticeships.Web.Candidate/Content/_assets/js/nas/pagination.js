//TODO: Do we have this somewhere already?
if (!window.console) window.console = {};
if (!window.console.log) window.console.log = function () { };

// Hooks up the pagination control and manages the history.
$(document).ready(function(){

    //Needs off/on to prevent multiple firing as binds additional handlers on each load.
    $("#pagedList").off("click", "a.page-navigation__btn").on("click", "a.page-navigation__btn", function (e) {
        e.preventDefault();
        console.log(e);
        loadResultsPage(this.href, true);
        return false;
    });

    function loadResultsPage(url, updateHistory) {

        var pagenavigation = $("div.page-navigation");
        var container = pagenavigation.attr("data-ajax-update");
        var method = pagenavigation.attr("data-ajax-method");

        $.ajax({
            url: url,
            type: method,
            success: function (response) {
                $(container).html(response);
                if (updateHistory && window.history && history.pushState) {
                    console.log("Pushing url: " + url);
                    history.pushState(url, "SFA Apprenticeships", url);
                }
                $('body').stop().animate({ scrollTop: 0 });
            },
            error: function (error) {

            }
        });
    }

    $(window).on('popstate', function (event) {
        console.log("Popping url: " + event.originalEvent.state);
        if (event.originalEvent && event.originalEvent.state) {
            console.log("Popping load call");
            loadResultsPage(event.originalEvent.state, false);
        }
    });

    $(window).on('load', function() {
        console.log("Pushing start url: " + window.location.href);
        history.replaceState(window.location.href, "SFA Apprenticeships", window.location.href);
    });

});