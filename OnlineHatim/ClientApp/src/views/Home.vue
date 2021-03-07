<template>
  <div class="container shape-container align-items-center">
    <div class="col px-0 pt-5">
      <div class="row justify-content-center align-items-center">
        <div class="col-lg-7 text-center pt-lg">
            <h1 class="pb-4">Online Hatim Uygulaması</h1>
            <div class="row">
              <div class="col pb-3">
                 <router-link to="/hatim-create">
                <base-button
                  tag="a"
                  href="/hatim-create"
                  class="btn-1 mr-5"
                  outline
                  type="success"
                  >Hatim Oluştur
                </base-button>
              </router-link>
              </div>
              <div class="col">
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
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: "home",
  components: {},
};
</script>
