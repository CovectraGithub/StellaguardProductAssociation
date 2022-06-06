
$.validator.addMethod("checkifmultipleof",
    function (
        value, // element to be validated
        element, // HTML element to which the validator is attached
        params // array of name/value pairs of the parameters extracted from the HTML
    ) {
        var baseValue = parseInt($(params).val());
        var targetValue = Number(value);
        if (targetValue % baseValue != 0) {
            var message = $(element).attr('data-val-multipleof');
            $.validator.messages.checkIfMultipleOf = message;
            return false;
        }
        return true;
    });

var adapterArray = $.validator.unobtrusive.adapters;
adapterArray = $.grep(adapterArray, function (element, index) {
    return element.name !== 'range';
});
$.validator.unobtrusive.adapters = adapterArray;

$.validator.unobtrusive.adapters.add("checkifmultipleof", ["basepropname"], function (options) {
    var paramField = "#" + options.params.basepropname;
    options.rules["checkIfMultipleOf"] = paramField;
    if (options.message != null) {
        $.validator.messages.nameminlength = options.message;
    }
});
