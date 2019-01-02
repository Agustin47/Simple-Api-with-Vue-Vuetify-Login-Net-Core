import axios from 'axios';


const api = 'api/client/';
let configuration = {
    headers: {
        "Authorization": `Bearer ${localStorage.getItem("token")}`
    }
};

const get = async() => {
    let response = await axios.get(api, configuration);

    if (response.data.status === 'ZERO_RESULTS')
        throw new Error(`No hay resultados`);

    return response.data;
}

const update = async(editedItem) => await axios.put(`${api}`, editedItem, configuration);

const create = async(newItem) => await axios.post(`${api}`, newItem, configuration);

const drop = async(id) => await axios.delete(`${api}${id}`, {}, configuration);

export default {
    get,
    update,
    create,
    drop
}