export const logger = store => {
    return next => {
        return action => {
            console.log('[Middleware] dispatching', action)
            const result = next(action)
            console.log('[Middleware] new state', store.getState())
            return result
        }
    }
}