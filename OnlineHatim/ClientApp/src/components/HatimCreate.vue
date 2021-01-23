using System.Reflection.Metadata;<template>
  <div class="hatim-create">
    Hatim Oluştur
   
      <input v-model="hatim.name" placeholder="Hatim İsmi" />
      <input type="date" v-model="hatim.enddate" placeholder="Bitiş Tarihi" />
      <input @click="post" type="submit" value="Kaydet" />

    <pre>{{ sendNewPostResult }}</pre>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "HatimCreate",
  data() {
    return {
      hatim: {
        name: null,
        enddate: null,
      },
       sendNewPostResult: null
    };
  },
  methods: {
    post() {
      axios.post("api/hatim", this.hatim).then(obj => {
          this.sendNewPostResult = obj.data;
          console.log(obj.data);
          
      })
    },
  },
};
</script>