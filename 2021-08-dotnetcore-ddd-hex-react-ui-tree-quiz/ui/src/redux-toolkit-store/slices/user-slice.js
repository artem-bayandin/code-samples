import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'
import { userApi } from '../../api'

const LS_USER_ID = 'USER_ID'

const setUserIdToStorage = userId => {
    localStorage.setItem(LS_USER_ID, userId)
}

const getUserIdFromStorage = () => {
    return localStorage.getItem(LS_USER_ID)
}

const createUserAsync = async () => {
    const response = await userApi.createUser()
    // return response.data
    return response
}

const checkUserIdAndCreateUserIfNeeded = createAsyncThunk(
    'user/checkUserIdInStorage',
    async () => {
        let userId = getUserIdFromStorage()
        if (!userId) {
            userId = await createUserAsync()
            setUserIdToStorage(userId)
        }
        return userId
    }
)

const fetchQuizAnswers = createAsyncThunk(
    'user/fetchQuizAnswers',
    async (quizId) => {
        // this seems to be not a good idea, but it is what it is
        const userId = getUserIdFromStorage()
        
        const response = await userApi.fetchQuizAnswers(userId, quizId)
        // return response.data
        return response
    }
)

const saveQuizAnswers = createAsyncThunk(
    'user/saveQuizAnswers',
    async ({quizId, selectedNodes}) => {
        // this seems to be not a good idea, but it is what it is
        const userId = getUserIdFromStorage()
        
        const response = await userApi.saveQuizAnswers(userId, quizId, selectedNodes)
        // return response.data
        return response
    }
)

const userSlice = createSlice({
    name: 'user',
    initialState: {
        userId: null,
        selectedNodes: []
    },
    reducers: {
    },
    extraReducers: builder => {
        builder
            .addCase(fetchQuizAnswers.pending, (state, action) => {
                state.selectedNodes.length = 0
            })
            .addCase(fetchQuizAnswers.fulfilled, (state, action) => {
                // { userId, quizId, selectedNodes }
                state.selectedNodes = action.payload && Array.isArray(action.payload.selectedNodes)
                    ? action.payload.selectedNodes
                    : []
            })
            .addCase(saveQuizAnswers.fulfilled, (state, action) => {
            })
            .addCase(checkUserIdAndCreateUserIfNeeded.fulfilled, (state, action) => {
                state.userId = action.payload
            })
    }
})

const { reducer: userReducer /*, actions: userActions */ } = userSlice
// export const { createUser } = userActions
export { userReducer, fetchQuizAnswers, saveQuizAnswers, checkUserIdAndCreateUserIfNeeded }