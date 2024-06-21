import React from 'react';
import './SelectionWindow.css';

function SelectionWindow({ selectedProduct, flowerType, flowerQuantity, onTypeChange, onQuantityChange, onAddToCart, onClose }) {
  return (
    <div className="selection-window">
      <button className="close-button" onClick={onClose}>Close</button>
      <h2>Choose flower type for {selectedProduct.title}</h2>
      <select value={flowerType} onChange={onTypeChange}>
        <option value="">Select flower type</option>
        <option value="Roses">Roses</option>
        <option value="Tulips">Tulips</option>
        <option value="Orchids">Orchids</option>
      </select>
      <input type="number" value={flowerQuantity} onChange={onQuantityChange} min="1" max="50" />
      <button onClick={onAddToCart}>Add to Cart</button>
      
    </div>
  );
}

export default SelectionWindow;
