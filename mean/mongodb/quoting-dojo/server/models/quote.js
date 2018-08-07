const mongoose = require("mongoose");

const QuoteSchema = new mongoose.Schema({
    author: {type: String, required: [true, "An author name is required."], minlength: 2, maxlength: 45}, 
    content: {type: String, required: [true, "A quote is required."], minlength: 5, maxlength: 155}
    }, 
    {timestamps: true});

mongoose.model('Quote', QuoteSchema);