Array.prototype.containsUser = function (User) {
    var yes = false;
    $(this).each(function () {
        if (this.Id == User.Id)  yes=true;
    });
    return yes;

}