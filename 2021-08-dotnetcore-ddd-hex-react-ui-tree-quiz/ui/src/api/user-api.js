import { localAxios as axios } from './local-axios'

export const userApi = {
    fetchQuizAnswers: async (userId, quizId) =>{
        const response = await axios.get(`user/${userId}/quiz/${quizId}`)
        return response.data
    },
    saveQuizAnswers: async (userId, quizId, selectedNodes) => {
       await axios.post(`user/${userId}/quiz/${quizId}`, selectedNodes)
    },
    createUser: async () => {
        const response = await axios.post('user')
        return response.data
    }
}