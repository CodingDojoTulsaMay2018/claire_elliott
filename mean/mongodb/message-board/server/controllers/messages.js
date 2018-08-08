const mongoose = require("mongoose");
const Message = mongoose.model("Message");
const Comment = mongoose.model("Comment");

module.exports = {
    index: (req, res) => {
        Message.find({}).sort({createdAt: -1}).exec(function(err, messinDB){
            if(err) {
                console.log(err);
            }
            else {
                res.render("index", {posts: messinDB});
            }
        });
    }, 
    create: (req, res) => {
        const message = new Message(req.body);
        message.save((err) =>{
            if(err){
                for(var key in err.errors){
                    console.log(err.errors[key].message);
                    req.flash('messageCreation', err.errors[key].message);
                }
                res.redirect("/");
            } 
            else{
            res.redirect("/");
            }
        });
    },
    comment: (req, res) => {
        const comment = new Comment(req.body);
        comment.save((err) => {
            if(err){
                for(var key in err.errors){
                    console.log(err.errors[key].message);
                    req.flash('commentCreation', err.errors[key].message);
                }
                res.redirect("/");
            } 
            else{
                Message.findByIdAndUpdate({_id: req.params.id}, {$push: {comments: comment}}, (err) => {
                    if(err){
                        console.log(err);
                    }
                    else{
                        res.redirect("/");
                    }
                });
            }
        });
    }
};