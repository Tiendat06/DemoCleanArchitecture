import clsx from "clsx";
import styles from "~/styles/Pages/User/user.module.scss";
import {Link} from "react-router-dom";
import {AccountProvider} from "~/context/AccountContext";
import {ChangeUserRoleModal, AccountList, ResetPasswordModal} from "~/features/Account";
import {useAppContext} from "~/context/AppContext";
import {useEffect} from "react";

function AccountPage() {
    const {userData} = useAppContext();
    useEffect(() => {
        if (userData?.roleName === 'User') {
            window.location = '/dashboard/user';
        }
    }, [userData.roleName]);

    return (
        <>
            <AccountProvider>
                <div className={clsx(styles["manage-user"], 'p-5')}>
                    <div className={clsx(styles["manage-user__table"])}>
                        <h3 className={clsx(styles["manage-user__table-title"], 'mb-5')}>
                            <p className='mb-0'>Account Settings/</p>
                            <p className={clsx(styles['manage-user__table-page'], 'mb-0')}> Manage Account</p>
                        </h3>
                        <ul className={clsx(styles["manage-user__table-list"], 'mb-3')}>
                            <Link to='/dashboard/user'
                                  className={clsx(styles["manage-user__table-item"])}>
                                <i className="fa-solid fa-user-gear"></i>
                                <p>Manage User</p>
                            </Link>
                            <Link to='/dashboard/account'
                                  className={clsx(styles["manage-user__table-item"], styles['manage-user__table-item--choose'])}>
                                <i className="fa-solid fa-gears"></i>
                                <p>Manage Account</p>
                            </Link>
                        </ul>

                        <div className={clsx(styles['user-card'], 'card')}>
                            <h5 className={clsx(styles['user-card__header'], "card-header")}>User Management</h5>
                            <div className="card-body">
                                <div className="table-responsive text-nowrap">
                                    <table className="table table-hover table-bordered">
                                        <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Full Name</th>
                                            <th>Email</th>
                                            <th className="text-center">Admin</th>
                                            <th className="text-center">User</th>
                                            <th className="text-center">Ban</th>
                                            <th className="text-center">Reset Password</th>
                                        </tr>
                                        </thead>
                                        <tbody>
                                            <AccountList />
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <ChangeUserRoleModal />
                <ResetPasswordModal />
            </AccountProvider>
        </>
    );
}

export default AccountPage;