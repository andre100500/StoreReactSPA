import { ProductDto } from "./productTypes";

export interface UserDto {
    id: string;
    userName: string;
    email: string;
    products: ProductDto[];
}
export interface CreateUserDto {
    userName: string;
    email: string;
    password: string;
}
export interface UpdateUserDto {
    id: string;
    userName?: string;
    email?: string;
}
