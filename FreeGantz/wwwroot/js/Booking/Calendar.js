const reservationDate_date = document.getElementById('reservationDate_date');
const nextYear = new Date().getFullYear() + 1;
const myCalender = new CalendarPicker('#myCalendarWrapper', {
    // If max < min or min > max then the only available day will be today.
    min: new Date(),
    max: new Date(nextYear, 10), // NOTE: new Date(nextYear, 10) is "Nov 01 <nextYear>"
    locale: 'en-US', // Can be any locale or language code supported by Intl.DateTimeFormat, defaults to 'en-US'
    showShortWeekdays: false // Can be used to fit calendar onto smaller (mobile) screens, defaults to false
});

$(reservationDate_date).attr('readonly', true);
myCalender.onValueChange((currentValue)=> setDateValueInSummary(currentValue));
const setDateValueInSummary=(currentValue)=>{
    let locales = 'en-EN';
    let options = { weekday: 'long', year: 'numeric', month: 'numeric', day: 'numeric' };
    reservationDate_date.value = currentValue.toLocaleDateString(locales, options);
}
setDateValueInSummary(myCalender.value);