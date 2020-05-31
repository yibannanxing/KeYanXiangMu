<template>
    <div style="padding:10px">
        <Timeline>
            <TimelineItem v-for="item in yijians" key="item">
                <p class="time">{{item.shenPiRenName}} </p>
                <p class="content">
                    审核时间：{{ gettime(item.createDate)}}
                </p>
                <p class="content">
                    <!--<span v-if="(item-1).status==1">初审人通过</span>
                    <span v-if="(item-1).status==2">部门通过</span>
                    <span v-if="(item-1).status==3">科研处通过</span>-->
                    <span v-if="item.status==2||item.status==3||item.status==1">通过</span>
                    <span v-else-if="item.status==-2">退回</span>
                </p>
                <p class="content">
                    <span v-if="item.status==2">部门意见：</span>
                    <span v-else-if="item.status==3">科研处意见：</span>
                    <span v-else-if="item.status==1">初审人意见：</span>
                    <span v-else-if="item.status==-2">退回意见：</span>
                    {{item.shenHeYiJian}}
                </p>

            </TimelineItem>
        </Timeline>


    </div>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    const moment = require('moment');
    const qs = require('qs');
    export default {
        data() {
            return {
                yijians: []
            }
        },
        props: ['id'],
        mounted() {
            this.getbmyijian();
        },
        computed: {},
        components: {

        },
        methods: {
            getbmyijian(status) {
                //GetShenHeYiJian

                axios.get('api/Cg_ShenHe/GetShenHeYiJians', {
                    params: {
                        id: this.id,
                    }
                })
                    .then(response => {
                        this.yijians = response.data.results;
                        //console.log(this.yijians);
                    }).catch(error => {
                        console.log(error);
                        this.tableLoading = false;
                    });
            },
            //转化时间
            gettime(time) {
                return moment(time).format('YYYY-MM-DD HH:mm:ss')
            },


        }
    };
</script>
<style scoped>
    .time {
        font-size: 14px;
        font-weight: bold;
    }

    .content {
        padding-left: 5px;
    }
</style>