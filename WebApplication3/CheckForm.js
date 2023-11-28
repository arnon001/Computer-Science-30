function CheckForm() {
    var fName = document.getElementById("fName").value;
    var i = 0;
    if (fName.length < 2) {
        document.getElementById("erFname").value = "short fName";
        document.getElementById("erFname").style.display = "inline";
        i++;
    }
    else
        if (fName.length > 20) {
            document.getElementById("erFname").value = "long fName";
            document.getElementById("erFname").style.display = "inline";
            i++;
        }
        else
            document.getElementById("erFname").style.display = "none";
    var lName = document.getElementById("lName").value;
    if (lName.length < 2) {
        document.getElementById("erLname").value = "short lName";
        document.getElementById("erLname").style.display = "inline";
        i++;
    }
    else
        if (lName.length > 20) {
            document.getElementById("erLname").value = "long lName";
            document.getElementById("erLname").style.display = "inline";
            i++;
        }
        else
            document.getElementById("erLname").style.display = "none";
    var email = document.getElementById("email").value.toString();
    if (email.length < 6  || email.lastIndexOf('.') == -1) {
        document.getElementById("erEmail").value = "email wrong";
        document.getElementById("erEmail").style.display = "inline";
        i++;
    }
    else
        document.getElementById("erEmail").style.display = "none";

    var password = document.getElementById("password").value.toString();
    if (password.length < 7 || password > 20) {
        document.getElementById("erPassword").value = "Too short or long password!";
        document.getElementById("erPassword").style.display = "inline";
        i++;
    }
    else
        document.getElementById("erPassword").style.display = "none;"
    if (i != 0) {
        return false;
    }
    else {
        alert("GOOD INPUT")
        document.getElementById("submit").disabled = false;
    }
}