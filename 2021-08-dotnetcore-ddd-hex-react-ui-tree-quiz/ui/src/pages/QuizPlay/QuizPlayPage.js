import { QuizGameContainer } from '../../containers/QuizGame/QuizGameContainer'
import './QuizPlayPage.css'

export const QuizPlayPage = () => {
    const quiz = {
        id: 1,
        name: 'some name',
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
    }

    return (
        <QuizGameContainer quiz={quiz} />
    )
}