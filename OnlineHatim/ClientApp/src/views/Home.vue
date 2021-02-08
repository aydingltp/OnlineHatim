<template>
  <div>
    <h1>Online Hatim Uygulaması</h1>
    <div>
      <router-link to="/hatim-create">
        <base-button
          tag="a"
          href="/hatim-create"
          class="btn-1"
          outline
          type="success"
          >Hatim Oluştur
        </base-button>
      </router-link>
      <router-link to="/hatim-list">
        <base-button
          tag="a"
          href="/hatim-list"
          class="btn-1"
          outline
          type="primary"
          >Hatme Katıl
        </base-button>
      </router-link>
    </div>
  </div>
</template>
<script>
export default {
  name: "home",
  components: {
  },
};
</script>
