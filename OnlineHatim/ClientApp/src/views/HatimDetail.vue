<template>
  <div class="hatimdetail">
    hatim detail
    {{ title }}
    <div>
      <table class="table">
        <thead>
          <tr>
            <th scope="col">Cüz No:</th>
            <th scope="col">İsim</th>
            <th scope="col">Soyisim</th>
            <th scope="col">Durum</th>
          </tr>
        </thead>
        <tbody v-for="cuz in cuzler.hatimCuz" :key="cuz.id">
          <tr>
            <td>{{ cuz.cuzNo }}</td>
            <td>{{ cuz.user }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "HatimDetail",

  data() {
    return {
      cuzler: [],
      title: null,
    };
  },
  created() {
    axios.get("api/hatim/" + this.$route.params.id, {}).then((obj) => {
      this.cuzler = obj.data;
      console.log(obj.data);
    });
    this.title = this.$route.params.id;
    console.log(this.$route.params.id);
  },
};
</script>