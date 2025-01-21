import clsx from "clsx";
import styles from '~/styles/Pages/Site/login.module.scss';
import {FPT_Telecom_logo, fpt_services} from '~/assets';
import {LoginProvider} from "~/context/LoginContext";
import {LoginForm} from "~/features/Site";

function LoginPage () {
    return (
        <>
            <LoginProvider>
                <div className={clsx(styles["login"])}>
                    <div className={clsx(styles["login-left"], 'col-lg-6 col-md-6 col-sm-6')}>
                        <img src={fpt_services} className={clsx(styles["login-left__img"])} alt=""/>
                    </div>

                    <div className={clsx(styles["login-right"], 'col-lg-6 col-md-6 col-sm-6')}>
                        <div className="col-lg-12 col-md-12 col-sm-12 text-center">
                            <img src={FPT_Telecom_logo} className={clsx(styles["login-right__logo"])} alt=""/>
                        </div>
                        <LoginForm />
                    </div>
                </div>
            </LoginProvider>
        </>
    );
}

export default LoginPage;