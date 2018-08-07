const mongoose = require("mongoose");
const Quote = mongoose.model("Quote");

module.exports = {
    index: (req, res) => {
        Quote.find({}, (err, quotesinDB)=>{
            if(err) {
                console.log(err);
            } else {
                console.log(quotesinDB);
                res.render("index");
            }
        });
    }, 
    create: (req, res) =>{
        console.log("Hit create!");
        const quote = new Quote();
        console.log(req.body);
        quote.author = req.body.author;
        quote.content = req.body.content;
        quote.save((err) =>{
            if(err){
                console.log(err);
                for(var key in err.errors){
                    req.flash('quoting', err.errors[key].message);
                }
                res.redirect("/");
            } 
            else{
            res.redirect("/quotes");
            }
        });
    },
    display: (req, res) => {
        Quote.find({}).sort({createdAt: -1}).exec(function(err, quotesinDB){
            if(err) {
                console.log(err);
            }
            else {
                console.log(quotesinDB);
                res.render("display", {quotes: quotesinDB});
            }
        });
    }
};