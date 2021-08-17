import React from 'react'
import { QuizTreeComponent } from '../../components'
import './AnswersItemPage.css'

export const AnswersItemPage = () => {
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
    const answers = [10, 12]

    return (
        <div className="answers-item-page">
            <QuizTreeComponent
                quiz={quiz}                
                answers={answers} />
        </div>
    )
}