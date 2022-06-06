var AddUserAddress = AddUserAddress || {};
var $vars = $('#script\\.js').data();
AddUserAddress.showPopupWhenMsgIsavailable = function () {
    var message = $vars.message;
    if (message != "") {
        $('#myModal').modal('show');
    }
};
AddUserAddress.closePopup = function () {
    $(".closePopup").click(function () {
        $("#customdiv").html('');
        $("#myModal").hide();
        if ($vars.isgoodmessage) {
            document.location = $vars.action;
        }
    });
};
AddUserAddress.populateReasonDropDown = function () {
        $.get(
            //'@Url.Action("PopulateStateDropDown", "Company")',
            $vars.countryaction,
            { countryId: $("select#SelectedCountryId").val() },
            function (response) {
                var states = $.parseJSON(response);
                var stateDropDown = $("select#SelectedStateId");

                $("select#SelectedStateId > option").remove();

                for (i = 0; i < states.length; i++) {
                    stateDropDown.append($("<option/>").val(states[i].Value).text(states[i].Text));
                }
            });
};

AddUserAddress.checkvalid = function () {
    $("#btnSubmit").click(function () {
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
    });
    
};
AddUserAddress.cancel = function () {
    $("#btnCancel").click(function () {
        document.location = $vars.action;
        return false;
    });
}
AddUserAddress.onlyNumeric = function (e) {
    var evt = (e) ? e : window.event;
    var charCode = (evt.keyCode) ? evt.keyCode : evt.which;
    if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 96 || charCode > 105)) {
        return false;
    }onlyNumeric
    return true;
};
AddUserAddress.countrySelect = function () {
    $("select#SelectedCountryId").change(function () {
        if ($("select#SelectedCountryId").val() > 0)
            //populateReasonDropDown();//populateReasonDropDown($("select#DispositionId").val());
            AddUserAddress.populateReasonDropDown();
        else {
            $("select#SelectedStateId > option").remove();
        }
    });
}
AddUserAddress.setStateDropdown = function () {
    var selectedStatus = $("select#SelectedCountryId").val();
    if (selectedStatus != null && selectedStatus != '') {
        //populateReasonDropDown();
        AddUserAddress.populateReasonDropDown();
        setTimeout(function () {
            $("select#SelectedStateId").val($vars.selectedstate);
        }, 100)
    }
}

$(document).ready(function () {
    AddUserAddress.countrySelect();
    AddUserAddress.setStateDropdown();
    AddUserAddress.showPopupWhenMsgIsavailable();
    AddUserAddress.closePopup();
    AddUserAddress.checkvalid();
    AddUserAddress.cancel();
});

