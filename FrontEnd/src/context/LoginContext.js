import {useContext, createContext, useEffect} from "react";
import {useAppContext} from "~/context/AppContext";

const LoginContext = createContext();

export const LoginProvider = ({ children }) => {
    const {userData} = useAppContext();
    useEffect(() => {
        if(userData) window.location = '/dashboard/user';
    }, [userData]);

    return (
        <LoginContext.Provider value={{ok: 1}}>
            {children}
        </LoginContext.Provider>
    )
}

export const useLoginContext = () => useContext(LoginContext);