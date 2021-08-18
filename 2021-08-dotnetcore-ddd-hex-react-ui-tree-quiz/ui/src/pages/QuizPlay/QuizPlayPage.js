import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { useParams } from 'react-router-dom'
import './QuizPlayPage.css'
import { QuizGameContainer } from '../../containers/QuizGame/QuizGameContainer'
import { fetchQuizById } from '../../redux-toolkit-store'

export const QuizPlayPage = () => {
    const quiz = useSelector(state => state.quizzes.quiz)
    const dispatch = useDispatch()
    const { id } = useParams();

    useEffect(() => {
        dispatch(fetchQuizById(id))
    }, [])

    return (
        <>{ quiz && <QuizGameContainer quiz={quiz} /> }</>
    )
}