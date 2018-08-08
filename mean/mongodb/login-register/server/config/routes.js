const users = require("./../controllers/users");

module.exports = (app) => {
    app.get("/", users.index),
    app.post("/login", users.login),
    app.post("/register", users.register),
    app.get("/success", users.success)
};