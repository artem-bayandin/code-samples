import { configureStore } from '@reduxjs/toolkit'
import { quizReducer } from './slices/quiz-slice'
import { userReducer } from './slices/user-slice'

export const store = configureStore({
    reducer: {
        quizzes: quizReducer,
        users: userReducer
    }
})