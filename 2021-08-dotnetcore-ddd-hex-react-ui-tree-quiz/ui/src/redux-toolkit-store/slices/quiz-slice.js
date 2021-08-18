import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import { quizApi } from '../../api'

const fetchQuizzes = createAsyncThunk(
    'quiz/fetchQuizzes',
    async () => {
        const response = await quizApi.fetchQuizzes()
        // return response.data
        return response
    }
)

const fetchQuizById = createAsyncThunk(
    'quiz/fetchQuizById',
    async (quizId) => {
        const response = await quizApi.fetchQuizById(quizId)
        // return response.data
        return response
    }
)

const quizSlice = createSlice({
    name: 'quiz',
    initialState: {
        quizzes: [],
        quiz: null
    },
    reducers: {
    },
    extraReducers: builder => {
        builder
            .addCase(fetchQuizzes.pending, (state, action) => {
                state.quizzes.length = 0
            })
            .addCase(fetchQuizzes.fulfilled, (state, action) => {
                state.quizzes = action.payload
            })
            .addCase(fetchQuizById.pending, (state, action) => {
                state.quiz = null
            })
            .addCase(fetchQuizById.fulfilled, (state, action) => {
                state.quiz = action.payload
            })
    }
})

const { reducer: quizReducer /*, actions: quizActions*/ } = quizSlice
// export const { fetchQuizzes } = quizActions
export { quizReducer, fetchQuizzes, fetchQuizById }