const users = require("./../controllers/sharks");

module.exports = (app) => {
    app.get("/", users.root),
    app.get("/new/:name", users.new),
    app.get("/remove/:name", users.remove),
    app.get("/:name", users.display)
};