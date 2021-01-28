<template>
    <div class="hatimdetail">
        hatim detail
        {{title}}

    </div>
</template>

<script>
    import axios from 'axios'
    export default {
        name: 'HatimDetail',

        data() {
            return {
                cuzler: [],
                title: null

            }
        },
        created() {
            axios.get("api/hatim/"+this.$route.params.id, {}).then(obj => {
                this.cuzler = obj.data;
                console.log(obj.data);
            });
            this.title = this.$route.params.id;
            console.log(this.$route.params.id);
        },
        mounted(){
            axios.get("api/hatim/"+this.$route.params.id, {}).then(obj => {
                this.cuzler = obj.data;
                console.log(obj.data);
            });
            this.title = this.$route.params.id;
            console.log(this.$route.params.id);

        }

    }
</script>