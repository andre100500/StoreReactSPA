import { api } from "../apiClient/api";
import { UserDto, CreateUserDto, UpdateUserDto } from "../types/userTypes";

const userApi = api("/users");

export const userService = {
    getAll: async (): Promise<UserDto> => {
        return await userApi.get<UserDto>();
    },
    getById: async (id: string): Promise<UserDto> => {
        return await api(`/users/${id}`).get<UserDto>();
    }
}