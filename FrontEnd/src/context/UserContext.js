import {useContext, createContext, useReducer, useRef} from "react";
import reducer, {initialState} from "~/store/User/reducers";
const UserContext = createContext();

export const UserProvider = ({ children }) => {
    const [state, dispatch] = useReducer(reducer, initialState);
    const {user, userList} = state;
    const toast = useRef(null);

    return (
        <UserContext.Provider value={{state, dispatch, user, userList, toast}}>
            {children}
        </UserContext.Provider>
    )
}

export const useUserContext = () => useContext(UserContext);