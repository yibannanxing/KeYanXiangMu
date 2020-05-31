<template>
    <div style="padding:10px">

        <i-button @click="modalzuyuan=true"  type="primary">新增组员</i-button>
        <i-table ref="selection" :columns="columns" size="small" :data="xiangmuzuyuans" border="true" :loading="tableLoading" ></i-table>
        <!--<Table :columns="columns" :data="data1"></Table>-->

        <Modal title="添加组员"
               v-model="modalzuyuan"
               width="40%"
               :footer-hide="true"
               :styles="{top: '0'}"
               :mask-closable="false"
               :scrollable='false'
               :transfer="false"
               class-name="vertical-center-modal">
            <div :style="{height:matchHeight+'px','overflow-y':'auto',padding:0}">
                <studentxiangmuzuyuan v-if="modalzuyuan" @close="close" :xiangmuId="xiangmuId" v-model="studentxiangmuzuyuan"></studentxiangmuzuyuan>
            </div>
        </Modal>

    </div>

   

</template>
<script>
    import Vue from "vue";
    import axios from 'axios';
    import { mapState } from 'vuex';
    import studentxiangmuzuyuan from '../components/studentxiangmuzuyuan.vue';
    const qs = require('qs');
    export default {
        data() {
            return {
                modalzuyuan: false,
                matchHeight: window.innerHeight * 0.8,
                tableLoading: false,
                columns: [
                    {
                        
                        title: '姓名',
                        key: 'xiangMuZuChengYuanXingMing'
                        
                    },
                    {
                        
                        title: '性别',
                        key: 'xingBie'
                    },
                    {
                        
                        title: '出生年月',
                        key: 'chuShengNianYue'
                    },
                    {
                        
                        title: '研究专长',
                        key: 'yanJiuZhuanChang'
                    },
                    {
                        
                        title: '学历',
                        key: 'xueLi'
                    },
                    {
                        
                        title: '所属部门',
                        key: 'suoSuBuMenMingCheng'
                    },
                    //{
                        
                    //    title: '联系电话',
                    //    key: 'lianXiDianHua'
                    //},
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
                                            this.currentId = params.row.id
                                            this.type = 0
                                            this.modalshow = true

                                        }
                                    }
                                }, '编辑'),
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
            }
        },
        model: {
            prop: 'xiangmuzuyuans',
            event:'changeModel'
        },
        props: ['xiangmuzuyuans','xiangmuId'],
        watch: {
            xiangmuzuyuans: {
                deep: true,
                handler(val, oldVal) {
                    console.log(val)
                    this.$emit('changeModel', this.xiangmuzuyuans);
                }
            }
        },
        mounted() {
            
        },
        computed: {},
        components: {
            studentxiangmuzuyuan
        },
        methods: {
            close(zy) {
                this.modalzuyuan = false;
                this.xiangmuzuyuans.push(zy)
            },
            //删除
            deleteItem(id) {

                this.$Modal.confirm({
                    title: "删除",
                    content: "您确定要删除嘛",
                    onOk: () => {
                        if (this.xiangmuzuyuans.splice(id, 1)) {
                            this.$Notice.success({
                                title: '操作成功',
                            });
                        } else {
                            this.$Notice.error({
                                    title: '系统错误',
                                    desc: response.data.error.displayInfo
                                });
                        }

                    },
                })
            },
        }
    };
</script>
<style>
    
</style>