const mongoose = require("mongoose");

const CommentSchema = new mongoose.Schema({
    name: {type: String, required: [true, "Your name is required."], minlength: 2, maxlength: 45}, 
    content: {type: String, required: [true, "A comment is required."], minlength: 2, maxlength: 255}
    },
    {timestamps: true}
);

mongoose.model("Comment", CommentSchema);

const MessageSchema = new mongoose.Schema({
    name: {type: String, required: [true, "Your name is required."], minlength: 2, maxlength: 45}, 
    content: {type: String, required: [true, "A message is required."], minlength: 5, maxlength: 255},
    comments: {type: [CommentSchema]}
    },
    {timestamps: true}
);

mongoose.model("Message", MessageSchema);