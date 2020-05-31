"use strict";

var _interopRequireDefault = require("@babel/runtime/helpers/interopRequireDefault");

exports.__esModule = true;
exports.default = void 0;

var _babelHelperVueJsxMergeProps = _interopRequireDefault(require("@vue/babel-helper-vue-jsx-merge-props"));

var _utils = require("../utils");

var _functional = require("../utils/functional");

var _createNamespace = (0, _utils.createNamespace)('cell-group'),
    createComponent = _createNamespace[0],
    bem = _createNamespace[1];

function CellGroup(h, props, slots, ctx) {
  var Group = h("div", (0, _babelHelperVueJsxMergeProps.default)([{
    "class": [bem(), {
      'van-hairline--top-bottom': props.border
    }]
  }, (0, _functional.inherit)(ctx, true)]), [slots.default && slots.default()]);

  if (props.title) {
    return h("div", [h("div", {
      "class": bem('title')
    }, [props.title]), Group]);
  }

  return Group;
}

CellGroup.props = {
  title: String,
  border: {
    type: Boolean,
    default: true
  }
};

var _default = createComponent(CellGroup);

exports.default = _default;