<template>
  <div id="ordercake">

    <div class="ordercakeimg">
      <img v-bind:src="require('../../src/assets/' + orderInfo.cake.imageName)" /> 
      <div class="price">${{orderInfo.cake.price}}</div>
    </div>

    <div class="ordercakedetails">
      <h3>{{orderInfo.cake.name}}</h3>
      <p>{{orderInfo.cake.description}}</p>
      <ul>
        <li><b>Style:</b> {{orderInfo.cake.style}}</li>
        <li><b>Size:</b> {{orderInfo.cake.size}}</li>
        <li><b>Flavor:</b> {{orderInfo.cake.flavor}}</li>
        <li><b>Frosting:</b> {{orderInfo.cake.frosting}}</li>
        <li><b>Filling:</b> {{orderInfo.cake.filling}}</li>
      </ul>

      <form class="form-register" @submit.prevent="submitOrder">
        <div class="alert alert-danger" role="alert" v-if="createOrderErrors">
        There were problems creating this order.
      </div>
      <div class="orderforms">
        <div class="form-group">
          <label for="name">Quantity:</label>
          <input v-model="orderInfo.quantity"
          type="number"
          class="form-control"
          required
          min="1"
          max="10"
          />
        </div>
        <div class="form-group">
          <label for="price">Name:</label>
          <input v-model="orderInfo.customerName"
          type="text"
          class="form-control"
          required
          />
        </div>
        <div class="form-group">
        <label for="name">Phone:</label>
        <input v-model="orderInfo.phoneNumber"
        type="tel"
        pattern="[0-9]{3}-[0-9]{3}-[0-9]{4}"
        placeholder="123-456-7890"
        class="form-control"
        required
        />
        </div>
        <div class="form-group">
        <label for="name">Email:</label>
        <input v-model="orderInfo.email"
        type="email"
        class="form-control"
        required
        />
        </div>
        <div class="form-group">
        <label for="name">Pickup Date:</label>
        <input data-provide="datepicker" v-model="orderInfo.date"
        class="form-control"
        type="date"
        v-bind:min="minDate" 
        v-bind:max="maxDate"
        required
        />
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

      </div>
      <div class="form-group" v-if="orderInfo.cake.style != 'Cupcake'">
      <label for="name">Add Message to Cake ($5.00):</label>
      <input v-model.trim="orderInfo.writingOnCake"
      type="text" maxlength="150"
      class="form-control"
      />

    

      </div>
      <button class="btn btn-lg btn-info btn-block" type="submit" >Submit Order</button>
    </form>

    </div>

  </div>
</template>

<script>
export default {
  name: 'order-cake',
  data() {
    return {
      minDate: '',
      maxDate: '',
      orderInfo: {
        quantity: '',
        customerName: '',
        phoneNumber: '',
        email: '',
        writingOnCake: '',
        orderStatus: 'pending',
        date: '',
        time: '',
        cake: []
      },
      createOrderErrors: false,
    };
  },
  methods: {
    submitOrder() {
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
    getCake(id) {
      fetch(`${process.env.VUE_APP_REMOTE_API_CAKE}/getCake/${id}`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.orderInfo.cake = data;
      })
      .catch((err) => console.error(err));
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
    this.getCake(this.$route.params.id);
    this.getMinDate();
    this.getMaxDate();
  }
}
</script>

<style>
#ordercake {
  margin-top: 30px;
  margin-left: 10%;
  margin-right: 10%;
  padding: 15px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between
}
#ordercake .ordercakedetails {
  width: 63%;
}
#ordercake .ordercakeimg {
  position: relative;
  width: 35%;
}
#ordercake .ordercakeimg > img {
  border-radius: 5px;
  width: 100%;
}
.ordercakedetails .orderforms {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between
}
.ordercakedetails .orderforms div {
  width: 49%;
}
</style>