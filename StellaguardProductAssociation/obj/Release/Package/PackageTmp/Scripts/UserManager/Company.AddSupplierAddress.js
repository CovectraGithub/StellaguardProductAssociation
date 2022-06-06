var ValidationMessage = (ValidationMessage) ? ValidationMessage : "";
var AddSupplierAddress = AddSupplierAddress || {};
var $vars = $('#script\\.js').data();
AddSupplierAddress.showPopupWhenMsgIsavailable = function () {
    var message = $vars.message;
    if (message != "") {
        $('#myModal').modal('show');
    }
};
AddSupplierAddress.closePopup = function () {
    $(".closePopup").click(function () {
        $("#customdiv").html('');
        $("#myModal").hide();
        if ($vars.isgoodmessage=="True") {
            document.location = $vars.action;
        }
    });
};
AddSupplierAddress.populateReasonDropDown = function () {
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

AddSupplierAddress.checkvalid = function () {
    $("#btnSubmit").click(function (e) {
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
AddSupplierAddress.cancel = function () {
    $("#btnCancel").click(function () {
        document.location = $vars.action;
        return false;
    });
}
AddSupplierAddress.onlyNumeric = function (e) {
    var evt = (e) ? e : window.event;
    var charCode = (evt.keyCode) ? evt.keyCode : evt.which;
    if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 96 || charCode > 105)) {
        return false;
    }
    return true;
};
AddSupplierAddress.countrySelect = function () {
    $("select#SelectedCountryId").change(function () {
        if ($("select#SelectedCountryId").val() > 0)
            //populateReasonDropDown();//populateReasonDropDown($("select#DispositionId").val());
            AddSupplierAddress.populateReasonDropDown();
        else {
            $("select#SelectedStateId > option").remove();
        }
    });
}
AddSupplierAddress.setStateDropdown = function () {
    var selectedStatus = $("select#SelectedCountryId").val();
    if (selectedStatus != null && selectedStatus != '') {
        //populateReasonDropDown();
        AddSupplierAddress.populateReasonDropDown();
        setTimeout(function () {
            $("select#SelectedStateId").val($vars.selectedstate);
        }, 100)
    }
}

$(document).ready(function () {
    AddSupplierAddress.countrySelect();
    AddSupplierAddress.setStateDropdown();
    AddSupplierAddress.showPopupWhenMsgIsavailable();
    AddSupplierAddress.closePopup();
    AddSupplierAddress.checkvalid();
    AddSupplierAddress.cancel();
});

