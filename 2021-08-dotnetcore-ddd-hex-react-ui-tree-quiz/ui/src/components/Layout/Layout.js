import React from 'react'
import { Footer } from './Footer/Footer'
import { Header } from './Header/Header'
import './Layout.css'

export const Layout = (props) => {
    return (
        <>
            <Header />
            <main>
                {props.children}
            </main>
            <Footer />
        </>
    )
}