const sharks = require("./../controllers/sharks");

module.exports = (app) => {
    app.get("/sharks", sharks.index),    
    app.get("/sharks/:id", sharks.display),
    app.post("/sharks", sharks.create),
    app.put("/sharks/:id", sharks.update),
    app.delete("/sharks/:id", sharks.destroy),
    app.all("*", sharks.all)
};