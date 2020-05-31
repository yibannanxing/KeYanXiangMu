<template>
    <div style="padding:10px">
        <i-button @click="add"
                  v-if="!isView"
                  style="margin:5px 5px 5px 0 ; "
                  type="primary">新增经费</i-button>
        <i-table ref="selection"
                 :columns="columns"
                 size="small"
                 :data="jingfeilist"
                 border="true"
                 :loading="tableLoading"></i-table>

        <Modal title="添加/编辑"
               v-model="tjjingfei"
               width="30%"
               :footer-hide="true"
               :styles="{top: '0'}"
               :mask-closable="false"
               :scrollable='false'
               :transfer="false"
               class-name="vertical-center-modal">
            <div :style="{height:matchHeight+'px','overflow-y':'auto',padding:0}">
                <xiangmujingfei v-if="tjjingfei" @close="close" :jingfei="jingfei"></xiangmujingfei>
            </div>
        </Modal>

    </div>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import xiangmujingfei from '../components/xiangmujingfei.vue';
    import { mapState } from 'vuex';
    const qs = require('qs');
    export default {
        data() {
            return {
                jingfei: {},
                tjjingfei: false,
                matchHeight: window.innerHeight * 0.4,
                tableLoading: false,
                columns: [
                    {
                        title: '经费名称',
                        key: 'mingCheng'

                    },
                    {
                        title: '金额',
                        key: 'jinE'
                    },

                ],
                operationColumn: {
                    title: '操作',
                    align: 'center',
                    render: (h, params) => {
                        return h('div', [
                            h('i-button', {
                                props: {
                                    type: 'primary',
                                    size: 'small'
                                },
                                style: {
                                    marginRight: '5px'
                                },
                                on: {
                                    click: () => {
                                        this.jingfei = params.row
                                        this.tjjingfei = true

                                    }
                                }
                            }, '编辑'),
                            h('i-button', {
                                props: {
                                    type: 'error',
                                    size: 'small'
                                },
                                style: {

                                },
                                on: {
                                    click: () => {
                                        this.deleteItem(params.index)
                                    }
                                }
                            }, '删除')

                        ]);
                    }
                }
            }
        },
        model: {
            prop: 'jingfeilist',
            event: 'changeModel'
        },
        props: ['jingfeilist', 'xiangmuId', 'isView'],
        watch: {

        },
        mounted() {
            if (!this.isView) {
                this.columns.push(this.operationColumn);
            }
        },
        computed: {},
        components: {
            xiangmujingfei
        },
        methods: {
            add() {
                this.jingfei = {};
                this.tjjingfei = true
            },
            close(jf) {
                this.tjjingfei = false;
                var matchItems = this.jingfeilist.filter(p => p.id == jf.id);
                var isPlus = false;
                var _index = 0;
                var x = 0;
                this.jingfeilist.forEach((item, index) => {
                    if (matchItems.length > 0) {
                        var obj = matchItems[0];
                        if (obj.id == item.id) {
                            this.jingfeilist[index] = jf;
                            x = 1;
                        }
                    }
                    else {
                        if (jf.mingCheng == item.mingCheng) {
                            isPlus = true;
                            _index = index;

                        }
                    }
                })
                if (isPlus) {
                    this.jingfeilist[_index].jinE += jf.jinE;
                }
                else {
                    if (_index == 0 && isPlus == false && x == 0) {
                        this.jingfeilist.push(jf);
                    }
                }

                this.changeTotal();
            },
            //删除
            deleteItem(id) {
                this.$Modal.confirm({
                    title: "删除",
                    content: "您确定要删除嘛",
                    onOk: () => {
                        if (this.jingfeilist.splice(id, 1)) {
                            this.$Notice.success({
                                title: '操作成功',
                            });
                            this.changeTotal();
                        } else {
                            this.$Notice.error({
                                title: '系统错误',
                                desc: '系统错误'
                            });
                        }

                    },
                })
            },
            changeTotal() {
                var _jf = 0;
                if (this.jingfeilist) {
                    this.jingfeilist.forEach((item, index) => {
                        _jf += item.jinE
                    })
                }
                this.$emit('changeModel', this.jingfeilist);
                this.$emit('changeTotal', this.numFilter(_jf));
            },
            numFilter(value) {
                // 截取当前数据到小数点后两位 不四舍五入
                let tempVal = parseFloat(value).toFixed(3)
                let realVal = tempVal.substring(0, tempVal.length - 1)
                return realVal * 1

            }
        }
    };
</script>
<style>
</style>