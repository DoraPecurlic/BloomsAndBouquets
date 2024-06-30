import React from 'react';
import './Card.css';


function Card({ image, title, onChoose }) {
    return (
      <div className="card">
        {image}
        <div className="card-title">{title}</div>
        <button className="choose-button" onClick={onChoose}>Choose flower type</button>
      </div>
    );
}

export default Card;