


$.validator.addMethod("duplicates",
    function (value, element, params) {
        var duplicates = identifyDuplicatesFromArray(getSerialNumberArray(value));
        if (duplicates.count == 0) {
            return true;
        }
        else {
            var message = $(element).attr('data-val-duplicates');
            $.validator.messages.nameminlength = message += duplicates.forEach(function () { return this.toString() + '\n'; });
            return false;
        }
    });

$.validator.addMethod("serialnumlength",
    function (value, element, params) {
        var length = params.length;
        if (value.length != length) {
            var message = $(element).attr('data-val-serialnumlength');
            $.validator.messages.serialnumlength = $.format(message, length);
            return false;
        }
        else {
            return true;
        }
    });

$.validator.unobtrusive.adapters.add("duplicates", function (options) {
    if (options.message != null) {
        $.validator.messages.duplicates = options.message;
    }
});

$.validator.unobtrusive.adapters.add("serialnumlength", function (options) {

});


function correctMultipleNewlines(str) {
    return str.replace(/\n+/, "\n").trim("\n");
}

function getSerialNumberArray(str) {
    str = correctMultipleNewlines(str);
    return str.split('\n');
}

function identifyDuplicatesFromArray(arr) {
    var i;
    var len = arr.length;
    var obj = {};
    var duplicates = [];
    for (i = 0; i < len; i++) {
        if (!obj[arr[i]]) {
            obj[arr[i]] = {};
        }
        else {
            duplicates.push(arr[i]);
        }
    }
    return duplicates;
}