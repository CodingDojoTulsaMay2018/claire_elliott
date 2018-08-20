const mongoose = require("mongoose");

const PokeSchema = new mongoose.Schema({
    name: {type: String, required: [true, "Give this poor Pokemon a name!"]}, 
    species: {type: String, required: [true, "What species is the Pokemon?"]},
    trainer: {type: String, default: "Wild"},
    ratings: {type: Array},
    url: {type: String, required: [true, "Send in a pic of the Pokemon!"]}
    },
    {timestamps: true});

mongoose.model('Poke', PokeSchema);