import React from 'react'
import './ResultsListPage.css'
import { QuizListContainer } from '../../containers'

export const ResultsListPage = () => {
    const quizzes = [{
        id: 3,
        name: 'third'
    }, {
        id: 4,
        name: 'fourth'
    }]
    return (
        <div className="results-list-page">
            <QuizListContainer
                header="Choose a quiz to view results"
                items={quizzes}
                results />
        </div>
    )
}