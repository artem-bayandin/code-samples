import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import './AnswersListPage.css'
import { QuizListComponent } from '../../components'
import { fetchQuizzes } from '../../redux-toolkit-store'

export const AnswersListPage = () => {
    const quizzes = useSelector(state => state.quizzes.quizzes)
    const dispatch = useDispatch()

    useEffect(() => {
        dispatch(fetchQuizzes())
    }, [])

    return (
        <div className="answers-list-page">
            <QuizListComponent
                header="Choose a quiz to view answers"
                items={quizzes}
                answers />
        </div>
    )
}