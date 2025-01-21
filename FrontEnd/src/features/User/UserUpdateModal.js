import CustomModal from "~/components/Modal/CustomModal";
import styles from '~/styles/Components/Modal/customModal.module.scss';
import userStyles from '~/styles/Pages/User/user.module.scss';
import clsx from "clsx";
import {useUserContext} from "~/context/UserContext";
import {onChangeUser, updateUser} from "~/store/User/actions";
import {useCallback} from "react";
import {handleUpdateUserService} from "~/services/UserService";
import {Toast} from "primereact/toast";

function UserUpdateModal() {
    const {user, dispatch, toast} = useUserContext();

    const handleUpdateUser = useCallback(async () => {
        const data = await handleUpdateUserService(user);
        const message = data.message;
        // console.log(data);
        if(data.status === 200) {
            toast.current.show({ severity: 'success', summary: 'Success', detail: message, life: 3000 });
            dispatch(updateUser(data.data));
        } else{
            toast.current.show({ severity: 'warn', summary: 'Warning', detail: message, life: 3000 })
        }
    }, [user])

    return (
        <>
            <Toast ref={toast} />
            <CustomModal
                id="update-user"
                modalButtonCloseName="Close"
                modalButtonSaveName="Save"
                modalTitle="Update User"
                onClickButtonSave={handleUpdateUser}
                modalButtonSaveClassName={clsx(userStyles['user-button__save'])}
            >
                <div className="form-group">
                    <div className="form-group">
                        <label className={clsx(styles['modal-label'])} htmlFor="fullname">Full name</label>
                        <input value={user?.name}
                               onChange={e => dispatch(onChangeUser({name: e.target.value}))}
                               placeholder="Full name..." type="text" id="fullname" className={clsx(styles['modal-input'], "form-control")}/>
                    </div>
                    <div className="form-group">
                        <label className={clsx(styles['modal-label'])} htmlFor="email">Email</label>
                        <input value={user?.email}
                               onChange={e => dispatch(onChangeUser({email: e.target.value}))}
                               placeholder="Email..." type="email" id="email" className={clsx(styles['modal-input'], "form-control")}/>
                    </div>
                    <div className="form-group">
                        <label className={clsx(styles['modal-label'])} htmlFor="username">User name</label>
                        <input value={user?.userName}
                               onChange={e => dispatch(onChangeUser({userName: e.target.value}))}
                               placeholder="User name..." type="text" className={clsx(styles['modal-input'], "form-control")}/>
                    </div>
                </div>
            </CustomModal>
        </>
    );
}

export default UserUpdateModal;