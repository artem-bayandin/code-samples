import React from 'react'
import './QuizPlayNodeComponent.css'

export const QuizPlayNodeComponent = ({node, relation, clicked}) => {
    return (
        <div className='quiz-play-node-component link' onClick={() => clicked(node)}>{relation}</div>
    )
}