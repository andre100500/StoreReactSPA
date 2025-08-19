import { cache } from "react";

const = API_URL = 'https://localhost:XXXX/api';

const getToken = () => localStorage.getItem('token');

export const fetchProducts = async () => {
    const token = getToken();

    if (!token) {
        console.error("No token found. User is not authenticated.");
        window.location.href = '/login';
        return;
    }
    try {
        const response = await fetch(`${API_URL}/products`, {
            method: 'GET',
            headers: {
                'Authorization': `Bearer ${token}`
            }
        });
        if (response.status === 401) {
            localStorage.removeItem('token');
            window.location.href = '/login';
            throw new Error("Невірний або прострочений токен. Увійдіть знову.");
        }
        if (response.status === 403) {
            throw new Error("У вас немає доступу до цього ресурсу.");
        }
        if (!response.ok) {
            throw new Error(`Сталася помилка на сервері: ${response.status}`);
        }

        return await response.json();
    }
    catch (e) {
        console.error("Помилка при отриманні продуктів:", e.message);
        throw e;
    }
}