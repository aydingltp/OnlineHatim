<template>
  <div class="container shape-container align-items-center pl-5 pr-5">
    <div class="col px-0 pl-4 pr-4">
      <div class="row justify-content-center align-items-center">
        <div class="col-lg-7 text-center pt-lg">
          <h3 class="text">Hatme Katıl</h3>
        </div>
      </div>
      <div class="row justify-content-center align-items-center">
        <table class="table table-hover text-center">
          <thead>
            <tr>
              <th scope="col">Hatim İsmi</th>
              <th scope="col">Bitiş Tarihi</th>
            </tr>
          </thead>
          <tbody>
            <div v-if="loading">
              <content-placeholders>
                <content-placeholders-text :lines="30" />
              </content-placeholders>
            </div>

            <tr v-for="cuz in cuzler" :key="cuz.id">
              <td>
                <router-link :to="'/' + cuz.urlCode">
                  {{ cuz.name }}
                </router-link>
              </td>
              <td>{{ cuz.endDate | moment("DD / MM / YYYY") }}</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "HatimList",

  data() {
    return {
      cuzler: [],
      title: null,
      loading: true
    };
  },
  created() {
    axios.get("api/hatim/", {}).then((obj) => {
      this.cuzler = obj.data;
      console.log(obj.data);
      this.loading = false;
    });
  },
};
</script>