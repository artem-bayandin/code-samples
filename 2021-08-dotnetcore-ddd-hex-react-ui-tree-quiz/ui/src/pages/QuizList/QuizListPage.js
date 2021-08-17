import React from 'react'
import './QuizListPage.css'
import { QuizListContainer } from '../../containers'

export const QuizListPage = () => {
    const quizzes = [{
        id: 1,
        name: 'first'
    }, {
        id: 2,
        name: 'second'
    }]
    return (
        <div className="quiz-list-page">
            <QuizListContainer
                header="Choose a quiz to play"
                items={quizzes}
                play />
        </div>
    )
}