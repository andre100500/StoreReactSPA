const API_URL = "https://localhost:XXXX/api";

const getToken = (): string | null => localStorage.getItem("token");

const locationHrefLogin = '/login';

const handleResponse = async<T>(response: Response): Promise<T> => {
    if (response.status === 401) {
        localStorage.removeItem("token");
        window.location.href = locationHrefLogin;
        throw new Error('Сесія недійсна. Будь ласка, увійдіть знову.');
    }
    if (!response.ok) {
        const errorData = await response.json();
        throw new Error(errorData.message || "Помилка запиту");
    }
    if (response.ok) {
        return null as T;
    }
    return response.json() as Promise<T>;
}


class ApiClient {
    private baseUrl: string;
    constructor(resource: string) {
        this.baseUrl = `${API_URL}${resource}`;
    }

    private async request<T>(
        method: "GET" | "POST" | "PUT" | "PATCH" | "DELETE",
        path: string = "",
        body?: any
    ): Promise<T> {
        const token = getToken();
        if (!token) {
            window.location.href = locationHrefLogin;
            throw new Error("Користувач не авторизований");
        }
        const headers: HeadersInit = {
            Authorization: `Bearer ${token}`,
            "Content-Type": "application/json",
        };
        const response = await fetch(`${this.baseUrl}${path}`, {
            method,
            headers,
            body: body ? JSON.stringify(body) : undefined,
        });
        return handleResponse<T>(response);
    }
    get<T>(path = ""): Promise<T> {
        return this.request<T>("GET", path);
    }

    post<T>(data: any, path = ""): Promise<T> {
        return this.request<T>("POST", path, data);
    }

    put<T>(data: any, path = ""): Promise<T> {
        return this.request<T>("PUT", path, data);
    }

    patch<T>(data: any, path = ""): Promise<T> {
        return this.request<T>("PATCH", path, data);
    }

    delete<T>(path = ""): Promise<T> {
        return this.request<T>("DELETE", path);
    }
}
export default ApiClient;
