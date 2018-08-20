const path = require('path');
module.exports = {
    root: (req, res) => {
    },
    angular: (req,res,next) => {
        res.sendFile(path.resolve("./public/dist/public/index.html"));
    }
};