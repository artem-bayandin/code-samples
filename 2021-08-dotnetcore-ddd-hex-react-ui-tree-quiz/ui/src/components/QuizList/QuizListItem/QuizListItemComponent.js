import React from 'react'
import './QuizListItemComponent.css'
import { Link } from 'react-router-dom'
import { Routes } from '../../../navigation'

export const QuizListItemComponent = (props) => {
    const { itemId, name } = props
    return (
        <div className="quiz-list-item">
            <span>Id: {itemId}</span>
            <span>Name: {name}</span>
            {
                props.view && (
                    <Link to={`${Routes.QUIZ_LIST}/${itemId}`}>view</Link>
                )
            }
            {
                props.play && (
                    <Link to={`${Routes.QUIZ_LIST}/${itemId}/${Routes.PART_QUIZ_PLAY}`}>play</Link>
                )
            }
            {
                props.answers && (
                    <Link to={`${Routes.ANSWERS_LIST}/${itemId}`}>answers</Link>
                )
            }
        </div>
    )
}