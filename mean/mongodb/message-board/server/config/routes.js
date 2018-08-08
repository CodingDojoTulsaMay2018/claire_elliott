const messages = require("./../controllers/messages");

module.exports = (app) => {
    app.get("/", messages.index),
    app.post("/message/add", messages.create),
    app.post("/comments/add/:id", messages.comment)
};