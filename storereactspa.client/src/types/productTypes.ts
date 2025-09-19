export interface ProductDto {
    id: string;
    name: string;
    price: number;
    userId: string;
}
export interface CreateProductDto {
    name: string;
    descripton: string;
    category: string;
    price: number;
    discountValue: number;
}
export interface UpdateProductDto {
    name?: string;
    description?: string;
    category?: string;
    price?: number;
    discountValue?: number;
}