import React from 'react';
import './Header.css';

export function Header({ onCartClick }) {
    return (
      <header className="header">
        <div className="shop-name">Blooms & Bouquets</div>
        <button className="cart-button" onClick={onCartClick}>Cart</button>
      </header>
    );
}

export default Header;