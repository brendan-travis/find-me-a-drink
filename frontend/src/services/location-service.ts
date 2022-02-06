import {ILocationResponse} from "./interfaces";

export const getLocations = async (offset: number, limit: number, rating?: string, categories?: string, tags?: string, search?: string): Promise<ILocationResponse> => {
    let url = `http://localhost:30200/find-me-a-drink/api/locations?offset=${offset}&limit=${limit}`;

    if (rating) {
        url += `&sort_by_rating=${rating}`;
    }

    if (categories) {
        url += `&category_filter=${categories}`;
    }

    if (tags) {
        url += `&tag_filter=${tags}`;
    }

    if (search) {
        url += `&keyword_filter=${search}`;
    }

    const response = await fetch(url);
    return await response.json() as ILocationResponse;
};
