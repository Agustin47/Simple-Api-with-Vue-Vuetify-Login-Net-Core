import axios from 'axios';

const api = 'api/login/';

const login = async(usuario) => await axios.post(`${api}`, usuario);


export default {
    login
}