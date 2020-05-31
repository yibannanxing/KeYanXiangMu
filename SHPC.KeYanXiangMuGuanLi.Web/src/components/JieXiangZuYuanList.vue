<template>
    <div style="padding:10px">
        <i-table ref="selection" :columns="columns" size="small" :data="jiexiangzuyuan" border="true" :loading="tableLoading"></i-table>

        <Modal title="组员"
               v-model="modalzuyuan"
               width="40%"
               :footer-hide="true"
               :styles="{top: '0'}"
               :mask-closable="false"
               :scrollable='false'
               :transfer="false"
               class-name="vertical-center-modal">
            <div :style="{height:matchHeight+'px','overflow-y':'auto',padding:0}">
                <!--<xiangmuzuyuan v-if="modalzuyuan" :xiangmuzuyuan="currentxiangmuzuyuan" @close="close"></xiangmuzuyuan>-->
                <jiexiangzuyuanEdit v-if="modalzuyuan" :isstu="isstu" :jiexiangzuyuan="currentjiexiangzuyuan" @close="close"></jiexiangzuyuanEdit>
            </div>
        </Modal>

    </div>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    import { fail } from "assert";
    import jiexiangzuyuanEdit from './jiexiangzuyuanEdit.vue';

    const qs = require('qs');
    export default {
        data() {
            return {
                modalzuyuan: false,
                matchHeight: window.innerHeight * 0.6,
                tableLoading: false,
                columns: [
                    {
                        title: '姓名',
                        key: 'xingMing'

                    },
                    //{

                    //    title: '部门',
                    //    key: 'buMen'
                    //},
                    //{

                    //    title: '职务',
                    //    key: 'zhiWu'
                    //},
                    //{

                    //    title: '研究专长',
                    //    key: 'yanJiuZhuanChang'
                    //},
                    //{

                    //    title: '所属专业',
                    //    key: 'zuanYe'
                    //},
                    //{

                    //    title: '项目研究分工情况',
                    //    key: 'fenGongQingKuang'
                    //},
                ],
                bumen: {

                    title: '部门',
                    key: 'buMen'
                },
                zhiWu: {

                    title: '职务',
                    key: 'zhiWu'
                },
                yanJiuZhuanChang: {

                    title: '研究专长',
                    key: 'yanJiuZhuanChang'
                },
                zuanYe: {
                    title: '所属专业',
                    key: 'zuanYe'
                },
                fenGongQingKuang: {
                    title: '项目研究分工情况',
                    key: 'fenGongQingKuang'
                },
                caozuo: {
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
                                        this.currentjiexiangzuyuan = params.row
                                        this.modalzuyuan = true
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
                },
                //jiexiangzuyuan: [],
                currentjiexiangzuyuan: {}
            }
        },
        model: {
            prop: 'jiexiangzuyuan',
            event: 'changeModel'
        },
        props: ['jiexiangzuyuan', 'isstu'],
        mounted() {
            //console.log(this.isstu)
            if (this.isstu) {
                this.columns.push(this.yanJiuZhuanChang)
                this.columns.push(this.zuanYe)
                this.columns.push(this.fenGongQingKuang)
                this.columns.push(this.caozuo)
            } else {
                this.columns.push(this.bumen)
                this.columns.push(this.zhiWu)
                this.columns.push(this.fenGongQingKuang)
                this.columns.push(this.caozuo)
               // this.columns.push(this.bumen, this.zhiWu, this.fenGongQingKuang, this.caozuo)
            }
           
        },
        computed: {},
        components: {
            jiexiangzuyuanEdit
        },
        methods: {
            getjxzys() {
                this.tableLoading = true;
                axios.get('api/JieXiang/GetJieXiangZuYuans', {
                    params: {
                        id: this.lxid,
                    }
                })
                    .then(response => {
                        this.jiexiangzuyuan = response.data.results
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            close(zy) {
                this.modalzuyuan = false;
                //console.log(zy)
                var matchItems = this.jiexiangzuyuan.filter(p => p.liXiangId == zy.liXiangId);
                var a = 0;
                if (matchItems.length > 0) {
                    //var obj = matchItems[0];
                    matchItems.forEach((item, index) => {
                        if (zy.xingMing == item.xingMing) {
                            this.jiexiangzuyuan[index] = zy;
                            a++;
                        }
                    })
                }
                this.$emit('changeModel', this.jiexiangzuyuan);
                console.log(this.jiexiangzuyuan);
            },
            deleteItem(id) {
                this.$Modal.confirm({
                    title: "删除",
                    content: "您确定要删除嘛",
                    onOk: () => {
                        if (this.jiexiangzuyuan.splice(id, 1)) {
                            this.$Notice.success({
                                title: '操作成功',
                            });
                            //this.$emit('changeModel', this.xiangmuzuyuans);
                        } else {
                            this.$Notice.error({
                                title: '系统错误',
                                desc: '系统错误'
                            });
                        }

                    },
                })
            },


        }
    };
</script>
<style>
</style>