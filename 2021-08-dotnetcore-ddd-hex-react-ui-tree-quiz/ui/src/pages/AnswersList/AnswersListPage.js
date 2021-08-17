import React from 'react'
import './AnswersListPage.css'
import { QuizListComponent } from '../../components'

export const AnswersListPage = () => {
    const quizzes = [{
        id: 3,
        name: 'third'
    }, {
        id: 4,
        name: 'fourth'
    }]
    return (
        <div className="answers-list-page">
            <QuizListComponent
                header="Choose a quiz to view answers"
                items={quizzes}
                answers />
        </div>
    )
}