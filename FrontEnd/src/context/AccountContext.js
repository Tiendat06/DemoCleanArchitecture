import {useContext, createContext, useReducer, useRef} from "react";
import {useAppContext} from "~/context/AppContext";
import reducer, {initialState} from "~/store/Account/reducers";

const AccountContext = createContext();

export const AccountProvider = ({ children }) => {
    const [state, dispatch] = useReducer(reducer, initialState);
    const {account, accountList, role, roleList} = state;
    const toast = useRef(null);

    const {userData} = useAppContext();
    if(!userData) {
        window.location = '/';
    }

    return (
        <AccountContext.Provider value={{account, accountList, role, roleList, dispatch, toast}}>
            {children}
        </AccountContext.Provider>
    )
}

export const useAccountContext = () => useContext(AccountContext);