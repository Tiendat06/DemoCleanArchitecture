import FetchAPI from "~/hooks/FetchAPI";

export const handleChangeUserRoleService = async (accountId, roleId) => {
    return await FetchAPI({
        url: 'api/Account/change-role',
        method: 'POST',
        body: JSON.stringify({
            accountId, roleId
        }),
    })
}

export const getAllRolesService = async () => {
    return await FetchAPI({
        url: 'api/Role',
    });
}

export const handleResetPasswordService = async (accountId) => {
    return await FetchAPI({
        url: 'api/Account/reset-password',
        method: 'POST',
        body: JSON.stringify({
            accountId
        })
    });
}