

var numberLength = 20;

var serialNumbersTxtBox = $("#SerialNumbers");

var serialNumbersArray = new Array();

var serialNumbersStr;

var packageTypePrefix = '1';

function throwError(errorVar,error) {
    errorVar = error;
}

function validateSerialNumbers(serialNumbersTxtBox,countLabel,numberLength,packageType,startNumber,endNumber,callback) {
    
    if (countLabel != null) {
        var currentCount = int.parse(countLabel.html());
    }

    serialNumbersTxtBox.unbind('keypress').keypress(function (e) { // Need to unbind first to prevent from firing twice

        if (e.which == 13) {
            serialNumbersStr = serialNumbersTxtBox.val();
            var serialNumbersArray = getSerialNumberArray(serialNumbersStr);
            var lastSerialNumber = serialNumbersArray.pop();

            // Check length

            if (lastSerialNumber.length != numberLength) {
                return 'Length must be ' + numberLength;
            }

            // Check duplicate

            var duplicateCheck = serialNumbersArray.every(function (value, index, traversedObject) {
                if (value == lastSerialNumber) {
                    return 'Number already exists';
                }
                else {
                    return true;
                }
            });

            if (duplicateCheck != true) {
                return duplicateCheck;
            }

            if (packageType != null) {
                // Check arguments
                if (startNumber == null || endNumber == null) {
                    return 'Invalid arguments to JavaScript function';
                }
                // Check if number falls in range
                if (lastSerialNumber < startNumber || lastSerialNumber > startNumber) {
                    return 'Package type must be ' + packageType;
                }
            }

            // If all validations successful
            if (countLabel != null) {
                currentCount++;
                countLabel.html(currentCount);
            }
            return true;
        }
    });
}