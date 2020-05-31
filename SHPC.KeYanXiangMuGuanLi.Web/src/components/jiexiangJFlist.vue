<template>
    <div style="padding:10px">

        <i-table ref="selection"
                 :columns="columns"
                 size="small"
                 :data="jiexiangjflist"
                 border="true"
                 :loading="tableLoading"
                 @on-selection-change="getjiexianglist"></i-table>

    </div>
</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    const qs = require('qs');
    export default {
        data() {
            return {
                tableLoading: false,
                jiexiangjflist: [],
                columns: [
                    {
                        title: '经费名称',
                        key: 'jingFeiMingCheng',
                    },
                    {
                        title: '金额',
                        key: 'jinE',
                    },
                    {
                        title: '开支说明',
                        key: 'kaiZhiShuoMing',
                    }, 
                    
                ],
            }
        },
        props: ['jxid'],
        mounted() {
            if (this.jxid != null) {
                this.getjiexianglist();
            }
            
        },
        computed: {},
        components: {
            
        },
        methods: {
            getjiexianglist() {
                //GetJieXiangjfs
                this.tableLoading = true;
                axios.get('api/JieXiang/GetJieXiangjfs', {
                    params: {
                        id: this.jxid
                    }
                })
                    .then(response => {
                        this.jiexiangjflist = response.data.results
                        //this.totalRows = response.data.totalRows
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