const coins = require("./../controllers/coins");

module.exports = (app) => {
    app.get("/", coins.root),
    app.all("*", coins.angular)
};