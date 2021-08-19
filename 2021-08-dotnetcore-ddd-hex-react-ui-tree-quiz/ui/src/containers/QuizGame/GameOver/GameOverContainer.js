import React from 'react'
import { useDispatch } from 'react-redux'
import { useHistory } from 'react-router-dom'
import { saveQuizAnswers } from '../../../redux-toolkit-store'
import { Routes } from '../../../navigation'
import './GameOverContainer.css'

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
        <div className='game-over'>
            <div className='header'>
                <span className='result'>{result}</span></div>
            <div className='ask-to-save'>That's the end. Do you want to save your results?</div>
            <div className='choice-container'>
                <span className='link' onClick={() => saveResults()}>yes</span>
                <span className='link' onClick={() => goHome()}>no</span>
            </div>
        </div>
    )
}