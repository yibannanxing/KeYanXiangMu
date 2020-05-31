<template>
    <div style="padding:10px">

        <Row style="padding:5px 0;">
            <i-col span="4">
                姓名：<i-input v-model="filterObj.applyName" style="width:50%;"></i-input>
            </i-col>
            <i-col span="4">
                成果名称：<i-input v-model="filterObj.cgName" style="width:50%;"></i-input>
            </i-col>

            <i-col span="4">
                是否获奖：  <RadioGroup v-model="filterObj.isHuoJiang">
                    <Radio label="是">是</Radio>
                    <Radio label="否">否</Radio>
                </RadioGroup>
            </i-col>

            <i-col span="4">
                是否出版：  <RadioGroup v-model="filterObj.isChuBan">
                    <Radio label="是">是</Radio>
                    <Radio label="否">否</Radio>
                </RadioGroup>
            </i-col>
        </Row>
        <Row>
            <i-col span="8">
                认定范围:
                <Select v-model="filterObj.renDingFanWei" style="width:300px">
                    <Option v-for="item in renDingList" :value="item.fenZhi" :key="item.fenZhi">{{item.erJiMingCheng}}</Option>
                </Select>
                <!--<i-input v-model="filterObj.renDingFanWei" style="width:50%;"></i-input>-->
            </i-col>
        </Row>
        <Row style="padding:5px 0;">
            <i-col span="10">
                开始时间：  <DatePicker type="date" style="width:30%;"
                                   v-model="filterObj.startTime"></DatePicker>
                结束时间：  <DatePicker type="date" style="width:30%;"
                                   v-model="filterObj.endTime"></DatePicker>
            </i-col>
            <i-col span="10">
                <i-button @click="select" type="primary" style="margin-right:1px">查询</i-button>
                <i-button @click="reset" style="margin-right:1px">重置</i-button>
                <i-button type="primary" @click="daochu">
                    <Icon type="ios-download-outline"></Icon>导出全部数据
                </i-button>
                <i-button type="primary" @click="daochubyfenye">
                    <Icon type="ios-download-outline"></Icon>导出当前数据
                </i-button>
                <!--<i-button type="primary" @click="bumenadd">
                    <Icon type="ios-download-outline"></Icon>添加部门
                </i-button>-->
            </i-col>
        </Row>


        <i-table ref="selection" :columns="columns" size="small" :data="lists" border="true" :loading="tableLoading"></i-table>
        <div style="display:flex;justify-content:center;align-items:center;padding:5px;">
            <Page size="small" :total="totalRows" :page-size-opts="[10,15, 20, 30, 40]" show-total show-sizer show-elevator
                  :current="pageIndex" :page-size="pageSize" @on-change="pageIndexChange" @on-page-size-change="pageSizeChange" />
        </div>

    </div>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    const qs = require('qs');
    const moment = require('moment');
    export default {
        data() {
            return {
                lists: [],
                daochudata: [],
                totalRows: 0,
                pageIndex: 1,
                pageSize: 15,
                tableLoading: false,
                columns: [],
                columns_lw: [
                    {
                        title: '论文名称',
                        key: 'lunWenMingCheng',
                        width: 400,
                        fixed: 'left'
                    },
                    {
                        title: '论文类别',
                        key: 'lunWenLeiBieMingCheng',
                        width: 100,
                    },
                    {
                        title: '论文载体',
                        key: 'lunWenZaiTiMingCheng',
                        width: 100,

                    },
                    {
                        title: '期刊名称',
                        key: 'zaiTiMingCheng',
                        width: 400,
                    },
                    {
                        title: '国际标准刊号',
                        key: 'guoJiBiaoZhunHao',
                        width: 400,
                    },
                    {
                        title: '发表时间',
                        key: 'faBiaoShiJianName',
                        width: 200,
                    },
                    {
                        title: '收录情况',
                        key: 'shouLuQingKuangMingCheng',
                        width: 500,
                    },
                    {
                        title: '作者',
                        key: 'zuyuans',
                        width: 300,
                    },
                    {
                        title: '标注上海公安学院',
                        key: 'isBiaoZhuShangHaiGongAnXueYuan',
                        width: 100,
                    },
                    {
                        title: '论文字数',
                        key: 'lunWenZiShu',
                        width: 100,
                    },
                    {
                        title: '与行业联合发表',
                        key: 'isYuHangYe',
                        width: 100,
                    },
                    {
                        title: '与地方联合发表',
                        key: 'isYuDiFang',
                        width: 100,
                    },
                    {
                        title: '与境外联合发表',
                        key: 'isJingWai',
                        width: 100,
                    },
                    {
                        title: '跨学科论文',
                        key: 'isKuaXueKe',
                        width: 100,
                    },
                    {
                        title: '获奖级别',
                        key: 'lunWenHuoJiangJiBieName',
                        width: 150,
                    },
                    {
                        title: '获奖称号',
                        key: 'huoJiangMingCheng',
                        width: 200,
                    },
                    {
                        title: '获奖时间',
                        key: 'lunWenHuoJiangTime',
                        width: 200,
                    },
                    {
                        title: '上传人部门名称',
                        key: 'buMenMingCheng',
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
                ],
                columns_zz: [
                    {
                        title: '著作名称',
                        key: 'zuZuoMingCheng',
                        width: 400,
                        fixed: 'left'
                    },
                    {
                        title: 'ISBN',
                        key: 'isbn',
                        width: 300,
                    },
                    {
                        title: '类别',
                        key: 'zhuZuoLeiBieName',
                        width: 200,
                    },
                    {
                        title: '出版社',
                        key: 'chuBanSe',
                        width: 400,
                    },
                    {
                        title: '出版社级别',
                        key: 'chuBanSheJiBieName',
                        width: 200,
                    },
                    {
                        title: '出版时间',
                        key: 'chuBanShiJianName',
                        width: 200,
                    },
                    {
                        title: '著作者',
                        key: 'zuyuans',
                        width: 400,
                    },
                    {
                        title: '是否标注上海公安学院',
                        key: 'isBiaoZhuXueYuanName',
                        width: 100,
                    },
                    {
                        title: '全书字数',
                        key: 'quanShuZiShu',
                        width: 120,
                    },
                    {
                        title: '供稿章节',
                        key: 'gongGaoZhangJie',
                        width: 120,
                    },
                    {
                        title: '供稿字数',
                        key: 'gongGaoZiShu',
                        width: 120,
                    },
                    {
                        title: '著作获奖级别',
                        key: 'zuZhuoHuoJiangJiBieName',
                        width: 200,
                    },
                    {
                        title: '著作获奖称号',
                        key: 'huoJiangMingCheng',
                        width: 400,
                    },
                    {
                        title: '著作获奖时间',
                        key: 'zhuZhuoHuoJiangShiJianName',
                        width: 200,
                    },
                    {
                        title: '上传人部门名称',
                        key: 'buMenMingCheng',
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

                ],
                columns_jc: [
                    {
                        title: '教材名称',
                        key: 'jiaoCaiMingCheng',
                        width: 400,
                        fixed: 'left'
                    },
                    {
                        title: 'ISBN',
                        key: 'isbn',
                        width: 300,
                    },
                    {
                        title: '出版社',
                        key: 'chuBanShe',
                        width: 400,
                    },
                    {
                        title: '出版社级别',
                        key: 'chuBanSheJiBieName',
                        width: 200,
                    },
                    {
                        title: '出版时间',
                        key: 'chuBanShiJianName',
                        width: 200,
                    },
                    {
                        title: '编写人',
                        key: 'userName',
                        width: 400,
                    },
                    {
                        title: '参编情况',
                        key: 'canBianQingKuangName',
                        width: 400,
                    },
                    {
                        title: '是否标注上海公安学院',
                        key: 'isBiaoZhuXueYuanName',
                        width: 100,
                    },
                    {
                        title: '全书字数',
                        key: 'quanShuZiShu',
                        width: 120,
                    },
                    {
                        title: '参编章节',
                        key: 'canBianZhangJie',
                        width: 120,
                    },
                    {
                        title: '参编字数',
                        key: 'canBianZiShu',
                        width: 120,
                    },
                    {
                        title: '教材获奖级别',
                        key: 'jiaoCaiHuoJiangJiBieName',
                        width: 200,
                    },
                    {
                        title: '教材获奖称号',
                        key: 'huoJiangMingCheng',
                        width: 400,
                    },
                    {
                        title: '教材获奖时间',
                        key: 'jiaoCaiHuoJiangShiJianName',
                        width: 200,
                    },
                    {
                        title: '上传人部门名称',
                        key: 'buMenMingCheng',
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

                ],
                columns_rj: [
                    //软件名称、类别、开发完成日期、权利取得方式、权利范围、软件著作权登记号、证书号、发明（著作权）人、应用级别、是否行业联合专利（著作权）
                    {
                        title: '软件名称',
                        key: 'mingCheng',
                        width: 400,
                        fixed: 'left'
                    },
                    {
                        title: '类别',
                        key: 'leiBieName',
                        width: 300,
                    },
                    {
                        title: '开发完成日期',
                        key: 'kaiFaWanChengRiQiName',
                        width: 400,
                    },
                    {
                        title: '权利取得方式',
                        key: 'quanLiQuDeFangShi',
                        width: 200,
                    },
                    {
                        title: '权利范围',
                        key: 'quanLiFanWei',
                        width: 200,
                    },
                    {
                        title: '证书号',
                        key: 'zhengShuHao',
                        width: 400,
                    },
                    {
                        title: '发明（著作权）人',
                        key: 'famingren',
                        width: 400,
                    },
                    {
                        title: '应用级别',
                        key: 'yingYongJiBieName',
                        width: 100,
                    },
                    {
                        title: '是否行业联合专利',
                        key: 'isLianHeHangYeName',
                        width: 120,
                    },
                    {
                        title: '上传人部门名称',
                        key: 'buMenMingCheng',
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
                ],
                columns_zl: [
                    //专利名称、类别、专利号、专利申请日、授权公告日、证书号、是否行业联合专利（著作权）、应用级别
                    {
                        title: '专利名称',
                        key: 'mingCheng',
                        width: 400,
                        fixed: 'left'
                    },
                    {
                        title: '类别',
                        key: 'leiBieName',
                        width: 300,
                    },
                    {
                        title: '专利号',
                        key: 'zhuanLiHao',
                        width: 400,
                    },
                    {
                        title: '专利申请日',
                        key: 'zhuanLiShenQingRiName',
                        width: 200,
                    },
                    {
                        title: '授权公告日',
                        key: 'shouQuanGongGaoRiName',
                        width: 200,
                    },
                    {
                        title: '证书号',
                        key: 'zhengShuHao',
                        width: 400,
                    },
                    {
                        title: '是否行业联合专利',
                        key: 'isLianHeHangYeName',
                        width: 400,
                    },
                    {
                        title: '应用级别',
                        key: 'yingYongJiBieName',
                        width: 100,
                    },
                    {
                        title: '上传人部门名称',
                        key: 'buMenMingCheng',
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
                ],
                columns_qt: [
                    //其他名称、成果年度、科研成果简介
                    {
                        title: '其他名称',
                        key: 'mingCheng',
                        width: 400,
                        fixed: 'left'
                    },
                    {
                        title: '成果年度',
                        key: 'chengGuoNianDu',
                    },
                    {
                        title: '科研成果简介',
                        key: 'keYanChengGuoJianJie',
                    },
                    {
                        title: '上传人部门名称',
                        key: 'buMenMingCheng',
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
                ],
                columns_ky: [
                    //科研项目名称、项目级别、项目类别、项目状态、批准立项部门、科研项目来源、批准立项时间、批准结项时间、院内项目编号、院外项目编号、项目经费总额、项目组成员、是否由院科研主管部门管理、是否为本人指导的学生科研项目、项目获奖级别、项目获奖时间、项目获奖称号、项目获奖证书编号、项目成果采纳级别、项目成果采纳时间
                    {
                        title: '科研项目名称',
                        key: 'xiangMuMingCheng',
                        width: 400,
                        fixed: 'left'
                    },
                    {
                        title: '项目级别',
                        key: 'xiangMuJieBieName',
                        width: 200,
                    },
                    {
                        title: '项目类别',
                        key: 'xiangMuLeiBieName',
                        width: 200,
                    },
                    {
                        title: '项目状态',
                        key: 'xiangMuZhuangTaiName',
                        width: 200,
                    },
                    {
                        title: '批准立项部门',
                        key: 'piZunLiXiangBuMen',
                        width: 200,
                    },
                    {
                        title: '科研项目来源',
                        key: 'xiangMuLaiYuan',
                        width: 200,
                    },
                    {
                        title: '批准立项时间',
                        key: 'piZunLiXiangShiJianName',
                        width: 200,
                    }, {
                        title: '批准结项时间',
                        key: 'piZunJieXiangShiJianName',
                        width: 200,
                    },
                    {
                        title: '院内项目编号',
                        key: 'yuanNeiXiangMuBianHao',
                        width: 200,
                    },
                    {
                        title: '院外项目编号',
                        key: 'yuanWaiXiangMuBianHao',
                        width: 200,
                    },
                    {
                        title: '项目经费总额',
                        key: 'xiangMuZiZuZongE',
                        width: 200,
                    },
                    {
                        title: '项目组成员',
                        key: 'zuyuans',
                        width: 400,
                    }, {
                        title: '是否由院科研主管部门管理',
                        key: 'isYouYuanKeZhuGuanName',
                        width: 200,
                    },
                    {
                        title: '是否为本人指导的学生科研项目',
                        key: 'isWeiBenRenZhiDaoName',
                        width: 200,
                    },
                    {
                        title: '项目获奖级别',
                        key: 'huoJiangLeiXingName',
                        width: 200,
                    },
                    {
                        title: '项目获奖时间',
                        key: 'xiangMuHuoJiangShiJianName',
                        width: 200,
                    },
                    {
                        title: '项目获奖称号',
                        key: 'xiangMuHuoJiangMingCheng',
                        width: 400,
                    },
                    {
                        title: '项目获奖证书编号',
                        key: 'xiangMuHuoJiangZhengShuId',
                        width: 200,
                    },
                    {
                        title: '项目成果采纳级别',
                        key: 'xiangMuCaiNaJiBieName',
                        width: 200,
                    },
                    {
                        title: '项目成果采纳时间',
                        key: 'xiangMuChengGuoCaiNaShiJianName',
                        width: 200,
                    },
                    {
                        title: '上传人部门名称',
                        key: 'buMenMingCheng',
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
                ],
                filterObj: {
                    applyName: '',
                    startTime: '',
                    endTime: '',
                    isHuoJiang: '',
                    cgName: '',
                    isChuBan: '',
                    renDingFanWei: ''
                },
                renDingList: [],
            }
        },
        props: ['leixing'],
        watch: {
            leixing: {
                deep: true,
                handler(newName, oldName) {
                    switch (this.leixing) {
                        case "lunwen":
                            this.getlwlist();
                            this.getlwlistByfenye();
                            this.columns = this.columns_lw;
                            break;
                        case "zuzuo":
                            this.getzzlist();
                            this.getzzlistByfenye();
                            this.columns = this.columns_zz;
                            break;
                        case "jiaocai":
                            this.getjclist();
                            this.getjclistByfenye();
                            this.columns = this.columns_jc;
                            break;
                        case "ruanjian":
                            this.getrjlist(0);
                            this.getrjlistByfenye(0);
                            this.columns = this.columns_rj;
                            break;
                        case "zhuanli":
                            this.getrjlist(1);
                            this.getrjlistByfenye(1);
                            this.columns = this.columns_zl;
                            break;
                        case "qita":
                            this.getqtlist();
                            this.getqtlistByfenye();
                            this.columns = this.columns_qt;
                            break;
                        case "keyanxiangmu":
                            this.getkylist();
                            this.getkylistByfenye();
                            this.columns = this.columns_ky;
                            break;
                    }
                },
            }
        },
        mounted() {
            console.log(this.leixing);
            if (this.leixing == "lunwen") {
                this.columns = this.columns_lw;
                this.getrenDingList();
            }
            this.getlwlistByfenye();
            this.getlwlist();
        },
        computed: {},
        components: {

        },
        methods: {
            //论文
            getlwlist() {
                this.tableLoading = true;
                axios.get('api/Cg_LunWen/GetLunWenS', {
                    params: {

                    }
                })
                    .then(response => {
                        this.daochudata = response.data.results
                        // console.log(this.daochudata)
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            getlwlistByfenye() {
                this.tableLoading = true;
                axios.get('api/Cg_LunWen/GetLunWenSByFenYe', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                    }
                })
                    .then(response => {
                        this.lists = response.data.results
                        //console.log(this.lists )
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            selectbylw() {
                console.log(this.filterObj)
                this.tableLoading = true;
                axios.get('api/Cg_LunWen/GetLunWenByBase', {
                    params: {
                        applyName: this.filterObj.applyName,
                        startTime: this.filterObj.startTime,
                        endTime: this.filterObj.endTime,
                        isHuoJiang: this.filterObj.isHuoJiang,
                        cgName: this.filterObj.cgName,
                        isChuBan: this.filterObj.isChuBan,
                        renDingFanWei: this.filterObj.renDingFanWei,
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,

                    }
                })
                    .then(response => {
                        this.lists = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            //著作
            getzzlist() {
                this.tableLoading = true;
                axios.get('api/Cg_ZhuZuo/GetZhuZhuoS', {
                    params: {

                    }
                })
                    .then(response => {
                        this.daochudata = response.data.results
                        // console.log(this.daochudata)
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            getzzlistByfenye() {
                this.tableLoading = true;
                axios.get('api/Cg_ZhuZuo/GetZhuZhuoSByFenYe', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                    }
                })
                    .then(response => {
                        this.lists = response.data.results
                        //console.log(this.lists)
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            selectbyzz() {
                this.tableLoading = true;
                axios.get('api/Cg_ZhuZuo/GetZhuZhuoByBase', {
                    params: {
                        applyName: this.filterObj.applyName,
                        startTime: this.filterObj.startTime,
                        endTime: this.filterObj.endTime,
                        isHuoJiang: this.filterObj.isHuoJiang,
                        cgName: this.filterObj.cgName,
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                    }
                })
                    .then(response => {
                        this.lists = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            //教材
            getjclist() {
                this.tableLoading = true;
                axios.get('api/Cg_JiaoCai/GetJiaoCaiS', {
                    params: {

                    }
                })
                    .then(response => {
                        this.daochudata = response.data.results
                        //  console.log(this.daochudata)
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            getjclistByfenye() {
                this.tableLoading = true;
                axios.get('api/Cg_JiaoCai/GetJiaoCaiSByFenYe', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                    }
                })
                    .then(response => {
                        this.lists = response.data.results
                        //console.log(this.lists)
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            selectbyjc() {
                this.tableLoading = true;
                axios.get('api/Cg_JiaoCai/GetJiaoCaiByBase', {
                    params: {
                        applyName: this.filterObj.applyName,
                        startTime: this.filterObj.startTime,
                        endTime: this.filterObj.endTime,
                        isHuoJiang: this.filterObj.isHuoJiang,
                        cgName: this.filterObj.cgName,
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                    }
                })
                    .then(response => {
                        this.lists = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            //软件 专利
            getrjlist(lx) {
                this.tableLoading = true;
                axios.get('api/Cg_RuanJian/GetRuanJianS', {
                    params: {
                        lx: lx
                    }
                })
                    .then(response => {
                        this.daochudata = response.data.results
                        console.log(this.daochudata)
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            getrjlistByfenye(lx) {
                this.tableLoading = true;
                axios.get('api/Cg_RuanJian/GetRuanJianSByFenYe', {
                    params: {
                        lx: lx,
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                    }
                })
                    .then(response => {
                        this.lists = response.data.results
                        //console.log(this.lists)
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            selectbyrj(lx) {
                this.tableLoading = true;
                axios.get('api/Cg_RuanJian/GetRuanJianByBase', {
                    params: {
                        lx: lx,
                        applyName: this.filterObj.applyName,
                        startTime: this.filterObj.startTime,
                        endTime: this.filterObj.endTime,
                        isHuoJiang: this.filterObj.isHuoJiang,
                        cgName: this.filterObj.cgName,
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                    }
                })
                    .then(response => {
                        this.lists = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            //其他
            getqtlist() {
                this.tableLoading = true;
                axios.get('api/Cg_Qita/GetQiTaS', {
                    params: {

                    }
                })
                    .then(response => {
                        this.daochudata = response.data.results
                        //  console.log(this.daochudata)
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            getqtlistByfenye() {
                this.tableLoading = true;
                axios.get('api/Cg_Qita/GetQiTaSByFenYe', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                    }
                })
                    .then(response => {
                        this.lists = response.data.results
                        //console.log(this.lists)
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            selectbyqt() {
                this.tableLoading = true;
                axios.get('api/Cg_Qita/GetQiTaByBase', {
                    params: {
                        applyName: this.filterObj.applyName,
                        startTime: this.filterObj.startTime,
                        endTime: this.filterObj.endTime,
                        isHuoJiang: this.filterObj.isHuoJiang,
                        cgName: this.filterObj.cgName,
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                    }
                })
                    .then(response => {
                        this.lists = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            //科研项目
            getkylist() {
                this.tableLoading = true;
                axios.get('api/Cg_KeYanXiangMu/GetKeYanXiangMuS', {
                    params: {

                    }
                })
                    .then(response => {
                        this.daochudata = response.data.results
                        //  console.log(this.daochudata)
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            getkylistByfenye() {
                this.tableLoading = true;
                axios.get('api/Cg_KeYanXiangMu/GetKeYanXiangMuSByFenYe', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                    }
                })
                    .then(response => {
                        this.lists = response.data.results
                        //console.log(this.lists)
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            selectbyky() {
                this.tableLoading = true;
                axios.get('api/Cg_KeYanXiangMu/GetKeYanXiangMuByBase', {
                    params: {
                        applyName: this.filterObj.applyName,
                        startTime: this.filterObj.startTime,
                        endTime: this.filterObj.endTime,
                        isHuoJiang: this.filterObj.isHuoJiang,
                        cgName: this.filterObj.cgName,
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                    }
                })
                    .then(response => {
                        this.lists = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },

            select() {
                switch (this.leixing) {
                    case "lunwen":
                        this.selectbylw();
                        break;
                    case "zuzuo":
                        this.selectbyzz();
                        break;
                    case "jiaocai":
                        this.selectbyjc();
                        break;
                    case "ruanjian":
                        this.selectbyrj(0);
                        break;
                    case "zhuanli":
                        this.selectbyrj(1);
                        break;
                    case "qita":
                        this.selectbyqt();
                        break;
                    case "keyanxiangmu":
                        this.selectbyky();
                        break;
                }

            },
            pageIndexChange(currentIndex) {
                this.pageIndex = currentIndex
                switch (this.leixing) {
                    case "lunwen":
                        this.getlwlistByfenye();
                        break;
                    case "zuzuo":
                        this.getzzlistByfenye();
                        break;
                    case "jiaocai":
                        this.getjclistByfenye();
                        break;
                    case "ruanjian":
                        this.getrjlistByfenye(0);
                        break;
                    case "zhuanli":
                        this.getrjlistByfenye(1);
                        break;
                    case "qita":
                        this.getqtlistByfenye();
                        break;
                    case "keyanxiangmu":
                        this.getkylistByfenye();
                        break;
                }
            },
            pageSizeChange(currentpagrSize) {
                this.pageSize = currentpagrSize
                switch (this.leixing) {
                    case "lunwen":
                        this.getlwlistByfenye();
                        break;
                    case "zuzuo":
                        this.getzzlistByfenye();
                        break;
                    case "jiaocai":
                        this.getjclistByfenye();
                        break;
                    case "ruanjian":
                        this.getrjlistByfenye(0);
                        break;
                    case "zhuanli":
                        this.getrjlistByfenye(1);
                        break;
                    case "qita":
                        this.getqtlistByfenye();
                        break;
                    case "keyanxiangmu":
                        this.getkylistByfenye();
                        break;
                }
            },
            reset() {
                this.filterObj = {
                    applyName: '',
                    startTime: '',
                    endTime: '',
                    isHuoJiang: '',
                    cgName: '',
                }
                switch (this.leixing) {
                    case "lunwen":
                        this.getlwlistByfenye();
                        break;
                    case "zuzuo":
                        this.getzzlistByfenye();
                        break;
                    case "jiaocai":
                        this.getjclistByfenye();
                        break;
                    case "ruanjian":
                        this.getrjlistByfenye(0);
                        break;
                    case "zhuanli":
                        this.getrjlistByfenye(1);
                        break;
                    case "qita":
                        this.getqtlistByfenye();
                        break;
                    case "keyanxiangmu":
                        this.getkylistByfenye();
                        break;
                }
            },
            daochu() {
                var name = null;
                switch (this.leixing) {
                    case "lunwen":
                        name = "论文";
                        break;
                    case "zuzuo":
                        name = "著作";
                        break;
                    case "jiaocai":
                        name = "教材";
                        break;
                    case "ruanjian":
                        name = "软件";
                        break;
                    case "zhuanli":
                        name = "专利";
                        break;
                    case "qita":
                        name = "其他";
                        break;
                    case "keyanxiangmu":
                        name = "科研项目";
                        break;
                }
                this.$refs.selection.exportCsv({
                    filename: name + '统计表',
                    columns: this.columns,
                    data: this.daochudata
                });
            },
            daochubyfenye() {
                var name = null;
                switch (this.leixing) {
                    case "lunwen":
                        name = "论文";
                        break;
                    case "zuzuo":
                        name = "著作";
                        break;
                    case "jiaocai":
                        name = "教材";
                        break;
                    case "ruanjian":
                        name = "软件";
                        break;
                    case "zhuanli":
                        name = "专利";
                        break;
                    case "qita":
                        name = "其他";
                        break;
                    case "keyanxiangmu":
                        name = "科研项目";
                        break;
                }
                this.$refs.selection.exportCsv({
                    filename: name + '统计表',
                });
            },
            bumenadd() {
                axios.get('api/Cg_LunWen/updateBuMen', {
                    params: {

                    }
                }).then(response => {
                    if (!response.data.error) {
                        this.$Message.success('保存成功!');
                    } else {
                        this.$Message.error('保存失败!');
                    }
                });
            },
            //获取认定范围
            getrenDingList() {
                this.tableLoading = true;
                axios.get('api/Cg_LunWen/GetLunWenByRenDingFanWei', {
                    params: {

                    }
                })
                    .then(response => {
                        this.renDingList = response.data.results
                        //console.log(this.renDingList)
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
        }
    };
</script>
<style>
</style>