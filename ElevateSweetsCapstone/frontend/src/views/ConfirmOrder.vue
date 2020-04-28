<template>
  <div id="confirmorder">

  <h2>Your Order Has Been Placed!</h2>
  <p>If there are any problems with your order, or if you need to cancel or modify this order, please contact us.</p>

  <div>
  <ul>
    <li><b>Order ID:</b> {{order.orderId}}</li>
    <li><b>Total Order Cost (due at pickup):</b> ${{order.orderTotal}}.00</li>
    <li><b>Pickup Date and Time:</b> {{order.date}} at {{order.time}}</li>
    <li><b>Quantity:</b> {{order.quantity}}</li>
    <li><b>Customer Name:</b> {{order.customerName}} </li>              
    <li><b>Email:</b> {{order.email}} </li>
    <li><b>Customer Phone:</b> {{order.phoneNumber}}</li>
  </ul>
  <ul>
    <li><b>Cake Name:</b> {{order.cake.name}}</li>
    <li><b>Style:</b> {{order.cake.style}} </li>
    <li><b>Size:</b> {{order.cake.size}}</li>
    <li><b>Flavor:</b> {{order.cake.flavor}}</li>
    <li><b>Frosting:</b> {{order.cake.frosting}}</li>
    <li><b>Filling:</b> {{order.cake.filling}}</li>
    <li><b>Writing on Cake:</b> {{order.writingOnCake}}</li>
  </ul>
  </div>

</div>
</template>

<script>
export default {
  name: 'confirm-order',
  data() {
      return {
        order: []
    };
  },

  methods: {
    
    getOrder(id) {
      fetch(`${process.env.VUE_APP_REMOTE_API_ORDER}/getOrder/${id}`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.order = data;
      })
      .catch((err) => console.error(err));
    }
  },
  created() {
    this.getOrder(this.$route.params.id);
  }
}
</script>

<style>
#confirmorder {
  margin-top: 30px;
  margin-left: 10%;
  margin-right: 10%;
  padding: 15px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
  text-align: center;
}
#confirmorder ul {
  text-align: start;
  list-style: none;
}
#confirmorder div {
  margin-top: 30px;
  margin-left: 12%;
  margin-right: 12%;
  display: flex;
  justify-content: space-around;
}
</style>