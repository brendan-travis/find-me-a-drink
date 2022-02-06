export enum Category {
    "Bar Reviews",
    "Pub Reviews",
    "Closed Venues",
    "Other Reviews",
    "Uncategorized"
}

export enum Tag {
    "arcade games",
    "beer garden",
    "breakfast",
    "coffee",
    "dance floor",
    "darts",
    "food",
    "free wifi",
    "jukebox",
    "karaoke",
    "lgbt",
    "live music",
    "membership discount",
    "pool table",
    "quiz",
    "sofas",
    "sports",
    "sunday roasts",
}

export interface IRating {
    beer: number,
    atmosphere: number,
    amenities: number,
    value: number
}

export interface ILocation {
    address: string,
    category: Category,
    date: Date,
    excerpt: string,
    latitude: number,
    longitude: number,
    name: string,
    phone: string,
    rating: IRating,
    tags: string[],
    thumbnail: string,
    twitter: string,
    url: string
}

export interface ILocationResponse {
    data: ILocation[],
    limit: number,
    offset: number,
    recordCount: number
}