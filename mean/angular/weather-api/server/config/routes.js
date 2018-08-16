const weather = require("./../controllers/weather");

module.exports = (app) => {
    app.get("/", weather.root),
    app.all("*", weather.angular)
};