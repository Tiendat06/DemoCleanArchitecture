import CustomModal from "~/components/Modal/CustomModal";
import {useAccountContext} from "~/context/AccountContext";
import clsx from "clsx";
import userStyles from "~/styles/Pages/User/user.module.scss";
import {useCallback} from "react";
import {handleResetPasswordService} from "~/services/AccountService";
import {Toast} from "primereact/toast";

function ResetPasswordModal() {
    const {account, toast} = useAccountContext();

    const handleResetPassword = useCallback(async () => {
        // console.log(account.accountId);
        const data = await handleResetPasswordService(account.accountId);
        const message = data.message;
        if(data.status === 200){
            toast.current.show({ severity: 'success', summary: 'Success', detail: message, life: 3000 });
        } else{
            toast.current.show({ severity: 'warn', summary: 'Warning', detail: message, life: 3000 })
        }
    }, [account]);

    return (
        <>
            <Toast ref={toast} />
            <CustomModal
            id='reset-password'
            modalTitle='Reset Password'
            modalButtonSaveName='Reset'
            modalButtonCloseName='Close'
            onClickButtonSave={handleResetPassword}
            modalButtonSaveClassName={clsx(userStyles['user-button__save'])}

            >
                <p className='mb-0'>Are you sure to reset {account.name}'s password?</p>
            </CustomModal>
        </>
    );
}

export default ResetPasswordModal;