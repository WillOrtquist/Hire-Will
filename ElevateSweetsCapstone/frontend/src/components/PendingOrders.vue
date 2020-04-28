<template>
  <div id="pendingorderscontainer"> 
     
     <div class="search">
        <input class ="search-input" type="text" v-on:keyup="SearchOrders" id="search" name="search" placeholder="  Search Orders..."/>
        <input type="checkbox" id="filter" name="filter" v-on:click="FilterOrders">
      <label for="filter"> Show only Pending Orders</label><br>
    </div>

    <table id="orders" class = "table-bordered table-hover table-striped"> 
      <thead>
        <tr>
          <th class ="id">Order ID</th>
          <th class ="time">Pick Up Time</th>
          <th class ="order">Order Details</th>
          <th class ="customer">Customer Details</th>
          <th class ="status">Order Status</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="order in orders" :key="order.name" class="orderdetails">
          <td class ="id">{{order.orderId}}</td>
          <td class ="time">{{order.date}} at {{order.time}}</td>
          <td class ="order"><b>Cake Name:</b> {{order.cake.name}} <br/> <b>Style:</b> {{order.cake.style}} <br/> <b>Size:</b> {{order.cake.size}}<br/>
          <b>Flavor:</b> {{order.cake.flavor}} <br/> <b>Frosting:</b> {{order.cake.flavor}} <br/> <b>Filling:</b> {{order.cake.filling}} <br/> <b>Quantity:</b> {{order.quantity}}
          <br/><b>Writing on Cake:</b> {{order.cake.writingOnCake}}</td>
          <td class ="customer"><b>Customer Name:</b> {{order.customerName}} <br/> <b>Email:</b> {{order.email}} <br/> <b>Customer Phone:</b> {{order.phoneNumber}}</td>
          <td class ="status"><select v-model="order.orderStatus" v-on:change.prevent="UpdateOrderStatus(order.orderId, order.orderStatus)">
    <option v-for="status in statusChange" :key="status" :value="status">
      {{ status }} 
    </option>
</select></td>
        </tr>
      </tbody>
    </table>
</div>
</template>

<script>
export default {
    name: "pending-orders",
    data() {
      return {
        orders: [],
        filteredOrders: [],
        statusChange: [
          'pending',
          'canceled',
          'ready',
          'completed'
        ],
      }
    },
    methods: {
    getOrders() {
      fetch(`${process.env.VUE_APP_REMOTE_API_ORDER}/getAllOrders`)
      .then((response) => {
        return response.json();
      })
      .then((data) => {
        this.allOrders = data;
        this.orders = this.allOrders;
      })
      .catch((err) => console.error(err));
    },
    FilterOrders(){
     if(document.getElementById("filter").checked == true)
      {
        this.orders = this.orders.filter(function(u) {
          return u.orderStatus == 'pending'
        });
      }
      else{
      this.orders = this.allOrders;
      }
    },
  SearchOrders(){
      var query = document.getElementById("search").value.toLowerCase();
      this.orders = this.allOrders;
      this.orders = this.orders.filter(function(u) {
          return u.customerName.toLowerCase().includes(query) 
          || u.email.toLowerCase().includes(query)
          || u.phoneNumber.toLowerCase().includes(query)
          || u.orderStatus.toLowerCase().includes(query)
      });
    },
  UpdateOrderStatus(orderId, orderStatus) {
    let orderNew = {
        orderId: orderId,
        orderStatus: orderStatus
      }
      fetch(`${process.env.VUE_APP_REMOTE_API_ORDER}/updateOrderStatus`, {
        method: 'POST',
        headers: {
          Accept: 'application/json',
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(orderNew),
      })
        .then((response) => {
          if (response.ok) {
            this.FilterOrders();
          } else {
            this.updateCakeErrors = true;
          }
        })

        .then((err) => console.error(err));
    },
  },
  created() {
    this.getOrders();
  }
}
</script>


<style>
table{
  margin-top: 30px;
  margin-left: 2%;
  margin-right: 10%;
  padding: 15px;
  background-color: hsla(188, 56%, 8%, 0.7);
  color: whitesmoke;
  border-radius: 5px;
  table-layout: fixed;
}
th {  
    font-weight: bold; /* Make sure they're bold */
}

td, th {  
    padding: 5px;
}
#filter{
  margin-left: 65px;
}
.table-hover tbody tr:hover td, .table-hover tbody tr:hover th {
  background-color: hsla(187, 53%, 39%, 0.7);
  color: white;
}

.search{
    margin-top:30px;
    height: 60px;
    background-color: hsla(188, 56%, 8%, 0.7);
    padding: 10px;
    margin-left: 25px;
    width: 605px;
    border-radius: 5px;
    color: whitesmoke;
  }
.search-input{
    margin-top: 5px;
    border-radius: 5px;

  }

.id{
  width: 30px;
}
.time{
  width: 275px;
}
.order{
  width: 500px;
}
.customer{
  width: 500px;
}
.status{
  width: 100px;
}

</style>