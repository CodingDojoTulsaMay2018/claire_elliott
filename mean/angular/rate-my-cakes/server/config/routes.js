const poke = require("./../controllers/pokemon");

module.exports = (app) => {
    app.get("/pokemon", poke.root),
    app.get("/pokemon/:id", poke.display),
    app.post("/pokemon", poke.create),
    app.put("/pokemon/:id", poke.update)
};