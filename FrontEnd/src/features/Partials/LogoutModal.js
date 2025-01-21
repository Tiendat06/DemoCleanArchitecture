import CustomModal from "~/components/Modal/CustomModal";
import {danger_zone} from '~/assets';
import {CustomButton} from "~/components";
import React, {useCallback, useRef} from "react";
import {handleLogoutService} from "~/services/SiteService";
import {Toast} from "primereact/toast";

function LogoutModal() {
    const toast = useRef(null);
    const handleLogout = useCallback(async () => {
        const data = await handleLogoutService();
        const message = data.message;
        if(data.status === 200) {
            localStorage.removeItem('userData');
            toast.current.show({ severity: 'success', summary: 'Success', detail: message, life: 3000 });
            setTimeout(() => {
                window.location = '/';
            }, 3000);
        }
    }, []);

    return (
        <>
            <Toast ref={toast} />

            <CustomModal
                id='logout-modal'
                isStatic={true}
                modalHeaderClassName='d-none'
                modalFooterClassName='d-none'
                modalDialogClassName='modal-sm'
            >
                <img style={{width: "100%", objectFit: "cover"}} src={danger_zone} alt=""/>
                <div className="d-flex justify-content-center">
                    <CustomButton
                        CustomButtonLink='?'
                    onClick={handleLogout}>
                        Logout
                    </CustomButton>
                </div>
            </CustomModal>
        </>
    );
}

export default LogoutModal;