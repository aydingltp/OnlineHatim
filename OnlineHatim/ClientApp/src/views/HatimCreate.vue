
<template>
  <div class="container shape-container align-items-center">
    <div class="col px-0">
      <div class="row justify-content-center align-items-center">
        <div class="col-lg-7 text-center pt-lg">
          <h3 class="text">Hatim Oluştur</h3>
        </div>
      </div>
    </div>
    <div class="row justify-content-center align-items-center">
      <div class="col-lg-4 col-sm-6">
        <small class="d-block text-uppercase font-weight-bold mb-3">HATİM İSMİ</small>
        <base-input
          placeholder="Hatim İsmi"
          v-model="hatim.name"
          :disabled="saveEnabled">
        </base-input>
      </div>
      <div class="col-lg-4 col-sm-6">
        <small class="d-block text-uppercase font-weight-bold mb-3"
          >BİTİŞ TARİHİ</small>
        <base-input
          v-model="hatim.endDate"
          addon-left-icon="ni ni-calendar-grid-58"
          :disabled="saveEnabled">
          <flat-picker
            slot-scope="{ focus, blur }"
            @on-open="focus"
            @on-close="blur"
            :config="{ allowInput: true }"
            class="form-control datepicker"
            v-model="hatim.endDate">
          </flat-picker>
        </base-input>
      </div>
    </div>
    <div class="row justify-content-center align-items-center">
      <base-checkbox
        class="mb-3"
        v-model="hatim.isPrivate"
        :disabled="saveEnabled">
        Gizli Hatim
      </base-checkbox>
    </div>
    <div
      class="row justify-content-center align-items-center"
      v-if="hatim.isPrivate">
      <p style="font-color: green">
        (Hatminiz hatim listesinde gözükmeyecektir.)
      </p>
    </div>

    <div class="row justify-content-center align-items-center pb-4">
      <base-button
        @click="post"
        :disabled="saveEnabled"
        class="btn-1"
        type="success">
        Kaydet</base-button>
    </div>
    <div class="row justify-content-center align-items-center" v-if="show">
      <base-alert type="success" icon="ni ni-like-2">
        <span slot="text"
          ><strong>Hatminiz başarıyla oluşturuldu! </strong>
        </span>
      </base-alert>
    </div>

    <div class="row justify-content-center align-items-center" v-if="show">
      Linkiniz :
      <a v-bind:href="'/' + hatim.urlCode">
        &nbsp; {{link + hatim.urlCode }}</a>
    </div>
  </div>
</template>

<script>
import flatPicker from "vue-flatpickr-component";
import "flatpickr/dist/flatpickr.css";
import axios from "axios";
export default {
  name: "HatimCreate",
  components: {
    flatPicker,
  },
  data() {
    return {
      show: false,
      hatim: {
        name: null,
        endDate: null,
        urlCode: null,
        isPrivate: false,
      },
      link: "hatim.dirayettv.net/",
    };
  },
  methods: {
    post() {
      axios.post("api/hatim", this.hatim).then((obj) => {
        if (obj.status === 200) {
          this.show = true;
          this.hatim = obj.data;
          console.log(obj.data);
        } else {
          console.log("hata oluştu.");
        }
      });
    },
  },
  computed: {
    saveEnabled() {
      if (this.show == false) {
        return false;
      } else {
        return true;
      }
    },
  },
};
</script>