<template>
<div class="hatimlist">
hatimlisttttt
    <table>
        <tr>
            <th>Hatim İsmi</th>
            <th>Bitiş Tarihi</th>
            <th>Detaya git</th>
        </tr>
        <tr v-for="cuz in cuzler" :key="cuz.id">
            <td>{{cuz.name}}</td>
            <td>{{cuz.endDate}}</td>
            <td>{{cuz.urlCode}}</td>
        </tr>
    </table>
</div>
</template>

<script>
    import axios from "axios";

    export default {
        name: 'HatimList',

        data() {
            return {
                cuzler: [],
                title: null

            };
        },
        created() {
            axios.get("api/hatim/", {}).then(obj => {
                this.cuzler = obj.data;
                console.log(obj.data);
            });
        }
    }
</script>