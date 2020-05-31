<template>
    <div style="padding:10px">
        <i-button @click="upload" type="primary" style="margin-bottom:5px">成果上传</i-button>
        <i-table ref="selection" :columns="columns" size="small" :data="chengguolist" border="true" :loading="tableLoading" @on-selection-change="getChengGuoList"></i-table>
        <div style="display:flex;justify-content:center;align-items:center;padding:5px;">
            <Page size="small" :total="totalRows" :page-size-opts="[10,15, 20, 30, 40]" show-total show-sizer show-elevator
                  :current="pageIndex" :page-size="pageSize" @on-change="pageIndexChange" @on-page-size-change="pageSizeChange" />
        </div>

        <Modal title=" "
               v-model="modalshow"
               width="60%"
               :footer-hide="true"
               :styles="{top: '0'}"
               :mask-closable="false"
               :scrollable='false'
               :transfer="false"
               class-name="vertical-center-modal">
            <div :style="{height:matchHeight+'px','overflow-y':'auto',padding:0}">
                <FuJian v-if="modalshow&type==0" @close="close" :id="id"> </FuJian>
                <chengguoShow v-if="modalshow&type==1" :isview="isview" @close="close" :id="id"> </chengguoShow>
            </div>
        </Modal>


    </div>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    import FuJian from './FuJian.vue';
    import chengguoShow from './chengguoShow.vue';
    const qs = require('qs');
    export default {
        data() {
            return {
                matchHeight: window.innerHeight * 0.8,
                modalshow: false,
                tableLoading: false,
                totalRows: 0,
                pageIndex: 1,
                pageSize: 15,
                columns: [
                    {
                        title: '作者',
                        key: 'zuoZeMingCheng',

                    },
                    {
                        title: '成果名称',
                        key: 'chengGuoMingCheng',

                    },
                    {
                        title: '成果类型',
                        key: 'chengGuoLeiXingName',

                    },
                    {
                        title: '期刊名称',
                        key: 'chengGuoMingCheng',
                    },
                    {
                        title: '年期',
                        key: 'nianQi',
                    },
                    {
                        title: '操作',
                        align: 'center',
                        width: 240,
                        fixed: 'right',
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
                                            this.id = params.row.id
                                            this.type = 0
                                            this.modalshow = true
                                        }
                                    }
                                }, '编辑'),
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
                                            this.id = params.row.id
                                            this.type = 1
                                            this.isview = true
                                            this.modalshow = true
                                        }
                                    }
                                }, '详情'),
                                h('i-button', {
                                    props: {
                                        type: 'error',
                                        size: 'small'
                                    },
                                    style: {
                                        marginRight: '5px'
                                    },
                                    on: {
                                        click: () => {
                                            this.deleteItem(params.row.id)
                                        }
                                    }
                                }, '删除'),

                            ]);
                        }
                    }
                ],
                chengguolist: [],
            }
        },
        props: [],
        mounted() {
            this.getChengGuoList()
        },
        computed: {},
        components: {
            FuJian, chengguoShow
        },
        methods: {
            close() {
                this.modalshow = false;
                this.getChengGuoList();
            },
            getChengGuoList() {
                this.tableLoading = true;
                axios.get('api/XiangMuChengGuo/GetXiangMuChengGuoByUser', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize
                    }
                })
                    .then(response => {
                        this.chengguolist = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            pageIndexChange(currentIndex) {
                this.pageIndex = currentIndex
                this.getChengGuoList()
            },
            pageSizeChange(currentpagrSize) {
                this.pageSize = currentpagrSize
                this.getChengGuoList()
            },
            //审核
            shenhe(id) {

            },
            //删除
            deleteItem(id) {
                //DelXiangMuChengGuo
                this.$Modal.confirm({
                    title: "删除",
                    content: "您确定要删除嘛",
                    onOk: () => {
                        axios.get('api/XiangMuChengGuo/DelXiangMuChengGuo', { params: { ChengGuoID: id } }).then(response => {
                            if (!response.data.error) {
                                this.$Notice.success({
                                    title: '操作成功',
                                });
                                this.getChengGuoList();
                            } else {
                                this.$Notice.error({
                                    title: '系统错误',
                                });
                            }
                        }).catch(error => {
                            console.log(error);
                        });
                    },
                })
            },
            upload() {
                this.id = null;
                this.type = 0;
                this.modalshow = true;
            }
        }
    };
</script>
<style>
</style>