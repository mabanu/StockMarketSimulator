import {useEffect, useState} from "react";

enum Order {
    Sale, Buy
}

interface User {
    name: string,
    stock: string,
    order: Order,
    quantity: number
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
            {data?.map((user, index) => <div key={index}>{user.name} {Order[user.order]}</div>)}
        </>
    )
}

export default UsersData;