import styles from "~/styles/Partials/Footer/footer.module.scss";
import clsx from "clsx";

function Footer() {
    const currentYear = new Date().getFullYear();
    return (
        <>
            <footer className={clsx(styles["footer"])}>
                <p className={clsx(styles["footer-text"])}>
                    &copy; Copyright {currentYear} - DatTT103.
                </p>
            </footer>
        </>
    )
}

export default Footer;