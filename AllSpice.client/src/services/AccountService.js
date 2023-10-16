import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Favorite } from '../models/Favorite.js'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop'
import { api } from './AxiosService'


class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getMyFavorites() {
    try {
      const response = await api.get('account/favorites')
      logger.log('[MY FAVORITES]', response.data)
      AppState.getMyFavorites = response.data.map(favorite => new Favorite(favorite))
    } catch (error) {
      Pop.error(error)
    }
  }
}

export const accountService = new AccountService()
