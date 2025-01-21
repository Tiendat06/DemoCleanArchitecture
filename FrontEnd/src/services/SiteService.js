import FetchAPI from "~/hooks/FetchAPI";

export const handleLoginFormService = async (loginInformation) => {
    const {email, password} = loginInformation;
    return await FetchAPI({
        url: 'api/Auth/login',
        method: 'POST',
        body: JSON.stringify({
            email,
            password,
        })
    });
}

export const handleLogoutService = async () => {
    return await FetchAPI({
        url: 'api/Auth/logout',
    });
}