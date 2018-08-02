const express = require("express");
let session = require("express-session");
const path = require("path");
const app = express();
const PORT = 7078;

app.use(session({
    secret: 'somethingcool',
    resave: false,
    saveUninitialized: true,
    cookie: { maxAge: 6000 }
}));
app.use(express.static(path.join(__dirname + "/static")));
app.set("views", path.join(__dirname + "/views"));
app.set("view engine", "ejs");

require("./server/config/routes")(app);

app.listen(PORT, ()=>{
    console.log(`Listening on port ${PORT}`);
});