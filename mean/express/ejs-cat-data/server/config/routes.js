module.exports = app =>{
    app.get("/", (req,res)=>{
        res.render("cats");
    });

    app.get("/cats/1", (req,res)=>{
        var cat_info = {
            imgurl: "/images/husky01.jpg",
            name: "Pickles",
            favthing: "Licking windows",
            age:4,
            interests: ["eating toilet paper","taking baths","WALKIES!!","head pats"]
        };
        res.render("profile",{cat: cat_info});
    });

    app.get("/cats/2", (req,res)=>{
        var cat_info = {
            imgurl: "/images/husky02.jpg",
            name: "Smuggy McSmuggerton",
            favthing: "Judging you",
            age:6,
            interests: ["not fetching that ball","sitting on your bed","pets"]
        };
        res.render("profile",{cat: cat_info});
    });

    app.get("/cats/3", (req,res)=>{
        var cat_info = {
            imgurl: "/images/husky03.jpg",
            name: "Rascal",
            favthing: "Making snow angels",
            age:1,
            interests: ["taking long walks","hiding in the snow","hunting woodland creatures","playing fetch"]
        };
        res.render("profile",{cat: cat_info});
    });

    app.get("/cats/4", (req,res)=>{
        var cat_info = {
            imgurl: "/images/husky04.jpg",
            name: "Simba",
            favthing: "Being held",
            age: "2 months",
            interests: ["screaming a lot","especially at night","hiding under blankets","seeking revenge for my murdered father"]
        };
        res.render("profile",{cat: cat_info});
    });
};