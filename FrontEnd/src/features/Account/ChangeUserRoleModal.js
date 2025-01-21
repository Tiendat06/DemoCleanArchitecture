import CustomModal from "~/components/Modal/CustomModal";
import {Toast} from "primereact/toast";
import {useAccountContext} from "~/context/AccountContext";
import {handleChangeUserRoleService} from "~/services/AccountService";
import {changeUserRole} from "~/store/Account/actions";
import clsx from "clsx";
import userStyles from "~/styles/Pages/User/user.module.scss";

function ChangeUserRoleModal() {
    const {role, account, dispatch, toast} = useAccountContext();

    const handleChangeUserRole = async () => {
        // accountId, roleId, roleName
        const accountId = account.accountId;
        const roleId = role.roleId;
        const roleName = role.roleName;
        const data = await handleChangeUserRoleService(accountId, roleId);
        const message = data.message;
        if(data.status === 200){
            const user = {accountId, roleId, roleName}
            dispatch(changeUserRole(user));
            toast.current.show({ severity: 'success', summary: 'Success', detail: message, life: 3000 });
        } else{
            toast.current.show({ severity: 'warn', summary: 'Warning', detail: message, life: 3000 })
        }
    }

    return (
        <>
            <Toast ref={toast}></Toast>
            <CustomModal
                id="change-user-role-modal"
                modalButtonSaveName="Save"
                dataBsDisMissModalSaveBtn="modal"
                modalButtonCloseName="Close"
                modalTitle="Set Role"
                onClickButtonSave={handleChangeUserRole}
                modalButtonSaveClassName={clsx(userStyles['user-button__save'])}

            >
                <p className='mb-0'>Are you sure to set role '{role.roleName}' for '{account.name}'</p>
            </CustomModal>
        </>
    );
}

export default ChangeUserRoleModal;