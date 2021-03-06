<template>
  <div id="app">   
    <main>
      <fade-transition origin="center" mode="out-in" :duration="250">
        <router-view />
      </fade-transition>
      <div class="footer">
        <p>© Hayrat Yardım 2021</p>
      </div>
    </main>
  </div>
</template>
<script>
import { FadeTransition } from "vue2-transitions";
import BaseNav from "./components/argon/BaseNav";
export default {
  components: {
    FadeTransition,
    BaseNav,
  },
};
</script>

<style scoped>

.footer {
  position: fixed;
  left: 0;
  bottom: 0;
  width: 100%;
  background-color: mediumseagreen;
  color: white;
  text-align: center;
  padding: 0px 0px;
}
.footer p {
  margin-bottom: 0px;
}
th,
td {
  vertical-align: middle !important ;
}

@media only screen and (max-width: 700px) {
  .pl-5,
  .px-5 {
    padding-left: 0rem !important;
  }

  .pr-5,
  .px-5 {
    padding-right: 0rem !important;
  }
  .pl-4,
  .px-4 {
    padding-left: 0rem !important;
  }

  .pr-4,
  .px-4 {
    padding-right: 0rem !important;
  }

  .table th,
  .table td {
    padding: 0.5rem;
    vertical-align: middle !important;
  }
}
</style>