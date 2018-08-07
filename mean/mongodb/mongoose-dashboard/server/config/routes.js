const sharks = require("./../controllers/sharks");

module.exports = (app) => {
    app.get("/", sharks.index),
    app.get("/sharks/new", sharks.add_shark),
    app.get("/sharks/:id", sharks.display),
    app.post("/sharks", sharks.create),
    app.get("/sharks/edit/:id", sharks.edit_shark),
    app.post("/sharks/:id", sharks.update),
    app.get("/sharks/destroy/:id", sharks.destroy)
};