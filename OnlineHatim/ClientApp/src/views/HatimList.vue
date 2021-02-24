<template>
  <div class="hatimlist">
    hatimlisttttt

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