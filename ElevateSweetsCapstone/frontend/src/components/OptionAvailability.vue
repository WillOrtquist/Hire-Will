<template>
  <div id='optionavailability'>

    <div class="stylegroup">
      <h2>Cake Styles</h2>
      <div v-for="option in options.styles" :key="option.id">
        <button v-if="option.isAvailable" v-on:click.prevent="UpdateStyleAvailability(option.id, !option.isAvailable)" class="btn btn-success btn-block">{{option.style}}</button>
        <button v-if="!option.isAvailable" v-on:click.prevent="UpdateStyleAvailability(option.id, !option.isAvailable)" class="btn btn-danger btn-block">{{option.style}}</button>
      </div>
    </div>

    <!-- <div class="stylegroup">
      <h2>Cake Sizes</h2>
      <div v-for="option in options.sizes" :key="option.id">
        <button v-if="option.isAvailable" v-on:click.prevent="UpdateSizeAvailability(option.id, !option.isAvailable)" class="btn btn-success btn-block">{{option.size}}</button>
        <button v-if="!option.isAvailable" v-on:click.prevent="UpdateSizeAvailability(option.id, !option.isAvailable)" class="btn btn-danger btn-block">{{option.size}}</button>
      </div>
    </div> -->

    <div class="stylegroup">
      <h2>Add/Remove Size For Style</h2>
      <label for="style">Select the Style to Add/Remove Sizes:</label>
      <select class="form-control" v-model="selectedStyleId" @change="getSizesListFiltered(selectedStyleId)">
        <option v-for="option in options.styles" :value="option.id" :key="option.id">{{ option.style }} </option>
      </select>
      <div v-for="option in options.sizesByStyle" :value="option.id" :key="option.id">
        <button v-if="option.styleId==selectedStyleId" v-on:click.prevent="RemoveSizeFromStyle(selectedStyleId, option.id)" class="btn btn-success btn-block">{{option.size}}</button>
        <button v-if="option.styleId!=selectedStyleId" v-on:click.prevent="AddSizeToStyle(selectedStyleId, option.id)" class="btn btn-danger btn-block">{{option.size}}</button>
      </div>
    </div>

    <div class="stylegroup">
      <h2>Cake Flavors</h2>
      <div v-for="option in options.flavors" :key="option.id">
        <button v-if="option.isAvailable" v-on:click.prevent="UpdateFlavorAvailability(option.id, !option.isAvailable)" class="btn btn-success btn-block">{{option.flavor}}</button>
        <button v-if="!option.isAvailable" v-on:click.prevent="UpdateFlavorAvailability(option.id, !option.isAvailable)" class="btn btn-danger btn-block">{{option.flavor}}</button>
      </div>
    </div>

    <div class="stylegroup">
      <h2>Cake Frostings</h2>
      <div v-for="option in options.frostings" :key="option.id">
        <button v-if="option.isAvailable" v-on:click.prevent="UpdateFrostingAvailability(option.id, !option.isAvailable)" class="btn btn-success btn-block">{{option.frosting}}</button>
        <button v-if="!option.isAvailable" v-on:click.prevent="UpdateFrostingAvailability(option.id, !option.isAvailable)" class="btn btn-danger btn-block">{{option.frosting}}</button>
      </div>
    </div>

    <div class="stylegroup">
      <h2>Cake Fillings</h2>
      <div v-for="option in options.fillings" :key="option.id">
        <button v-if="option.isAvailable" v-on:click.prevent="UpdateFillingAvailability(option.id, !option.isAvailable)" class="btn btn-success btn-block">{{option.filling}}</button>
        <button v-if="!option.isAvailable" v-on:click.prevent="UpdateFillingAvailability(option.id, !option.isAvailable)" class="btn btn-danger btn-block">{{option.filling}}</button>
      </div>
    </div>

  </div>
</template>

