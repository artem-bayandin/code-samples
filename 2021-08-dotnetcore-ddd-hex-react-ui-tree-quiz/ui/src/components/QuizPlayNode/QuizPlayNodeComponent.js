import React from 'react'
import './QuizPlayNodeComponent.css'

export const QuizPlayNodeComponent = ({node, relation, clicked}) => {
    return (
        <div onClick={() => clicked(node)}>{relation}</div>
    )
}