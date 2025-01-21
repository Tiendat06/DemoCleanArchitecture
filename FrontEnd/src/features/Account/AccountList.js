import {useLayoutEffect, useState} from "react";
import {getAllUsers} from "~/services/UserService";
import {getAllRolesService, handleChangeUserRoleService} from "~/services/AccountService";
import clsx from "clsx";
import styles from "~/styles/Pages/User/user.module.scss";
import {getAccount, changeUserRole, setAccount, setRole, getRole} from '~/store/Account/actions';
import {useAccountContext} from "~/context/AccountContext";

function AccountList() {
    const {accountList, roleList, dispatch, toast} = useAccountContext();
    useLayoutEffect(() => {
        const getUsersList = async () => {
            const data = await getAllUsers();
            dispatch(getAccount(data.data));
        }

        const getRoleList = async () => {
            const roleData = await getAllRolesService();
            dispatch(getRole(roleData.data));
        }
        getUsersList();
        getRoleList();
    }, []);

    const handleSetAccountAndRole = (user, role) => {
        dispatch(setAccount(user));
        dispatch(setRole(role));
    }

    return (
        <>
            {accountList?.map((user, index) => (
                <tr key={`user-list-${index}`}>
                    <td>{index + 1}</td>
                    <td>{user?.name}</td>
                    <td>{user?.email}</td>
                    {roleList?.map((role, index) => (
                        <td key={`role-list-${index}`} className="text-center"><i
                            data-bs-target='#change-user-role-modal'
                            data-bs-toggle="modal"
                            onClick={() => handleSetAccountAndRole(user, role)}
                            className={clsx(styles['user-list__icon'],
                                (user?.roleName === role?.roleName && styles['user-list__icon--choose']),
                                (role?.roleName === 'Admin' ? "fa-solid fa-user-gear":
                                    role?.roleName === 'User' ? "fa-solid fa-user":
                                        "fa-solid fa-lock"
                                )
                                )}></i></td>
                    ))}
                    <td className="text-center"><i
                        data-bs-target="#reset-password"
                        data-bs-toggle="modal"
                        onClick={() => dispatch(setAccount(user))}
                        className={clsx(styles['user-list__icon'], "fa-solid fa-key")}></i>
                    </td>
                </tr>
            ))}
        </>
    );
}

export default AccountList;