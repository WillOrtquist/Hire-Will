<template>
<div id="ordercustomcake">

  <form @submit.prevent="submitOrder(orderInfo.cake.size.basePrice, orderInfo.cake.size.size, orderInfo.cake.style.style)">
    <div class="alert alert-danger" role="alert" v-if="createOrderErrors">
      There were problems creating this order.
    </div>

    <div class="form-group">
      <label for="style">Style:</label>
      <select class="form-control" v-model="orderInfo.cake.style" @change.prevent="FilterSizes(orderInfo.cake.style.id)">
        <option v-for="style in cake.styles" :key="style.id" :value="style">{{ style.style }}</option>
      </select>
    </div>
      
    <div class="form-group">
      <label for="size">Size:</label>
      <select class="form-control" v-model="orderInfo.cake.size">
        <option v-for="size in cake.sizes" :key="size.id" :value="size">{{ size.size }} ${{size.basePrice}}</option>
      </select>
    </div>
    
    <div class="form-group">
      <label for="flavor">Flavor:</label>
      <select class="form-control" v-model="orderInfo.cake.flavor">
        <option v-for="flavor in cake.flavors" :key="flavor.id" :value="flavor.flavor">{{ flavor.flavor }}</option>
      </select>
    </div>
    
    <div class="form-group">
      <label for="frosting">Frosting:</label>
      <select class="form-control" v-model="orderInfo.cake.frosting">
        <option v-for="frosting in cake.frostings" :key="frosting.id" :value="frosting.frosting">{{ frosting.frosting }}</option>
      </select>
    </div>
      
    <div class="form-group">
      <label for="filling">Filling:</label>
      <select class="form-control" v-model="orderInfo.cake.filling">
        <option v-for="filling in cake.fillings" :key="filling.id" :value="filling.filling">{{ filling.filling }}</option>
      </select>
    </div>

    <div class="form-group">
      <label for="name">Quantity:</label>
      <input v-model="orderInfo.quantity" min="1" type="number" class="form-control" required />
    </div>

    <div class="form-group">
      <label for="price">Name:</label>
      <input v-model="orderInfo.customerName" type="text" class="form-control" required />
    </div>

    <div class="form-group">
      <label for="name">Phone:</label>
      <input v-model="orderInfo.phoneNumber" type="tel" class="form-control" required pattern="[0-9]{3}-[0-9]{3}-[0-9]{4}"
        placeholder="123-456-7890" />
    </div>

    <div class="form-group">
      <label for="name">Email:</label>
      <input v-model="orderInfo.email" type="email" class="form-control" required />
    </div>

    <div class="form-group">
      <label for="name">Pickup Date:</label>
      <input v-bind:min="minDate" v-bind:max="maxDate" v-model="orderInfo.date" type="date" class="form-control" required />
    </div>

    <div class="form-group">
      <label for="name">Pickup Time:</label>
      <select v-model="orderInfo.time" class="form-control">
        <option value="9:00am">9:00am</option>
        <option value="10:00am">10:00am</option>
        <option value="11:00am">11:00am</option>
        <option value="12:00am">12:00pm</option>
        <option value="1:00pm">1:00pm</option>
        <option value="2:00pm">2:00pm</option>
        <option value="3:00pm">3:00pm</option>
        <option value="4:00pm">4:00pm</option>
        <option value="5:00pm">5:00pm</option>
      </select>
    </div>

    <div class="form-group" v-if="orderInfo.cake.style.style != 'Cupcake'">
      <label for="name">Add Message to Cake ($5.00):</label>
      <input v-model.trim="orderInfo.writingOnCake" type="text" maxlength="150" class="form-control" />
      <input type="hidden" v-model="orderInfo.id"/>
    </div>

    <button class="btn btn-lg btn-info btn-block" type="submit" >Submit Order</button>
  </form>

</div>

  
</template>

<script>
export default {
  name: 'order-cake',
  data() {
    return {
      minDate: '',
      maxDate: '',

      cake: {
        styles: [],
        sizes: [],
        flavors: [],
        frostings: [],
        fillings: []
      },
      orderInfo: {
        quantity: '',
        customerName: '',
        phoneNumber: '',
        email: '',
        writingOnCake: '',
        orderStatus: 'pending',
        date: '',
        time: '',
        cake: {
          name: 'Custom',
          style: '',
          size: '',
          flavor: '',
          frosting: '',
          filling: '',
          price: 25
        }
      },
      createOrderErrors: false,
    };
  },
  
  methods: {
    submitOrder(baseprice, size, style) {
      this.orderInfo.cake.price = baseprice;
      this.orderInfo.cake.size = size;
      this.orderInfo.cake.style = style;
      
      if (this.orderInfo.writingOnCake !== ''){
        this.orderInfo.cake.price += 5;
      } 
      fetch(`${process.env.VUE_APP_REMOTE_API_ORDER}/cakeOrder`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.orderInfo),
        
      })

        .then((response) => {
          
          if (response.ok) {
            return response.json();
          }     
        })
        .then( (data)=>{
           let createdId=data;
           this.$router.push({ path: `/ordercustomcake/${createdId}`});
         
      })
    },
    getFrostingsList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllFrostings`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.cake.frostings = data.filter(function(u) {
        return u.isAvailable
      })
      })
      .catch((err) => console.error(err));
    },
    getFillingsList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllFillings`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.cake.fillings = data.filter(function(u) {
        return u.isAvailable
      })
      })
      .catch((err) => console.error(err));
    },
    getFlavorsList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllFlavors`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.cake.flavors = data.filter(function(u) {
        return u.isAvailable
      })
      })
      .catch((err) => console.error(err));
    },
    getStylesList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllStyles`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.cake.styles = data.filter(function(u) {
        return u.isAvailable
      })
      })
      .catch((err) => console.error(err));
    },
    getSizesList() {
      fetch(`${process.env.VUE_APP_REMOTE_API_OPTIONS}/getAllSizes`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.allSizes = data.filter(function(u) {
        return u.isAvailable
      })
        this.cake.sizes = this.allSizes;
      })
      .catch((err) => console.error(err));
    },
     FilterSizes(id){
        this.cake.sizes = this.allSizes.filter( u => {
          return u.styleId == id
        });
     },
     getMinDate(){
      var today = new Date();
      var dd = String(today.getDate() + 2).padStart(2, '0');
      var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
      var yyyy = today.getFullYear();
      today = yyyy + '-' + mm + '-' + dd;
      this.minDate = today; 
    },
    getMaxDate(){
      var today = new Date();
      var dd = String(today.getDate() + 2).padStart(2, '0');
      var mm = String(today.getMonth() + 7).padStart(2, '0'); //January is 0!
      var yyyy = today.getFullYear();
      today = yyyy + '-' + mm + '-' + dd;
      this.maxDate = today; 
    }
  },
  created() {
    this.getFrostingsList();
    this.getFillingsList();
    this.getFlavorsList();
    this.getSizesList();
    this.getStylesList();
    this.getMinDate();
    this.getMaxDate();
  }
}
</script>

<style>
#ordercustomcake {
  margin-top: 30px;
  margin-left: 10%;
  margin-right: 10%;
  padding: 15px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
}
#ordercustomcake form {
  width: 100%;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between
}
#ordercustomcake div {
  width: 49%;
}
</style>