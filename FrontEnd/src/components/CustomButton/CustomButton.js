import styles from '~/styles/Components/Button/button.module.scss';
import clsx from "clsx";
import {memo} from "react";
import {Link} from "react-router-dom";

function CustomButton({ children, onClick, CustomButtonClassName='',
                          CustomButtonLink = '', dataBsToggle = '', dataBsTarget = '' }) {
    return (
        <>
            <Link to={CustomButtonLink}>
                <button onClick={onClick} data-bs-target={dataBsTarget} data-bs-toggle={dataBsToggle} className={clsx(styles['button-default-1'], `${CustomButtonClassName}`)}>
                    {children}
                </button>
            </Link>
        </>
    );
}

export default memo(CustomButton);