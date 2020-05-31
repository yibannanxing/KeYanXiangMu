<template>
    <div style="padding:10px">
        <div>
            <Row>
                <i-col span="4">
                    <Radio-group v-model="ZhuangTai" type="button" size="large" style="margin-bottom:5px">
                        <Radio label="3">未审核</Radio>
                        <Radio label="4">已审核</Radio>
                    </Radio-group>
                </i-col>
                <i-col span="4">
                    姓名：<i-input v-model="filterObj.name" style="width:100px;"></i-input>
                </i-col>
                <i-col span="5">
                    部门：<i-input v-model="filterObj.bumen" style="width:50%;"></i-input>
                </i-col>
                <i-col span="4">
                    <i-button @click="select" type="primary" style="margin-right:1px">查询</i-button>
                    <i-button @click="reset" style="margin-right:1px">重置</i-button>
                </i-col>
            </Row>
        </div>
        <i-table ref="selection" :columns="columns" size="small" :data="cglist" border="true" :loading="tableLoading" @on-selection-change="getcglist"></i-table>
        <div style="display:flex;justify-content:center;align-items:center;padding:5px;">
            <Page size="small" :total="totalRows" :page-size-opts="[10,15, 20, 30, 40]" show-total show-sizer show-elevator
                  :current="pageIndex" :page-size="pageSize" @on-change="pageIndexChange" @on-page-size-change="pageSizeChange" />
        </div>

        <Modal title=""
               v-model="modalshow"
               width="90%"
               :footer-hide="true"
               :styles="{top: '0'}"
               :mask-closable="false"
               :scrollable='false'
               :transfer="false"
               class-name="vertical-center-modal">
            <div :style="{height:matchHeight+'px','overflow-y':'auto',padding:0}">
                <!--<CG_upload v-if="modalshow&&type==0" @close="close"></CG_upload>-->
                <CG_kyxm v-if="modalshow&&type==1" :id="id" :isview="isview" :isshenhe="isshenhe" @close="close" :istuihui="istuihui" :shlx="shlx" :issee="issee" :iswanjie="iswanjie"></CG_kyxm>
                <CG_zuzuo v-if="modalshow&&type==2" :id="id" :isview="isview" :isshenhe="isshenhe" @close="close" :istuihui="istuihui" :shlx="shlx" :issee="issee" :iswanjie="iswanjie"></CG_zuzuo>
                <CG_jiaocai v-if="modalshow&&type==3" :id="id" :isview="isview" :isshenhe="isshenhe" @close="close" :istuihui="istuihui" :shlx="shlx" :issee="issee" :iswanjie="iswanjie"></CG_jiaocai>
                <CG_lunwen v-if="modalshow&&type==4" :id="id" :isview="isview" :isshenhe="isshenhe" @close="close" :istuihui="istuihui" :shlx="shlx" :issee="issee" :iswanjie="iswanjie"></CG_lunwen>
                <CG_ruanjian v-if="modalshow&&type==5" :id="id" :isview="isview" :isshenhe="isshenhe" @close="close" :istuihui="istuihui" :shlx="shlx" :issee="issee" :iswanjie="iswanjie"></CG_ruanjian>
                <CG_Qita v-if="modalshow&&type==6" :id="id" :isview="isview" :isshenhe="isshenhe" @close="close" :istuihui="istuihui" :shlx="shlx" :issee="issee" :iswanjie="iswanjie"></CG_Qita>

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
                shlx: 3,
                iswanjie: false,
                issee: false,
                istuihui: false,
                ZhuangTai: '3',
                id: null,
                isview: true,
                isshenhe: true,
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
                        fixed: 'left',

                    },
                    {
                        title: '部门',
                        key: 'bumen',
                        width: 200,

                    },
                    {
                        title: '成果类型',
                        key: 'cgLeiXingMingCheng',
                        width: 200,

                    },
                    {
                        title: '成果名称',
                        key: 'cgMingCheng',
                        width: 200,

                    },
                    {
                        title: '上级审核人',
                        key: 'shangJiShenHeRen',
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
                        title: '获奖类型',
                        key: 'huoJiangLeiXingName',
                        width: 200,
                    },

                ],
                cglist: [],
                weishenhe: {
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
                                        this.iswanjie = true
                                        this.id = params.row.cgId
                                        this.istuihui = false
                                        this.isview = true
                                        this.issee = true
                                        this.isshenhe = true
                                        this.modalshow = true

                                    }
                                }
                            }, '审核'),
                        ]);
                    }
                },
                yishenhe: {
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
                                        this.istuihui = true
                                        this.isview = true
                                        this.isshenhe = true
                                        this.issee = true
                                        this.modalshow = true
                                    }
                                }
                            }, '详情'),
                        ]);
                    }
                },
                filterObj: {
                    name: "",
                    bumen:"",
                },
            }
        },
        props: [],
        watch: {
            ZhuangTai: {
                deep: true,
                handler(newName, oldName) {
                    this.getcglist()
                    this.columns.splice(-1);
                    if (this.ZhuangTai == 3) {
                        this.columns.push(this.weishenhe);
                    } else if (this.ZhuangTai == 4) {
                        this.columns.push(this.yishenhe);
                    }
                },
            }
        },
        mounted() {
            if (this.ZhuangTai == 3) {
                this.columns.push(this.weishenhe);
            }

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
                // GetJiLuByKeYanChu
                this.tableLoading = true;
                if (this.ZhuangTai == 4) {
                    axios.get('api/Cg_JiLu/GetJiLuByKeYanChu', {
                        params: {
                            skip: (this.pageIndex - 1) * this.pageSize,
                            take: this.pageSize,
                        }
                    })
                        .then(response => {
                            this.cglist = response.data.results
                            this.totalRows = response.data.totalRows
                            this.tableLoading = false;
                        }).catch(error => {
                            console.log(error);
                            this.tableLoading = false;
                        });

                } else {
                    axios.get('api/Cg_JiLu/GetCgJiLuByStatus', {
                        params: {
                            skip: (this.pageIndex - 1) * this.pageSize,
                            take: this.pageSize,
                            status: this.ZhuangTai,
                        }
                    })
                        .then(response => {
                            this.cglist = response.data.results
                            this.totalRows = response.data.totalRows
                            this.tableLoading = false;
                        }).catch(error => {
                            console.log(error);
                            this.tableLoading = false;
                        });
                }

            },
            pageIndexChange(currentIndex) {
                this.pageIndex = currentIndex
                this.getcglist()
            },
            pageSizeChange(currentpagrSize) {
                this.pageSize = currentpagrSize
                this.getcglist()
            },
            close() {
                this.modalshow = false;
                this.getcglist();
            },
            select() {
                // SelectJiLu
                axios.get('api/Cg_JiLu/SelectJiLu', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                        name: this.filterObj.name,
                        bumen: this.filterObj.bumen,
                        zhuangtai:this.ZhuangTai,
                    }
                })
                    .then(response => {
                        this.cglist = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            reset() {
                this.filterObj = {
                    name: "",
                    bumen:"",
                }
                this.getcglist();
            },

        }
    };
</script>
<style>
</style>