<script>
export default {
  name: 'option-availability',
  data() {
    
    return {
      options: {
        styles: [],
        sizes: [],
        flavors: [],
        frostings: [],
        fillings: [],
        sizesByStyle: []
      },
      selectedStyleId: 1,
      updateCakeError: false
    }
  },
  methods: {
    UpdateStyleAvailability(id, isAvailable) {
      let optionNew = {
        id: id,
        isAvailable: isAvailable
      }
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/updateStyle`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(optionNew),
      })
        .then((response) => {
          if (response.ok) {
            this.getStylesList();
          } else {
            this.updateCakeErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
    UpdateSizeAvailability(id, isAvailable) {
      let optionNew = {
        id: id,
        isAvailable: isAvailable
      }
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/updateSize`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(optionNew),
      })
        .then((response) => {
          if (response.ok) {
            this.getSizesList();
            this.selectedStyleId = 0;
          } else {
            this.updateCakeErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
    UpdateFlavorAvailability(id, isAvailable) {
      let optionNew = {
        id: id,
        isAvailable: isAvailable
      }
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/updateFlavor`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(optionNew),
      })
        .then((response) => {
          if (response.ok) {
            this.getFlavorsList();
          } else {
            this.updateCakeErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
    UpdateFrostingAvailability(id, isAvailable) {
      let optionNew = {
        id: id,
        isAvailable: isAvailable
      }
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/updateFrosting`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(optionNew),
      })
        .then((response) => {
          if (response.ok) {
            this.getFrostingsList();
          } else {
            this.updateCakeErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
    UpdateFillingAvailability(id, isAvailable) {
      let optionNew = {
        id: id,
        isAvailable: isAvailable
      }
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/updateFilling`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(optionNew),
      })
        .then((response) => {
          if (response.ok) {
            this.getFillingsList();
          } else {
            this.updateCakeErrors = true;
          }
        })

        .then((err) => console.error(err));
    },

  RemoveSizeFromStyle(styleId, sizeId) {
      let sizeRemove = {
        id: styleId,
        sizeId: sizeId
      }
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/sizeRemove`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(sizeRemove),
      })
        .then((response) => {
          if (response.ok) {
            this.getSizesListFiltered(styleId);
            this.selectedStyleId = styleId;
          } else {
            this.updateCakeErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
    AddSizeToStyle(styleId, sizeId) {
      let sizeAdd = {
        id: styleId,
        sizeId: sizeId
      }
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/sizeAdd`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(sizeAdd),
      })
        .then((response) => {

          if (response.ok) {
            this.getSizesListFiltered(styleId);
            this.selectedStyleId = styleId;
          } else {
            this.updateCakeErrors = true;
          }
        })

        .then((err) => console.error(err));
    },

    getFrostingsList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllFrostings`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.options.frostings = data;
      })
      .catch((err) => console.error(err));
    },
    getFillingsList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllFillings`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.options.fillings = data;
      })
      .catch((err) => console.error(err));
    },
    getFlavorsList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllFlavors`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.options.flavors = data;
      })
      .catch((err) => console.error(err));
    },
    getStylesList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllStyles`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.options.styles = data;
      })
      .catch((err) => console.error(err));
    },
    getSizesList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllSizes`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.options.sizes = data;
      })
      .catch((err) => console.error(err));
    },
    getSizesListFiltered(id) {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllSizesF/${id}`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.options.sizesByStyle = data;
      })
      .catch((err) => console.error(err));
    },
  },
  created() {
    this.getFrostingsList();
    this.getFillingsList();
    this.getFlavorsList();
    this.getSizesList();
    this.getStylesList();
    this.getSizesListFiltered(1);
  },
}
</script>

<style>
  #optionavailability {
    margin-left: 10%;
    margin-right: 10%;
    margin-top: 30px;
  }
  .stylegroup {
  margin-bottom: 15px;
  padding: 15px;
  padding-right: 35px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
 }
 .stylegroup div {
   width: 49%;
 } 
 .stylegroup h2 {
   width: 100%;
 }
</style>