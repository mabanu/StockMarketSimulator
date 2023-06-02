import {useEffect, useState} from "react";

interface User {
    name: string,
}

function UsersData() {
    const [data, setData] = useState<User[]>([]);

    useEffect(() => {
        fetch("user")
            .then(response => response.json())
            .then(json => setData(json))
            .catch(() => "FUCK");
    }, []);

    return (
        <>
            {data?.map((user, index) => <div key={index}>{user.name}</div>)}
        </>
    )
}

export default UsersData;