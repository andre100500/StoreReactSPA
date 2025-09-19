import ApiClient from "../apiClient/api";
import { ProductDto, CreateProductDto, UpdateProductDto } from "../types/productTypes";

const productApi = new ApiClient("/products");

export const productService = {
    getAll: (): Promise<ProductDto[]> => productApi.get<ProductDto[]>(),
    getById: (id: number): Promise<ProductDto> => productApi.get<ProductDto>(`/${id}`),
    create: (data: CreateProductDto): Promise<ProductDto> => productApi.post<ProductDto>(data),
    update: (id: number, data: UpdateProductDto): Promise<ProductDto> => productApi.put<ProductDto>(data, `/${id}`),
    delete: (id: number): Promise<void> => productApi.delete<void>(`/${id}`),
};