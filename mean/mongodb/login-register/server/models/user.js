const mongoose = require("mongoose");

var fromFuture = function(birthday){
    return birthday < Date.now();
};

const UserSchema = new mongoose.Schema({
    first_name: {type: String, required: [true, "First name is required."], minlength: 2, maxlength: 45}, 
    last_name: {type: String, required: [true, "Last name is required."], minlength: 2, maxlength: 45}, 
    email: {type: String, trim: true, lowercase: true, unique: true, required: "Email address is required", match: [/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/, "Please fill in a valid email address"]},
    password: {type: String, required: [true, "A password is required."], minlength: 5, maxlength: 255},
    birthday: {type: Date, required: [true, "A birthday is required."], validate: [fromFuture, "Birthday must not be in the future."]}
    },
    {timestamps: true}
);

mongoose.model("User", UserSchema);