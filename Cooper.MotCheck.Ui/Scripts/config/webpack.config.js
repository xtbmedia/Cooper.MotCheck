const path = require("path");
 
module.exports = {
    mode: 'development',
    entry: {
        index: "./Scripts/src/registration-form.js"
    },
    output: {
        path: path.resolve(__dirname, "../../wwwroot/lib/app/"),
        filename: "app.js"
    },
    module: {
        rules: [
            {
                use: {
                    loader: "babel-loader"
                },
                test: /\.js$/,
                exclude: /node_modules/ //excludes node_modules folder from being transpiled by babel. We do this because it's a waste of resources to do so.
            }
        ]
    },
    devtool: "source-map"
}