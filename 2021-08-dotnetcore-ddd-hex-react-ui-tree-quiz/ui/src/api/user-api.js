const user = {
    id: 'EF2D18ED-883E-442F-B1D8-9830825395B2'
}

const userAnswers = [{
    userId: user.id,
    quizId: 6,
    selectedNodes: [10, 12]
}]


export const userApi = {
    fetchQuizAnswers: async (userId, quizId) =>{
        return userAnswers.find(x => x.userId === userId && x.quizId == quizId)
    },
    saveQuizAnswers: async (userId, quizId, selectedNodes) => {
        // this does not return anything

        // but update some data
        const exist = userAnswers.find(x => x.userId === userId && x.quizId == quizId)
        if (exist) {
            exist.selectedNodes = selectedNodes
        } else {
            userAnswers.push({
                userId,
                quizId: +quizId,
                selectedNodes
            })
        }

        return;
    },
    createUser: async () => {
        return user.id
    }
}