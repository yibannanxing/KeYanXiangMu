var path = require('path');
var webpack = require('webpack');

const VueLoaderPlugin = require('vue-loader/lib/plugin');
const tsImportPluginFactory = require('ts-import-plugin');

module.exports = {
    mode: 'production', //production, development
    entry: {
        app: './src/app.ts'
    },
    output: {
        path: path.resolve(__dirname, './wwwroot/scripts'),
        publicPath: './scripts/',
        filename: '[name].js'
    },
    plugins: [
        // make sure to include the plugin for the magic
        new VueLoaderPlugin(),
        new tsImportPluginFactory()
    ],
    module: {
        rules: [
            {
                test: /\.vue$/,
                loader: 'vue-loader',
                options: {
                    loaders: {
                        // Since sass-loader (weirdly) has SCSS as its default parse mode, we map
                        // the "scss" and "sass" values for the lang attribute to the right configs here.
                        // other preprocessors should work out of the box, no loader config like this necessary.
                        'scss': 'vue-style-loader!css-loader!sass-loader',
                        'sass': 'vue-style-loader!css-loader!sass-loader?indentedSyntax',
                        'less': 'vue-style-loader!sass-loader!less-loader'
                    }
                    // other vue-loader options go here
                }
            },
            {
                //按需配置vant
                test: /\.(jsx|tsx|js|ts)$/,
                loader: 'ts-loader',
                options: {
                    transpileOnly: true,
                    getCustomTransformers: () => ({
                        before: [tsImportPluginFactory({ libraryName: 'vant', style: true })]
                    }),
                    compilerOptions: {
                        module: 'esnext'
                    }
                },
                exclude: /node_modules/
            },
            {
                test: /\.(png|jpg|gif|svg|ttf|woff|eot)$/,
                loader: 'file-loader',
                options: {
                    name: '[name].[ext]?[hash]'
                }
            },
            {
                test: /\.css$/,
                loader: 'style-loader!css-loader'
            },
            {
                test: /\.less$/,
                use: [
                    'vue-style-loader',
                    'css-loader',
                    'less-loader'
                ]
            }
        ]
    },
    resolve: {
        extensions: ['.ts', '.js', '.vue', '.json'],
        alias: {
            'vue$': 'vue/dist/vue.esm.js'
        }
    },
    devServer: {
        historyApiFallback: true,
        noInfo: true
    },
    performance: {
        hints: false
    },
    devtool: '#eval-source-map'
};



if (process.env.NODE_ENV === 'production') {
    module.exports.devtool = '#source-map';
    module.exports.plugins = (module.exports.plugins || []).concat([
        new webpack.DefinePlugin({
            'process.env': {
                NODE_ENV: '"production"'
            }
        }),
        new webpack.LoaderOptionsPlugin({
            minimize: true
        })
    ]);
}