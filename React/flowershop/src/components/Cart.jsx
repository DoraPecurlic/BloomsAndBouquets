import React from 'react';
import './Cart.css';

function Cart({ cart, onClose, onRemove, onUpdate }) {
    return (
      <div className="cart-modal">
        <div className="cart-content">
          <h2>Cart</h2>
          {cart.length === 0 ? (
            <p>Your cart is empty</p>
          ) : (
            <ul>
              {cart.map((item, index) => (
                <li key={index} className="cart-item">
                  {item.product.title} - {item.type} - Quantity: {item.quantity}
                  <div className="cart-item-buttons">
                    <button className="update-button" onClick={() => onUpdate(index)}>Update</button>
                    <button className="remove-button" onClick={() => onRemove(index)}>Remove</button>
                  </div>
                </li>
              ))}
            </ul>
          )}
          <button className="close-button" onClick={onClose}>Close</button>
        </div>
      </div>
    );
}

export default Cart;