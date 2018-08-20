const mongoose = require("mongoose");

const SharkSchema = new mongoose.Schema({
    name: {type: String, required: [true, "A cute name is required."], minlength: 5, maxlength: 45}, 
    species: {type: String, required: [true, "A species is required."], minlength: 5, maxlength: 255},
    age: {type: Number, required: [true, "An age is required."]},
    location: {type: String, required: [true, "A location is required."], minlength: 5, maxlength: 255},
    img: {type: String}
    },
    {timestamps: true});

mongoose.model('Shark', SharkSchema);