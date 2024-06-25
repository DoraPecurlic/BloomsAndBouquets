import React, { useState, useEffect } from 'react';
import { getOrders } from './AxiosConfig';



function OrderList({ userId }){
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        const fetchOrders = async () => {
          try {
            const orders = await getOrders(userId);
            setOrders(orders);
          } catch (error) {
            console.error('Error fetching orders:', error);
          }
        };
    
        fetchOrders();
      }, [userId]);

      return (
        <div className="order-list">
          <h2>Orders</h2>
          {orders.length === 0 ? (
            <p>No orders found for this user.</p>
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