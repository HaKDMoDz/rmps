inethelper.onThunderbirdLoad = function() {
  document.getElementById("threadPaneContext")
          .addEventListener("popupshowing", function(e) { this.showThunderbirdContextMenu(e); }, false);
};

inethelper.showThunderbirdContextMenu = function(event) {
  // show or hide the menuitem based on what the context menu is on
  // see http://kb.mozillazine.org/Adding_items_to_menus
  document.getElementById("context-inethelper").hidden = (GetNumSelectedMessages() > 0);
};

window.addEventListener("load", function(e) { inethelper.onFirefoxLoad(e); }, false);
