const express = require("express");
const path = require("path");
const app = express();
const PORT = 6872;
const bodyParser = require('body-parser');

app.use(bodyParser.json());
app.use(express.static(path.join(__dirname, "./public/dist/public")));

require("./server/config/mongoose");
require("./server/config/routes")(app);

app.listen(PORT, ()=>{
    console.log(`Listening on port: ${PORT}!`);
});