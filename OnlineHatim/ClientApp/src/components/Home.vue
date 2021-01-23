<template>
    <div class="home">
        <img src="../assets/logo.png" />
        <div>
            <router-link to="/hatim-create">Hatim Olustur</router-link>
            <router-link to="/hatim-list">Hatme Katil</router-link>
        </div>
    </div>

</template>

<script>
    export default {
        name: 'Home',

    }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>