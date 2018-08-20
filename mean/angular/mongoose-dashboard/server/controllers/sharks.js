const mongoose = require("mongoose");
const Shark = mongoose.model("Shark");

module.exports = {
    all: (req, res, next) => {
        res.sendFile(path.resolve("./public/dist/public/index.html"));
    },
    index: (req, res) => {
        Shark.find({})
            .then(sharks => res.json(sharks))
            .catch(err => res.json(err));
    },
    display: (req, res) => {
        Shark.findOne({
                _id: req.params.id
            })
            .then(sharks => res.json(sharks))
            .catch(err => res.json(err));
    },
    create: (req, res) => {
        console.log("CREATING!!!", req.body);
        Shark.create(req.body)
            .then(shark => res.json(shark))
            .catch(err => res.json(err));
    },
    update: (req, res) => {
        Shark.findOneAndUpdate({
                _id: req.params.id
            }, req.body)
            .then(shark => res.json(shark))
            .catch(err => res.json(err));
    },
    destroy: (req, res) => {
        Shark.remove({
                _id: req.params.id
            })
            .then(shark => res.json({
                message: "Success"
            }))
            .catch(err => res.json(err));
    }
};