using System.Reflection.Metadata;<template>
  <div class="hatim-create">
    Hatim Oluştur
    <div class="row">
      <div class="col-lg-4 col-sm-6">
        <small class="d-block text-uppercase font-weight-bold mb-3"
          >HATİM İSMİ</small
        >
        <base-input placeholder="Hatim İsmi" v-model="hatim.name"> </base-input>
      </div>
      <div class="col-lg-4 col-sm-6">
        <small class="d-block text-uppercase font-weight-bold mb-3"
          >BİTİŞ TARİHİ</small
        >
        <base-input v-model="hatim.enddate" addon-left-icon="ni ni-calendar-grid-58">
          <flat-picker
            slot-scope="{ focus, blur }"
            @on-open="focus"
            @on-close="blur"
            :config="{ allowInput: true }"
            class="form-control datepicker"
            v-model="hatim.enddate"
          >
          </flat-picker>
        </base-input>
      </div>
    </div>
    <base-button @click="post" class="btn-1" type="success">Kaydet</base-button>
    <div class="row" v-if="show">
       Hatminiz başarıyla oluşturuldu. <br>
       Linkiniz : {{ this.link }}
    </div>
    <div class="row">
       Linki Kopyala  <button class="btn-1" @click="CopyUrl"></button>
    </div>
    <pre>{{ hatim }}</pre>
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
        enddate: null,
        urlCode: null,
      },
      link: "hatim.dirayettv.net/",
    };
  },
  methods: {
    post() {
      axios.post("api/hatim", this.hatim).then((obj) => {
        if (obj.status == 200) {
          this.show = true;
          this.hatim = obj.data;
          console.log(obj.data);
        }
        else{
           console.log("hata oluştu.")
        }
      });
    },
    CopyUrl(){
      var Url =  this.link; /*document.getElementById('myid'); /*GET vuejs el reference here (via $ref) but how?*/
      Url = window.location.href;
      console.log(Url)
      Url.select();
      document.execCommand("copy");
    }
  },
};
</script>