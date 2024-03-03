mergeInto(LibraryManager.library, {

  Hello: function () {
    window.alert("Hello, world!");
  },



  ShowAdv: function()
  {
YaGames.init().then(ysdk => ysdk.adv.showFullscreenAdv({
    callbacks: {
    	onOpen: () => {
          console.log('Video ad open.');
       
          myGameInstance.SendMessage("GameManager", "OpenAdv");
        },
        onClose: function(wasShown) {
      	  console.log('Video ad closed.');
          myGameInstance.SendMessage("GameManager", "CloseAdv");

        },
        onError: function(error) {
          // some action on error
        }
    }
}))

  },
});