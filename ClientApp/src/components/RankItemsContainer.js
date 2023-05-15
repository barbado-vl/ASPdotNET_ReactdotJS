import { useState } from "react";
import RankItems from "./RankItems";

const RankItemsContainer = ({dataType, imgArr}) => {
    const albumLocalStorageKey = "album";
    const movieLocalStorageKey = "movies";

    const [albumItems, setAlbumItems] = useState(JSON.parse(localStorage.getItem(albumLocalStorageKey)));
    const [movieItems, setMovieItems] = useState(JSON.parse(localStorage.getItem(movieLocalStorageKey)));

    var data = [];
    var setFunc = null;
    var localStorageKey = "";

    if (dataType === 1) {
        data = movieItems;
        setFunc = setMovieItems;
        localStorageKey = movieLocalStorageKey;
    }
    else if (dataType === 2) {
        data = albumItems;
        setFunc = setAlbumItems;
        localStorageKey = albumLocalStorageKey;
    }

    return (
        <RankItems items={data} setItems={setFunc} dataType={dataType} imgArr={imgArr} localStorageKey={localStorageKey} />
    )

}
export default RankItemsContainer;