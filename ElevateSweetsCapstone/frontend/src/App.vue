<template>
  <div id="app">
    <div id="navbarcontents">
      <router-link :to="{name: 'home'}"><img class="navimg" src="./assets/elevate-sweets.png"></router-link>
      <div class="navbardropdown">
        <button class="btn btn-info">Menu</button>
        <div class="dropdowncontent">
          <router-link :to="{name: 'home'}" class="btn btn-info" role="button">Home</router-link>
          <router-link :to="{name: 'standard-cakes'}" class="btn btn-info" role="button">House Favorites</router-link>
          <router-link :to="{name: 'order-custom-cake'}" class="btn btn-info" role="button">Custom Cake</router-link>
        </div>
      </div>
      <div class="adminbutton">
        <router-link :to="{name: 'admin-menu'}" class="btn btn-default" role="button">Admin Menu</router-link>
      </div>
    </div>

    <router-view/>
  </div>
</template>

<style>
html, #app{
  background-color: rgb(45, 214, 214);
}
#navbarcontents {
  background-color: rgb(56, 54, 54);
  display: flex;
  justify-content: space-between;
  align-items: center;
  height: 15vh;
}
.navbardropdown .btn{
  font-size: 22px;
  margin: 10px;
}
#navbarcontents .navimg {
  height: 15vh;
  margin-right: 50px;
  margin-left: 20px;
}
.navbardropdown {
  width: 100%;
}
.adminbutton .btn{
  color: whitesmoke;
  width: 120px;
}
.navbardropdown button {
  display: none;
}
@media (max-width:800px) {
  .navbardropdown button {
    display: inherit;
  }
  .navbardropdown {
    position: relative;
    display: inline-block;
  }
  .dropdowncontent {
    display: none;
    position: absolute;
    background-color: rgb(56, 54, 54);
    border-radius: 5px;
    z-index: 10;
  }
  .dropdowncontent .btn {
    display: block;
    margin: 3px;
  }
  .navbardropdown:hover .dropdowncontent {
    display: block;
  }
  .navbardropdown > .btn {
    width: 100%;
    margin: 3px;
  }
  .navbardropdown {
    margin-right: 50px;
  }
}
</style>