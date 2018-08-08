const express = require("express");
const path = require("path");
const app = express();
const PORT = 6869;
const session = require('express-session');
const flash = require('express-flash');
const bodyParser = require('body-parser');

app.use(bodyParser.urlencoded({extended: true}));
app.use(flash());
app.use(session({
  secret: 'somethingcool',
  resave: false,
  saveUninitialized: true,
  cookie: { maxAge: 60000 }
}));
app.use(express.static(path.join(__dirname, "./static")));
app.set("views", path.join(__dirname, "./views"));
app.set("view engine", "ejs");

require("./server/config/mongoose");
require("./server/config/routes")(app);

app.listen(PORT, ()=>{
    console.log(`Listening on port: ${PORT}!`);
});