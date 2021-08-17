import React from 'react'
import './QuizTreeComponent.css'
import { QuizTreeNodeComponent } from './QuizTreeNode/QuizTreeNodeComponent'

export const QuizTreeComponent = props => {
    const { quiz, answers } = props
    const label = answers && answers.length
        ? `Your answers to a quiz '${quiz.id} : ${quiz.name}'`
        : `Quiz '${quiz.name}' tree`
    return (
        <div className='quiz-tree-container'>
            <div className='header'>{label}</div>
            <QuizTreeNodeComponent node={quiz.root} answers={answers} />
        </div>
    )
}