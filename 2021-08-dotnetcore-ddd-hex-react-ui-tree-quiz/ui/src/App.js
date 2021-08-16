import React from 'react'

import { RouterConfig } from './navigation/RouterConfig'
import { Layout } from './layout'

const App = (props) => {
    return (
        <>
            <Layout>
                <RouterConfig {...props}/>
            </Layout>
        </>
    )
}

export default App