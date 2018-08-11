const mongoose = require("mongoose");

const AnimalSchema = new mongoose.Schema({
    name: {type: String, required:[true, "Please enter an animal's name!"], maxlength:[15, "Name must be shorter than 15 chars!"]},
    population: {type: Number, required:[true, "How many animals are left?"]}
}, {timestamps: true});

mongoose.model("Animal", AnimalSchema);