<template>
<div id="cakeform">
  <div class="alert alert-danger" role="alert" v-if="createCakeErrors">
        There were problems creating this cake.
      </div>
  <form class="form-register" @submit.prevent="createCake">
  <div id="createcakecontainer">
    <div class="form-group">
      <label for="name">Name:</label>
      <input v-model="cake.name"
      type="text"
      class="form-control"
      required
      />
    </div>
    <div class="form-group">
      <label for="price">Price:</label>
      <input v-model="cake.price"
      type="text"
      class="form-control"
      required
      />
    </div>
    <div class="form-group">
      <label for="style">Style:</label>
      <input v-model="cake.style"
      type="text"
      class="form-control"
      required
      />
    </div>
    <div class="form-group">
      <label for="size">Size:</label>
      <input v-model="cake.size"
      type="text"
      class="form-control"
      required
      />
    </div>
    <div class="form-group">
      <label for="flavor">Flavor:</label>
      <input v-model="cake.flavor"
      type="text"
      class="form-control"
      required
      />
    </div>
    <div class="form-group">
      <label for="icing">Frosting:</label>
      <input v-model="cake.frosting"
      type="text"
      class="form-control"
      required
      />
    </div>
    <div class="form-group">
      <label for="filling">Filling:</label>
      <input v-model="cake.filling"
      type="text"
      class="form-control"
      required
      />
    </div>
    <div class="form-group">
      <label for="description">Description:</label>
      <input v-model="cake.description"
      type="text"
      class="form-control"
      required
      />
    </div>
    <div class="form-group">
      <label for="imageName">Image File Name, if loaded (otherwise leave placeholder file)</label>
      <input v-model="cake.imageName"
      type="text"
      class="form-control"
      />
    </div>
    <div class="form-group">
      <label for="imageName">Cake is available for sale:</label>
      <input type="checkbox" v-model="cake.isAvailable"
      class="form-control checkbox"
      />
    </div>
  </div>
  
  <button class="btn btn-lg btn-info btn-block" type="submit" >
      Create Cake
    </button>
  </form>
</div>

</template>

<script>
export default {
  name: 'create-cake',
  data() {
    return {
      cake: {
        name: '',
        price: '',
        style: '',
        size: '',
        flavor: '',
        frosting: '',
        filling: '',
        description: '',
        imageName: 'placeholder-image.png',
        isAvailable: true
      },
      createCakeErrors: false,
    };
  },
  methods: {
    createCake() {
      fetch(`${process.env.VUE_APP_REMOTE_API_CAKE}/newCake`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.cake),
      })
        .then((response) => {
          if (response.ok) {
            this.$router.push({ path: '/standardcakes/' });
          } else {
            this.createCakeErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
  },

}
</script>

<style>
#cakeform{
  margin-top: 30px;
  margin-left: 10%;
  margin-right: 10%;
  padding: 15px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
}
#cakeform .form-group {
  width: 49%;
}
#createcakecontainer {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  font-weight: bold;
}
#cakeform .checkbox {
  width: 35px;
}
</style>