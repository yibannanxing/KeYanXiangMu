import _mergeJSXProps from "@vue/babel-helper-vue-jsx-merge-props";
import { createNamespace } from '../utils';
import { inherit } from '../utils/functional'; // Types

var _createNamespace = createNamespace('cell-group'),
    createComponent = _createNamespace[0],
    bem = _createNamespace[1];

function CellGroup(h, props, slots, ctx) {
  var Group = h("div", _mergeJSXProps([{
    "class": [bem(), {
      'van-hairline--top-bottom': props.border
    }]
  }, inherit(ctx, true)]), [slots.default && slots.default()]);

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
export default createComponent(CellGroup);