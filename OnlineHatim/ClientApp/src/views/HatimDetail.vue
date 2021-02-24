<template>
  <div class="hatimdetail">
    hatim detail
    {{ title }}
    <div class="container">
      <table class="table">
        <thead>
          <tr>
            <th scope="col">Cüz No:</th>
            <th scope="col">İsim</th>
            <th scope="col">Soyisim</th>
            <th scope="col">Durum</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="cuz in cuzler" :key="cuz.id">
            <td>{{ cuz.cuzNo }}. Cüz</td>
            <td v-if="cuz.userId">
              <input aria-describedby="addon-right addon-left" v-bind:placeholder= 'cuz.user.name' disabled="disabled" class="form-control">
              </td>
            <td v-else>
              <input aria-describedby="addon-right addon-left" placeholder="İsim" class="form-control is-valid">
            </td>
            <td v-if="cuz.userId">
              <input aria-describedby="addon-right addon-left" v-bind:placeholder=  'cuz.user.surname' disabled="disabled" class="form-control">
          
            </td>
            <td v-else>
              <input aria-describedby="addon-right addon-left" placeholder="Soyisim" class="form-control is-valid">
            </td>
            <td v-if="cuz.userId">Alınmış</td>
            <td v-else><button type="submit" class="btn btn-success">Save</button></td>
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
      hatimName: null,
      endDate: null,
      urlCode: null,
      title: null,
    };
  },
  created() {
    axios.get("api/hatim/" + this.$route.params.id, {}).then((obj) => {
      this.cuzler = obj.data.hatimCuz;
      //this.cuzler.user = obj.data.hatimCuz.User;
      this.hatimName = obj.data.name;
      this.urlCode = obj.data.urlCode;

      console.log(obj.data);
    });
    this.title = this.$route.params.id;
    console.log(this.$route.params.id);
  },
};
</script>