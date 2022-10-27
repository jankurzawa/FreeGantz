let validName = false;
let validEmail = false;
let validMessage = false;
let notBot = false;
let notPoor = false;
let notMenel = false;
let iphone = false;
let nameClicked = false;
let emailClicked = false;
let messageClicked = false;

document.getElementById("submitName").addEventListener("click", function () {
    validName = false;

    if (validNameFunc()) {
        validName = true;
        document.getElementById("name").readOnly = true;
        document.getElementById("name").style.backgroundColor = "#9fe69a";
    }
    else {
        document.getElementById("name").value = "Invalid name";
        nameClicked = false;
    }
    enableSend();
});

document.getElementById("submitEmail").addEventListener("click", function () {
    validEmail = false;

    if (validEmailFunc()) {
        validEmail = true;
        document.getElementById("email").readOnly = true;
        document.getElementById("email").style.backgroundColor = "#9fe69a";
    }
    else {
        document.getElementById("email").value = "Invalid e-mail";
        emailClicked = false;
    }
    enableSend();
});

document.getElementById("messageArea").addEventListener("input", function () {
    validMessage = false;

    if (messageArea.value != null && /\S/.test(messageArea.value)) {
        validMessage = true;
    }
    enableSend();
});

document.getElementById("notBot").addEventListener("change", e => {
    notBot = false;
    if (e.target.checked === true) {
        notBot = true;
        document.getElementById("notBot").style.backgroundColor = "#9fe69a";
    }
    enableSend();
});
document.getElementById("notPoor").addEventListener("change", e => {
    notPoor = false;
    if (e.target.checked === true) {
        notPoor = true;
        document.getElementById("notPoor").style.backgroundColor = "#9fe69a";
    }
    enableSend();
});
document.getElementById("notMenel").addEventListener("change", e => {
    notMenel = false;
    if (e.target.checked === true) {
        notMenel = true;
        document.getElementById("notMenel").style.backgroundColor = "#9fe69a";
    }
    enableSend();
});
document.getElementById("iphone").addEventListener("change", e => {
    iphone = false;
    if (e.target.checked === true) {
        iphone = true;
        document.getElementById("iphone").style.backgroundColor = "#9fe69a";
    }
    enableSend();
});

document.getElementById("sendButton").addEventListener("click", function () {
    alert("Your message has been sent!");
});

document.getElementById("name").addEventListener("click", function () {
    if (!nameClicked) {
        nameClicked = true;
        document.getElementById("name").value = "";
    }
});

document.getElementById("email").addEventListener("click", function () {
    if (!emailClicked) {
        emailClicked = true;
        document.getElementById("email").value = "";
    }
});

document.getElementById("messageArea").addEventListener("click", function () {
    if (!messageClicked) {
        messageClicked = true;
        document.getElementById("messageArea").value = "";
    }
});

document.getElementById("reset").addEventListener("click", function () {
    nameClicked = false;
    emailClicked = false;
    messageClicked = false;
    document.getElementById("name").style.backgroundColor = "#FFFFFF";
    document.getElementById("email").style.backgroundColor = "#FFFFFF";
});

function validNameFunc() {
    let regex = /^(?=[A-Z]{1,1}[a-z]{1,}\s[A-Z]{1,1}[a-z]{1,}).{5,31}$/;
    let ctrl = document.getElementById("name");
    return regex.test(ctrl.value);
}

function validEmailFunc() {
    let regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    let ctrl = document.getElementById("email");
    return regex.test(ctrl.value);
}

function enableSend() {
    document.getElementById("sendButton").disabled = true;
    if (validName === true && validEmail === true && validMessage === true && notBot === true && notPoor === true
        && notMenel === true && iphone === true) {
        document.getElementById("sendButton").disabled = false;
    }
}
