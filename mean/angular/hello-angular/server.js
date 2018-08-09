const path = require("path");
const express = require("express");
const PORT = 6879;
const app = express();
const bodyParser = require('body-parser');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended: true}));
app.use(express.static( __dirname + '/public/dist/public'));

app.listen(PORT, ()=>{
    console.log(`Listening on port: ${PORT}!`);
});