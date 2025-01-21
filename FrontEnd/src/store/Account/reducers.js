import {CHANGE_ROLE, GET_ACCOUNT, GET_ROLE, SET_ACCOUNT, SET_ROLE} from './constansts';

export const initialState = {
    account: '',
    accountList: [],

    role: '',
    roleList: [],
}

function reducer(state, action) {
    let newState;
    switch (action.type) {
        case SET_ACCOUNT:
            newState = {
                ...state,
                account: {...action.payLoad},
            }
            break;
        case GET_ACCOUNT:
            newState = {
                ...state,
                accountList: [...action.payLoad]
            }
            break;
        case SET_ROLE:
            newState = {
                ...state,
                role: {...action.payLoad},
            }
            break;
        case GET_ROLE:
            newState = {
                ...state,
                roleList: [...action.payLoad]
            }
            break;
        case CHANGE_ROLE:
            let newAccountList = [...state.accountList];
            newState = {
                ...state,
                accountList: newAccountList.map(item =>
                    item.accountId === action.payLoad.accountId ?
                        {...item, ...action.payLoad} : item)
            }
            break;
        default:
            throw new Error(`Unknown action type: ${action.type}`);
    }
    // console.log(newState);
    return newState;
}

export default reducer;