import React, { useState, useEffect } from 'react';
import { fetchProducts } from './api';

function AdminDashboard() {
    const [products, setProducts] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const getProducts = async () => {
            try {
                // Call the function from your api.js file
                const data = await fetchProducts();
                setProducts(data);
            } catch (err) {
                // The error thrown from api.js is caught here
                setError(err.message);
            } finally {
                setIsLoading(false);
            }
        };

        getProducts();
    }, []); // The empty array [] means this runs once when the component mounts

    if (isLoading) {
        return <div>Завантаження...</div>;
    }

    if (error) {
        return <div style={{ color: 'red' }}>Помилка: {error}</div>;
    }

    return (
        <div>
            <h1>Список продуктів</h1>
            <ul>
                {products.map(product => (
                    <li key={product.id}>{product.name} - {product.price} грн</li>
                ))}
            </ul>
        </div>
    );
}

export default AdminDashboard;