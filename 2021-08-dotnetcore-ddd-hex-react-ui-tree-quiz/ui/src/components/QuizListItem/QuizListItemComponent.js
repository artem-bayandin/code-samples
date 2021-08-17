import React from 'react'
import './QuizListItem.css'
import { Link } from 'react-router-dom'
import { routes } from '../../navigation'

export const QuizListItemComponent = (props) => {
    const { itemId, name } = props
    return (
        <div className="quiz-list-item">
            <span>Id: {itemId}</span>
            <span>Name: {name}</span>
            {
                props.view && (
                    <Link to={`${routes.QUIZ_LIST}/${itemId}`}>view</Link>
                )
            }
            {
                props.play && (
                    <Link to={`${routes.QUIZ_LIST}/${itemId}/${routes.PART_QUIZ_PLAY}`}>play</Link>
                )
            }
            {
                props.results && (
                    <Link to={`${routes.RESULTS_LIST}/${itemId}`}>results</Link>
                )
            }
        </div>
    )
}