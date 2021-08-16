import axios from 'axios'

import { BASE_URI } from './uris'

export const localAxios = axios.create({baseURL: BASE_URI})