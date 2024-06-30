import React, { useState, useEffect } from 'react';
import { getOrders } from './AxiosConfig';



function OrderList({ userId, updateOrders  }){
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        const fetchOrders = async () => {
          console.log('Fetching orders for user ID:', userId); 

          try {
            const orders = await getOrders(userId);
            console.log('Fetched orders:', orders); 
            setOrders(orders);
            updateOrders(orders);
          } catch (error) {
            console.error('Error fetching orders:', error);
          }
        };
    
        fetchOrders();
      }, [userId, updateOrders]);

      return (
        <div className="order-list">
          {orders.length === 0 ? (
            <p>Your cart is empty.</p>
          ) : (
            <ul>
              {orders.map(order => (
                <li key={order.id}>
                  <p>Order ID: {order.id}</p>
                  <p>Flower Type: {order.flowerType}</p>
                  <p>Quantity: {order.quantity}</p>
                  <p>Order Type ID: {order.orderTypeId}</p>
                </li>
              ))}
            </ul>
          )}
        </div>
      );

}

export default OrderList;