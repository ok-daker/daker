Array.prototype.containsUser = function (User) {
    var yes = false;
    $(this).each(function () {
        if (this.Id == User.Id)  yes=true;
    });
    return yes;
}
Array.prototype.removeUser = function (User) {
    var usrs = this;
    var yes = false;
    $(this).each(function () {
        if (this.Id == User.Id) usrs.pop(this);
    });
    return usrs;

}