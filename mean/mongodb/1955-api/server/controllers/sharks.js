const mongoose = require("mongoose");
const Shark = mongoose.model("Shark");

module.exports = {
    root: (req, res) => {
        Shark.find({}, (err, sharksinDB) => {
            if(err) {
                console.log(err);
                res.json({message: "Error", error: err});
            }
            else {
                res.json({message: "Success", sharks: sharksinDB});
            }
        });
    },
    display: (req, res) => {
        Shark.findOne({name: req.params.name}, (err, sharksinDB) => {
            if(err) {
                console.log(err);
                res.json({message: "Error", error: err});
            }
            else {
                res.json({message: "Success", sharks: sharksinDB});
            }
        });
    },
    remove: (req, res) => {
        Shark.findOneAndRemove({name: req.params.name}, (err, sharksinDB) => {
            if(err) {
                console.log(err);
                res.json({message: "Error", error: err});
            }
            else {
                res.json({message: "Success", sharks: sharksinDB});
            }
        });
    },
    new: (req, res) => {
        var shark = new Shark({name: req.params.name});
        shark.save((err, sharksinDB) => {
            if(err) {
                console.log(err);
                res.json({message: "Error", error: err});
            }
            else {
                Shark.findOne({name: req.params.name}, (err, sharksinDB) => {
                    if(err) {
                        console.log(err);
                        res.json({message: "Error", error: err});
                    }
                    else {
                        res.json({message: "Success", sharks: sharksinDB});
                    }
                });
            }
        });
    }
};