$('#feed-btn').click(function(){
        $.ajax({
              url: 'Feed',
              success: function(serverResponse) {
                console.log("Received this from server:", serverResponse);
                console.log("Now, I can use the serverResponse to manipulate the DOM");
                $('#dojo-img').attr('src','~/images/dojo_like.gif');
              }
          });
      });