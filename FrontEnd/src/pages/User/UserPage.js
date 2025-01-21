import clsx from "clsx";
import styles from '~/styles/Pages/User/user.module.scss';
import {Link} from "react-router-dom";
import {UserProvider} from "~/context/UserContext";
import {useAppContext} from "~/context/AppContext";
import {UserUpdateModal, UserList, UserDeleteModal} from "~/features/User";
import UserAddModal from "~/features/User/UserAddModal";
import {CustomButton} from "~/components";

function UserPage() {
    const {userData} = useAppContext();

    return (
        <>
            <UserProvider>
                <div className={clsx(styles["manage-user"], 'p-5')}>
                    <div className={clsx(styles["manage-user__table"])}>
                        <h3 className={clsx(styles["manage-user__table-title"], 'mb-5')}>
                            <p className='mb-0'>Account Settings/</p>
                            <p className={clsx(styles['manage-user__table-page'], 'mb-0')}> Manage User</p>
                        </h3>
                        <ul className={clsx(styles["manage-user__table-list"], 'mb-3')}>
                            <Link to='/dashboard/user'
                                  className={clsx(styles["manage-user__table-item"], styles['manage-user__table-item--choose'])}>
                                <i className="fa-solid fa-user-gear"></i>
                                <p>Manage User</p>
                            </Link>
                            {userData?.roleName === 'Admin' &&
                            <Link to='/dashboard/account'
                                  className={clsx(styles["manage-user__table-item"])}>
                                <i className="fa-solid fa-gears"></i>
                                <p>Manage Account</p>
                            </Link>
                            }
                        </ul>
                        {userData?.roleName === 'Admin' &&
                        <div className={clsx(styles['add-user__btn'])}>
                            <CustomButton
                                dataBsToggle="modal"
                                dataBsTarget="#add-user"
                            >
                                <i className="fa-solid fa-user-plus"></i>
                                <span style={{marginLeft: 5}}>Add User</span>
                            </CustomButton>
                        </div>
                        }

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
                                            <th>Username</th>
                                            <th>Created At</th>
                                            <th>Updated At</th>
                                            {userData?.roleName === 'Admin' &&
                                            <th>Actions</th>
                                            }
                                        </tr>
                                        </thead>
                                        <tbody>
                                            <UserList/>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <UserAddModal />
                <UserUpdateModal />
                <UserDeleteModal />
            </UserProvider>
        </>
    )
}

export default UserPage;