
async function FetchAPI({
    url='',
    method='GET',
    body = null,
    headers = {
        'Content-Type': 'application/json',
    },
    credentials = 'include',
    }) {

    const api_url = process.env.REACT_APP_API_URL;

    const options = {
        method,
        headers,
        credentials,
    }

    if (['POST', 'PUT', 'PATCH', 'DELETE'].includes(method.toUpperCase()) && body) {
        options.body = body;
    }

    try {
        const response = await fetch(`${api_url}/${url}`, options);
        // Token expired
        if (response.status === 401) {
            localStorage.removeItem('userData');
            setTimeout(() => {
                window.location = '/'
            }, 3000);
            return {
                status: 401,
                message: 'Token Expired !'
            };
        }
        return response.json();
    } catch (e) {
        localStorage.removeItem('userData');
        window.location = '/';
        console.log(e.message);
    }
}

export default FetchAPI;