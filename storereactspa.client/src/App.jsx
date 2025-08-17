import {useState } from 'react';
import Login from './Login';
import './App.css';

function App() {
    const [token, setTokenState] = useState(localStorage.getItem('token'));
    const setToken = (userToken) => {
        localStorage.setItem('token', userToken);
        setTokenState(userToken);
    };
    if (!token) {
        return <Login setToken={setToken} />;
    }
    return (
        <div>
            <h1>Admin Panel</h1>
            {/* Your AdminPanelComponent where you fetch products */}
        </div>
    );

    async function fetchProducts() {
        const token = await localStorage.getItem('token');
        try {
            const response = await fetch('https://localhost:XXXX/api/products', {
                method: 'GET',
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            });
            if (!token) {
                throw new Error("Ви не авторизовані!");
            }
            if (response.status === 401) {
                throw new Error("Невірний або прострочений токен. Увійдіть знову.");
            }
            if (response.status === 403) {
                throw new Error("У вас немає доступу до цього ресурсу.");
            }
            if (response.status === 404) {
                throw new Error("Продукти не знайдені.");
            }
            if (response.ok) {
                const products = await response.json();
                console.log("Отримані продукти:", products);
                return products;
            }
            throw new Error(`Сталася помилка: ${response.status} ${response.statusText}`);
        } catch (e) {
            console.error("Помилка при отриманні продуктів:", e.message);
            alert(e.message);
        }
       
    }
}

export default App;