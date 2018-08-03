const express = require("express");
const path = require("path");
const app = express();
const server = app.listen(7080);
const io = require("socket.io")(server);

app.set("views", path.join(__dirname + "/views"));
app.set("view engine", "ejs");
require("./server/config/routes")(app);

io.on('connection', function (socket){
    console.log("I made it heare!");
    socket.on('posting_form', function(data){
        let luckyNum = Math.floor(Math.random()*1000)+1;
        socket.emit('updated_message', {msg: `You emitted the following information to the server: ${data}\n\nYour lucky number emitted by the server is ${luckyNum}!`});
    } );
});