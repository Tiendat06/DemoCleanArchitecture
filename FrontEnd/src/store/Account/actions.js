import {CHANGE_ROLE, GET_ACCOUNT, GET_ROLE, SET_ACCOUNT, SET_ROLE} from './constansts'

export const getAccount = payLoad => {
    return {
        type: GET_ACCOUNT,
        payLoad
    }
}

export const setAccount = payLoad => {
    return {
        type: SET_ACCOUNT,
        payLoad
    }
}

export const getRole = payLoad => {
    return {
        type: GET_ROLE,
        payLoad
    }
}

export const setRole = payLoad => {
    return {
        type: SET_ROLE,
        payLoad
    }
}

export const changeUserRole = payLoad => {
    return {
        type: CHANGE_ROLE,
        payLoad
    }
}