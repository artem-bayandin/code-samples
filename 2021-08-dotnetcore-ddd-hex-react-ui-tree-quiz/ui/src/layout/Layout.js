import React from 'react'

export const Layout = (props) => {
    return (
        <>
            <main>
                {props.children}
            </main>
        </>
    )
}