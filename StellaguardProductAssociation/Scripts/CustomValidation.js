
var regex = "";

var serialNumbers = "";

var serialNumbersArrayjs = new Array();

var ErrorMessage = "";

var ValidationResult = true;

var str = "";

var packageType = "";

var startNumber = 0;
var endNumber = 0;


function correctMultipleNewlines(str) {
    
    return str.replace(/\n+/g, "\n").trim("\n");
}

function getSerialNumberArray(str) {

    str = correctMultipleNewlines(str);
    
    return str.split('\n');
}

function between(x, min, max) {
    var Result = false;
    var checkNo = min.toString();
    var serialNumber = Number(x);
    if (checkNo.indexOf(',') === -1) {
        if (serialNumber >= min && serialNumber <= max) {
            Result = true;
            return Result;
        }
    }
    else {
        var minArray = min.split(',');
        var maxArray = max.split(',');
        var len = minArray.length, i = 0;


        for (i; i < len ; i++) {

            if (x >= minArray[i] && x <= maxArray[i]) {
                Result = true;
            }
        }
    }
    return Result;
}

function DuplicateCheck(serialNumbersArray) {
    

    var i;
    var len = serialNumbersArray.length;
    var obj = {};
    var duplicates = [];
    
    for (i = 0; i < len; i++) {

        if (!obj[serialNumbersArray[i]]) {

            obj[serialNumbersArray[i]] = 1;

        }

        else {
            obj[serialNumbersArray[i]]++;

            if (obj[serialNumbersArray[i]] == 2) {
                duplicates.push(serialNumbersArray[i]);
            }
        }

    }

    if (duplicates.length != 0) {
        var duplicatelen = duplicates.length, j = 0;
        for (j; j < duplicatelen ; j++) {
            if (ErrorMessage != "") {
                ErrorMessage = ErrorMessage + "<br/>" + duplicates[j];
            }
            else {
                ErrorMessage = "<br/><br/>" + duplicates[j];
            }

        }
        return false;
    }
    else {
        return true;

    }


}


function CheckvalidSerialNumber(serialNumbersArrayjs, regex) {
    ErrorMessage = "";
    var len = serialNumbersArrayjs.length, i = 0;
    for (i; i < len ; i++) {
        var strlen = serialNumbersArrayjs[i];

        if (strlen != "") {
            if (strlen.match(regex, 'm') == null) {
                if (ErrorMessage != "") {
                    ErrorMessage = ErrorMessage + "<br/>" + serialNumbersArrayjs[i];
                }
                else {
                    ErrorMessage = "<br/><br/>" + serialNumbersArrayjs[i];
                }

            }
        }
    }

    if (ErrorMessage != "")
        return false;
    else
        return true;
}

function CheckvalidSerialNumberSingle(serialNumbersArrayjs, regex) {

    ErrorMessage = "";

    var strlen = serialNumbersArrayjs;

    if (strlen != "") {
        if (strlen.match(regex, 'm') == null) {
            if (ErrorMessage != "") {
                ErrorMessage = ErrorMessage + "<br/>" + serialNumbersArrayjs;
            }
            else {
                ErrorMessage = "<br/><br/>" + serialNumbersArrayjs;
            }

        }
    }


    if (ErrorMessage != "")
        return false;
    else
        return true;
}

function checkPackageType(serialNumbersArrayjs, packageType, startNumber, endNumber) {
    var len = serialNumbersArrayjs.length, i = 0;
    for (i ; i < len; i++) {

        var strlen = serialNumbersArrayjs[i];
        if (strlen != "") {
            if (!between(strlen, startNumber, endNumber)) {
                var str = strlen;
                if (ErrorMessage != "") {
                    ErrorMessage = ErrorMessage + "<br/>" + str;
                }
                else {
                    ErrorMessage = "<br/><br/>" + str;
                }

            }
        }
    }

    if (ErrorMessage != "")
        return false;
    else
        return true;

}


function checkPackageTypeSingle(serialNumbersArrayjs, packageType, startNumber, endNumber) {



    var strlen = serialNumbersArrayjs;
    if (strlen != "") {
        if (!between(strlen, startNumber, endNumber)) {
            var str = strlen;
            if (ErrorMessage == "") {
                ErrorMessage = ErrorMessage + "<br/>" + str;
            }
            else {
                ErrorMessage = "<br/><br/>" + str;
            }

        }
    }


    if (ErrorMessage != "")
        return false;
    else
        return true;

}

