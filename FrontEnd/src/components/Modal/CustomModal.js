import clsx from "clsx";

function CustomModal ({id = '', children = '',
                          isStatic = false,
                          modalTitle = '',
                          modalTitleClassName = '',
                          modalDialogClassName = '',
                          modalContentClassName = '',
                          modalHeaderClassName = '',
                          modalBodyClassName = '',
                          modalFooterClassName = '',
                          modalButtonSaveClassName = '',
                          modalButtonCloseClassName = '',
                          modalButtonSaveName = '',
                          modalButtonCloseName = '',
                          dataBsDisMissModalSaveBtn = '',
                          onClickButtonSave = () => {},
                          onClickButtonClose = () => {},
                      }) {
    return (
        <>
            <div className="modal fade" id={id} data-bs-backdrop={`${isStatic}`} data-bs-keyboard="false"
                 tabIndex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                <div className={clsx("modal-dialog", `${modalDialogClassName}`)}>
                    <div className={clsx("modal-content", `${modalContentClassName}`)}>
                        <div className={clsx("modal-header", `${modalHeaderClassName}`)}>
                            <h5 className={clsx(`modal-title`, `${modalTitleClassName}`)}
                                id="staticBackdropLabel">{modalTitle}</h5>
                            <button type="button" className="btn-close" data-bs-dismiss="modal"
                                    aria-label="Close"></button>
                        </div>
                        <div className={clsx("modal-body", `${modalBodyClassName}`)}>
                            {children}
                        </div>
                        <div className={clsx("modal-footer", `${modalFooterClassName}`)}>
                            <button onClick={onClickButtonClose} type="button" className={clsx("btn btn-secondary", `${modalButtonCloseClassName}`)} data-bs-dismiss="modal">{modalButtonCloseName}</button>
                            <button onClick={onClickButtonSave} type="button" className={clsx("btn btn-primary", `${modalButtonSaveClassName}`)} data-bs-dismiss={dataBsDisMissModalSaveBtn}>{modalButtonSaveName}</button>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}

export default CustomModal;