import CustomModal from "~/components/Modal/CustomModal";
import clsx from "clsx";
import userStyles from "~/styles/Pages/User/user.module.scss";
import {useUserContext} from "~/context/UserContext";
import {useCallback} from "react";
import {handleDeleteUserService} from "~/services/UserService";
import {deleteUser} from "~/store/User/actions";
import {Toast} from "primereact/toast";

function UserDeleteModal() {
    const {user, dispatch, toast} = useUserContext();

    const handleDeleteUser = useCallback(async () => {
        console.log(user);
        console.log(user?.userId);
        const data = await handleDeleteUserService(user?.userId);
        const message = data.message;
        console.log(data);
        if(data.status === 200) {
            toast.current.show({ severity: 'success', summary: 'Success', detail: message, life: 3000 });
            dispatch(deleteUser(user?.userId));
        } else{
            toast.current.show({ severity: 'warn', summary: 'Warning', detail: message, life: 3000 })
        }
    }, [user]);
    
    return (
        <>
            <Toast ref={toast} />
            <CustomModal
                id="delete-user"
                modalButtonCloseName="Close"
                modalButtonSaveName="Save"
                modalTitle="Delete User"
                modalButtonSaveClassName={clsx(userStyles['user-button__save'])}
                dataBsDisMissModalSaveBtn="modal"
                onClickButtonSave={handleDeleteUser}
            >
                <p className="mb-0">Are you sure to delete user '{user?.name}' ?</p>
            </CustomModal>
        </>
    );
}

export default UserDeleteModal;