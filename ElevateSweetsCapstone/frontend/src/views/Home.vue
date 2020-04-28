<template>
<div id="homepage">
  <div id="homeinfo">
    <div class="hometext">
      <p>Elevate Sweets provides delicious artisan cakes and treats for all occasions using the finest seasonal ingredients available. All of our baked goods are made fresh daily by veteran bakers with a keen sense for flavor and aesthetic. Select from one of our house favorites or create a custom cake from our currently available options.</p>
    </div>
    <div class="homebtn">
      <router-link :to="{name: 'standard-cakes'}" class="btn btn-info" role="button">House Favorites</router-link>
      <router-link :to="{name: 'order-custom-cake'}" class="btn btn-info" role="button">Custom Cake</router-link>
    </div>
  </div>
</div>
</template>

<script>
export default {
  name: 'home'
}
</script>

<style>
#homepage {
  background-image: url('../../src/assets/home-background.jpg');
  height: 85vh;
  background-position: center;
  background-size: cover;
  padding-left: 7%;
  padding-right: 7%;
}
.hometext {
  width: 100%;
  padding: 2vh;
  background-color: hsla(187, 92%, 91%, 0.6);
  border: 4px solid rgba(68, 68, 68, 0.5);
  border-radius: 10px;
  font-size: 22px;
  margin-top: 7vh;
  margin-bottom: 10vh;
}
.homebtn {
  width: 100%;
  display: flex;
  justify-content: center;
}
#homeinfo {
  width: 52%;
  display: flex;
  flex-wrap: wrap;
}
#homeinfo .btn {
  border: 2px solid black;
  box-shadow: 1px 2px 40px rgba(0,0,0,.6);
  font-size: 2.2vw;
  font-weight: bold;
  margin: 2vh;
}
@media (max-width:900px) {
  #homepage {
    background-position: right;
    background-color: hsla(188, 56%, 8%, 0.5);
    background-blend-mode: multiply;
  }
  #homeinfo {
    width: 100%;
  }
  #homeinfo .btn {
    font-size: 4.6vw;
  }
}
</style>
