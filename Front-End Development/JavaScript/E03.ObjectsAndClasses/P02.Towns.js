function TownLocater (input) {

    input.map((city) => {
        const[town,latitude,longitude] = city.split(" | ");
        
        return {town,latitude,longitude};
    })
    .forEach((city) => {
        
        let fixedLat = Number(city.latitude).toFixed(2);
        let fixedLong = Number(city.longitude).toFixed(2);

        console.log(`{ town: '${city.town}', latitude: '${fixedLat}', longitude: '${fixedLong}' }`);
    })
}

TownLocater(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
);