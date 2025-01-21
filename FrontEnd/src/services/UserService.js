import FetchAPI from "~/hooks/FetchAPI";

export const getAllUsers = async () => {
    return await FetchAPI({
       url: "api/User",
    });
}

export const handleAddUserService = async (user) => {
    return await FetchAPI({
        url: "api/User",
        method: "POST",
        body: JSON.stringify({
            name: user?.name,
            email: user?.email,
            password: user?.password,
            userName: user?.userName,
        })
    });
}

export const handleUpdateUserService = async (user) => {
    return await FetchAPI({
        url: `api/User/${user?.userId}`,
        method: 'PUT',
        body: JSON.stringify({
            name: user?.name,
            email: user?.email,
            userName: user?.userName,
        })
    })
}

export const handleDeleteUserService = async (id) => {
    return await FetchAPI({
        url: `api/User/${id}`,
        method: 'DELETE',
    });
}