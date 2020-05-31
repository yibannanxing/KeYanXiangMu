<template>
    <div style="padding:10px">
        项目类型:
        <i-select v-model="xiangmuleixing" style="width:100px;margin-bottom:3px">
            <i-option value="-1">请选择</i-option>
            <i-option value="0">重点项目</i-option>
            <i-option value="1">一般项目</i-option>
        </i-select>
        结项时间:<DatePicker type="date" style="width:200px;margin-bottom:3px" v-model="EndTime"></DatePicker>
        <i-button @click="select" type="primary" style="margin-left:5px;margin-bottom:3px">查询</i-button>
        <i-button @click="reset" style="margin-right:1px">重置</i-button>
        <i-table ref="selection"
                 :columns="columns"
                 size="small"
                 :data="jiexianglist"
                 border="true"
                 :loading="tableLoading"
                 @on-selection-change="getjiexianglist"></i-table>

        <div style="display:flex;justify-content:center;align-items:center;padding:5px;">
            <Page size="small"
                  :total="totalRows"
                  :page-size-opts="[10,15, 20, 30, 40]"
                  show-total
                  show-sizer
                  show-elevator
                  :current="pageIndex"
                  :page-size="pageSize"
                  @on-change="pageIndexChange"
                  @on-page-size-change="pageSizeChange" />
        </div>

        <Modal title="编辑/查看"
               v-model="modalshow"
               width="80%"
               :footer-hide="true"
               :styles="{top: '0'}"
               :mask-closable="false"
               :scrollable='false'
               :transfer="false"
               class-name="vertical-center-modal">
            <div :style="{height:matchHeight+'px','overflow-y':'auto',padding:0}">

                <JieXiangEdit v-if="modalshow&&type==1" :jxid="id" :isView="isView" @close="close"></JieXiangEdit>
                <JieXiangEdit_stu v-if="modalshow&&type==0" :jxid="id" :isView="isView" @close="close"></JieXiangEdit_stu>

                <!--<jiaogongBase v-if="modalshow&!isStudent"
                          @close="close"
                          :isView="isView"
                          :id="currentId"
                          :jumpType="0"></jiaogongBase>
            <studentBase v-if="modalshow&isStudent"
                         @close="close"
                         :isView="isView"
                         :id="currentId"
                         :jumpType="0"></studentBase>-->
            </div>
        </Modal>


    </div>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    const moment = require('moment');
    const qs = require('qs');
    import JieXiangEdit from '../components/JieXiangEdit.vue';
    import JieXiangEdit_stu from '../components/JieXiangEdit_stu.vue';
    export default {
        data() {
            return {
                isstu: false,
                xiangmuleixing: ['-1'],
                EndTime: '',
                id: null,
                isView: false,
                modalshow: false,
                matchHeight: window.innerHeight * 0.8,
                tableLoading: false,
                totalRows: 0,
                pageIndex: 1,
                pageSize: 15,
                columns: [
                    {
                        title: '项目名称',
                        key: 'xiangMuMingCheng',
                    },
                    {
                        title: '项目类型',
                        key: 'xiangMuLeiXing',
                        render: (h, params) => {
                            if (params.row.xiangMuLeiXing == 0) {
                                return h('span', "重点项目")
                            } else if (params.row.xiangMuLeiXing == 1) {
                                return h('span', "一般项目")
                            }
                            //return h('span', moment(params.row.createDate).format('YYYY-MM-DD')
                            //)
                        },
                    },
                    {
                        title: '负责人',
                        key: 'fuZeRenMingCheng',
                    },
                    {
                        title: '部门',
                        key: 'buMenMingCheng',
                    },
                    {
                        title: '结项时间',
                        key: 'jieXiangTime',
                        render: (h, params) => {
                            return h('span', moment(params.row.jieXiangTime).format('YYYY-MM-DD')
                            )
                        },
                    },
                    {
                        title: '核准经费',
                        key: 'heZunJingFei',

                    },
                    {
                        title: '实际经费',
                        key: 'shiJiJingFei',
                    },
                    {
                        title: '操作',
                        align: 'center',
                        width: 180,

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
                                            this.isView = false
                                            if (params.row.jieXiangLeiXing == 0) {
                                                this.type = 0
                                            } else if (params.row.jieXiangLeiXing == 1) {
                                                this.type = 1
                                            }
                                            //this.isStudent = params.row.liXiangLeiXing == 0
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
                                            this.isView = true
                                            if (params.row.jieXiangLeiXing == 0) {
                                                this.type = 0
                                            } else if (params.row.jieXiangLeiXing == 1) {
                                                this.type = 1
                                            }
                                            //this.isStudent = params.row.liXiangLeiXing == 0
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

                                    },
                                    on: {
                                        click: () => {
                                            this.deleteItem(params.row.id)

                                        }
                                    }
                                }, '删除')

                            ]);
                        }
                    }
                ],
                jiexianglist: []
            }
        },
        props: [],
        mounted() {
            this.getjiexianglist();
        },
        computed: {},
        components: {
            JieXiangEdit,
            JieXiangEdit_stu
        },
        methods: {
            getjiexianglist() {
                //GetJieXinags
                this.tableLoading = true;
                axios.get('api/JieXiang/GetJieXinags', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,

                    }
                })
                    .then(response => {
                        this.jiexianglist = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });

            },
            pageIndexChange(currentIndex) {
                this.pageIndex = currentIndex
                this.getjiexianglist()
            },
            pageSizeChange(currentpagrSize) {
                this.pageSize = currentpagrSize
                this.getjiexianglist()
            },
            //删除
            deleteItem(id) {
                this.$Modal.confirm({
                    title: "删除",
                    content: "您确定要删除嘛",
                    onOk: () => {
                        axios.get('api/JieXiang/DelJieXiang', { params: { id: id } }).then(response => {
                            if (!response.data.error) {
                                this.$Notice.success({
                                    title: '操作成功',
                                });
                                this.getjiexianglist();
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
            close() {
                this.modalshow = false;
                this.getjiexianglist()
            },
            select() {
                //GetJieXiangBy
                this.tableLoading = true;
                axios.get('api/JieXiang/GetJieXiangBy', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                        xiangmuleixing: this.xiangmuleixing,
                        EndTime: this.EndTime
                    }
                })
                    .then(response => {
                        this.jiexianglist = response.data.results
                        this.totalRows = response.data.totalRows
                        this.tableLoading = false;
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            reset() {
                this.xiangmuleixing = -1;
                this.EndTime = "";
                this.select();
                //xiangmuleixing: ['-1'],
                //    EndTime: '',
            }

        }
    };
</script>
<style scoped>

</style>