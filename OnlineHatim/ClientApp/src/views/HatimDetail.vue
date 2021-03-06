<template>
  <div class="container shape-container align-items-center pl-5 pr-5">
    <notifications group="foo" />
    <div class="col px-0 pl-4 pr-4">
      <div class="row justify-content-center align-items-center">
        <div class="col-lg-7 text-center pt-lg">
          <h3 class="text">{{ title }}</h3>
        </div>
      </div>
      <div class="row justify-content-center align-items-center">
        <table class="table table-hover">
          <thead>
            <tr>
              <th scope="col">Cüz No:</th>
              <th scope="col">İsim Soyisim</th>
              <th scope="col">Durum</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(cuz, id) in cuzler" :key="id">
              <td>
                 {{ cuz.cuzNo }}. Cüz
              </td>

              <td v-if="cuz.fullName">
                <input
                  aria-describedby="addon-right addon-left"
                  v-bind:placeholder="cuz.fullName"
                  disabled="disabled"
                  class="form-control"
                />
              </td>
              <td v-else>
                <input
                  v-model="fullNames[id]"
                  aria-describedby="addon-right addon-left"
                  placeholder="İsim Soyisim"
                  class="form-control is-valid"
                />
              </td>

              <td v-if="cuz.fullName">
                <span class="badge text-uppercase badge-danger"
                  >Cüz Alındı</span
                >
              </td>

              <td v-else>
                <button
                  @click.prevent="submit(id, fullNames[id])"
                  class="btn btn-success btn-sm mt-2"
                >
                  Kaydet
                </button>
              </td>
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
  name: "HatimDetail",

  data() {
    return {
      cuzler: [],
      hatimName: null,
      endDate: null,
      urlCode: null,
      title: null,
      fullNames: [],
    };
  },
  methods: {
    async submit(id, fullName) {
      await axios
        .post(
          "api/hatim/takecuz/" + this.title + "/" + id + "?fullName=" + fullName
        )
        .then((obj) => {
          if (obj.status === 200) {
            this.show = true;
            this.cuzler = obj.data.hatimCuz;
            console.log("cuzler : " + obj.data.hatimCuz);
            this.hatim = obj.data;
            this.$notify({
              group: "foo",
              title: "Cüz Alındı.",
              text: "Allah kabul etsin.",
              type: "success"
            });
          } else {
            console.log("hata oluştu.");
          }
        });
    },
  },
  async created() {
    await axios.get("api/hatim/" + this.$route.params.id, {}).then((obj) => {
      this.cuzler = obj.data.hatimCuz;
      this.hatimName = obj.data.name;
      this.urlCode = obj.data.urlCode;
    });
    this.title = this.$route.params.id;
  },
};
</script>