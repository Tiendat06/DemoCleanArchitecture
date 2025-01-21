import clsx from "clsx";
import userStyles from "~/styles/Pages/User/user.module.scss";
import styles from "~/styles/Components/Modal/customModal.module.scss";
import CustomModal from "~/components/Modal/CustomModal";
import {addUser, onChangeUser} from '~/store/User/actions';
import {useUserContext} from "~/context/UserContext";
import React, {useCallback} from "react";
import {handleAddUserService} from "~/services/UserService";
import {Toast} from "primereact/toast";

function UserAddModal() {
    const {user, dispatch, toast} = useUserContext();

    const handleAddUser = useCallback(async () => {
        const data = await handleAddUserService(user);
        const message = data.message;

        if(data.status === 201) {
            dispatch(addUser(data.data));
            toast.current.show({ severity: 'success', summary: 'Success', detail: message, life: 3000 });
        } else{
            toast.current.show({ severity: 'warn', summary: 'Warning', detail: message, life: 3000 })
        }
    }, [user])

    return (
        <>
            <Toast ref={toast} />

            <CustomModal
                id="add-user"
                modalButtonCloseName="Close"
                modalButtonSaveName="Save"
                modalTitle="Add User"
                onClickButtonSave={handleAddUser}
                modalButtonSaveClassName={clsx(userStyles['user-button__save'])}
            >
                <div className="form-group">
                    <div className="form-group">
                        <label className={clsx(styles['modal-label'])} htmlFor="fullname">Full name</label>
                        <input onChange={e => dispatch(onChangeUser({name: e.target.value}))} placeholder="Full name..."
                               type="text" id="fullname" className={clsx(styles['modal-input'], "form-control")}/>
                    </div>
                    <div className="form-group">
                        <label className={clsx(styles['modal-label'])} htmlFor="email">Email</label>
                        <input onChange={e => dispatch(onChangeUser({email: e.target.value}))} placeholder="Email..."
                               type="email" id="email" className={clsx(styles['modal-input'], "form-control")}/>
                    </div>
                    <div className="form-group">
                        <label className={clsx(styles['modal-label'])} htmlFor="username">User name</label>
                        <input onChange={e => dispatch(onChangeUser({userName: e.target.value}))}
                               placeholder="User name..." type="text"
                               id="username"
                               className={clsx(styles['modal-input'], "form-control")}/>
                    </div>
                    <div className="form-group">
                        <label className={clsx(styles['modal-label'])} htmlFor="pwd">Password</label>
                        <input onChange={e => dispatch(onChangeUser({password: e.target.value}))}
                               placeholder="Password..." type="text"
                               id="pwd"
                               className={clsx(styles['modal-input'], "form-control")}/>
                    </div>
                </div>
            </CustomModal>
        </>
    );
}

export default UserAddModal;