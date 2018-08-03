const express = require("express");
const path = require("path");
const app = express();
const server = app.listen(7081);
const io = require("socket.io")(server);

app.set("views", path.join(__dirname + "/views"));
app.set("view engine", "ejs");
require("./server/config/routes")(app);
var count = 0;
io.on('connection', function (socket){
    console.log("I made it here!");
    io.emit('display', {counter: count});
    socket.on('plus_one', function(){
        count++;
        io.emit('display', {counter: count});
        });
    socket.on('reset_counter', function(){
        count = 0;
        io.emit('display', {counter: count});
    });
});