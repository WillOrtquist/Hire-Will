<template>
<div id="standardcakescontainer">
  <div v-for="cake in availableCakes" :key="cake.name" class="cakeinfo">
    <h3>{{cake.name}}</h3>

    <div class="cakeimg">
      <img v-bind:src="require('../../src/assets/' + cake.imageName)" /> 
      <div class="price">${{cake.price}}</div>
    </div>
    <p>{{cake.description}}</p>

    <div class="cakedetails">
      <ul>
        <li><b>Style:</b> {{cake.style}}</li>
        <li><b>Size:</b> {{cake.size}}</li>
        <li><b>Flavor:</b> {{cake.flavor}}</li>
        <li><b>Frosting:</b> {{cake.frosting}}</li>
        <li><b>Filling:</b> {{cake.filling}}</li>
      </ul>
      <router-link v-bind:to="{name: 'order-cake',params: {id:cake.id}}" class="btn btn-info" role="button">Purchase Cake</router-link>
    </div>
  </div>
</div>
</template>

<script>

export default {
  name: "standard-cakes",
  data() {
    return {
      cakes: [],
    }
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
  },
  created() {
    this.getCakeList();
  },
  computed: {
    availableCakes() {
      return this.cakes.filter(function(u) {
        return u.isAvailable
      })
    }
  }
}
</script>

<style>
.cakeinfo {
  margin-top: 30px;
  padding: 15px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
  width: 49%;
}
#standardcakescontainer {
  margin-left: 14%;
  margin-right: 14%;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
}
.cakeimg > img {
  width: 100%;
  border-radius: 5px;
  margin-bottom: 10px;
}
#standardcakescontainer li {
  list-style: none;
}
#standardcakescontainer h3 {
  text-align: center;
}
.cakeimg {
  position: relative;
}
.price {
  position: absolute;
  top: 8px;
  right: 10px;
  background-color: hsla(188, 56%, 8%, 0.7);
  padding: 5px;
  border-radius: 5px;
}
#standardcakescontainer .newcakebtn {
  margin: 20px;
  border: 2px solid black;
  box-shadow: 1px 2px 20px rgba(0,0,0,.6);
}
.cakedetails {
  display: flex;
  justify-content: space-between;
  align-items: flex-end;
  flex-wrap: wrap;
}
.cakedetails .btn {
  height: 40px;
}
@media (max-width:900px) {
  .cakeinfo {
    width: 100%;
  }
}
@media (max-width:1300px) {
  #standardcakescontainer {
    margin-left: 7%;
    margin-right: 7%;
  }
}
</style>