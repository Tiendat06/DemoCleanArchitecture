import styles from "~/styles/Pages/User/user.module.scss";
import clsx from "clsx";
import {getAllUsers} from "~/services/UserService";
import {useLayoutEffect} from "react";
import {useUserContext} from "~/context/UserContext";
import {getUser, setUser} from '~/store/User/actions';
import {useAppContext} from "~/context/AppContext";
import {formatDate} from "~/utils/formatDate";

function UserList() {
    const {userData} = useAppContext();
    useLayoutEffect(() => {
        const getUsersList = async () => {
            const data = await getAllUsers();
            dispatch(getUser(data.data));
        }
        getUsersList();
    }, []);

    const {userList, dispatch} = useUserContext();

    return (
        <>
            {userList?.map((item, index) => (
                <tr key={`user-list-${index}`}>
                    <td>{index + 1}</td>
                    <td>{item?.name}</td>
                    <td>{item?.email}</td>
                    <td>{item?.userName}</td>
                    <td>{formatDate(item?.createdAt)}</td>
                    <td>{formatDate(item?.updatedAt)}</td>
                    {userData?.roleName === 'Admin' &&
                    <td>
                        <div className={styles['user-table__actions']}>
                            <div data-bs-target="#update-user" data-bs-toggle="modal" className={clsx(styles["user-table__actions-edit"])}>
                                <i onClick={() => dispatch(setUser(item))} className="text-warning fa-solid fa-pen-to-square"></i>
                            </div>
                            <div className={clsx(styles["user-table__actions-delete"])}>
                                <i onClick={() => dispatch(setUser(item))} data-bs-target="#delete-user" data-bs-toggle="modal" className="text-danger fa-solid fa-trash"></i>
                            </div>
                        </div>
                    </td>
                    }
                </tr>
            ))}
        </>
    );
}

export default UserList;