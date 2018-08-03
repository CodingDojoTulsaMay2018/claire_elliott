module.exports = app =>{
    app.get("/", (req,res)=>{
        res.render("index");
    });

    app.post("/process", (req,res)=>{
        req.session.answers = req.body;
        res.redirect("/results");
    });

    app.get("/results", (req,res)=>{
        res.render("results", {answers: req.session.answers});
    });
};