import styles from "~/styles/Partials/Header/header.module.scss";

import clsx from "clsx";
import {useAppContext} from "~/context/AppContext";

function Header() {
    const {userData} = useAppContext();
    return (
        <>
            <header className={clsx(styles["header"])}>
                <div className={clsx(styles["header-container"])}>
                    <div className={clsx(styles["header-right"])}>
                        <div className={clsx(styles["header-right__login"])}>
                            <i className={clsx(styles["header-right__login-img"], "fa-regular fa-circle-user")}></i>
                            <p className={clsx(styles["header-right__login-text"])}>{userData?.userName}</p>
                        </div>
                    </div>
                </div>
            </header>
        </>
    )
}

export default Header;