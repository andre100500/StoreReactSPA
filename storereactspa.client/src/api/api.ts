const API_URL = "https://localhost:XXXX/api";

const getToken = (): string | null => localStorage.getItem("token");

const locationHrefLogin = '/login';

const handleResponse = async<T>(response: Response): Promise<T> => {
    if (response.status === 401) {
        localStorage.removeItem("token");
        window.location.href = locationHrefLogin;
        throw new Error('Сесія недійсна. Будь ласка, увійдіть знову.');
    }
    if (response.ok) {
        return Promise.resolve(null as T);
    }
    return response.json();
}


export const api = (path: string) => {
    const url = `${API_URL}${path}`;
    const _fetch = async<T>(method: 'GET' | 'POST' | 'PUT' | 'PATCH' | 'DELETE', body?: any): Promise<T> => {
        const token = getToken();
        if (!token) {
            window.location.href = locationHrefLogin;
            throw new Error("Користувач не авторизований");
        }
        const headers: HeadersInit = {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json',
        };
        const options: RequestInit = {
            method,
            headers,
        };
        if (body) {
            options.body = JSON.stringify(body);
        }
        const response = await fetch(url, options);
        return handleResponse<T>(response);
    };
    return {
        get: <T>(): Promise<T> => _fetch<T>('GET'),

        post: <T>(data: any): Promise<T> => _fetch<T>('POST', data),

        put: <T>(data: any): Promise<T> => _fetch<T>('PUT', data),

        patch: <T>(data: any): Promise<T> => _fetch<T>('PATCH', data),

        delete: <T>(): Promise<T> => _fetch<T>('DELETE'),

    }
}
