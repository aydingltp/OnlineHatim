<template>
  <div class="hatimlist">
    hatimlisttttt
    <base-button outline type="default">Default</base-button>
    <base-button outline type="success">Success</base-button>
    <div class="container">
      <div class="row">
        <div class="col-md-6">
          <base-input placeholder="Success" :valid="true"></base-input>
        </div>
        <div class="col-md-6">
          <base-input placeholder="Error input" :valid="false"></base-input>
        </div>
      </div>
      <div class="row">
        <div>
          <base-checkbox class="mb-3" v-model="checkboxes.unchecked">
            Unchecked
          </base-checkbox>
          <base-checkbox class="mb-3" v-model="checkboxes.checked">
            Checked
          </base-checkbox>

          <base-checkbox
            class="mb-3"
            v-model="checkboxes.uncheckedDisabled"
            disabled
          >
            Unchecked
          </base-checkbox>
          <base-checkbox
            class="mb-3"
            v-model="checkboxes.checkedDisabled"
            disabled
          >
            Checked
          </base-checkbox>
        </div>
       
      </div>
    </div>

    <table>
      <tr>
        <th>Hatim İsmi</th>
        <th>Bitiş Tarihi</th>
        <th>Detaya git</th>
      </tr>
      <tr v-for="cuz in cuzler" :key="cuz.id">
        <td>{{ cuz.name }}</td>
        <td>{{ cuz.endDate }}</td>
        <td>{{ cuz.urlCode }}</td>
      </tr>
    </table>
    <div class="row">
          <base-alert type="warning">
            <span class="alert-inner--icon"><i class="ni ni-like-2"></i></span>
            <span class="alert-inner--text"
              ><strong>Warning!</strong> This is a warning alert—check it out
              that has an icon too!</span
            >
          </base-alert>
    </div>
    <div class="row">
        <div role="alert" class="alert alert-warning alert-dismissible">
            <span class="alert-inner--icon"><i class="ni ni-bell-55"></i></span>
            <span class="alert-inner--text">
                <span><strong>Warning!</strong> This is a warning alert—check it out!</span>
            </span>
            <button type="button" data-dismiss="alert" aria-label="Close" class="close"><span aria-hidden="true">×</span>
            </button>
            </div>
    </div>
     <section class="section section-components">
        <div class="container">
            <h3 class="h4 text-success font-weight-bold mb-4">Tabs</h3>
            <tabs-section></tabs-section>
            <progress-section></progress-section>
            <div class="row row-grid justify-content-between">
                <div class="col-lg-5">
                    <h3 class="h4 text-success font-weight-bold mb-5">Navigation Pills</h3>
                    <tabs :fill="false" circle>
                        <tab-pane>
                            <span slot="title" class="nav-link-icon d-block"><i class="ni ni-atom"></i></span>
                        </tab-pane>
                        <tab-pane>
                            <span slot="title" class="nav-link-icon d-block"><i class="ni ni-chat-round"></i></span>
                        </tab-pane>
                        <tab-pane>
                            <span slot="title" class="nav-link-icon d-block"><i
                                    class="ni ni-cloud-download-95"></i></span>
                        </tab-pane>
                    </tabs>
                </div>
                <div class="col-lg-5">
                    <h3 class="h4 text-success font-weight-bold mb-5">Labels</h3>
                    <badge type="primary" class="text-uppercase">Primary</badge>
                    <badge type="success" class="text-uppercase">Success</badge>
                    <badge type="danger" class="text-uppercase">Danger</badge>
                    <badge type="warning" class="text-uppercase">Warning</badge>
                    <badge type="info" class="text-uppercase">Info</badge>
                </div>
            </div>
            <h3 class="mt-lg mb-4">
                <span>Alerts</span>
            </h3>
            <base-alert type="success" icon="ni ni-like-2" dismissible>
                <span slot="text"><strong>Success!</strong> This is a success alert—check it out!</span>
            </base-alert>

            <base-alert type="info" icon="ni ni-bell-55" dismissible>
                <span slot="text"><strong>Info!</strong> This is an info alert—check it out!</span>
            </base-alert>

            <base-alert type="warning" icon="ni ni-bell-55" dismissible>
                <span slot="text"><strong>Warning!</strong> This is a warning alert—check it out!</span>
            </base-alert>

            <base-alert type="danger" icon="ni ni-support-16" dismissible>
                <span slot="text"><strong>Danger!</strong> This is an error alert—check it out!</span>
            </base-alert>

            <typography></typography>
            <!-- Images -->
            <h2 class="mt-lg mb-5">
                <span>Images</span>
            </h2>
            <images></images>
            <h2 class="mt-lg mb-5">
                <span>Javascript Components</span>
            </h2>
            <h3 class="h4 text-success font-weight-bold mb-4">Modals</h3>
            <!-- Modals -->
            <modals></modals>
             Datepicker
            <h3 class="h4 text-success font-weight-bold mt-md mb-4">Datepicker</h3>
            <date-pickers></date-pickers>
            <!-- Tooltips and Popovers -->
            <h3 class="h4 text-success font-weight-bold mt-md mb-4">Tooltips &amp; Popovers</h3>
            <tooltips></tooltips>
        </div>
    </section>
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