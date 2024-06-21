document.addEventListener('DOMContentLoaded', function() {
    const itemsGrid = document.querySelector('.items-grid');
    const modal = document.querySelector('.modal');
    const cartItemsList = document.querySelector('.cart-items');
    const cartTotal = document.querySelector('.cart-total');

    let items = [
        { id: 1, name: 'Bouquet' },
        { id: 2, name: 'Box Of Blooms' },
        { id: 3, name: 'Basket Of Blooms' },
        { id: 4, name: 'Posy' },
        { id: 5, name: 'Flower Cone' },
        { id: 6, name: 'Flower Vase Arrangement' },
        { id: 7, name: 'Single Flower' }
    ];

    let cart = JSON.parse(localStorage.getItem('cart')) || {};

    function displayOrderTypes() {
        for (const item of items) {
            let itemElement = document.createElement('div');
            itemElement.classList.add('item');
            itemElement.innerHTML = `
                <img src="images/${item.id}.jpg" alt="${item.name}">
                <h2>${item.name}</h2>
                <button class="add-to-cart-btn" data-id="${item.id}" data-name="${item.name}">Add to cart</button>
            `;
            itemsGrid.appendChild(itemElement);
        }

        const addToCartButtons = document.querySelectorAll('.add-to-cart-btn');
        addToCartButtons.forEach(button => {
            button.addEventListener('click', openModal);
        });
    }

    function openModal(event) {
        const itemId = event.target.getAttribute('data-id');
        const itemName = event.target.getAttribute('data-name');

        const modalContent = modal.querySelector('.modal-content');
        modalContent.innerHTML = `
            <span class="close">&times;</span>
            <h2>Add to Cart</h2>
            <label for="flower-type">Choose flower type:</label>
            <select id="flower-type">
                <option value="Roses">Roses</option>
                <option value="Tulips">Tulips</option>
                <option value="Hydrangeas">Hydrangeas</option>
                <option value="Gerberas">Gerberas</option>
                <option value="Lilies">Lilies</option>
                <option value="Orchids">Orchids</option>
            </select>
            <br>
            <label for="number-of-flowers">Number of flowers:</label>
            <input type="number" id="number-of-flowers" value="1">
            <br>
            <button class="add-to-cart-modal-btn">Add to Cart</button>
        `;

        const closeBtn = modalContent.querySelector('.close');
        closeBtn.addEventListener('click', closeModal);

        const addToCartModalBtn = modalContent.querySelector('.add-to-cart-modal-btn');
        addToCartModalBtn.addEventListener('click', () => {
            const flowerType = modalContent.querySelector('#flower-type').value;
            const numberOfFlowers = parseInt(modalContent.querySelector('#number-of-flowers').value);

            addToCart(itemId, itemName, flowerType, numberOfFlowers);
            closeModal();
        });

        modal.style.display = 'block';
    }

    function closeModal() {
        modal.style.display = 'none';
    }

    function addToCart(itemId, itemName, flowerType, numberOfFlowers) {
        const cartKey = `${itemId}`;
        if (!cart[cartKey]) {
            cart[cartKey] = {
                Id: itemId,
                name: itemName,
                type: flowerType,
                quantity: numberOfFlowers
            };
        } else {
            cart[cartKey].quantity += numberOfFlowers;
        }

        localStorage.setItem('cart', JSON.stringify(cart));

        updateCart();
    }

    function updateCart() {
        cartItemsList.innerHTML = '';
        let total = 0;

        for (let key in cart) {
            const item = cart[key];
            const itemTotal = calculateItemTotal(item.type, item.quantity);
            total += itemTotal;

            const li = document.createElement('li');
            li.textContent = `${item.name}, ${item.type}, Quantity: ${item.quantity} - $${itemTotal.toFixed(2)}`;
            cartItemsList.appendChild(li);
        }

        cartTotal.textContent = `$${total.toFixed(2)}`;
    }

    function calculateItemTotal(type, quantity) {
        return quantity * 10; 
    }

    updateCart();
    displayOrderTypes();
});
