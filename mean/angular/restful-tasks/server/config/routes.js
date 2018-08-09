const tasks = require("./../controllers/tasks");

module.exports = (app) => {
    app.get("/tasks", tasks.root),
    app.get("/tasks/:id", tasks.display),
    app.post("/tasks", tasks.create),
    app.put("/tasks/:id", tasks.update),
    app.delete("/tasks/:id", tasks.delete)
};