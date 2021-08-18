import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import './QuizListPage.css'
import { QuizListComponent } from '../../components'
import { fetchQuizzes } from '../../redux-toolkit-store'

export const QuizListPage = () => {
    const quizzes = useSelector(state => state.quizzes.quizzes)
    const dispatch = useDispatch()

    useEffect(() => {
        dispatch(fetchQuizzes())
    }, [])

    return (
        <div className="quiz-list-page">
            <QuizListComponent
                header="Choose a quiz to play"
                items={quizzes}
                play />
        </div>
    )
}