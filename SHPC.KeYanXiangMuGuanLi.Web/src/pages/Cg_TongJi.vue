<template>
    <div style="padding:10px">
        <div style="padding:5px 0;">
            姓名：<i-input v-model="filterObj.applyName" style="width:200px"></i-input>
            部门：<i-input v-model="filterObj.bumen" style="width:200px"></i-input>

            开始时间：  <DatePicker type="date" v-model="filterObj.startTime" style="width:200px"></DatePicker>
            <!--<i-input v-model="filterObj.startTime" style="width:50%;"></i-input>-->
            结束时间：<!--<i-input v-model="filterObj.bumen" style="width:50%;"></i-input>-->
            <DatePicker type="date" v-model="filterObj.endTime" style="width:200px"></DatePicker>

            <i-button @click="select" type="primary" style="margin-right:1px">查询</i-button>
            <i-button @click="reset" style="margin-right:1px">重置</i-button>

        </div>

        <i-table ref="selection" :columns="columns" size="small" :data="huizonglist" border="true" :loading="tableLoading" @on-selection-change="gethuizong"></i-table>

        <div style="display:flex;justify-content:center;align-items:center;padding:5px;">
            <Page size="small" :total="totalRows" :page-size-opts="[10,15, 20, 30, 40]" show-total show-sizer show-elevator
                  :current="pageIndex" :page-size="pageSize" @on-change="pageIndexChange" @on-page-size-change="pageSizeChange" />
        </div>

        <Modal title=""
               v-model="modalshow"
               width="40%"
               :footer-hide="true"
               :styles="{top: '0'}"
               :mask-closable="false"
               :scrollable='false'
               :transfer="false"
               class-name="vertical-center-modal">
            <div :style="{height:matchHeight+'px','overflow-y':'auto',padding:0}">
                <CG_NianDuKaoHe v-if="modalshow" :id="id" @close="close"></CG_NianDuKaoHe>
            </div>
        </Modal>
    </div>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    import expandRow from './expandRow.vue';
    import CG_NianDuKaoHe from '../components/CG_NianDuKaoHe.vue';
    import { triggerAsyncId } from "async_hooks";
    const moment = require('moment');
    const qs = require('qs');
    export default {
        data() {
            return {
                modalshow: false,
                matchHeight: window.innerHeight * 0.5,
                id: null,
                tableLoading: false,
                totalRows: 0,
                pageIndex: 1,
                pageSize: 10,
                columns: [
                    {
                        type: 'expand',
                        width: 50,
                        render: (h, params) => {
                            return h(expandRow, {
                                props: {
                                    row: params.row,
                                }
                            })
                        }
                    },
                    {
                        title: '年度',
                        key: 'nianDu'
                    },
                    {
                        title: '姓名',
                        key: 'userName'
                    },
                    {
                        title: '所属部门',
                        key: 'buMenMingCheng'
                    },
                    {
                        title: '专技职务',
                        key: 'zhuanJiZhiWu',
                        render: (h, params) => {
                            return h('span', this.getzhuanjizhiwu(params.row.zhuanJiZhiWu));
                        },
                    },
                    {
                        title: '教官职务',
                        key: 'jiaoGuanZhiWu',
                        render: (h, params) => {
                            return h('span', this.getjiaoguanzhiwu(params.row.jiaoGuanZhiWu));
                        },
                    },
                    {
                        title: '科研分数',
                        key: 'keYanFen'
                    },
                    {
                        title: '考核分',
                        key: 'kaoHeFen'
                    },
                    {
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
                                            this.modalshow = true
                                            this.id = params.row.id
                                        }
                                    }
                                }, '考核分填写'),

                            ]);
                        }
                    }
                ],
                huizonglist: [],
                filterObj: {
                    applyName: '',
                    bumen: '',
                    startTime: '',
                    endTime: '',
                },
            }
        },
        props: [],
        mounted() {
            this.savrniandu();
            //this.gethuizong();
        },
        computed: {},
        components: {
            expandRow,
            CG_NianDuKaoHe
        },
        methods: {
            //GetJilus
            gethuizong() {
                this.tableLoading = true;
                axios.get('api/Cg_JiLu/GetNianDus', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                    }
                })
                    .then(response => {
                        this.huizonglist = response.data.results;
                        this.totalRows = response.data.totalRows;
                        this.tableLoading = false;
                        //console.log(this.huizonglist);
                    }).catch(error => {
                        console.log(error);
                    });
            },
            pageIndexChange(currentIndex) {
                this.pageIndex = currentIndex
                this.gethuizong()
            },
            pageSizeChange(currentpagrSize) {
                this.pageSize = currentpagrSize
                this.gethuizong()
            },
            getzhuanjizhiwu(num) {
                num = parseInt(num);
                switch (num) {
                    case -1:
                        return "";
                        break;
                    case 0:
                        return "教授";
                        break;
                    case 1:
                        return "副教授";
                        break;
                    case 2:
                        return "讲师";
                        break;
                    case 3:
                        return "助教";
                        break;
                    case 4:
                        return "研究员";
                        break;
                    case 5:
                        return "副研究员";
                        break;
                    case 6:
                        return "助理研究员";
                        break;
                    case 7:
                        return "研究实习员";
                        break;
                    case 8:
                        return "其他正高";
                        break;
                    case 9:
                        return "其他副高";
                        break;
                    case 10:
                        return "其他中级";
                        break;
                    case 11:
                        return "其他初级";
                    case 12:
                        return "无";
                        break;
                }
            },
            getjiaoguanzhiwu(num) {
                num = parseInt(num);
                switch (num) {
                    case -1:
                        return "";
                        break;
                    case 0:
                        return "特级教官";
                        break;
                    case 1:
                        return "高级教官";
                        break;
                    case 2:
                        return "中级教官";
                        break;
                    case 3:
                        return "初级教官";
                        break;
                    case 4:
                        return "无";
                        break;
                }
            },
            reset() {
                this.filterObj = {
                    applyName: '',
                    bumen: '',
                    startTime: '',
                    endTime: '',
                }
                this.gethuizong()
            },
            select() {
                //GetJilusByziduan
                this.tableLoading = true;
                axios.get('api/Cg_JiLu/GetNianDusByziduan', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                        applyName: this.filterObj.applyName,
                        bumen: this.filterObj.bumen,
                        startTime: this.filterObj.startTime,
                        endTime: this.filterObj.endTime,
                    }
                })
                    .then(response => {
                        this.huizonglist = response.data.results;
                        this.totalRows = response.data.totalRows;
                        this.tableLoading = false;
                        //console.log(this.huizonglist);
                    }).catch(error => {
                        console.log(error);
                    });
            },
            savrniandu() {
                //SaveNianDu
                this.tableLoading = true;
                axios.post('api/Cg_JiLu/SaveNianDu',
                    qs.stringify({

                    })).then(response => {
                        if (!response.data.error) {
                            this.tableLoading = false;
                            this.gethuizong();
                            // console.log(response.data);
                        } else {
                            //this.$Message.error('保存失败!');
                        }
                    });

            },
            close() {
                this.modalshow = false;
                this.gethuizong();
            },
        }
    };
</script>
<style>
</style>