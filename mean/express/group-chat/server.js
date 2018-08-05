const express = require("express");
var session = require('express-session');
var app = express();
// var ses = express-session();
const path = require("path");
const bodyParser = require('body-parser');
const server = app.listen(7084, function () {
console.log("listening on port 7084");
});
app.use(express.static(path.join(__dirname, "./static")));
app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');
require("./server/config/routes")(app);
app.use(bodyParser.urlencoded({
    extended: true
}));

const io = require('socket.io')(server);
var names = [];
var msgs = [];

io.on('connection', function (socket) {
    //sends all chats to new connections
    socket.emit('chats', {
        chats: msgs
    });
    // sends list of users to new connection
    socket.on('receive_userlist', function(){
        console.log("User list received, updating userlist");
        io.emit('update_userlist', {userlist: names});
    });
    
    console.log("back at server");
    //grabbing user name and validating duplicates
    socket.on('name', function (name) {
        var dup = false;
        console.log(name.name);
        for (var i = 0; i < names.length; i++) {
            if (names[i] == name.name) {
                socket.emit('dupes', {
                    dupes: "This name is already taken"
                });
                dup = true;
            }
            continue;
        }
        //if valid name, pushes it back to html
        if (dup != true) {
            names.push(name.name);
            console.log(names);
            // broadcasts new user's name to chat room
            socket.broadcast.emit('new_user', {new_user: name.name});
        }
    });
    //bringing in a new message, putting it into array, and sending single message back
    socket.on('text', function (text) {
        console.log(text.msg + " is the data");
        msgs.push({person:text.person, msg: text.msg});
        console.log(text.person + " is the person");
        io.emit('msg', {
            msg: text.msg, person: text.person
        });
    });
    
});

