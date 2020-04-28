<template>
<div>
  
<div id="addoptioncontainer">
  
  <div id="addoptionform">
  <form @submit.prevent="addFrosting">
  <div class="form-group">
      <label for="frosting">Add New Frosting Name:</label>
      <input v-model="frosting.frosting" type="text" class="form-control" required />
    </div>
    <div class="form-group">
      <label for="available">Set new frosting to available:</label>
      <input type="checkbox" v-model="frosting.isAvailable"
      class="form-control checkbox" 
      />
      <div id="btnctr">
      <button class="btn btn-lg btn-info btn-center btn-block" type="submit" >Submit</button>
      </div>
    </div>
    
    
    
  </form>
  </div>
  <div id="addoptionform">
  <form @submit.prevent="addFilling">
  <div class="form-group">
      <label for="filling">Add New Filling Name:</label>
      <input v-model="filling.filling" type="text" class="form-control" required />
    </div>
    <div class="form-group">
      <label for="available">Set new filling to available:</label>
      <input type="checkbox" v-model="filling.isAvailable"
      class="form-control checkbox"
      />
    </div>
    <div id="btnctr">
    <button class="btn btn-lg btn-info btn-block" type="submit" >Submit</button>
    </div>
  </form>
  </div>
  <div id="addoptionform">
  <form @submit.prevent="addFlavor">
  <div class="form-group">
      <label for="flavor">Add New Flavor Name:</label>
      <input v-model="flavor.flavor" type="text" class="form-control" required />
    </div>
    <div class="form-group">
      <label for="available">Set new flavor to available:</label>
      <input type="checkbox" v-model="flavor.isAvailable"
      class="form-control checkbox"
      />
    </div>
    <div id="btnctr">
    <button class="btn btn-lg btn-info btn-block" type="submit" >Submit</button>
    </div>
  </form>
  </div>
  <div id="addoptionform">
  <form @submit.prevent="addStyle">
  <div class="form-group">
      <label for="style">Add New Cake Style Name:</label>
      <input v-model="style.style" type="text" class="form-control" required />
    </div>
    <label for="currentStyle">Choose a Default Cake Size for this Style:</label>
    <select class="form-control" v-model="style.sizeId" required>
        <option v-for="size in cake.sizes" :key="size.id" :value="size.id">{{ size.size }}</option>
      </select>
    <div class="form-group">
      <label for="available">Set new style to available:</label>
      <input type="checkbox" v-model="style.isAvailable"
      class="form-control checkbox"
      />
    </div>
    <div id="btnctr">
      <button class="btn btn-lg btn-info btn-block" type="submit" >Submit</button>
      </div>
  </form>
  </div>
  <div id="addoptionform">
  <form @submit.prevent="addSize">
    <div class="form-group">
      <label for="currentStyle">Choose a Cake Style for this Size:</label>
      <select class="form-control" v-model="size.styleId" required>
        <option v-for="style in cake.styles" :key="style.id" :value="style.id">{{ style.style }}</option>
      </select>
    </div>
  <div class="form-group">
      <label for="size">Add New Cake Size Name:</label>
      <input v-model="size.size" type="text" class="form-control" required />
    </div>
    <div class="form-group">
      <label for="size.basePrice">Base Price for New Size:</label>
      <input v-model="size.basePrice" type="text" class="form-control" required />
    </div>
    
    <div class="form-group">
      <label for="available">Set new size to available:</label>
      <input type="checkbox" v-model="size.isAvailable"
      class="form-control checkbox"
      />
    </div>
<div id="btnctr">
    <button class="btn btn-lg btn-info btn-block" type="submit" >Submit</button>
    </div>
  </form>
  </div> 
  </div>
  </div>
</template>

<script>
export default {
    name: 'add-option',
    data() {
    return {
      cake: {
        styles: [],
        sizes: []
      },

      frosting: {
          frosting: '',
          isAvailable: true
        },
      filling: {
          filling: '',
          isAvailable: true

        },
        flavor: {
          flavor: '',
          isAvailable: true
        },
        style: {
          style: '',
          isAvailable: true,
          price: 0,
          sizeId: 0
        },
        size: {
          size: '',
          isAvailable: true,
          basePrice: '',
          styleId: 0
        },

      updateFillingOptionErrors: false,
      updateFrostingOptionErrors: false,
      updateFlavorOptionErrors: false,
      updateSizeOptionErrors: false,
      updateStyleOptionErrors: false,
    };
    
  },
methods: {
  getStylesList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllStyles`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.cake.styles = data;
      })
      .catch((err) => console.error(err));
    },
     getSizesList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllSizes`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.cake.sizes = data;
      })
      .catch((err) => console.error(err));
    },
  addFrosting() 
    {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/newFrosting`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.frosting),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/ordercustomcake/' });
          } else {
            this.updateFrostingOptionErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
  addFilling() 
    {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/newFilling`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.filling),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/ordercustomcake/' });
          } else {
            this.updateFlavorOptionErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
  addFlavor() 
    {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/newFlavor`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.flavor),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/ordercustomcake/' });
          } else {
            this.updateFillingOptionErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
  addStyle() 
    {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/newStyle`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.style),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/ordercustomcake/' });
          } else {
            this.updateStyleOptionErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
    addSize() 
    {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/newSize`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.size),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/ordercustomcake/' });
          } else {
            this.updateSizeOptionErrors = true;
          }
        })

        .then((err) => console.error(err));
    }
},

  created() {
    this.getStylesList();
    this.getSizesList();
  }
}
</script>



<style>
#addoptioncontainer {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  font-weight: bold;
  margin-top: 30px;
  margin-left: 5%;
  margin-right: 5%;
}
#addoptionform{
  margin-bottom: 30px;
  padding: 15px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
  width: 48%
}
#addoptionform .form-group {
  
}

#addoptionform .checkbox {
  width: 35px;
}
#btnctr {
  padding-right: 25px;
  width: 100%;
}


</style>