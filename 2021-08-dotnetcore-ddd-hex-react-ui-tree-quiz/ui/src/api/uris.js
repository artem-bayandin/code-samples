export const BASE_URI = `https://localhost:6001/api/`

const QUIZ = `quiz`
export const GET_QUIZ_LIST = `${QUIZ}/`
export const GET_QUIZ_ITEM = `${QUIZ}/{:id}`

const USER = `user`
export const POST_USER_CREATE = `${USER}/`
export const GET_USER_QUIZ_ANSWERS = `${USER}/{:userId}/quiz/{:quizId}`
export const POST_SAVE_QUIZ_ANSWERS = GET_USER_QUIZ_ANSWERS