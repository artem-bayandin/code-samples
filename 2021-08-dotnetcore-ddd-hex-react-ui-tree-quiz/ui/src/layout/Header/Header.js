import React from 'react'
import { Link } from 'react-router-dom'
import { routes } from '../../navigation'
import './Header.css'

export const Header = () => {
    return (
        <header>
            <Link to={routes.ROOT}>home</Link>
            <Link to={routes.QUIZ_LIST}>quizzes</Link>
            <Link to={routes.RESULTS_LIST}>results</Link>
        </header>
    )
}