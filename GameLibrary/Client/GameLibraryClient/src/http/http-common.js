import axios from 'axios'

export const HTTP = axios.create({
  baseURL: 'http://localhost:22200/api',
  headers: {
    'crossDomain': true,
    'Accept': 'application/json',
    'Content-Type': 'application/json',
    Authorization: 'Bearer ' + localStorage.getItem('access_token')
  }
})
