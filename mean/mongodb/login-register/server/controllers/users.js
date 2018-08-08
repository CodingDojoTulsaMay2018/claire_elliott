const mongoose = require("mongoose");
const User = mongoose.model("User");
const bcrypt = require('bcrypt');

module.exports = {
    index: (req, res) => {
        res.render("index");
    },
    register: (req, res) => {
        const user = new User(req.body);
        user.save((err) =>{
            if(err){
                for(var key in err.errors){
                    console.log(err.errors[key].message);
                    req.flash('registration', err.errors[key].message);
                }
                res.redirect("/");
            } 
            else{
                req.session.id = user._id;
                req.session.name = user.name;
                user.password = bcrypt.hashSync(req.body.password, 10);
                console.log(user.password);
                user.save();
                res.redirect("/success");
            }
        });
        
    },
    login: (req, res) => {
        console.log(req.body.email);
        User.findOne({email: req.body.email}, (err, user) =>{
            if(user.email == null){
                console.log("Email is invalid");
            }
            else{
                var isValid = bcrypt.compareSync(req.body.password, user.password);
                console.log(user.password);
                if(isValid){
                    req.session.id = user._id;
                    req.session.name = user.name;
                    res.redirect("/success");
                }
                else{
                    console.log("Password is invalid");
                    res.redirect("/");
                }
            }
        });
        
    },
    success: (req, res) => {
        res.render("success");
    }
};