var ListUserAddress = ListUserAddress || {};
var $vars = $('#script\\.js').data();
ListUserAddress.showPopupWhenMsgIsavailable = function () {
    var message = $vars.message;
    if (message != "") {
        $('#myModal').modal('show');
    }
};
ListUserAddress.closePopup = function () {
    $(".closePopup").click(function () {
        $("#customdiv").html('');
        $("#myModal").hide();
        if ('@ViewBag.IsGoodMessage') {
            document.location = $vars.action;
        }
    });
};
ListUserAddress.setTableLayoutInLowResolution = function () {
    $('#gridContent:visible').css("max-width", (screen.width - 75) + "px")
    $('#gridContent:visible').css("overflow-x", "auto")
};

ListUserAddress.checkvalid = function () {
    var result = false;
    if ($("#frm").valid()) {
        return true;
    }
    else {
        $(".validsummary").show();
        $('#myModal').modal('show');
        return false;
    }
};
$(document).ready(function () {
    ListUserAddress.showPopupWhenMsgIsavailable();
    ListUserAddress.closePopup();
    ListUserAddress.setTableLayoutInLowResolution();
});

