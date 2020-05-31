<template>
    <div style="padding:10px">
        <Row style="padding:5px 0;">
            <i-col span="5">
                项目名称：<i-input v-model="filterObj.mingcheng" style="width:50%;"></i-input>
            </i-col>
            <i-col span="5">
                姓名：<i-input v-model="filterObj.applyName" style="width:50%;"></i-input>
            </i-col>
            <i-col span="5">
                部门：<i-input v-model="filterObj.bumen" style="width:50%;"></i-input>
            </i-col>
            <i-col span="5">
                项目类型：
                <i-select v-model="filterObj.xiangmuleixing" style="width:50%;">
                    <i-option value="0">科研项目</i-option>
                    <i-option value="1">著作</i-option>
                    <i-option value="2">教材</i-option>
                    <i-option value="3">论文</i-option>
                    <i-option value="5">软件与专利</i-option>
                    <i-option value="6">其他</i-option>
                </i-select>
            </i-col>
        </Row>
        <Row style="padding:5px 0;">
            <i-col span="6">
                批准立项时间：<DatePicker type="date" style="width:60%;"
                                   v-model="filterObj.startTime"></DatePicker>
            </i-col>
            <i-col span="6">
                批准结项时间：<DatePicker type="date" style="width:60%;"
                                   v-model="filterObj.endTime"></DatePicker>
            </i-col>
            <i-col span="6">
                <i-button @click="select" type="primary" style="margin-right:1px">查询</i-button>
                <i-button @click="reset" style="margin-right:1px">重置</i-button>
            </i-col>
        </Row>

        <i-table ref="selection" :columns="columns" size="small" :data="cglist" border="true" :loading="tableLoading" @on-selection-change="getcglist"></i-table>
        <div style="display:flex;justify-content:center;align-items:center;padding:5px;">
            <Page size="small" :total="totalRows" :page-size-opts="[10,15, 20, 30, 40]" show-total show-sizer show-elevator
                  :current="pageIndex" :page-size="pageSize" @on-change="pageIndexChange" @on-page-size-change="pageSizeChange" />
        </div>

        <Modal title=""
               v-model="modalshow"
               width="80%"
               :footer-hide="true"
               :styles="{top: '0'}"
               :mask-closable="false"
               :scrollable='false'
               :transfer="false"
               class-name="vertical-center-modal">
            <div :style="{height:matchHeight+'px','overflow-y':'auto',padding:0}">
                <!--<CG_upload v-if="modalshow&&type==0" @close="close"></CG_upload>-->
                <CG_kyxm v-if="modalshow&&type==1" :id="id" :isview="isview" :isshenhe="isshenhe" @close="close" :istuihui="istuihui" :shlx="shlx"></CG_kyxm>
                <CG_zuzuo v-if="modalshow&&type==2" :id="id" :isview="isview" :isshenhe="isshenhe" @close="close" :istuihui="istuihui" :shlx="shlx"></CG_zuzuo>
                <CG_jiaocai v-if="modalshow&&type==3" :id="id" :isview="isview" :isshenhe="isshenhe" @close="close" :istuihui="istuihui" :shlx="shlx"></CG_jiaocai>
                <CG_lunwen v-if="modalshow&&type==4" :id="id" :isview="isview" :isshenhe="isshenhe" @close="close" :istuihui="istuihui" :shlx="shlx"></CG_lunwen>
                <CG_ruanjian v-if="modalshow&&type==5" :id="id" :isview="isview" :isshenhe="isshenhe" @close="close" :istuihui="istuihui" :shlx="shlx"></CG_ruanjian>
                <CG_Qita v-if="modalshow&&type==6" :id="id" :isview="isview" :isshenhe="isshenhe" @close="close" :istuihui="istuihui" :shlx="shlx"></CG_Qita>

            </div>
        </Modal>

    </div>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    import CG_kyxm from '../components/CG_kyxm.vue';
    import CG_zuzuo from '../components/CG_zuzuo.vue';
    import CG_jiaocai from '../components/CG_jiaocai.vue';
    import CG_lunwen from '../components/CG_lunwen.vue';
    import CG_ruanjian from '../components/CG_ruanjian.vue';
    import CG_Qita from '../components/CG_Qita.vue';
    const qs = require('qs');
    const moment = require('moment');
    export default {
        data() {
            return {
                id: null,
                issee: false,
                isview: false,
                istuihui: false,
                isshenhe: false,
                modalshow: false,
                matchHeight: window.innerHeight * 0.8,
                tableLoading: false,
                totalRows: 0,
                pageIndex: 1,
                pageSize: 15,
                columns: [
                    {
                        title: '姓名',
                        key: 'userName',
                        width: 100,
                        fixed: 'left'

                    },
                    {
                        title: '部门',
                        key: 'bumen',
                        width: 200,

                    },
                    {
                        title: '项目来源',
                        key: 'xiangMuLaiYuan',
                        width: 200,

                    },
                    {
                        title: '批准立项时间',
                        key: 'startDate',
                        width: 200,
                        render: (h, params) => {
                            if (params.row.startDate != null) {
                                return h('span', moment(params.row.startDate).format('YYYY-MM-DD'))
                            } else {
                                return h('span', " ")
                            }
                        },
                    },
                    {
                        title: '批准结项时间',
                        key: 'endDate',
                        width: 200,
                        render: (h, params) => {
                            if (params.row.endDate != null) {
                                return h('span', moment(params.row.endDate).format('YYYY-MM-DD'))
                            } else {
                                return h('span', " ")
                            }
                        },

                    },
                    {
                        title: '项目类别',
                        key: 'cgLeiXingMingCheng',
                        width: 200,

                    },
                    {
                        title: '成果名称',
                        key: 'cgMingCheng',
                        width: 200,

                    },
                    {
                        title: '院内/外项目编号',
                        key: 'yuanNeiXiangMuBianHao',
                        width: 200,

                    },
                    {
                        title: '本人署名排序',
                        key: 'shuMingPaiXu',
                        width: 200,

                    },
                    {
                        title: '项目组成员',
                        key: 'xiangMuZuChengYuan',
                        width: 400,

                    },
                    {
                        title: '进度',
                        key: 'status',
                        width:200,
                        render: (h, params) => {
                            if (params.row.status == 1) {
                                return h('span', "待初审")
                            } else if (params.row.status == 2) {
                                return h('span', "待部门审核")
                            } else if (params.row.status == 3) {
                                return h('span', "待科研处审核")
                            } else if (params.row.status == 4) {
                                return h('span', "已完结")
                            } else if (params.row.status == -2) {
                                return h('span', "退回")
                            }

                        },

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
                                            if (params.row.cgLeiXingMingCheng == "科研项目") {
                                                this.type = 1
                                            } else if (params.row.cgLeiXingMingCheng == "著作") {
                                                this.type = 2
                                            } else if (params.row.cgLeiXingMingCheng == "教材") {
                                                this.type = 3
                                            } else if (params.row.cgLeiXingMingCheng == "论文") {
                                                this.type = 4
                                            } else if (params.row.cgLeiXingMingCheng == "软件与专利") {
                                                this.type = 5
                                            } else if (params.row.cgLeiXingMingCheng == "其他") {
                                                this.type = 6
                                            }
                                            this.id = params.row.cgId
                                            this.istuihui = false
                                            this.isview = false
                                            this.isshenhe = false
                                            this.modalshow = true
                                        }
                                    }
                                }, '详情'),

                            ]);
                        }
                    }
                ],
                cglist: [],
                filterObj: {
                    applyName: '',
                    bumen: '',
                    mingcheng: '',
                    xiangmuleixing: -1,
                    startTime: '',
                    endTime: '',
                    huojiangleixing: -1,
                    huojiangtime: '',
                },
            }
        },
        props: [],
        mounted() {
            this.getcglist();
        },
        computed: {},
        components: {
            CG_kyxm,
            CG_zuzuo,
            CG_jiaocai,
            CG_lunwen,
            CG_ruanjian,
            CG_Qita,
        },
        methods: {
            getcglist() {
                //Cg_JiLuController GetCgJilus
                this.tableLoading = true;
                axios.get('api/Cg_JiLu/GetCgJilus', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,

                    }
                })
                    .then(response => {
                        this.cglist = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                        console.log(this.cglist)
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            pageIndexChange(currentIndex) {
                this.pageIndex = currentIndex
                this.getcglist()
            },
            pageSizeChange(currentpagrSize) {
                this.pageSize = currentpagrSize
                this.getcglist()
            },
            reset() {
                this.filterObj = {
                    applyName: '',
                    bumen: '',
                    mingcheng: '',
                    xiangmuleixing: -1,
                    startTime: '',
                    endTime: '',
                    huojiangleixing: -1,
                    huojiangtime: '',
                }
                this.getcglist()
            },
            select() {
                //GetCgJiluBase
                this.tableLoading = true;
                axios.get('api/Cg_JiLu/GetCgJiluBase', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                        applyName: this.filterObj.applyName,
                        bumen: this.filterObj.bumen,
                        mingcheng: this.filterObj.mingcheng,
                        xiangmuleixing: this.filterObj.xiangmuleixing,
                        startTime: this.filterObj.startTime,
                        endTime: this.filterObj.endTime,
                        huojiangleixing: this.filterObj.huojiangleixing,
                        huojiangtime: this.filterObj.huojiangtime,
                    }
                })
                    .then(response => {
                        this.cglist = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                        console.log(this.cglist)
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            }
        }
    };
</script>
<style>
</style>