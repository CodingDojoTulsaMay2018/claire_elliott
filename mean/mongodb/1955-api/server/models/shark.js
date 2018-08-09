const mongoose = require("mongoose");

const SharkSchema = new mongoose.Schema({
    name: {type: String}, 
    species: {type: String},
    age: {type: Number},
    location: {type: String},
    img: {type: String}
    },
    {timestamps: true});

mongoose.model('Shark', SharkSchema);