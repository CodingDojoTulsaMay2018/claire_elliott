


const express = require("express");
const path = require("path");
const app = express();
const server = app.listen(7081);
const io = require("socket.io")(server);

app.set("views", path.join(__dirname + "/views"));
app.set("view engine", "ejs");
require("./server/config/routes")(app);
var color = "green";
io.on('connection', function (socket){
    console.log("I made it here!");
    io.emit('display', {bgcolor: color});
    socket.on('green', function(){
        color = "green";
        io.emit('display', {bgcolor: color});
    });
    socket.on('blue', function(){
        color = "blue";
        io.emit('display', {bgcolor: color});
    });
    socket.on('purple', function(){
        color = "purple";
        io.emit('display', {bgcolor: color});
    });

});