import axios from 'axios';


const api = 'api/Policy/';
let configuration = {
    headers: {
        "Authorization": `Bearer ${localStorage.getItem("token")}`
    }
};

const get = async(name) => {
    let apiRequest = api;
    if (name != null)
        apiRequest += name;

    let response = await axios.get(apiRequest, configuration);

    if (response.data.status === 'ZERO_RESULTS')
        throw new Error(`No hay resultados`);

    return response.data;
}

export default {
    get
}