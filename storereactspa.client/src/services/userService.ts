import ApiClient from "../apiClient/api";
import { UserDto, CreateUserDto, UpdateUserDto } from "../types/userTypes";


const userApi = new ApiClient("/users");

export const userService = {
    getAll: (): Promise<UserDto[]> => userApi.get<UserDto[]>(),
    getById: (id: string): Promise<UserDto> => userApi.get<UserDto>(`/${id}`),
    create: (data: CreateUserDto): Promise<UserDto> => userApi.post<UserDto>(data),
    update: (id: string, data: UpdateUserDto): Promise<UserDto> => userApi.put(data, `/${id}`),
    delete: (id: string): Promise<void> => userApi.delete<void>(`/${id}`),

};