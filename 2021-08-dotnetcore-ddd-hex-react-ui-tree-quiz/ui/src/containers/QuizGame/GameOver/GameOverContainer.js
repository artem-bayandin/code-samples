import React from 'react'

export const GameOverContainer = ({quizId, result, answers}) => {
    return (
        <>
            <div>game over, your result: {result}</div>
            <div>do you want to save results?</div>
        </>
    )
}