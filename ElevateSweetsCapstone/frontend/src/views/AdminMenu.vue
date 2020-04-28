<template>
<div id="adminmenu">
  <div class="adminbtn">
    <button v-on:click="openPendingOrders" class="btn btn-info btn-block">Orders</button>
    <button v-on:click="openCreateCake" class="btn btn-info btn-block">Create Fav.</button>
    <button v-on:click="openToggleCakes" class="btn btn-info btn-block">Disable Fav.</button>
    <button v-on:click="openAddOption" class="btn btn-info btn-block">Add Cake Option</button>
    <button v-on:click="openOptionAvailability" class="btn btn-info btn-block">Disable Cake Option</button>
    <button v-on:click="openRegester" class="btn btn-info btn-block">Register User</button>
  </div>

  <div v-if="pendingOrdersOpen">
    <pending-orders/>
  </div>

  <div v-if="createCakeOpen">
    <create-cake/>
  </div>

  <div v-if="toggleCakesOpen">
    <cake-availability/>
  </div>

  <div v-if="addOptionOpen">
    <add-option/>
  </div>

  <div v-if="optionAvailabilityOpen">
    <option-availability/>
  </div>

  <div v-if="registerOpen">
    <register/>
  </div>

</div>
</template>

<script>
import CreateCake from '@/components/CreateCake.vue'
import PendingOrders from '@/components/PendingOrders.vue'
import CakeAvailability from '@/components/CakeAvailability.vue'
import Register from '@/components/Register.vue'
import AddOption from '@/components/AddOption.vue'
import OptionAvailability from '@/components/OptionAvailability.vue'

export default {
  name: 'admin-menu',
  components: {
    CreateCake,
    PendingOrders,
    CakeAvailability,
    Register,
    AddOption,
    OptionAvailability,
  },
  data() {
    return {
      createCakeOpen: false,
      pendingOrdersOpen: true,
      toggleCakesOpen: false,
      registerOpen: false,
      addOptionOpen: false,
      optionAvailabilityOpen: false,
    };
  },
  methods: {
    openAddOption() {
      this.clearScreen();
      this.addOptionOpen = true;
    },
    openOptionAvailability() {
      this.clearScreen();
      this.optionAvailabilityOpen = true;
    },
    openCreateCake() {
      this.clearScreen();
      this.createCakeOpen = true;
    },
    openPendingOrders() {
      this.clearScreen();
      this.pendingOrdersOpen = true;
    },
    openToggleCakes() {
      this.clearScreen();
      this.toggleCakesOpen = true;
    },
    openRegester() {
      this.clearScreen();
      this.registerOpen = true;
    },
    clearScreen() {
      this.createCakeOpen = false;
      this.pendingOrdersOpen = false;
      this.toggleCakesOpen = false;
      this.registerOpen = false;
      this.addOptionOpen = false;
      this.optionAvailabilityOpen = false;
    },
  }
}
</script>

<style>
  #adminmenu .btn {
    margin: 10px;
    border: 2px solid black;
  }
  .adminbtn {
    display: flex;
    border-bottom: 10px solid rgb(56, 54, 54);
    background-color: hsla(188, 56%, 8%, 0.7);
  }
</style>