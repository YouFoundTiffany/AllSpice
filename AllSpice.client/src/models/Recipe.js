


export const RecipeSchema = new Schema({
    title: { type: String, required: true, maxLength: 75, minLength: 3 },
    coverImg: { type: String, required: true, maxLength: 250, minLength: 3 },
    category: { type: String, enum: ['cats', 'dogs', 'games', 'gachamon', 'animals', 'misc'], required: true, default: 'misc' },
    creatorId: { type: Schema.Types.ObjectId, required: true, ref: 'Account' }
    archived: { type: Boolean, default: false },
},
    { timestamps: true, toJSON: { virtuals: true } })