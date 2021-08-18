import React, { useState } from 'react'
import './QuizGameContainer.css'
import { GameOverContainer } from './GameOver/GameOverContainer'
import { QuizPlayNodeComponent } from '../../components'

export const QuizGameContainer = ({quiz}) => {
    const wrapCurrentQuestion = text => {
        return (
            <div className='question'>{text}</div>
        )
    }

    const [currentNode, setCurrentNode] = useState(quiz.root)
    const [answers, setAnswers] = useState([])
    const [currentQuestion, setCurrentQuestion] = useState(wrapCurrentQuestion(currentNode.text))

    const nodeClicked = node => {
        setCurrentNode({...node})
        setAnswers([...answers, node.id])
        if (node.children && node.children.length) {
            setCurrentQuestion(wrapCurrentQuestion(node.text))
        } else {
            setCurrentQuestion(null)
        }
    }

    return (
        <div className="quiz-play-page">
            <div className="quiz-name">{quiz.name}</div>
            <div className="current-node">
                {currentQuestion}
                {
                    currentNode.children
                        && currentNode.children.length
                        && <div className='options'>
                            {
                                currentNode.children.map(item => 
                                    <QuizPlayNodeComponent
                                        key={item.node.id}
                                        node={item.node}
                                        relation={item.relation}
                                        clicked={nodeClicked}
                                    />
                                )
                            }
                        </div>

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