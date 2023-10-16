import { AppState } from "../AppState.js"
import { Favorite } from "../models/Favorite.js"
// FIXME re-import
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class FavoritesService {
    // STUB Create Favorite
    async createFavorite(favoriteData) {
        const response = await api.post('api/favorites', favoriteData)
        logger.log(response.data)
        const newFavorite = new Favorite(response.data)
        AppState.favorites.unshift(newFavorite)
        return newFavorite
    }

    // STUB Get Favorite
    // async getFavorites() {
    //     const response = await api.get('api/favorites')
    //     logger.log('[GOT FAVORITES]', response.data)
    //     AppState.favorites = response.data.map(favorite => new Favorite(favorite))
    // }

    // STUB Delete Favorite
    async archiveResponse(favoriteId) {
        const response = await api.delete(`api/favorites/${favoriteId}`)
        logger.log('[DELETED FAVORITE]', response.data)
        // FIXME NEED TO ADD TO OR MAKE WTIH A PUSH OR SOMETHNG
    }


}
export const favoritesService = new FavoritesService()