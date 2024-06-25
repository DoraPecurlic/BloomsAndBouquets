import React, { useState, useEffect } from 'react';
import Header from './components/Header';
import Card from './components/Card';
import SelectionWindow from './components/SelectionWindow';
import Cart from './components/Cart';
import './App.css';

import OrderList from './OrderList';


const products = [
  { id: 1, title: 'Bouquet', image: <img src={`${process.env.PUBLIC_URL}/images/1.jpg`} alt="Product 1" /> },
  { id: 2, title: 'Box Of Blooms', image: <img src={`${process.env.PUBLIC_URL}/images/2.jpg`} alt="Product 2" /> },
  { id: 3, title: 'Basket Of Blooms', image: <img src={`${process.env.PUBLIC_URL}/images/3.jpg`} alt="Product 3" /> },
  { id: 7, title: 'Single Flower', image: <img src={`${process.env.PUBLIC_URL}/images/7.jpg`} alt="Product 4" /> },
  { id: 5, title: 'Flower Cone', image: <img src={`${process.env.PUBLIC_URL}/images/5.jpg`} alt="Product 5" /> },
  { id: 6, title: 'Flower Vase Arrangement', image: <img src={`${process.env.PUBLIC_URL}/images/6.jpg`} alt="Product 6" /> },
  { id: 4, title: 'Posy', image: <img src={`${process.env.PUBLIC_URL}/images/4.jpg`} alt="Product 7" /> },
];

function App() {
  const [cart, setCart] = useState([]);
  const [flowerType, setFlowerType] = useState('');
  const [flowerQuantity, setFlowerQuantity] = useState(1);
  const [selectedProduct, setSelectedProduct] = useState(null);
  const [selectedIndex, setSelectedIndex] = useState(null);
  const [showCart, setShowCart] = useState(false);
  const [notification, setNotification] = useState('');



  useEffect(() => {
    const savedCart = JSON.parse(localStorage.getItem('cart'));
    if (savedCart) {
      setCart(savedCart);
    }
  }, []);

  useEffect(() => {
    localStorage.setItem('cart', JSON.stringify(cart));
  }, [cart]);

  const addToCart = () => {
    const newCartItem = { product: selectedProduct, type: flowerType, quantity: flowerQuantity };
    if (selectedIndex !== null) {
      const updatedCart = [...cart];
      updatedCart[selectedIndex] = newCartItem;
      setCart(updatedCart);
      setSelectedIndex(null);
      setShowCart(true);  
    } else {
      setCart([...cart, newCartItem]);
    }
    setSelectedProduct(null);
    setFlowerType('');
    setFlowerQuantity(1);
    showNotification('Added to cart!');
  };

  const showNotification = (message) => {
    setNotification(message);
    setTimeout(() => {
      setNotification('');
    }, 2000);
  };

  const handleFlowerTypeChange = (e) => setFlowerType(e.target.value);
  const handleFlowerQuantityChange = (e) => setFlowerQuantity(e.target.value);
  const handleProductSelection = (product) => {
    setSelectedProduct(product);
    setShowCart(false); 
  };

  

  const handleCartClick = () => setShowCart(true);
  const handleCartClose = () => setShowCart(false);

  const handleRemove = (index) => {
    const updatedCart = cart.filter((_, i) => i !== index);
    setCart(updatedCart);
  };

  const handleUpdate = (index) => {
    const itemToEdit = cart[index];
    setSelectedProduct(itemToEdit.product);
    setFlowerType(itemToEdit.type);
    setFlowerQuantity(itemToEdit.quantity);
    setSelectedIndex(index);
    setShowCart(false);  
  };

  return (
    <div className="App">
      <Header onCartClick={handleCartClick} />
      <div className="items-grid">
        {products.map(product => (
          <div key={product.id} className="item">
            <Card 
              image={product.image} 
              title={product.title} 
              onChoose={() => handleProductSelection(product)} 
            />
          </div>
        ))}
      </div>
      {selectedProduct && (
        <SelectionWindow 
          selectedProduct={selectedProduct}
          flowerType={flowerType}
          flowerQuantity={flowerQuantity}
          onTypeChange={handleFlowerTypeChange}
          onQuantityChange={handleFlowerQuantityChange}
          onAddToCart={addToCart}
          onClose={() => {
            setSelectedProduct(null);
            if (selectedIndex !== null) setShowCart(true);
          }}
        />
      )}
      {showCart && (
        <Cart 
          cart={cart} 
          onClose={handleCartClose} 
          onRemove={handleRemove}
          onUpdate={handleUpdate}
        />
      )}
      <OrderList userId={2} />
      {notification && <div className="notification">{notification}</div>}
    </div>
  );
}

export default App;