function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 96 || charCode > 105)) {
        return false;
    }
    return true;
}


function isNumberChild(e) {
    if (e.which == 13) {
        return true;
    }

    if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57) && (e.keyCode < 96 || e.keyCode > 105)) {
        //display error message
        $("#errmsg").html("Digits Only").show().fadeOut("slow");
        return false;
    }
    else {
        return true;
    }

}

function checkCount(serialNumbers) {
    
    if ( serialNumbers.trim() == "" )
    {
        return 0;
    }
    else
    {
        var serialNumbersArrayjs = getSerialNumberArray( serialNumbers );
        return serialNumbersArrayjs.length;
    }
}

function ExtractDetailsFromHRCode(code) {
    code = $.trim(code);
    var length = code.length;
    var serialNumber = "";
    var gTIN = "";
    var expiryDate = "";
    var lotNumber = "";
    var date;

    if (code.substring(0, 2) == '01') {
        gTIN = code.substring(2, 16);
    }
    if (code.substring(16, 18) == '17') {
        expiryDate = code.substring(18, 24);
    }
    else if (code.substring(16, 18) == '10') {
        lotNumber = code.substring(18, length - 12);
    }

    if (code.substring(24, 26) == '10') {
        lotNumber = code.substring(26, length - 12);
    }

    if (code.substring(length - 12, length - 12 + 2) == '21') {
        serialNumber = code.substring(length - 10, length);
    }

    var data = {
        items: [
          { GTIN: gTIN, ExpiryDate: expiryDate, LotNumber: lotNumber, SerialNumber: serialNumber },

        ]
    };

    return data
}
function CheckvalidHRCode(hrCodeArrayjs, regex, hrLength) {
    return true;
    ErrorMessage = "";
    var len = hrCodeArrayjs.length, i = 0;
    for (i; i < len ; i++) {

        var data = ExtractDetailsFromHRCode(hrCodeArrayjs[i]);
        var strlen = data.items[0].SerialNumber;
        if (strlen == "" || strlen.match(regex, 'm') == null) {
            if (ErrorMessage != "") {
                ErrorMessage = ErrorMessage + "<br/>" + hrCodeArrayjs[i];
            }
            else {
                ErrorMessage = "<br/><br/>" + hrCodeArrayjs[i];
            }
        }
    }

    if (ErrorMessage != "")
        return false;
    else
        return true;
}
function checkHRCodePackageType(hrCodeArrayjs, packageType, startNumber, endNumber, gtin) {
    ErrorMessage = "";

    var len = hrCodeArrayjs.length, i = 0;
    for (i ; i < len; i++) {
        var data = ExtractDetailsFromHRCode(hrCodeArrayjs[i]);
        var strlen = data.items[0].SerialNumber;
        var sgtin = data.items[0].GTIN;

        if (strlen == "" || !between(strlen, startNumber, endNumber) || sgtin != gtin) {

            if (ErrorMessage != "") {
                ErrorMessage = ErrorMessage + "<br/>" + hrCodeArrayjs[i];

            }
            else {
                ErrorMessage = "<br/><br/>" + hrCodeArrayjs[i];
            }
        }
    }
    if (ErrorMessage != "")
        return false;
    else
        return true;

}
function getHRCodeArray(str) {
    str = str.replace(/\n+/, "\n").trim("\n");
    return str.split('\n');
}

function clearZeroValuedInput(inputDOM) {
    if (inputDOM.val() == '0') {
        inputDOM.val('');
    }
}

function checkIfMultipleOf(dividend, divisor) {
    if (dividend % divisor == 0)
        return true;
    else
        return false;
}

if (typeof String.prototype.trim !== 'function') {
    String.prototype.trim = function () {
        return this.replace(/^\s+|\s+$/g, '');
    };
}

// String reverse
String.prototype.reverse =
function()
{
	splitext = this.split("");
	revertext = splitext.reverse();
	reversed = revertext.join("");
	return reversed;
}

// function to calculate EAN / UPC checkdigit
function eanCheckDigit(s)
{
	var result = 0;
	var rs = s.reverse();
	for (counter = 0; counter < rs.length; counter++)
	{
		result = result + parseInt(rs.charAt(counter)) * Math.pow(3, ((counter+1) % 2));
	}
	return (10 - (result % 10)) % 10;
}