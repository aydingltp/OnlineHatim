<template>
  <div class="container shape-container align-items-center">
    <div class="col px-0">
      <div class="row justify-content-center align-items-center">
        <div class="col-lg-7 text-center pt-lg">
          <h3 class="text">Hatim Oluştur</h3>
        </div>
      </div>
      <div class="row justify-content-center align-items-center">
         <table>
      <tr>
        <th>Hatim İsmi</th>
        <th>Bitiş Tarihi</th>
      </tr>
      <tr v-for="cuz in cuzler" :key="cuz.id">
        <td><a v-bind:href="'/'+ cuz.urlCode"> {{ cuz.name }}</a></td>
        <td>{{ cuz.endDate }}</td>
      </tr>
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
      checkboxes: {
        unchecked: false,
        checked: true,
        uncheckedDisabled: false,
        checkedDisabled: true,
      },
    };
  },
  created() {
    axios.get("api/hatim/", {}).then((obj) => {
      this.cuzler = obj.data;
      console.log(obj.data);
    });
  },
};
</script>