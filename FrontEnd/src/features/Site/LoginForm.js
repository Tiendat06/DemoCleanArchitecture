import clsx from "clsx";
import React, {useCallback, useRef, useState} from "react";
import styles from "~/styles/Pages/Site/login.module.scss";
import {CustomButton} from "~/components";
import {handleLoginFormService} from "~/services/SiteService";
import {Toast} from "primereact/toast";

function LoginForm() {
    const toast = useRef(null);

    const [loginInformation, setLoginInformation] = useState({
        email: "",
        password: "",
    });

    const handleLoginForm = useCallback(async () => {
        const data = await handleLoginFormService(loginInformation);
        const msg = data.message;
        const user = data.data;
        if (data.status === 200) {
            toast.current.show({ severity: 'success', summary: 'Success', detail: 'Login Successfully', life: 3000 });
            setTimeout(() => {
                localStorage.setItem("userData", JSON.stringify(user));
                window.location = '/dashboard/user';
            }, 3000)
        } else{
            toast.current.show({ severity: 'warn', summary: 'Warning', detail: msg, life: 3000 })
        }
    }, [loginInformation]);

    return (
        <>
            <div className={clsx(styles["login-right__form"], 'col-lg-5 col-md-5 col-sm-5')}>
                <div className={clsx(styles['login-right__form-item'])}>
                    <label htmlFor="email"
                           className={clsx(styles["login-right__label"], 'col-lg-12 col-md-12 col-sm-12')}>
                        Email
                    </label>
                    <input value={loginInformation.email}
                           onChange={e => setLoginInformation({...loginInformation, email: e.target.value})}
                           placeholder="Enter email..." type="email" id="email"
                           className={clsx(styles["login-right__inp"], 'form-control col-lg-12 col-md-12 col-sm-12')}/>
                </div>

                <div className={clsx(styles['login-right__form-item'])}>
                    <label htmlFor="email"
                           className={clsx(styles["login-right__label"], 'col-lg-12 col-md-12 col-sm-12')}>
                        Password
                    </label>
                    <input value={loginInformation.password}
                           onChange={e => setLoginInformation({...loginInformation, password: e.target.value})}
                           placeholder="Enter password..." type="email" id="email"
                           className={clsx(styles["login-right__inp"], 'form-control col-lg-12 col-md-12 col-sm-12')}/>
                </div>

                <div className={clsx(styles['login-right__form-btn'])}>
                    <Toast ref={toast} />

                    <CustomButton
                        onClick={handleLoginForm}
                        CustomButtonClassName={styles["login-right__form-btn--inner"]}
                    >
                        Login
                    </CustomButton>
                </div>
            </div>
        </>
    );
}

export default LoginForm;