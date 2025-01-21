import styles from "~/styles/Partials/Navbar/navbar.module.scss";
import clsx from "clsx";
import {FPT_Telecom_logo} from "~/assets";

function NavbarHeader() {
    return (
        <>
            <nav className={clsx(styles['navbar-header'])}>
                <img src={FPT_Telecom_logo} className={clsx(styles["navbar-header__logo"])} alt=""/>
            </nav>
        </>
    );
}

export default NavbarHeader;