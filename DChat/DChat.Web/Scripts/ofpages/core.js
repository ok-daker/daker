
var Notification =Notification  || window.mozNotification || window.webkitNotification;
function Notice(title, body) {
    if (Notification && Notification.permission != "granted") {
        Notification.requestPermission(function (status) {
            //获取授权
            if (status == "denied") {
                alert("未能正常推送消息，请检查你的浏览器设置.");
                return;
            }
            if (Notification.permission !== status) {

                Notification.permission = status;
            }
        });
      
    }
    var instance = new Notification(
          title, {
              body: body
          }
      );
}
function InViewState() {
    var visibilityState = document.visibilityState || document.webkitVisibilityState || document.mozVisibilityState;
    if (visibilityState == "visible") {
        return true;
    } else {
        return false;
    }
}


