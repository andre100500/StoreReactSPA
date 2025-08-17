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
                throw new Error("�� �� �����������!");
            }
            if (response.status === 401) {
                throw new Error("������� ��� ������������ �����. ������ �����.");
            }
            if (response.status === 403) {
                throw new Error("� ��� ���� ������� �� ����� �������.");
            }
            if (response.status === 404) {
                throw new Error("�������� �� �������.");
            }
            if (response.ok) {
                const products = await response.json();
                console.log("������� ��������:", products);
                return products;
            }
            throw new Error(`������� �������: ${response.status} ${response.statusText}`);
        } catch (e) {
            console.error("������� ��� �������� ��������:", e.message);
            alert(e.message);
        }
       
    }
}

export default App;