import {UPDATE_USER, ADD_USER, GET_USER, DELETE_USER, ON_CHANGE_USER, SET_USER} from "~/store/User/constants";

export const initialState = {
    user: '',
    userList: [],
}

function reducer(state, action) {
    let newState;
    switch (action.type) {
        case SET_USER:
            newState = {
                ...state,
                user: {...action.payLoad}
            }
            break;
        case GET_USER:
            newState = {
                ...state,
                userList: [...action.payLoad],
            }
            break;
        case ON_CHANGE_USER:
            newState = {
                ...state,
                user: {...state.user, ...action.payLoad}
            }
            break;
        case ADD_USER:
            newState = {
                ...state,
                userList: [...state.userList, action.payLoad],
            }
            break;
        case UPDATE_USER:
            let newUserList = [...state.userList];
            let newUpdateUser = newUserList.map(user =>
                user.userId === action.payLoad.userId ?
                    {...user, ...action.payLoad} : user)
            newState = {
                ...state,
                userList: newUpdateUser,
            };
            break;
        case DELETE_USER:
            let userList = [...state.userList];
            let newDeletedUser = userList.filter(user => user.userId !== action.payLoad);
            newState = {
                ...state,
                userList: newDeletedUser,
            }
            break;
        default:
            throw new Error(`Unhandled action type ${action.type}`);
    }
    // console.log(newState);
    return newState;
}

export default reducer;