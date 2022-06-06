var ListSupplierAddress = ListSupplierAddress || {};
var $vars = $('#script\\.js').data();
ListSupplierAddress.showPopupWhenMsgIsavailable = function () {
    var message = $vars.message;
    if (message != "") {
        $('#myModal').modal('show');
    }
};
ListSupplierAddress.closePopup = function () {
    $(".closePopup").click(function () {
        $("#customdiv").html('');
        $("#myModal").hide();
        if ('@ViewBag.IsGoodMessage') {
            document.location = $vars.action;
        }
    });
};
ListSupplierAddress.setTableLayoutInLowResolution = function () {
    $('#gridContent:visible').css("max-width", (screen.width - 75) + "px")
    $('#gridContent:visible').css("overflow-x", "auto")
};

ListSupplierAddress.checkvalid = function () {
    var result = false;
    if ($("#frm").valid()) {
        return true;
    }
    else {
        $(".validsummary").show();
        $("#myCustomSummary").html($(".validsummary").html()); //Added for passing in partial view
        $(".validsummary").hide(); //Added for clear from screen RJ
        $('#myModal').modal('show');
        return false;
    }
};
$(document).ready(function () {
    ListSupplierAddress.showPopupWhenMsgIsavailable();
    ListSupplierAddress.closePopup();
    ListSupplierAddress.setTableLayoutInLowResolution();
});

