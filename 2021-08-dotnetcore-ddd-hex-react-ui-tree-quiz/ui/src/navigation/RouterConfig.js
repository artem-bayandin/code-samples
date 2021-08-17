import React from 'react'
import { Switch, Route } from 'react-router'

import * as routes from './route-constants'
import * as pages from '../pages'
import { NotFound } from './NotFound/NotFound'

export const RouterConfig = () => {
    return (
        <Switch>
            <Route exact path={routes.ROOT} render={(props) => <pages.IndexPage {...props} />} />
            <Route exact path={routes.QUIZ_LIST} render={(props) => <pages.QuizListPage {...props} />} />
            <Route exact path={routes.QUIZ_ITEM} render={(props) => <pages.QuizItemPage {...props} />} />
            <Route exact path={routes.QUIZ_ITEM_PLAY} render={(props) => <pages.QuizPlayPage {...props} />} />
            <Route exact path={routes.RESULTS_LIST} render={(props) => <pages.ResultsListPage {...props} />} />
            <Route exact path={routes.RESULTS_ITEM} render={(props) => <pages.ResultsItemPage {...props} />} />
            <Route path="*" component={NotFound} />
        </Switch>
    )
}