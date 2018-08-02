module.exports = app =>{
    app.get("/", (req,res)=>{
        if(!req.session.count){
            req.session.count = 1;
        }else{
            req.session.count += 1;
        }
        res.render("index", { session: req.session });
    });

    app.get("/add", (req,res)=>{
        req.session.count += 1;
        res.redirect("/");
    });

    app.get("/reset", (req,res)=>{
        req.session.destroy();
        res.redirect("/");
    });
};