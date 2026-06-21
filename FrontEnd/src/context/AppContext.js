import {useContext, createContext, useState, useEffect, useRef} from "react";
import {useLocation} from "react-router-dom";
import FetchAPI from "~/hooks/FetchAPI";
import {Toast} from "primereact/toast";

const AppContext = createContext();

export const AppProvider = ({ children }) => {
    const api_url = process.env.REACT_APP_API_URL;
    const toast = useRef(null);
    const currentPath = useLocation().pathname;
    const [currentLocation, setCurrentLocation] = useState(currentPath);
    const [userData, setUserData] = useState(JSON.parse(localStorage.getItem("userData")) ?? '');
    const [dashboardLinkItems, setDashboardLinkItems] = useState('accountSettings');
    const [dashBoardSubLink, setDashBoardSubLink] = useState('');

    useEffect(() => {
        const userId = userData?.userId;
        if(!userId) return;

        const getUserById = async () => {
            const data = await FetchAPI({
                url: `api/User/${userId}`,
            });
            if(data?.data){
                setUserData(data.data);
            }
        }
        getUserById();
    }, [userData?.userId]);

    useEffect(() => {
        setCurrentLocation(currentPath)
    }, [currentPath]);

    return (
        <AppContext.Provider value={{api_url, currentLocation, toast,
            userData, setUserData,
            dashboardLinkItems, setDashboardLinkItems,
            dashBoardSubLink, setDashBoardSubLink,
        }}>
            {children}
            <Toast ref={toast} />
        </AppContext.Provider>
    )
}

export const useAppContext = () => useContext(AppContext);