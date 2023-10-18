export class Favorite {
    constructor(data) {

        this.id = data.id
        this.accountId = data.accountId
        this.recipeId = data.recipeId
    }
}


// {
//    X "favoriteId": 5,
//    X     "accountId": "65303e16eb30414cdaea8c44",
//      x       "id": 2,
//                 "title": "The Senior Jake Burrito",
//                     "instructions": "Take your burrito and cook it, then add hotdog.  Boom, Burrito.",
//                         "img": "https://images.unsplash.com/photo-1584031036380-3fb6f2d51880?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=900&q=80",
//                             "category": "Mexican",
//                                 "creatorId": "652adee5b67e85d46a338d15",
//                                     "archived": false,
//                                         "creator": null
// }