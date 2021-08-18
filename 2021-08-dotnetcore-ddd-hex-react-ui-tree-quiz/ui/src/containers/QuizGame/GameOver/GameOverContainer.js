import React from 'react'
import { useDispatch } from 'react-redux'
import { useHistory } from 'react-router-dom'
import { saveQuizAnswers } from '../../../redux-toolkit-store'
import { Routes } from '../../../navigation'

export const GameOverContainer = ({quizId, result, answers}) => {
    const dispatch = useDispatch()
    const history = useHistory()

    const goHome = () => {
        history.push(Routes.ROOT)
    }

    const viewResults = () => {
        history.push(`${Routes.ANSWERS_LIST}/${quizId}`)
    }

    const saveResults = () => {
        dispatch(saveQuizAnswers({quizId, selectedNodes: answers}))
            .then(() => {
                viewResults()
            })
    }

    return (
        <>
            <div>game over, your result: {result}</div>
            <div>do you want to save results?</div>
            <div>
                <span onClick={() => saveResults()}>yes</span>
                <span onClick={() => goHome()}>no</span>
            </div>
        </>
    )
}