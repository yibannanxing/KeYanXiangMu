<template>
    <div style="width:100%;">
        项目类型:
        <i-select v-model="xiangmuleixing" style="width:100px">
            <i-option value="-1">请选择</i-option>
            <i-option value="0">重点项目</i-option>
            <i-option value="1">一般项目</i-option>
        </i-select>

        研究类型:
        <i-select v-model="yanjiuleixing" style="width:100px">
            <i-option value="-1">请选择</i-option>
            <i-option value="0">基础研究</i-option>
            <i-option value="1">应用研究</i-option>
            <i-option value="2">综合研究</i-option>
            <i-option value="3">其他</i-option>
        </i-select>
        立项时间:<DatePicker type="date" style="width:200px;margin-bottom:5px; margin-right:5px" v-model="StartTime"></DatePicker>
        结项时间:<DatePicker type="date" style="width:200px;margin-bottom:5px; margin-right:5px" v-model="EndTime"></DatePicker>
        <i-button @click="select" type="primary">查询</i-button>
        <!--<i-button type="success" @click="daochu"><Icon type="ios-download-outline"></Icon> 导出</i-button>-->
        <i-table ref="selection" :columns="columns" size="small" :data="xiangmulist" border="true" :loading="tableLoading" @on-selection-change="getXiangMuList"></i-table>
        <div style="display:flex;justify-content:center;align-items:center;padding:5px;">
            <Page size="small" :total="totalRows" :page-size-opts="[10,15, 20, 30, 40]" show-total show-sizer show-elevator
                  :current="pageIndex" :page-size="pageSize" @on-change="pageIndexChange" @on-page-size-change="pageSizeChange" />
        </div>

        <Modal title="编辑/查看"
               v-model="modalshow"
               width="90%"
               :footer-hide="true"
               :styles="{top: '0'}"
               :mask-closable="false"
               :scrollable='false'
               :transfer="false"
               class-name="vertical-center-modal">
            <div :style="{height:matchHeight+'px','overflow-y':'auto',padding:0}">

                <jiaogongBase v-if="modalshow&!isStudent"
                              @close="close"
                              :isView="isView"
                              :id="currentId"
                              :jumpType="0"></jiaogongBase>
                <studentBase v-if="modalshow&isStudent"
                             @close="close"
                             :isView="isView"
                             :id="currentId"
                             :jumpType="0"></studentBase>
            </div>
        </Modal>

        <Modal title=" "
               v-model="jiexiangshow"
               width="80%"
               :footer-hide="true"
               :styles="{top: '0'}"
               :mask-closable="false"
               :scrollable='false'
               :transfer="false"
               class-name="vertical-center-modal">
            <div :style="{height:matchHeight+'px','overflow-y':'auto',padding:0}">
                <!--<FuJian v-if="modalshow&type==0" @close="close" :id="id"> </FuJian>
                <chengguoShow v-if="modalshow&type==1" @close="close" :id="id"> </chengguoShow>-->
                <JieXiangEdit v-if="jiexiangshow&&type==1" @close="close" :isView="isView" :id="currentId" :jumpType="0"></JieXiangEdit>
                <JieXiangEdit_stu v-if="jiexiangshow&&type==0" @close="close" :isView="isView" :id="currentId" :jumpType="0"></JieXiangEdit_stu>
            </div>
        </Modal>




    </div>
