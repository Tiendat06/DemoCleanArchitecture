import userRoutes from "~/routes/UserRoutes";
import {Routes, Route} from "react-router-dom";
import siteRoutes from "~/routes/SiteRoutes";
import accountRoutes from "~/routes/AccountRoutes";

function AppRoutes() {
    const appRoutes = [
        ...userRoutes,
        ...siteRoutes,
        ...accountRoutes,
    ];

    return (
        <Routes>
            {appRoutes?.map((route, index) => (
               <Route key={`router-${index}`} path={route.path} element={route.element}></Route>
            ))}
        </Routes>
    )

}

export default AppRoutes;