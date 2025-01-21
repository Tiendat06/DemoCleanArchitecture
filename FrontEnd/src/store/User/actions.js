import {UPDATE_USER, ADD_USER, GET_USER, DELETE_USER, ON_CHANGE_USER, SET_USER} from "~/store/User/constants";

export const updateUser = payLoad => {
    return {
        type: UPDATE_USER,
        payLoad
    }
}

export const addUser = payLoad => {
    return {
        type: ADD_USER,
        payLoad
    }
}

export const getUser = payLoad => {
    return {
        type: GET_USER,
        payLoad
    }
}

export const deleteUser = payLoad => {
    return {
        type: DELETE_USER,
        payLoad
    }
}

export const onChangeUser = payLoad => {
    return {
        type: ON_CHANGE_USER,
        payLoad
    }
}

export const setUser = payLoad => {
    return {
        type: SET_USER,
        payLoad
    }
}