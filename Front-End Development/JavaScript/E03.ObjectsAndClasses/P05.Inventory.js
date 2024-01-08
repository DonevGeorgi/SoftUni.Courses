function HeroAsemble(input){
    class Heroes {
        constructor(){
            this.heroes = [];
        }

        AddHero(name,level,items){

            const currHero = {
            name: name,
            level: Number(level),
            items: items
            }  

            this.heroes.push(currHero);
        }
    }

    let heroes = new Heroes();

    input.forEach(currHero => {
        const [name, level, items] = currHero.split(" / ");
        heroes.AddHero(name, level, items);
    });

    heroes.heroes.sort((a, b) => a.level > b.level ? 1 : -1).forEach( currHero => {
        console.log(`Hero: ${currHero.name}`);
        console.log(`level => ${currHero.level}`);
        console.log(`items => ${currHero.items}`);
    })
    
}

HeroAsemble([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]
    );

    HeroAsemble([
        'Batman / 2 / Banana, Gun',
        'Superman / 18 / Sword',
        'Poppy / 28 / Sentinel, Antara'
        ]
        );