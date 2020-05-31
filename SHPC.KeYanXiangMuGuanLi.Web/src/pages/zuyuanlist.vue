<template>
    <div style="padding:10px">

        <i-button v-if="!isView" @click="add" type="primary" style="margin:5px 0">新增组员</i-button>
        <i-table ref="selection" :columns="columns" size="small" :data="xiangmuzuyuans" border="true" :loading="tableLoading"></i-table>

        <Modal title="添加组员"
               v-model="modalzuyuan"
               width="40%"
               :footer-hide="true"
               :styles="{top: '0'}"
               :mask-closable="false"
               :scrollable='false'
               :transfer="false"
               class-name="vertical-center-modal">
            <div :style="{height:matchHeight+'px','overflow-y':'auto',padding:0}">
                <xiangmuzuyuan v-if="modalzuyuan" :xiangmuzuyuan="currentxiangmuzuyuan" @close="close"></xiangmuzuyuan>
            </div>
        </Modal>

    </div>



</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    import xiangmuzuyuan from '../components/xiangmuzuyuan.vue';
    const qs = require('qs');
    const moment = require('moment');
    export default {
        data() {
            return {
                currentId: null,
                currentxiangmuzuyuan: {},
                modalzuyuan: false,
                matchHeight: window.innerHeight * 0.6,
                tableLoading: false,
                columns: [
                    {
                        title: '组员名称',
                        key: 'xiangMuZuChengYuanXingMing'

                    },
                    {

                        title: '性别',
                        key: 'xingBie',
                        render: (h, params) => {
                            if (params.row.xingBie == '0') {
                                return h('span', "男")
                            } else {
                                return h('span', "女")
                            }
                        }
                    },
                    {

                        title: '出生年月',
                        key: 'chuShengNianYue',
                        render: (h, params) => {
                            return h('span', moment(params.row.chuShengNianYue).format('YYYY-MM-DD'))
                        }
                    },
                    {

                        title: '职务名称',
                        key: 'zhiWuMingCheng'
                    },
                    {

                        title: '研究专长',
                        key: 'yanJiuZhuanChang'
                    },
                    {

                        title: '学历',
                        key: 'xueLi'
                    },
                    {

                        title: '所属部门',
                        key: 'suoSuBuMenMingCheng'
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
                                        this.currentxiangmuzuyuan = params.row
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
                }
            }
        },
        model: {
            prop: 'xiangmuzuyuans',
            event: 'changeModel'
        },
        props: ['xiangmuzuyuans','xiangmuId', 'isView'],
        watch: {
            
        },
        mounted() {
            if (!this.isView) {
                this.columns.push(this.operationColumn);
            }
        },
        computed: {
        },
        components: {
            xiangmuzuyuan
        },
        methods: {
            add() {
                this.currentxiangmuzuyuan = {};
                this.modalzuyuan = true
            },
            close(zy) {
                this.modalzuyuan = false;
                console.log(zy);
                var matchItems = this.xiangmuzuyuans.filter(p => p.id == zy.id);
                if (matchItems.length > 0) {
                    var obj = matchItems[0];
                    this.xiangmuzuyuans.forEach((item, index) => {
                        if (obj.id == item.id) {
                            this.xiangmuzuyuans[index] = zy
                        }
                    })
                } else {
                    this.xiangmuzuyuans.push(zy);
                }
                this.$emit('changeModel', this.xiangmuzuyuans);
            },
            //删除
            deleteItem(id) {
                this.$Modal.confirm({
                    title: "删除",
                    content: "您确定要删除嘛",
                    onOk: () => {
                        if (this.xiangmuzuyuans.splice(id, 1)) {
                            this.$Notice.success({
                                title: '操作成功',
                            });
                            this.$emit('changeModel', this.xiangmuzuyuans);
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