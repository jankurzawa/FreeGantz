const inputTimeElement = document.getElementById('reservationDate_hour');
const hoursScoope = ["7:00 - 11:00", "11:00 - 15:00", "15:00 - 20:00", "20:00 - 01:00"];
const radio1 = document.getElementById('int1');
const radio2 = document.getElementById('int2');
const radio3 = document.getElementById('int3');
const radio4 = document.getElementById('int4');
$(inputTimeElement).attr('readonly', true);

radio1.addEventListener('change', (event)=>changeHoursSpan(event.target.value));
radio2.addEventListener('change', (event)=>changeHoursSpan(event.target.value));
radio3.addEventListener('change', (event)=>changeHoursSpan(event.target.value));
radio4.addEventListener('change', (event)=>changeHoursSpan(event.target.value));


const changeHoursSpan=(index)=>{
    inputTimeElement.value = hoursScoope[index];
}
const onLoadChecked =(htmlRadio)=>{
    htmlRadio.checked =true;
    changeHoursSpan(htmlRadio.value)
}
onLoadChecked(radio3);