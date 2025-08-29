import { api } from "./api";

export const fetchProducts = () => api("/products").get();
