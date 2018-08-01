module.exports = app =>{
    app.get("/cars", (req,res)=>{
        res.render("cars");
    });

    app.get("/cats", (req,res)=>{
        res.render("cats");
    });

    app.get("/cars/new", (req,res)=>{
        res.render("newcar");
    });
};