<template>
<div id="cakeavailability">

  <div v-for="cake in cakes" :key="cake.name" class="toggleselectbox">
    <img class="availabilityimg" v-bind:src="require('../../src/assets/' + cake.imageName)" /> 
    <div>
      <h5>{{cake.name}}</h5>
      <button v-if="cake.isAvailable" v-on:click.prevent="UpdateCakeAvailability(cake.id, !cake.isAvailable)" class="btn btn-success btn-lg btn-block">Available - click to disable</button>
      <button v-if="!cake.isAvailable" v-on:click.prevent="UpdateCakeAvailability(cake.id, !cake.isAvailable)" class="btn btn-danger btn-lg btn-block">Unavailable - click to enable</button>
    </div>
  </div>

</div>
</template>

<script>
export default {
  name: 'cake-availability',
  data() {
    return {
      cakes: [],
      updateCakeErrors: false,
    };
    
  },
  methods: {
    getCakeList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_CAKE}/getAll`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.cakes = data;
      })
      .catch((err) => console.error(err));
    },
  
 
    UpdateCakeAvailability(id, isAvailable) {
      let cakeNew = {
        id: id,
        isAvailable: isAvailable
      }
      fetch(`${process.env.VUE_APP_REMOTE_API_CAKE}/updateAvailable`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(cakeNew),
      })
        .then((response) => {
          if (response.ok) {
            this.getCakeList();
          } else {
            this.updateCakeErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
  },
  created() {
    this.getCakeList();
  },
  
}
</script>

<style>
#cakeavailability {
  margin-left: 5%;
  margin-right: 5%;
  margin-top: 30px;
  margin-bottom: 30px;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
}
.toggleselectbox {
  margin: 5px;
  height: 150px;
  width: 49%;
  display: flex;
  padding: 15px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
}
.availabilityimg {
  height: 100%;
}
.toggleselectbox div {
  margin: 15px;
  width: 100%;
  text-align: center;
}
.toggleselectbox div button {
  margin-top: 20px;
}
@media (max-width:1150px) {
  .toggleselectbox {
    width: 100%;
  }
}
</style>