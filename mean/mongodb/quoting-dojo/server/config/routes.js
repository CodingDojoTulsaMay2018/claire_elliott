const quotes = require("./../controllers/quotes");

module.exports = (app) => {
    app.get("/", quotes.index),
    app.post("/create", quotes.create),
    app.get("/quotes", quotes.display)
};