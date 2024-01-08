function MakingEmployeeList(names){
    
    const result = names.reduce((acc,curr) => {

        acc[curr] = curr.length;

        return acc;
    } , {})

    Object.keys(result).forEach((key) => {
        console.log(`Name: ${key} -- Personal Number: ${result[key]}`)
    })
}

MakingEmployeeList([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]);