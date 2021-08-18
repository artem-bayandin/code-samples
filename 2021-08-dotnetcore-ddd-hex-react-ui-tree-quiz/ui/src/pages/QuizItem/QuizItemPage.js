import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { useParams } from 'react-router-dom'
import './QuizItemPage.css'
import { QuizTreeComponent } from '../../components'
import { fetchQuizById } from '../../redux-toolkit-store'

export const QuizItemPage = () => {
    const quiz = useSelector(state => state.quizzes.quiz)
    const dispatch = useDispatch()
    const { id } = useParams();

    useEffect(() => {
        dispatch(fetchQuizById(id))
    }, [])

    return (
        <div className="answers-item-page">
            { quiz && <QuizTreeComponent quiz={quiz} /> }
        </div>
    )
}