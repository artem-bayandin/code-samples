import React from 'react'
import { Link } from 'react-router-dom'
import { Routes } from '../../../navigation'
import './Header.css'

export const Header = () => {
    return (
        <header>
            <Link to={Routes.ROOT}>home</Link>
            <Link to={Routes.QUIZ_LIST}>quizzes</Link>
            <Link to={Routes.ANSWERS_LIST}>answers</Link>
        </header>
    )
}