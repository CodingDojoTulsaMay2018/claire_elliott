const mongoose = require("mongoose");
const Task = mongoose.model("Task");

module.exports = {
    root: (req, res) => {
        Task.find({}, (err, tasksinDB) => {
            if(err) {
                console.log(err);
                res.json({message: "Error", error: err});
            }
            else {
                res.json({message: "Success", tasks: tasksinDB});
            }
        });
    },
    display: (req, res) => {
        Task.findOne({_id: req.params.id}, (err, tasksinDB) => {
            if(err) {
                console.log(err);
                res.json({message: "Error", error: err});
            }
            else {
                res.json({message: "Success", tasks: tasksinDB});
            }
        });
    },
    create: (req, res) => {
        var user = new Task(req.body);
        user.save((err, tasksinDB) => {
            if(err) {
                console.log(err);
                res.json({message: "Error", error: err});
            }
            else {
                res.json({message: "Success", tasks: tasksinDB});
            }
        });
    },
    update: (req, res) => {
        Task.findOneAndUpdate({_id: req.params.id}, req.body, (err, tasksinDB) => {
            if(err) {
                console.log(err);
                res.json({message: "Error", error: err});
            }
            else {
                res.json({message: "Success", tasks: tasksinDB});
            }
        });
    },
    delete: (req, res) => {
        Task.findOneAndRemove({_id: req.params.id}, (err, tasksinDB) => {
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