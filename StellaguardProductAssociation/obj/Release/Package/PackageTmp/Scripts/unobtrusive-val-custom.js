
// Author: Bhushan Shah

// data-val-* attributes reference: https://web.archive.org/web/20130919030425/http://denverdeveloper.wordpress.com/2012/09/26/some-things-ive-learned-about-jquery-unobtrusive-validation/
// All validation logic copied from jquery.validate.js

$.fn.isFormValid = function () {

    if (this.is('form') == false) {
        return false;
    }

    var errorMessages = new Array();

    $(this).find('input[type="text"],input[type="checkbox"],input[type="password"],textarea,select').each(function () {

        var $this = $(this);
        var $thisValue = $this.val();

        if ($this.attr('data-val') == 'true') {

            // Check required
            var requiredError = $this.attr('data-val-required');
            if (requiredError != null) {
                if (checkIfEmpty($thisValue)) {
                    errorMessages.push(requiredError);
                }
            }

            // Check regex
            var regexPatternError = $this.attr('data-val-regex');
            if (regexPatternError != null) {
                var regexPattern = $this.attr('data-val-regex-pattern');
                if (checkIfMatchesRegex($thisValue, regexPattern) == false) {
                    errorMessages.push(regexPatternError);
                }
            }

            // Check number
            var numberError = $this.attr('data-val-number');
            if (numberError != null) {
                if (checkIfNumber($thisValue) == false) {
                    errorMessages.push(numberError);
                }
            }

            // Check range
            var rangeError = $this.attr('data-val-range');
            if (rangeError != null) {
                var minValue = new Number($this.attr('data-val-range-min'));
                var maxValue = new Number($this.attr('data-val-range-max'));
                if (checkIfWithinRange($thisValue, minValue, maxValue) == false) {
                    errorMessages.push(rangeError);
                }
            }
        }

        // Check string length
        var lengthError = $this.attr('data-val-length');
        if (lengthError != null) {
            var minLength = $this.attr('data-val-length-min') == null ? 0 : new Number($this.attr('data-val-length-min'));
            var maxLength = $this.attr('data-val-length-max') == null ? Number.POSITIVE_INFINITY : new Number($this.attr('data-val-length-max'));
            if (checkIfLengthLessThanOrEqualTo($thisValue, maxLength) == false || checkIfLengthGreaterThanOrEqualTo($thisValue, minLength) == false) {
                errorMessages.push(lengthError);
            }
        }

        // Check equal to
        var equalToError = $this.attr('data-val-equalto');
        if (equalToError != null) {
            var otherFieldId = $this.attr('data-val-equalto-other').substring(2); // Remove "*." from the start of the string, prepended to the field Id by MVC
            var otherFieldValue = $('#' + otherFieldId + ':first').val();
            if (checkIfEqualTo($thisValue, otherFieldValue) == false) {
                errorMessages.push(equalToError);
            }
        }

        //  Check email
        var emailError = $this.attr('data-val-email');
        if (emailError != null) {
            // Following regex copied from jquery validation library
            if (checkIfEmail($thisValue) == false) {
                errorMessages.push(emailError);
            }
        }

        // Check url
        var urlError = $this.attr('data-val-url');
        if (urlError != null) {
            if (checkIfURL($thisValue) == false) {
                errorMessages.push(urlError);
            }
        }

        // Check date
        var dateError = $this.attr('data-val-date');
        if (dateError != null) {
            if (checkIfDate($thisValue) == false) {
                errorMessages.push(dateError);
            }
        }

        // Add dateISO, phone, creditcard etc. if needed
    });

    return errorMessages;
}

function checkIfEmpty(value) {
    if (value == "") {
        return true;
    }
    else {
        return false;
    }
}

function checkIfMatchesRegex(value, regex) {
    var match = new RegExp(regex).exec(value);
    return match && (match.index === 0) && (match[0].length === $thisValue.length);
}

function checkIfNumber(value) {
    return /^-?(?:\d+|\d{1,3}(?:,\d{3})+)?(?:\.\d+)?$/.test(value);
}

function checkIfWithinRange(value, min, max) {
    return value > min && value < max;
}

function checkIfLengthGreaterThan(value, minLength) {
    return value.length > minLength;
}

function checkIfLengthLessThan(value, maxLength) {
    return value.length < maxLength;
}

function checkIfLengthGreaterThanOrEqualTo(value, minLength) {
    return value.length >= minLength;
}

function checkIfLengthLessThanOrEqualTo(value, maxLength) {
    return value.length <= maxLength;
}

function checkIfEqualTo(value, target) {
    return value === target;
}

function checkIfEmail(value) {
    return /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$/i.test(value);
}

function checkIfURL(value) {
    return /^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i.test(value);
}

function checkIfDate(value) {
    return !/Invalid|NaN/.test(new Date(value));
}