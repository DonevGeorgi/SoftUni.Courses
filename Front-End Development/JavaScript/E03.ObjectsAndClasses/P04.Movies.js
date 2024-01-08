function MovieManageFunction(input){
    class MovieLibrary {
     constructor(){
         this.movies = [];
     }
 
     AddMovie(command) {
         const [_,name] = command.split("addMovie ");
         this.movies.push({name});
     }
     
     DirectedBy(command) {
         const [name,director] = command.split(" directedBy ");
         const result = this.movies.find((m) => m.name == name)
         
             if(result){
                result.director = director
             }
         
     }
 
     OnDate(command) {
         const [name,date] = command.split(" onDate ");
         const result = this.movies.find((m) => m.name == name)
         
             if(result){
                result.date = date
             }
     }
    }

    const movieLibrary = new MovieLibrary();

    input.forEach(movie => {

    if(movie.includes("addMovie")){
        movieLibrary.AddMovie(movie);
    }
    else if(movie.includes("directedBy")){
        movieLibrary.DirectedBy(movie);
    }
    else if(movie.includes("onDate")){
        movieLibrary.OnDate(movie);
    }
   });

   movieLibrary.movies
   .filter( (m) => m.name && m.director && m.date)
   .forEach( (m) => console.log(JSON.stringify(m)))
}

MovieManageFunction([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
    ]
    );