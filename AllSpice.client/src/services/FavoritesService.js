import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class FavoritesService {
    // STUB Create Favorite
    async createFavorite(favoriteData) {
        const response = await api.post('api/favorites', favoriteData)
        logger.log('[CREATED FAVORITE]', response.data)
        AppState.activeRecipeFavorites.push(new Favorite(response.data))
        AppState.myFavorites

    }

    // STUB Get All Favorites
    async getFavorites() {
        const response = await api.get('api/favorites')
        logger.log('[GOT FAVORITES]', response.data)
        AppState.favorites = response.data.map(favorite => new Favorite(favorite))
    }

    // STUB Remove Favorite
    async removeFavorite(favoriteId) {
        const response = await api.delete(`api/favorites/${favoriteId}`)
        logger.log('[REMOVE FAVORITE]', response.data)
        let indexToRemove = AppState.activeAlbumCollaborators.findIndex(favorite => favorite.id == favoriteId)
        AppState.activeRecipeFavorites.splice(indexToRemove, 1)
    }

    // STUB Get Favorite
    async getMyFavorites() {
        const response = await api.get('account/favorites')
        logger.log('[GOT FAVORITES]', response.data)
        AppState.myFavorites = response.data
        // .map(favorite => new Favorite(favorite))
    }

    // STUB Delete Favorite
    async archiveResponse(favoriteId) {
        const response = await api.delete(`api/favorites/${favoriteId}`)
        logger.log('[DELETED FAVORITE]', response.data)
        // FIXME NEED TO ADD TO OR MAKE WTIH A PUSH OR SOMETHNG
    }


}
export const favoritesService = new FavoritesService()