const mongoose = require("mongoose");
const Poke = mongoose.model("Poke");

module.exports = {
    root: (req, res) => {
        Poke.find({}, (err, pokesinDB) => {
            if(err) {
                console.log(err);
                res.json({message: "Error", error: err});
            }
            else {
                res.json({message: "Success", pokes: pokesinDB});
            }
        });
    },
    display: (req, res) => {
        Poke.findOne({_id: req.params.id}, (err, pokesinDB) => {
            if(err) {
                console.log(err);
                res.json({message: "Error", error: err});
            }
            else {
                res.json({message: "Success", pokes: pokesinDB});
            }
        });
    },
    create: (req, res) => {
        var poke = new Poke(req.body);
        poke.save((err, pokesinDB) => {
            if(err) {
                console.log(err);
                res.json({message: "Error", error: err});
            }
            else {
                res.json({message: "Success", pokes: pokesinDB});
            }
        });
    },
    update: (req, res) => {
        Poke.findOneAndUpdate({_id: req.params.id}, {$push: {ratings: req.body}}, (err, pokesinDB) => {
            if(err) {
                console.log(err);
                res.json({message: "Error", error: err});
            }
            else {
                res.json({message: "Success", pokes: pokesinDB});
            }
        });
    },
    delete: (req, res) => {
        Poke.findOneAndRemove({_id: req.params.id}, (err) => {
            if(err) {
                console.log(err);
                res.json({message: "Error", error: err});
            }
            else {
                res.json({message: "Success"});
            }
        });
    },
};