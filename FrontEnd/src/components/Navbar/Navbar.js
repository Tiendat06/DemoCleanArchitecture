import clsx from "clsx";
import styles from "~/styles/Partials/Navbar/navbar.module.scss";
import {useAppContext} from "~/context/AppContext";
import {Link} from "react-router-dom";
import {LogoutModal} from '~/features/Partials';

function Navbar() {
    const {userData, dashboardLinkItems, setDashboardLinkItems, dashBoardSubLink, setDashBoardSubLink} = useAppContext();

    return (
        <>
            <div className={clsx(styles["navbar-content"])}>
                <ul className={clsx(styles["sidebar-content__all-list"])}>
                    <li className={clsx(styles["sidebar-content__all-item"], 'mb-1')}>
                        <div onClick={() => setDashboardLinkItems('accountSettings')}
                             className={clsx(styles['sidebar-content__main-link'],
                                 (dashboardLinkItems === 'accountSettings' && styles['sidebar-content__main-link--choose']))}>
                            <i className="fa-solid fa-users"></i>
                            <span className='col-md-0'>Account Settings</span>
                        </div>
                        <ul style={{maxHeight: (dashboardLinkItems === 'accountSettings' ? 500 : 0)}}
                            className={clsx(styles["sidebar-content__all-item__list"])}>
                            {userData?.roleName === 'Admin' &&
                            <li onClick={() => setDashBoardSubLink('manageAccount')}
                                className={clsx(styles["sidebar-content__all-item__list-item"], 'mt-0')}>
                                <Link
                                    className={clsx(dashBoardSubLink === 'manageAccount' && styles["sidebar-content__all-item__list-item--choose"])}
                                    to='/dashboard/account'>
                                    <i className="fa-solid fa-gears"></i>
                                    <span>Manage Account</span>
                                </Link>
                            </li>
                            }
                            <li onClick={() => setDashBoardSubLink('manageUser')}
                                className={clsx(styles["sidebar-content__all-item__list-item"])}>
                                <Link
                                    className={clsx(dashBoardSubLink === 'manageUser' && styles["sidebar-content__all-item__list-item--choose"])}
                                    to='/dashboard/user'>
                                    <i className="fa-solid fa-user-gear"></i>
                                    <span>Manage User</span>
                                </Link>
                            </li>
                        </ul>
                    </li>
                    <li className={clsx(styles["sidebar-content__all-item"], 'mb-1')}>
                        <div onClick={() => setDashboardLinkItems('authenticationSettings')}
                             className={clsx(styles['sidebar-content__main-link'],
                                 (dashboardLinkItems === 'authenticationSettings' && styles['sidebar-content__main-link--choose']))}>
                            <i className="fa-solid fa-lock"></i>
                            <span className='col-md-0'>Authentication Settings</span>
                        </div>
                        <ul style={{maxHeight: (dashboardLinkItems === 'authenticationSettings' ? 500 : 0)}}
                            className={clsx(styles["sidebar-content__all-item__list"])}>
                            <li onClick={() => setDashBoardSubLink('logOut')}
                                className={clsx(styles["sidebar-content__all-item__list-item"], 'mt-0')}>
                                <div
                                    className={clsx(dashBoardSubLink === 'logOut' && styles["sidebar-content__all-item__list-item--choose"])}
                                    data-bs-target='#logout-modal'
                                    data-bs-toggle='modal'
                                >
                                    <i className="fa-solid fa-gears"></i>
                                    <span>Log Out</span>
                                </div>
                            </li>
                        </ul>
                    </li>
                </ul>
            </div>
            <LogoutModal />
        </>
    );
}

export default Navbar;