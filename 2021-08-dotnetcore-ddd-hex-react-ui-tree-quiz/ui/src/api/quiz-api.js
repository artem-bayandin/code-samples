import { localAxios as axios } from './local-axios'

export const quizApi = {
    fetchQuizzes: async () => {
        const response = await axios.get('quiz')
        return response.data
    },
    fetchQuizById: async (quizId) => {
        const response = await axios.get(`quiz/${quizId}`)
        return response.data
    }
}