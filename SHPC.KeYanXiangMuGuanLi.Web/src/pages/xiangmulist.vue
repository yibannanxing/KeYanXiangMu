    <template>
    <div style="width:100%;">
        <Row type="flex" justify="space-around" class="code-row-bg" style="padding:5px 0;">
            <i-col span="2">
                申请人：<i-input v-model="filterObj.applyName" style="width:50%;"></i-input>
            </i-col>
            <i-col span="3">
                部门：<i-input v-model="filterObj.bumen" style="width:50%;"></i-input>
            </i-col>
            <i-col span="4">
                项目类型：
                <i-select v-model="filterObj.xiangmuleixing" style="width:50%;">
                    <i-option value="0">重点项目</i-option>
                    <i-option value="1">一般项目</i-option>
                </i-select>
            </i-col>
            <i-col span="4">
                研究类型：
                <i-select v-model="filterObj.yanjiuleixing" style="width:50%;">
                    <i-option value="0">基础研究</i-option>
                    <i-option value="1">应用研究</i-option>
                    <i-option value="2">综合研究</i-option>
                    <i-option value="3">其他</i-option>
                </i-select>
            </i-col>
            <i-col span="4">
                立项时间：<DatePicker type="date" style="width:60%;"
                                 v-model="filterObj.startTime"></DatePicker>
            </i-col>
            <i-col span="4">
                结项时间：<DatePicker type="date" style="width:60%;"
                                 v-model="filterObj.endTime"></DatePicker>
            </i-col>
            <i-col span="3">
                <i-button @click="select" type="primary" style="margin-right:1px">查询</i-button>
                <i-button @click="reset" style="margin-right:1px">重置</i-button>
                <i-button type="primary" @click="daochu">
                    <Icon type="ios-download-outline"></Icon>导出
                </i-button>
            </i-col>
        </Row>

        <i-table ref="selection"
                 :row-class-name="rowClassName"
                 :columns="columns"
                 size="small"
                 :data="xiangmulist"
                 border="true"
                 :loading="tableLoading"
                 @on-selection-change="getXiangMuList"></i-table>

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
               width="95%"
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
    </div>
</template>
<script lang="ts">
    import Vue from "vue";
    import axios from 'axios';
    import jiaogongBase from '../default/jiaogongBase.vue';
    import studentBase from '../default/studentBase.vue';
    const qs = require('qs');
    const moment = require('moment');
    export default {
        data() {
            return {
                isStudent: false,
                matchHeight: window.innerHeight * 0.8,
                modalshow: false,
                isView: false,
                tableLoading: false,
                totalRows: 0,
                pageIndex: 1,
                pageSize: 15,
                currentId: null,
                filterObj: {
                    applyName: '',
                    bumen: '',
                    xiangmuleixing: -1,
                    yanjiuleixing: -1,
                    startTime: '',
                    sndTime: ''
                },
                columns: [
                    {
                        title: '项目名称',
                        key: 'xiangMuMingCheng',
                        width: 600,
                        fixed: 'left'

                    },
                    {
                        title: '申请人',
                        key: 'shenQingRenName',
                        width: 200,

                    },
                    {
                        title: '部门',
                        key: 'shenQingRenBuMenMingCheng',
                        width: 200,

                    },
                    {
                        title: '项目类型',
                        key: 'xiangMuLeiXingName',
                        width: 200,
                    },
                    {
                        title: '研究类型',
                        key: 'yanJiuLeiXingName',
                        width: 200,
                    },
                    {
                        title: '立项时间',
                        key: 'startDateTime',
                        width: 200,
                        render: (h, params) => {
                            return h('span', moment(params.row.startDateTime).format('YYYY-MM-DD')
                            )
                        }
                    },
                    {
                        title: '结项时间',
                        key: 'endDateTime',
                        width: 200,
                        render: (h, params) => {
                            return h('span', moment(params.row.endDateTime).format('YYYY-MM-DD')
                            )
                        },
                    },
                    {
                        title: '项目进度',
                        key: 'xiangMuZhuangTaiName',
                        width: 200,
                    },
                    {
                        title: '经费总额（万元）',
                        key: 'jingFeiZongE',
                        sortable: true,
                        width: 200,
                    },
                    {
                        title: '操作',
                        align: 'center',
                        width: 180,
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
                xiangmulist: []
            }
        },
        watch: {
        },
        mounted() {
            this.getXiangMuList()
        },
        components: {
            jiaogongBase, studentBase
        },
        computed: {
        },
        methods: {
            reset() {
                this.filterObj = {
                    applyName: '',
                    bumen: '',
                    xiangmuleixing: -1,
                    yanjiuleixing: -1,
                    startTime: '',
                    sndTime: ''
                };
                this.getXiangMuList();
            },
            close() {
                this.modalshow = false;
                this.getXiangMuList();
            },
            //总览
            getXiangMuList() {
                this.tableLoading = true;
                axios.get('api/XiangMu/GetXiangMuByZiDuan', {
                    params: {
                        skip: (this.pageIndex - 1) * this.pageSize,
                        take: this.pageSize,
                        applyName: this.filterObj.applyName,
                        bumen: this.filterObj.bumen,
                        xiangmuleixing: this.filterObj.xiangmuleixing,
                        yanjiuleixing: this.filterObj.yanjiuleixing,
                        startTime: this.filterObj.startTime,
                        endTime: this.filterObj.endTime,
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
                        axios.get('api/XiangMu/DelXiangMu', {
                            params: {
                                xiangmuId: id
                            }
                        }).then(response => {
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
                this.pageIndex = 1;
                this.getXiangMuList();

            },
            daochu() {
                this.$refs.selection.exportCsv({
                    filename: '科研项目总览表',
                    columns: this.columns.filter((col, index) => index < 9)
                });
            },
            rowClassName(row, index) {
                var timenow = new Date();
                var time = new Date(row.endDateTime);
               // console.log(this.DateDifference(timenow, time))
                if (this.DateDifference(timenow, time) >= 0 && this.DateDifference(timenow, time) <= 30) {
                    return 'demo-table-error-row';
                }
                return '';
            },
            DateDifference(faultDate, completeTime) {
                // let d1 = new Date(faultDate);
                // let d2 = new Date(completeTime);
                var stime = new Date(faultDate).getTime();
                var etime = new Date(completeTime).getTime();
                var usedTime = etime - stime;  //两个时间戳相差的毫秒数
                var days = Math.floor(usedTime / (24 * 3600 * 1000));
                //计算出小时数
                var leave1 = usedTime % (24 * 3600 * 1000);    //计算天数后剩余的毫秒数
                var hours = Math.floor(leave1 / (3600 * 1000));
                //计算相差分钟数
                var leave2 = leave1 % (3600 * 1000);        //计算小时数后剩余的毫秒数
                var minutes = Math.floor(leave2 / (60 * 1000));
                // var time = days + "天"+hours+"时"+minutes+"分";
                var time = days;
                return time;
            }
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

    /deep/ div.ivu-table .demo-table-error-row td {
       
        color:crimson;
    }
   
    /deep/ tr.ivu-table-row .demo-table-info-row {
        background-color: red;
        color: #fff;
    }
</style>
