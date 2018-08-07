const mongoose = require("mongoose");
const Shark = mongoose.model("Shark");

module.exports = {
    index: (req, res) => {
        Shark.find({}, (err, sharksinDB) => {
            if(err) {
                console.log(err);
            }
            else {
                res.render("index", {sharks: sharksinDB});
            }
        });
    }, 
    display: (req, res) => {
        Shark.findOne({_id: req.params.id}, (err, sharkinDB) => {
            if(err) {
                console.log(err);
            }
            else {
                res.render("display", {shark: sharkinDB});
            }
        });
    },
    add_shark: (req, res) => {
        res.render('addshark');
    }, 
    create: (req, res) =>{
        const shark = new Shark(req.body);
        shark.save((err) =>{
            if(err){
                console.log(err);
                for(var key in err.errors){
                    req.flash('creation', err.errors[key].message);
                }
                res.redirect("/sharks/new");
            } 
            else{
            res.redirect("/");
            }
        });
    },
    edit_shark: (req, res) => {
        Shark.findOne({_id: req.params.id}, (err, sharkinDB)=>{
            if(err) {
            } else {
                res.render("editshark", {shark: sharkinDB});
            }
        });
    }, 
    update: (req, res) =>{
        Shark.update({_id: req.params.id}, req.body, (err, sharkinDB) => {
            if(err){
                console.log(err);
                for(var key in err.errors){
                    req.flash('creation', err.errors[key].message);
                }
                res.redirect("/editshark");
            } 
            else{
            res.redirect("/sharks/" + req.params.id);
            }
        });
    },
    destroy: (req, res) =>{
        Shark.remove({_id: req.params.id}, (err, sharkinDB) => {
            if(err){
                console.log(err);
                for(var key in err.errors){
                    req.flash('creation', err.errors[key].message);
                }
                res.redirect("/sharks/" + req.params.id);
            } 
            else{
            res.redirect("/");
            }
        });
    }
};