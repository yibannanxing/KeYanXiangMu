<template>
    <div>
        <div v-if="kylist.length>0">
            <Divider orientation="left">科研项目</Divider>
            <i-table ref="selection" :columns="columnsky" size="small" :data="kylist" border="true" :loading="tableLoading"></i-table>
        </div>
        <div v-if="zzlist.length>0">
            <Divider orientation="left">著作</Divider>
            <i-table ref="selection" :columns="columnszz" size="small" :data="zzlist" border="true" :loading="tableLoading"></i-table>
        </div>
        <div v-if="jclist.length>0">
            <Divider orientation="left">教材</Divider>
            <i-table ref="selection" :columns="columnsjc" size="small" :data="jclist" border="true" :loading="tableLoading"></i-table>
        </div>
        <div v-if="lwlist.length>0">
            <Divider orientation="left">论文</Divider>
            <i-table ref="selection" :columns="columnslw" size="small" :data="lwlist" border="true" :loading="tableLoading"></i-table>
        </div>
        <div v-if="rjlist.length>0">
            <Divider orientation="left">软件与专利</Divider>
            <i-table ref="selection" :columns="columnsrj" size="small" :data="rjlist" border="true" :loading="tableLoading"></i-table>
        </div>
        <div v-if="qtlist.length>0">
            <Divider orientation="left">其他</Divider>
            <i-table ref="selection" :columns="columnsqt" size="small" :data="qtlist" border="true" :loading="tableLoading"></i-table>
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
    const moment = require('moment');
    const qs = require('qs');
    export default {
        data() {
            return {
                id: null,
                issee: false,
                isview: false,
                istuihui: false,
                isshenhe: false,
                iswanjie: false,
                modalshow: false,
                matchHeight: window.innerHeight * 0.8,
                columnsky: [
                    {
                        title: '来源',
                        key: 'xiangMuLaiYuan',
                        width: 300,
                        fixed: 'left'
                    },
                    {
                        title: '名称',
                        key: 'xiangMuMingCheng',
                        width: 300,
                    },
                    {
                        title: '类别',
                        key: 'xiangMuLeiBieName',
                        width: 100,

                    },
                    {
                        title: '批准立项时间',
                        key: 'liXiangShiJian',
                        width: 200,
                        render: (h, params) => {
                            if (params.row.liXiangShiJian != null) {
                                return h('span', moment(params.row.liXiangShiJian).format('YYYY-MM-DD'))
                            } else {
                                return h('span', " ")
                            }
                        },
                    },
                    {
                        title: '批准结项时间',
                        key: 'gongBuJieXiangShiJian',
                        width: 200,
                        render: (h, params) => {
                            if (params.row.gongBuJieXiangShiJian != null) {
                                return h('span', moment(params.row.gongBuJieXiangShiJian).format('YYYY-MM-DD'))
                            } else {
                                return h('span', " ")
                            }
                        },
                    },
                    {
                        title: '院内署名排序',
                        key: 'yuanNeiBenRenShuMingPaiXu',
                        width: 100,
                    },
                    {
                        title: '本人署名排序',
                        key: 'benRenShuMingPaiXu',
                        width: 100,
                    },
                    {
                        title: '项目组成员',
                        key: 'zuyuans',
                        width: 300,
                    },
                    {
                        title: '获奖名称',
                        key: 'xiangMuHuoJiangMingCheng',
                        width: 100,
                    },
                    {
                        title: '获奖级别',
                        key: 'huoJiangLeiXingName',
                        width: 100,
                    },
                    {
                        title: '获奖时间',
                        key: 'xiangMuHuoJiangTime',
                        width: 200,
                        render: (h, params) => {
                            if (params.row.xiangMuHuoJiangTime != null) {
                                return h('span', moment(params.row.xiangMuHuoJiangTime).format('YYYY-MM-DD'))
                            } else {
                                return h('span', " ")
                            }
                        },
                    },
                    {
                        title: '状态',
                        key: 'status',
                        width: 100,
                        render: (h, params) => {
                            if (params.row.status == 0) {
                                return h('span', "暂存")
                            } else if (params.row.status == 1) {
                                return h('span', "提交")
                            } else if (params.row.status == -1) {
                                return h('span', "已删除")
                            }
                        },
                    },
                    {
                        title: '操作',
                        align: 'center',
                        width: 100,
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
                                            this.type = 1
                                            this.modalshow = true
                                            this.id = params.row.id
                                            this.istuihui = false
                                            this.isview = false
                                            this.isshenhe = true
                                            this.issee = true
                                            this.shlx = 3
                                            this.iswanjie = false
                                        }
                                    }
                                }, '详情'),

                            ]);
                        }
                    }
                ],
                columnszz: [
                    {
                        title: '名称',
                        key: 'zuZuoMingCheng',
                        width: 300,
                        fixed: 'left'
                    },
                    {
                        title: '出版社',
                        key: 'chuBanSe',
                        width: 300,
                    },
                    {
                        title: '类别',
                        key: 'chuBanSeJiBie',
                        width: 100,
                        render: (h, params) => {
                            if (params.row.chuBanSeJiBie == 0) {
                                return h('span', "国家级")
                            } else if (params.row.chuBanSeJiBie == 1) {
                                return h('span', "省部级")
                            }
                        },
                    },
                    {
                        title: '出版时间',
                        key: 'chuBanShiJian',
                        width: 200,
                        render: (h, params) => {
                            if (params.row.chuBanShiJian != null) {
                                return h('span', moment(params.row.chuBanShiJian).format('YYYY-MM-DD'))
                            } else {
                                return h('span', " ")
                            }
                        },
                    },
                    {
                        title: '著作者',
                        key: 'zuyuans',
                        width: 200,
                    },
                    {
                        title: '本人署名排序',
                        key: 'fengMianBenRenShuMingPaiXu',
                        width: 100,
                    },
                    {
                        title: '获奖名称',
                        key: 'huoJiangMingCheng',
                        width: 100,
                    },
                    {
                        title: '获奖级别',
                        key: 'zuZhuoHuoJiangJiBieName',
                        width: 100,
                    },
                    {
                        title: '获奖时间',
                        key: 'zuZhuoHuoJiangShiJian',
                        width: 200,
                        render: (h, params) => {
                            if (params.row.zuZhuoHuoJiangShiJian != null) {
                                return h('span', moment(params.row.zuZhuoHuoJiangShiJian).format('YYYY-MM-DD'))
                            } else {
                                return h('span', " ")
                            }
                        },
                    },
                    {
                        title: '状态',
                        key: 'status',
                        width: 100,
                        render: (h, params) => {
                            if (params.row.status == 0) {
                                return h('span', "暂存")
                            } else if (params.row.status == 1) {
                                return h('span', "提交")
                            } else if (params.row.status == -1) {
                                return h('span', "已删除")
                            }
                        },
                    },
                    {
                        title: '操作',
                        align: 'center',
                        width: 100,
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
                                            this.type = 2
                                            this.modalshow = true
                                            this.id = params.row.id
                                            this.istuihui = false
                                            this.isview = false
                                            this.isshenhe = true
                                            this.issee = true
                                            this.shlx = 3
                                            this.iswanjie = false
                                        }
                                    }
                                }, '详情'),

                            ]);
                        }
                    }
                ],
                columnsjc: [
                    {
                        title: '名称',
                        key: 'jiaoCaiMingCheng',
                        width: 300,
                        fixed: 'left'
                    },
                    {
                        title: '出版社',
                        key: 'chuBanShe',
                        width: 300,
                    },
                    {
                        title: '参编情况',
                        key: 'canBianQingKuang',
                        width: 100,
                        render: (h, params) => {
                            if (params.row.canBianQingKuang == 0) {
                                return h('span', "主编")
                            } else if (params.row.canBianQingKuang == 1) {
                                return h('span', "副主编")
                            } else if (params.row.canBianQingKuang == 2) {
                                return h('span', "供稿人")
                            }
                        },
                    },
                    {
                        title: '出版时间',
                        key: 'chuBanShiJian',
                        width: 200,
                        render: (h, params) => {
                            if (params.row.chuBanShiJian != null) {
                                return h('span', moment(params.row.chuBanShiJian).format('YYYY-MM-DD'))
                            } else {
                                return h('span', " ")
                            }
                        },
                    },
                    {
                        title: '参编字数',
                        key: 'canBianZiShu',
                        width: 100,
                    },
                    {
                        title: '获奖名称',
                        key: 'huoJiangMingCheng',
                        width: 200,
                    },
                    {
                        title: '获奖级别',
                        key: 'jiaoCaiHuoJiangJiBieName',
                        width: 200,
                    },
                    {
                        title: '获奖时间',
                        key: 'jiaoCaiHuoJiangShiJian',
                        width: 200,
                        render: (h, params) => {
                            if (params.row.jiaoCaiHuoJiangShiJian != null) {
                                return h('span', moment(params.row.jiaoCaiHuoJiangShiJian).format('YYYY-MM-DD'))
                            } else {
                                return h('span', " ")
                            }
                        },
                    },
                    {
                        title: '状态',
                        key: 'status',
                        width: 100,
                        render: (h, params) => {
                            if (params.row.status == 0) {
                                return h('span', "暂存")
                            } else if (params.row.status == 1) {
                                return h('span', "提交")
                            } else if (params.row.status == -1) {
                                return h('span', "已删除")
                            }
                        },
                    },
                    {
                        title: '操作',
                        align: 'center',
                        width: 100,
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
                                            this.type = 3
                                            this.modalshow = true
                                            this.id = params.row.id
                                            this.istuihui = false
                                            this.isview = false
                                            this.isshenhe = true
                                            this.issee = true
                                            this.shlx = 3
                                            this.iswanjie = false
                                        }
                                    }
                                }, '详情'),

                            ]);
                        }
                    }
                ],
                columnslw: [
                    {
                        title: '名称',
                        key: 'lunWenMingCheng',
                        width: 400,
                        fixed: 'left'
                    },
                    {
                        title: '类别',
                        key: 'lunWenLeiBie',
                        width: 100,
                        render: (h, params) => {
                            if (params.row.lunWenLeiBie == 0) {
                                return h('span', "科研")
                            } else if (params.row.lunWenLeiBie == 1) {
                                return h('span', "教学")
                            }
                        },
                    },
                    {
                        title: '发表期刊',
                        key: 'faBiaoQiKan',
                        width: 200,
                    },
                    {
                        title: '当年期号',
                        key: 'dangNianQiHao',
                        width: 200,
                    },
                    {
                        title: '收录情况',
                        key: 'shouLuQiangKuang',
                        width: 300,
                        render: (h, params) => {
                            return h('span', this.shoulu(params.row.shouLuQiangKuang));
                        },
                    },
                    {
                        title: '作者',
                        key: 'zuyuans',
                        width: 300,
                    },
                    {
                        title: '本人署名排序',
                        key: 'benRenShuMingPaiXu',
                        width: 100,
                    },
                    {
                        title: '论文字数',
                        key: 'lunWenZiShu',
                        width: 100,
                    },
                    {
                        title: '是否与行业联合发展',
                        key: 'isYuHangYeLianHeFaBiao',
                        width: 100,
                        render: (h, params) => {
                            if (params.row.isYuHangYeLianHeFaBiao == 0) {
                                return h('span', "是")
                            } else if (params.row.isYuHangYeLianHeFaBiao == 1) {
                                return h('span', "否")
                            }
                        },
                    },
                    {
                        title: '获奖名称',
                        key: 'huoJiangMingCheng',
                        width: 100,
                    },
                    {
                        title: '获奖级别',
                        key: 'lunWenHuoJiangJiBieName',
                        width: 100,
                    },
                    {
                        title: '获奖时间',
                        key: 'lunWenHuoJiangShiJian',
                        width: 200,
                        render: (h, params) => {
                            if (params.row.lunWenHuoJiangShiJian != null) {
                                return h('span', moment(params.row.lunWenHuoJiangShiJian).format('YYYY-MM-DD'))
                            } else {
                                return h('span', " ")
                            }
                        },
                    },
                    {
                        title: '状态',
                        key: 'status',
                        width: 100,
                        render: (h, params) => {
                            if (params.row.status == 0) {
                                return h('span', "暂存")
                            } else if (params.row.status == 1) {
                                return h('span', "提交")
                            } else if (params.row.status == -1) {
                                return h('span', "已删除")
                            }
                        },
                    },
                    {
                        title: '操作',
                        align: 'center',
                        width: 100,
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
                                            this.type = 4
                                            this.modalshow = true
                                            this.id = params.row.id
                                            this.istuihui = false
                                            this.isview = false
                                            this.isshenhe = true
                                            this.issee = true
                                            this.shlx = 3
                                            this.iswanjie = false
                                        }
                                    }
                                }, '详情'),

                            ]);
                        }
                    }
                ],
                columnsrj: [
                    {
                        title: '名称',
                        key: 'mingCheng',
                        width: 300,
                        fixed: 'left'
                    },
                    {
                        title: '类别',
                        key: 'leiXing',
                        width: 200,
                        render: (h, params) => {
                            if (params.row.leiXing == 0) {
                                return h('span', "发明专利")
                            } else if (params.row.leiXing == 1) {
                                return h('span', "实用新型专利")
                            } else if (params.row.leiXing == 2) {
                                return h('span', "外观设计专利")
                            } else if (params.row.leiXing == 3) {
                                return h('span', "软件著作权")
                            }
                        },
                    },
                    {
                        title: '专利号/登记号',
                        key: 'zhuanLiHao',
                        width: 200,
                    },
                    {
                        title: '专利申请日/开发完成时间',
                        key: 'zhuanLiShenQingRi',
                        width: 200,
                        render: (h, params) => {
                            if (params.row.zhuanLiShenQingRi != null) {
                                return h('span', moment(params.row.zhuanLiShenQingRi).format('YYYY-MM-DD'))
                            } else {
                                return h('span', " ")
                            }
                        },
                    },
                    {
                        title: '专利权人/著作权人',
                        key: 'zhuanliren',
                        width: 300,
                    },
                    {
                        title: '发明人',
                        key: 'famingren',
                        width: 300,
                    },
                    {
                        title: '证书号',
                        key: 'zhengShuHao',
                        width: 200,
                    },
                    {
                        title: '状态',
                        key: 'status',
                        width: 100,
                        render: (h, params) => {
                            if (params.row.status == 0) {
                                return h('span', "暂存")
                            } else if (params.row.status == 1) {
                                return h('span', "提交")
                            } else if (params.row.status == -1) {
                                return h('span', "已删除")
                            }
                        },
                    },
                    {
                        title: '操作',
                        align: 'center',
                        width: 100,
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
                                            this.type = 5
                                            this.id = params.row.id
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
                columnsqt: [
                    {
                        title: '名称',
                        key: 'mingCheng',
                        width: 300,
                        fixed: 'left'
                    },
                    {
                        title: '成果年度',
                        key: 'chengGuoNianDu',
                        width: 200,
                    },
                    {
                        title: '科研成果简介',
                        key: 'keYanChengGuoJianJie',
                        width: 1000,
                    },
                    {
                        title: '状态',
                        key: 'status',
                        width: 100,
                        render: (h, params) => {
                            if (params.row.status == 0) {
                                return h('span', "暂存")
                            } else if (params.row.status == 1) {
                                return h('span', "提交")
                            } else if (params.row.status == -1) {
                                return h('span', "已删除")
                            }
                        },
                    },
                    {
                        title: '操作',
                        align: 'center',
                        width: 100,
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
                                            this.type = 6
                                            this.id = params.row.id
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
                kylist: [],
                zzlist: [],
                jclist: [],
                lwlist: [],
                rjlist: [],
                qtlist: [],
            }
        },
        props: { row: Object },
        mounted() {
            console.log(this.row);
            this.getky();
            this.getzz();
            this.getjc();
            this.getlw();
            this.getrj();
            this.getqt();
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
            getky() {
                axios.get('api/Cg_JiLu/Getcgkybyniandu', {
                    params: {
                        id: this.row.userId,
                        nianDu: this.row.nianDu
                    }
                })
                    .then(response => {
                        this.kylist = response.data.results;
                    }).catch(error => {
                        console.log(error);
                    });
            },
            getzz() {
                axios.get('api/Cg_JiLu/Getcgzzbyniandu', {
                    params: {
                        id: this.row.userId,
                        nianDu: this.row.nianDu
                    }
                })
                    .then(response => {
                        this.zzlist = response.data.results;
                    }).catch(error => {
                        console.log(error);
                    });
            },
            getjc() {
                axios.get('api/Cg_JiLu/Getcgjcbyniandu', {
                    params: {
                        id: this.row.userId,
                        nianDu: this.row.nianDu
                    }
                })
                    .then(response => {
                        this.jclist = response.data.results;
                    }).catch(error => {
                        console.log(error);
                    });
            },
            getlw() {
                axios.get('api/Cg_JiLu/Getcglwbyniandu', {
                    params: {
                        id: this.row.userId,
                        nianDu: this.row.nianDu
                    }
                })
                    .then(response => {
                        this.lwlist = response.data.results;
                    }).catch(error => {
                        console.log(error);
                    });
            },
            getrj() {
                axios.get('api/Cg_JiLu/Getcgrjbyniandu', {
                    params: {
                        id: this.row.userId,
                        nianDu: this.row.nianDu
                    }
                })
                    .then(response => {
                        this.rjlist = response.data.results;
                    }).catch(error => {
                        console.log(error);
                    });
            },
            getqt() {
                axios.get('api/Cg_JiLu/Getcgqtbyniandu', {
                    params: {
                        id: this.row.userId,
                        nianDu: this.row.nianDu
                    }
                })
                    .then(response => {
                        this.qtlist = response.data.results;
                    }).catch(error => {
                        console.log(error);
                    });
            },
            shoulu(num) {
                switch (num) {
                    case "0":
                        return "SCI（科学引文索引）";
                        break;
                    case "1":
                        return "SSCI（社会科学引文索引）";
                        break;
                    case "2":
                        return "EI（工程索引）";
                        break;
                    case "3":
                        return "CPCI（国际会议录索引）";
                        break;
                    case "4":
                        return "A&HCI（艺术与人文科学索引）";
                        break;
                    case "5":
                        return "CSCD（中国科技期刊引证报告）";
                        break;
                    case "6":
                        return "CSSCI（中文社会科学引文索引）";
                        break;
                    case "7":
                        return "北大中文核心期刊";
                        break;
                    case "8":
                        return "无";
                        break;

                }
            },
        }
    };
</script>
<style scoped>
    .expand-row {
        margin-bottom: 16px;
    }
</style>