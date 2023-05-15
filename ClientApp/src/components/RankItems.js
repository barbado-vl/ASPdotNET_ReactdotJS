import {useEffect, useState } from 'react';
import RankingGrid from "./RankingGrid";
import ItemCollection from "./ItemCollection";

const RankItems = ({items, setItems, dataType, imgArr, localStorageKey }) => {

    const [reload, setReload] = useState(false);

    function Reload() {
        setReload(true);
    }

    function autoRanking() {
        var arrNumCells = [2, 3, 4, 5];
        var arrNumRows = [1, 2, 3, 4];
        var arrCheck =[];

        arrNumCells.sort(() => Math.random() - 0.5);
        arrNumRows.sort(() => Math.random() - 0.5);

        const transformedCollection = [];

        for (let item of items) {
            var x;
            do {
                var y = Math.floor(Math.random() * (3 - 0 + 1)) + 0;   // Math.random() * (max - min + 1)) + min
                var z = Math.floor(Math.random() * (3 - 0 + 1)) + 0;
                x = (5 * (arrNumRows[y] - 1)) + arrNumCells[z] - arrNumRows[y];
            } while (arrCheck.includes(x) === true);
            arrCheck.push(x);
            item.ranking = x;
            transformedCollection.push(item);
        };
        setItems(transformedCollection);
        /* setReload(false); */
    }

    function drag(ev) { 
        ev.dataTransfer.setData("text", ev.target.id);
    }

    function allowDrop(ev) {
        ev.preventDefault();
    }

    function drop(ev) {

        ev.preventDefault();
        const targetElm = ev.target;
        if (targetElm.nodeName === "IMG") {
            return false;
        }
        if (targetElm.childNodes.length === 0) {
            var data = parseInt(ev.dataTransfer.getData("text").substring(5));
            const transformedCollection = items.map((item) => (item.id === parseInt(data)) ?
            { ...item, ranking: parseInt(targetElm.id.substring(5)) } : { ...item, ranking: item.ranking });
            setItems(transformedCollection);
        }
    }

    function getDataFromApi() {
        fetch(`item/${dataType}`)
        .then((results) => {
            return results.json();
        })
        .then(data => {

            setItems(data);
        })
    }

    useEffect(() => {
        if (items == null) {
            getDataFromApi();
        }

    }, [dataType]);

    useEffect(() => {
        if (items != null) {
            localStorage.setItem(localStorageKey, JSON.stringify(items));
        }
        setReload(false);
    }, [items])

    useEffect(() => {
        if (reload === true) {
            getDataFromApi();
        }
    },[reload])


    return (
         (items != null)?
            <main>
                <RankingGrid items={items} imgArr={imgArr} drag={drag} allowDrop={allowDrop} drop={drop } />
                <ItemCollection items={items} drag={drag} imgArr={imgArr} />
                <button onClick={autoRanking} className="auto-ranking" style={{ "marginTop": "10px" }}> <span className="text" >Auto Ranking</span > </button>
                <button onClick={Reload} className="reload" style={{ "marginTop": "10px" }}> <span className="text" >Reload</span > </button>
            </main>
            : <main>Loading...</main>
        )
}
export default RankItems;