function RoadRadar(speed, roadType) {

    let speedLimit = 0;
    let allowedSpeed = '';

    if(roadType === "motorway"){
        speedLimit =  130
        allowedSpeed = '130';
    }
    else if(roadType === "interstate"){
        speedLimit =  90
        allowedSpeed = '90';
    }
    else if(roadType === "city"){
        speedLimit =  50
        allowedSpeed = '50';
    }
    else if(roadType === "residential"){
        speedLimit =  20
        allowedSpeed = '20';
    }

    if(speed > speedLimit){
        
        let status = '';
        let difference = speed - speedLimit;

        if(difference <= 20){
            status = "speeding"
        }
        else if(difference <= 40){
            status = "excessive speeding"
        }
        else {
            status = "reckless driving"
        }

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${allowedSpeed} - ${status}`
        );
        
    }
    else {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    }
}

RoadRadar(90, 'interstate')