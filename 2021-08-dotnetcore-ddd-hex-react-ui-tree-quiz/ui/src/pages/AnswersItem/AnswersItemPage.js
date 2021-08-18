import React, { useEffect } from 'react'
import { useDispatch, useSelector } from 'react-redux'
import { useParams } from 'react-router-dom'
import './AnswersItemPage.css'
import { QuizTreeComponent } from '../../components'
import { fetchQuizAnswers, fetchQuizById } from '../../redux-toolkit-store'

export const AnswersItemPage = () => {
    const quiz = useSelector(state => state.quizzes.quiz)
    const selectedNodes = useSelector(state => state.users.selectedNodes)
    const dispatch = useDispatch()
    const { id } = useParams();

    useEffect(() => {
        dispatch(fetchQuizById(id))
        dispatch(fetchQuizAnswers(id))
    }, [])

    return (
        <>
            {
                quiz &&
                <div className="answers-item-page">
                    <QuizTreeComponent
                        quiz={quiz}                
                        answers={selectedNodes} />
                </div>
            }
        </>
    )
}