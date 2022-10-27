let counterDisplayElem = document.getElementById("changingNumberOfGuests");
let counterMinusElem = document.getElementById("BackNumber");
let counterPlusElem = document.getElementById("UpNumber");
let numberOfPeopleInsummary = document.getElementById("numberOfPeople");

let numberOfGuest = document.getElementById("guest");
let count = 1;
$(numberOfPeopleInsummary).attr('readonly', true);
updateDisplay();

counterMinusElem.addEventListener("click",()=>{
    count--;
    counterDisplayElem.innerHTML = count;
    numberOfPeopleInsummary.value = count;
    if(count < 2)
    {
        numberOfGuest.innerHTML = "Guest";
    }
    if(count < 1)
    {
        alert("The number of guests must be bigger than 0");
        count = 1;
        counterDisplayElem.innerHTML = count;
        numberOfPeopleInsummary.value = count;
    }
});


counterPlusElem.addEventListener("click",()=>{
    count++;
    counterDisplayElem.innerHTML = count;
    numberOfPeopleInsummary.value = count;
    numberOfGuest.innerHTML = "Guests";
    if(count > 8)
    {
        alert("Max number of guests in a table is 8, if you want a bigger group call us :)");
        count = 8;
        counterDisplayElem.innerHTML = count;
        numberOfPeopleInsummary.value = count;
    }
});


function updateDisplay(){
    counterDisplayElem.innerHTML = count;
    numberOfPeopleInsummary.value = count;
};

updateDisplay();
