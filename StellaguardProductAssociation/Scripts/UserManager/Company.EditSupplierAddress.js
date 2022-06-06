var EditSupplierAddress = EditSupplierAddress || {};
var $vars = $('#script\\.js').data();
EditSupplierAddress.showPopupWhenMsgIsavailable = function () {
    var message = $vars.message;
    if (message != "") {
        $('#myModal').modal('show');
    }
};
EditSupplierAddress.closePopup = function () {
    $(".closePopup").click(function () {
        $("#customdiv").html('');
        $("#myModal").hide();
        if ($vars.isgoodmessage=="True") {
            document.location = $vars.action;
        }
    });
};
EditSupplierAddress.populateReasonDropDown = function () {
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

EditSupplierAddress.checkvalid = function () {
    $("#btnSubmit").click(function () {
        var result = false;
        if ($("#frm").valid()) {
        	var cnpj = $("#CNPJNumber").val();
        	var sgln = $("#SGLN").val();
        	if (cnpj == "" && sgln == "") {
        		$("#myCustomSummary").html("");
        		$(".customsummary").html(ValidationMessage);
        		$('#myModal').modal('show');
        		e.preventDefault();
        	}
        	else {
        		return true;
        	}
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
EditSupplierAddress.cancel = function () {
    $("#btnCancel").click(function () {
        document.location = $vars.action;
        return false;
    });
}
EditSupplierAddress.onlyNumeric = function (e) {
    var evt = (e) ? e : window.event;
    var charCode = (evt.keyCode) ? evt.keyCode : evt.which;
    if (charCode > 31 && (charCode < 48 || charCode > 57) && (e.keyCode < 96 || e.keyCode > 105)) {
        return false;
    }
    return true;
};
EditSupplierAddress.countrySelect = function () {
    $("select#SelectedCountryId").change(function () {
        if ($("select#SelectedCountryId").val() > 0)
            //populateReasonDropDown();//populateReasonDropDown($("select#DispositionId").val());
            EditSupplierAddress.populateReasonDropDown();
        else {
            $("select#SelectedStateId > option").remove();
        }
    });
}
EditSupplierAddress.setStateDropdown = function () {
    var selectedStatus = $("select#SelectedCountryId").val();
    if (selectedStatus != null && selectedStatus != '') {
        //populateReasonDropDown();
        EditSupplierAddress.populateReasonDropDown();
        setTimeout(function () {
            $("select#SelectedStateId").val($vars.selectedstate);
        }, 100)
        
    }
}

$(document).ready(function () {
    EditSupplierAddress.countrySelect();
//    EditSupplierAddress.setStateDropdown();
    EditSupplierAddress.showPopupWhenMsgIsavailable();
    EditSupplierAddress.closePopup();
    EditSupplierAddress.checkvalid();
    EditSupplierAddress.cancel();
});

