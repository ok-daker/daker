Array.prototype.containsUser = function (User) {
    var yes = false;
    $(this).each(function () {
        if (this.Id == User.Id) yes = true;
    });
    return yes;
}
Array.prototype.removeUser = function (User) {
    var usrs = this;
    var yes = false;
    $(this).each(function () {
        if (this.Id == User.Id) {
            var index = usrs.lastIndexOf(this);
            if (index != -1) {
                usrs.splice(index, 1);
            }
        }

    });
    return usrs;

}