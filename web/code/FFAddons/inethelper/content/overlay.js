var inethelper = {
  onLoad: function() {
    this.initialized = true;
  },
  openMini : function(e) {
    var t = document.title;
    var u = document.location.href;
    var d = window.getSelection().toString();
    var u = "http://amonsoft.net/inet/inet0001.aspx?type=11&t="+encodeURIComponent(t)+"&u="+encodeURIComponent(u)+"&d="+encodeURIComponent(d);
    var w = "net_amonsoft_inethelper";
    var m = Components.classes["@mozilla.org/appshell/window-mediator;1"].getService(Components.interfaces.nsIWindowMediator).getMostRecentWindow(w);
    if (m) {
      m.focus();
    } else {
      m = window.openDialog(u, w, "chrome=yes,centerscreen");
    }
    return m;
  },
};
window.addEventListener("load", function(e) { inethelper.onLoad(e); }, false);
