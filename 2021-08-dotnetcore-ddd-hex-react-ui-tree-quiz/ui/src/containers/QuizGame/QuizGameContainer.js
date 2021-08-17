import React, { useState } from 'react'
import './QuizGameContainer.css'
import { GameOverContainer } from './GameOver/GameOverContainer'
import { QuizPlayNodeComponent } from '../../components'

export const QuizGameContainer = ({quiz}) => {
    const [currentNode, setCurrentNode] = useState(quiz.root)
    const [answers, setAnswers] = useState([])
    const [currentQuestion, setCurrentQuestion] = useState(<>{currentNode.text}</>)

    const nodeClicked = node => {
        setCurrentNode({...node})
        setAnswers([...answers, node.id])
        if (node.children && node.children.length) {
            setCurrentQuestion(<>{node.text}</>)
        } else {
            setCurrentQuestion(null)
        }
    }

    return (
        <div className="quiz-play-page">
            <div className="quiz-name">{quiz.name}</div>
            <div className="current-node">
                { currentQuestion }
                {
                    currentNode.children
                        && currentNode.children.length
                        && currentNode.children.map(item => 
                            <QuizPlayNodeComponent
                                key={item.node.id}
                                node={item.node}
                                relation={item.relation}
                                clicked={nodeClicked}
                            />
                        )

                }
                {
                    (!currentNode.children || !currentNode.children.length)
                        && <GameOverContainer
                                quizId={quiz.id}
                                result={currentNode.text}
                                answers={answers}
                            />
                }
            </div>
        </div>
    )
}