const inputTimeElement = document.getElementById('reservationTime');
const reservationDate_hour = document.getElementById('reservationDate_hour');
$(reservationDate_hour).attr('readonly', true);

console.log(inputTimeElement);
inputTimeElement.addEventListener('change', (event)=>{
    let hours = inputTimeElement.value.slice(0,2);
    let minutes = inputTimeElement.value.slice(3,5);
    if(minutes !== "00" ){
        inputTimeElement.value=`${hours}:00`;
        minutes = "00";
    }
    
    reservationDate_hour.value=`${hours}:${minutes}`
})