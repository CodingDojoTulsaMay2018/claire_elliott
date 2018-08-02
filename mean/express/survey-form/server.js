const express = require("express");
let session = require("express-session");
const path = require("path");
const bodyParser = require('body-parser');
const app = express();
const PORT = 7079;

app.use(session({
    secret: 'somethingcool',
    resave: false,
    saveUninitialized: true,
    cookie: { maxAge: 6000 }
}));
app.use(bodyParser.urlencoded({extended: true}));
app.set("views", path.join(__dirname + "/views"));
app.set("view engine", "ejs");

require("./server/config/routes")(app);

app.listen(PORT, ()=>{
    console.log(`Listening on port ${PORT}`);
});