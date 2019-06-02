const path = require("path");
const webpack = require("webpack");

module.exports = {
  mode: 'development',
  resolve: {
    extensions: [".ts", ".js"]
  },
  devtool: "inline-source-map",
  module: {
    rules: [
      {
        test: /\.ts?$/,
        loader: "ts-loader"
      }
    ]
  },
  entry: {
    "clientjs": "./source/Initialize.ts"
  },
  output: {
    path: path.join(__dirname, "/dist"),
    filename: "[name].js"
  }
};