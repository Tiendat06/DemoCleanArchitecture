import {Header, Body, Footer, Navbar, NavbarHeader} from '~/components';
import styles from "~/styles/Partials/Layouts/layouts.module.scss";
import clsx from "clsx";
import {useAppContext} from "~/context/AppContext";

function Layouts() {
    const {currentLocation} = useAppContext();

    return (
        <>
            {currentLocation.startsWith('/dashboard') ?
                <div className={clsx(styles["app"])}>
                    <div className={clsx(styles["app-navbar"])}>
                        <NavbarHeader />
                        <Navbar />
                    </div>
                    <div className={clsx(styles["app-content"])}>
                        <Header />
                        <Body />
                    </div>
                    <Footer />
                </div>
            :
                <div className={clsx(styles["app-login"])}>
                    <Body />
                </div>
            }
        </>
    )
}

export default Layouts;