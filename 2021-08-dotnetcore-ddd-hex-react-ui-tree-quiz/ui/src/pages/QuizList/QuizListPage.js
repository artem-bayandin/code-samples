import React from 'react'
import './QuizListPage.css'
import { QuizListComponent } from '../../components'

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
            <QuizListComponent
                header="Choose a quiz to play"
                items={quizzes}
                play />
        </div>
    )
}