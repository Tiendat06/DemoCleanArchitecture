import React, { useRef } from 'react';
import { Button } from 'primereact/button';
import { Toast } from 'primereact/toast';

function CustomToast() {


    return (
        <>
            <Toast ref={toast} />
            {/*<Button onClick={show} label="Show" />*/}
        </>
    );
}

export default CustomToast;