</template>
<script lang="ts">
    import Vue from "vue";
    import axios from 'axios';
    import jiaogongBase from '../default/jiaogongBase.vue';
    import studentBase from '../default/studentBase.vue';
    import JieXiangEdit from '../components/JieXiangEdit.vue';
    import JieXiangEdit_stu from '../components/JieXiangEdit_stu.vue';
    const qs = require('qs');
    const moment = require('moment');
    export default {
        data() {
            return {
                jiexiangshow: false,
                isjiexiang: false,
                matchHeight: window.innerHeight * 0.8,
                modalshow: false,
                type: -1,
                tableLoading: false,
                totalRows: 0,
                pageIndex: 1,
                pageSize: 15,
                currentId: null,
                xiangmuleixing: ['-1'],
                yanjiuleixing: ['-1'],
                StartTime: '',
                EndTime: '',
                columns: [
                    {
                        title: '项目名称',
                        key: 'xiangMuMingCheng'
                    },
                    {
                        title: '项目类型',
                        key: 'xiangMuLeiXingName'
                    },
                    {
                        title: '研究类型',
                        key: 'yanJiuLeiXingName'
                    },
                    {
                        title: '立项时间',
                        key: 'startDateTime',
                        render: (h, params) => {
                            return h('span', moment(params.row.startDateTime).format('YYYY-MM-DD'))
                        }
                    },
                    {
                        title: '结项时间',
                        key: 'endDateTime',
                        render: (h, params) => {
                            return h('span', moment(params.row.endDateTime).format('YYYY-MM-DD')
                            )
                        }
                    },
                    {
                        title: '项目进度',
                        key: 'xiangMuZhuangTaiName',
                    },
                    {
                        title: '经费总额（万元）',
                        key: 'jingFeiZongE'
                    },
                    {
                        title: '操作',
                        align: 'center',
                        width: 300,
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
                                            this.currentId = params.row.id
                                            this.isView = false
                                            this.isStudent = params.row.liXiangLeiXing == 0
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
                                            this.currentId = params.row.id
                                            this.isView = true
                                            this.isStudent = params.row.liXiangLeiXing == 0
                                            this.modalshow = true
                                            console.log(params.row)

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
                                            //this.deleteItem(params.row.id)
                                            this.daochu(params.row.id)
                                        }
                                    }
                                }, '导出'),
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
                                            //this.isView = true
                                            //this.isStudent = params.row.liXiangLeiXing == 0
                                            this.currentId = params.row.id
                                            if (params.row.liXiangLeiXing == 1) {
                                                this.type = 1
                                            } else if (params.row.liXiangLeiXing == 0) {
                                                this.type = 0
                                            }
                                            this.jiexiangshow = true

                                        }
                                    }
                                }, '结项')

                            ]);
                        }
                    }
                ],
                xiangmulist: []
            }
        },
        watch: {
        },
        mounted() {

            this.getXiangMuList()
        },
        components: {
            //xiangmuedit, xiangmushow,
            jiaogongBase,
            studentBase,
            JieXiangEdit,
            JieXiangEdit_stu
        },
        computed: {
        },
        methods: {
            close() {
                this.modalshow = false;
                this.getXiangMuList();
            },
            //查询全部
            getXiangMuList() {
                this.tableLoading = true;
                axios.get('api/XiangMu/GetXiangMusByUserId', { params: { skip: (this.pageIndex - 1) * this.pageSize, take: this.pageSize } })
                    .then(response => {
                        this.xiangmulist = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            pageIndexChange(currentIndex) {
                this.pageIndex = currentIndex
                this.getXiangMuList()
            },
            pageSizeChange(currentpagrSize) {
                this.pageSize = currentpagrSize
                this.getXiangMuList()
            },
            //删除
            deleteItem(id) {

                this.$Modal.confirm({
                    title: "删除",
                    content: "您确定要删除嘛",
                    onOk: () => {
                        axios.get('api/XiangMu/DelXiangMu', { params: { xiangmuId: id } }).then(response => {
                            if (!response.data.error) {
                                this.$Notice.success({
                                    title: '操作成功',
                                });
                                this.getXiangMuList();
                            } else {
                                this.$Notice.error({
                                    title: '系统错误',
                                    desc: response.data.error.displayInfo
                                });
                            }
                        }).catch(error => {
                            console.log(error);
                        });
                    },
                })
            },
            //筛选
            select() {
                this.tableLoading = true;
                axios.get('api/XiangMu/GetXiangMuByGeRen', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                        xiangmuleixing: this.xiangmuleixing,
                        yanjiuleixing: this.yanjiuleixing,
                        startTime: this.StartTime,
                        endTime: this.EndTime,
                    }
                })
                    .then(response => {
                        this.xiangmulist = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            daochu(id) {
                axios.get('api/XiangMu/GetPrint', {
                    params: {
                        id: id,
                    }
                })
                    .then(response => {
                        this.$Notice.success({
                            title: '请调整样式后，在作打印',
                        });
                        window.location.href = response.data;

                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },

        }
    }
</script>
<style scoped>
    .ivu-modal-body {
        padding: 0 !important;
        width: 100%;
        overflow-x: hidden !important;
        overflow-y: auto !important;
    }

    .vertical-center-modal {
        display: flex;
        align-items: center;
        justify-content: center;
    }
</style>
