var a = Math.ceil(Math.random() * 10);
var b = Math.ceil(Math.random() * 10);
var c = a + b

function DrawBotBoot() {
    document.write("Ile to jest " + a + " + " + b + " ? ");
    document.write("<input id='BotBootInput' type='text' maxlength='2' size='3' />");
}

function ValidBotBoot() {
    var d = document.getElementById('BotBootInput').value;
    if (d == c) {
        document.getElementById("submit_btn").click();
    } else {
        alert("Błędna odpowiedź");
    }

}