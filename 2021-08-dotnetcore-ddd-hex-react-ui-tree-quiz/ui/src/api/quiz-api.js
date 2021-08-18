const quizzes = [{
    id: 2,
    name: 'Yes / No',
    root: {
        'id':3,
        'text':`Do you want to start?`,
        'children':[
            {
                'relation':`yes`,
                'node':{
                    'id':4,
                    'text':`second step if yes`,
                    'children':[]
                }
            },
            {
                'relation':`no`,
                'node':{
                    'id':5,
                    'text':`Yeah! Thanks for not playing!`
                }
            }
        ]
    } 
}, {
    id: 6,
    name: 'Multi nodes',
    root: {
        'id':7,
        'text':`Do you want to start?`,
        'children':[
            {
                'relation':`yes`,
                'node':{
                    'id':8,
                    'text':`second step if yes`,
                    'children':[
                        
                    ]
                }
            },
            {
                'relation':`no`,
                'node':{
                    'id':9,
                    'text':`Yeah! Thanks for not playing!`
                }
            },
            {
                'relation':`not sure`,
                'node':{
                    'id':10,
                    'text':`Hmm... Are you a human?`,
                    'children':[
                        {
                            'relation':`not sure`,
                            'node':{
                                'id':11,
                                'text':`You have chosen the right one.`
                            }
                        },
                        {
                            'relation':`not sure`,
                            'node':{
                                'id':12,
                                'text':`You have chosen the left one.`
                            }
                        }
                    ]
                }
            }
        ]
    }
}]

export const quizApi = {
    fetchQuizzes: async () => {
        return quizzes.map(quiz => {
            return {
                id: +quiz.id,
                name: quiz.name
            }
        })
    },
    fetchQuizById: async (quizId) => {
        return quizzes.find(quiz => quiz.id == quizId)
    }
}