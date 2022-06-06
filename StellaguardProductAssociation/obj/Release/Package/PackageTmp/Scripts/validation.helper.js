
// Replace consecutive multiple newlines with single newline
function correctMultipleNewlines(str) {
    return str.replace(/\n+/, "\n").trim("\n");
}

// Split list of Serial Numbers into array of Serial Numbers
function getSerialNumberArray(str) {
    str = correctMultipleNewlines(str).trim('\n');
    return str.split('\n');
}