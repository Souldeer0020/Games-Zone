$.validator.addMethod('fileSize', function (value, element, param) { //Adds a new validation method called fileSize to jQuery Validator.
    var isValid = this.optional(element) || element.Files[0] <= param;

    return isValid;
});